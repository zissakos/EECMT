using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Diagnostics;
using VictorBush.Ego.NefsLib;

namespace DirtCameraMod
{
    public partial class Form1 : Form
    {
        const string EECMT_INI_FILENAME = "EECMT.ini";
        const string EECMT_CARS_INI_FILENAME = "EECMT_cars.ini";
        const string WINDOW_TITLE = "EECMT - Ego Engine Camera Modding Tool V1.0";

        INIFile eecmtINI;
        INIFile cars_ini;

        string GameName;
        string PathToGame;
        string SubPathToCars;
        string PathToCars;
        string CameraFilename;
        bool BinaryXML;

        List<string> Cars = new List<string>();
        List<string> Cameras = new List<string>();
        List<string> CameraAttributes = new List<string>();
        List<string> CameraParametersScalar = new List<string>();
        List<string> CameraParametersBool = new List<string>();
        List<string> CameraParametersVector3 = new List<string>();
        Dictionary<string, List<string>> ExistingValues = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eecmtINI = new INIFile(EECMT_INI_FILENAME);
            cars_ini = new INIFile(EECMT_CARS_INI_FILENAME);
            InitVariables(Application.StartupPath);
        }


        //any modding process starts with this, both on startup and after the user has chosen a new folder
        void InitVariables(string gamepath)
        {
            ClearUI();
            Text = WINDOW_TITLE;
            
            GameName = FindGameName(gamepath);
            if (GameName != null)
            {
                PathToGame = gamepath;
                SubPathToCars = eecmtINI.GetParameterValue(GameName, "carfolder");
                PathToCars = PathToGame + "\\" + SubPathToCars;
                CameraFilename = eecmtINI.GetParameterValue(GameName, "filename");
                BinaryXML = eecmtINI.GetParameterValueBool(GameName, "binaryXML");

                
                if (BinaryXML)
                {
                    string pathToBinXMLConverter = eecmtINI.GetParameterValue("DEFAULT", "binaryXMLConverter");
                    if (!File.Exists(pathToBinXMLConverter))
                    {
                        MessageBox.Show("The game uses binaryXML, but the binXML Converter specified in the ini file '" + EECMT_INI_FILENAME +
                            "' does not exist ('" + pathToBinXMLConverter + "'). Without it you won't be able to mod the camera files.");
                        return;
                    }
                }


                if (GameName == "DIRTRALLY2")
                {
                    if (!Directory.Exists(PathToCars))
                    {
                        MessageBox.Show("This is Dirt Rally 2.0. EECMT will now extract all cameras.xml files" +
                            " from the NEFS files and put them in a subfolder cars/models/{car}.");
                        extractNEFS();
                    }



                }

                tbGameLocation.Text = PathToGame;

                Enabled = false;
                LoadCarsCameras();
                Enabled = true;

                Text = WINDOW_TITLE + " [Game = " + GameName + "]";
                if (!BackupExists())
                {
                    DialogResult dr = MessageBox.Show("It appears there is no backup of the camera files. It is strongly suggested " +
                        "to make a backup before any modding. Do you want to make a backup now? " +
                        "(You can do it later by using the button 'Backup')", "Backup?", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) btBackup_Click(null, null);
                }
            }
        }

        void extractNEFS()
        {
            NefsProgressInfo _progressInfo = new NefsProgressInfo();
            _progressInfo.Progress = new Progress<NefsProgress>();

            DirectoryInfo di = new DirectoryInfo(PathToGame + "\\cars");
            foreach (FileInfo fi in di.GetFiles("*.nefs"))
            {
                try
                {
                    NefsArchive archive = new NefsArchive(fi.FullName, _progressInfo);
                    NefsItem item = archive.GetItem(13);
                    string car3 = fi.Name.Replace(fi.Extension, "");
                    FileInfo fi2 = new FileInfo(PathToCars + "\\" + car3 + "\\" + item.Filename);
                    item.Extract(fi2.FullName, _progressInfo);

                }
                catch (Exception)
                {
                }
            }
        }


        void putCameraFileBackToNEFS(string car3)
        {
            NefsProgressInfo _progressInfo = new NefsProgressInfo();
            _progressInfo.Progress = new Progress<NefsProgress>();

            NefsArchive archive = new NefsArchive(PathToGame + "\\cars\\" + car3 + ".nefs", _progressInfo);
            NefsItem item = archive.GetItem(13);
            item.Inject(getPathToCameraFile(car3), _progressInfo);
            archive.Save(archive.FilePath, _progressInfo);
        }

        //only return true if ALL vehicles have a backup of their camera file
        bool BackupExists()
        {
            bool result = true;
            foreach (string car3 in Cars)
            {
                string camfile = getPathToCameraFile(car3);
                result &= File.Exists(getBackupFilename(camfile));
            }
            return result;
        }

        //search the ini file for a section where the executable exists in the given path
        string FindGameName(string pathToGame)
        {
            string result = null;
            foreach (string game in eecmtINI.GetSections())
            {
                string executable = eecmtINI.GetParameterValue(game, "executable");
                if (executable == null) continue;
                if (File.Exists(pathToGame + "\\" + executable)) result = game;
            }
            return result;
        }
        string getCarName(string car3)
        {
            return cars_ini.GetParameterValue(GameName, car3);
        }

        public void LoadCarsCameras()
        {
            DirectoryInfo di = new DirectoryInfo(PathToCars);
            DirectoryInfo[] folders = di.GetDirectories();

            foreach (DirectoryInfo folder in folders)
            {
                string camfile = folder.FullName + "\\" + CameraFilename;
                if (File.Exists(camfile))
                {
                    string car3 = folder.Name;
                    Cars.Add(car3);
                    LoadCameras(car3);
                }
            }

            populateUI();
        }

        void LoadCameras(string car3)
        {
            //remove read-only flag
            FileInfo fi = new FileInfo(getPathToCameraFile(car3));
            fi.IsReadOnly = false;

            if (BinaryXML) ConvertBinXMLToPlainXML(getPathToCameraFile(car3), getPathToCameraFileEditable(car3));

            XmlDocument doc = new XmlDocument();
            doc.Load(getPathToCameraFileEditable(car3));

            XmlNodeList views = doc.GetElementsByTagName("View");
            foreach (XmlNode view in views)
            {
                string view_ident = view.Attributes.GetNamedItem("ident").Value;
                if (!view_ident.Contains("replay"))
                {
                    if (!Cameras.Contains(view_ident))
                    {
                        Cameras.Add(view_ident);
                    }

                    //collect everything in the "global" Lists<string>, fill internal "database" of Existing Values
                    foreach (XmlAttribute attr in view.Attributes)
                    {
                        if (!CameraAttributes.Contains(attr.Name)) CameraAttributes.Add(attr.Name);
                        AddExistingValue(attr.Name, attr.Value);
                    }
                    foreach (XmlNode node in view.SelectNodes("Parameter[@type='scalar']"))
                    {
                        string paramname = node.Attributes.GetNamedItem("name").Value;
                        if (!CameraParametersScalar.Contains(paramname)) CameraParametersScalar.Add(paramname);
                        AddExistingValue(paramname, node.Attributes.GetNamedItem("value").Value);
                    }
                    foreach (XmlNode node in view.SelectNodes("Parameter[@type='bool']"))
                    {
                        string paramname = node.Attributes.GetNamedItem("name").Value;
                        if (!CameraParametersBool.Contains(paramname)) CameraParametersBool.Add(paramname);
                        AddExistingValue(paramname, node.Attributes.GetNamedItem("value").Value);
                    }
                    foreach (XmlNode node in view.SelectNodes("Parameter[@type='vector3']"))
                    {
                        string paramname = node.Attributes.GetNamedItem("name").Value;
                        if (!CameraParametersVector3.Contains(paramname)) CameraParametersVector3.Add(paramname);
                        string existingvalue = "(" + node.Attributes.GetNamedItem("x").Value + ", " +
                            node.Attributes.GetNamedItem("y").Value + ", " +
                            node.Attributes.GetNamedItem("z").Value + ")";
                        AddExistingValue(paramname, existingvalue);
                    }
                }
            }
        }


        void ClearUI()
        {
            Cars.Clear();
            Cameras.Clear();
            CameraAttributes.Clear();
            CameraParametersScalar.Clear();
            CameraParametersBool.Clear();
            CameraParametersVector3.Clear();
            ExistingValues.Clear();

            lvCars.Items.Clear();
            lvCameras.Items.Clear();
            dgAttributes.Rows.Clear();
            dgBoolValues.Rows.Clear();
            dgVector3Values.Rows.Clear();
            dgScalarValues.Rows.Clear();
        }

        void populateUI()
        {
            //populate lists
            foreach (string car3 in Cars)
            {
                ListViewItem lvi = new ListViewItem(car3);
                if (GameName != null) lvi.SubItems.Add(getCarName(car3));
                lvi.Checked = true;
                lvCars.Items.Add(lvi);
            }

            foreach (string cam in Cameras)
            {
                ListViewItem lvi = new ListViewItem(cam);
                lvi.Checked = true;
                lvCameras.Items.Add(lvi);
            }

            //populate Datagrids
            foreach (string attr in CameraAttributes)
            {
                int row = dgAttributes.Rows.Add(attr);
                dgAttributes.Rows[row].Cells[0].ToolTipText = getToolTipText(attr);
            }
            foreach (string param in CameraParametersScalar)
            {
                int row = dgScalarValues.Rows.Add(param);
                dgScalarValues.Rows[row].Cells[0].ToolTipText = getToolTipText(param);
            }
            foreach (string param in CameraParametersBool)
            {
                int row = dgBoolValues.Rows.Add(param);
                dgBoolValues.Rows[row].Cells[0].ToolTipText = getToolTipText(param);
            }
            foreach (string param in CameraParametersVector3)
            {
                int row = dgVector3Values.Rows.Add(param);
                dgVector3Values.Rows[row].Cells[0].ToolTipText = getToolTipText(param);
            }
        }

        private string getToolTipText(string name)
        {
            string result = "Existing Values:\n";
            if (!ExistingValues.ContainsKey(name)) return result;
            result += String.Join("\n", ExistingValues[name]);
            return result;
        }


        void ConvertBinXMLToPlainXML(string inputfile, string outputfile)
        {
            string pathToBinXMLConverter = eecmtINI.GetParameterValue("DEFAULT", "binaryXMLConverter");
            string commandLine = eecmtINI.GetParameterValue("DEFAULT", "commandLineBinXML2PlainXML");
            FileInfo fi = new FileInfo(pathToBinXMLConverter);
            ProcessStartInfo psi = new ProcessStartInfo();
            //psi.WorkingDirectory = new FileInfo(inputfile).DirectoryName;
            psi.FileName = fi.FullName;
            psi.Arguments = commandLine.Replace("$infile", inputfile).Replace("$outfile", outputfile);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process myProcess = Process.Start(psi);
            myProcess.WaitForExit();
        }

        void ConvertPlainXMLToBinXML(string inputfile, string outputfile)
        {
            string pathToBinXMLConverter = eecmtINI.GetParameterValue("DEFAULT", "binaryXMLConverter");
            string commandLine = eecmtINI.GetParameterValue("DEFAULT", "commandLinePlainXML2BinXML");
            FileInfo fi = new FileInfo(pathToBinXMLConverter);
            ProcessStartInfo psi = new ProcessStartInfo();
            //psi.WorkingDirectory = new FileInfo(inputfile).DirectoryName;
            psi.FileName = fi.FullName;
            psi.Arguments = commandLine.Replace("$infile", inputfile).Replace("$outfile", outputfile);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process myProcess = Process.Start(psi);
            myProcess.WaitForExit();
        }
        private void AddExistingValue(string n, string v)
        {
            if (!ExistingValues.ContainsKey(n)) ExistingValues.Add(n, new List<string>());
            if (!ExistingValues[n].Contains(v)) ExistingValues[n].Add(v);
        }


        string getNewValue(string old, string cell_content)
        {
            Single result;
            if (cell_content.StartsWith("+") || cell_content.StartsWith("-"))
            {
                Single oldvalue = Convert.ToSingle(old, new CultureInfo("en-US"));
                Single delta = Convert.ToSingle(cell_content, new CultureInfo("en-US"));
                result = oldvalue + delta;
            }
            else if (cell_content.StartsWith("$"))
            {
                cell_content = cell_content.Remove(0, 1);
                result = Convert.ToSingle(cell_content, new CultureInfo("en-US"));
            }
            else
            {
                result = Convert.ToSingle(cell_content, new CultureInfo("en-US"));
            }
            return result.ToString("#######0.0000",new CultureInfo("en-US"));
        }



        // the camera file the game uses, binaryXML or not (usually cameras.xml)
        string getPathToCameraFile(string car3)
        {
            return PathToCars + "\\" + car3 + "\\" + CameraFilename;
        }

        // if the game uses binaryXML, the editable camera filename is different
        string getPathToCameraFileEditable(string car3)
        {
            string result = getPathToCameraFile(car3);
            if (BinaryXML) result += ".plain.xml";
            return result;
        }

        string getBackupFilename(string filename)
        {
            return filename + ".backup";
        }

        private void btChangeGameLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (tbGameLocation.Text != "") if (Directory.Exists(tbGameLocation.Text)) fbd.SelectedPath = tbGameLocation.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbGameLocation.Text = fbd.SelectedPath;
                btReload_Click(null, null);
            }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            InitVariables(tbGameLocation.Text);
            if (GameName == null) MessageBox.Show("The game in the chosen folder could not be identified. Please check the folder and the ini file '" + EECMT_INI_FILENAME + "' for a corresponding section with the game's executable file.");
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            btApply.Enabled = false;
            int numChanges = 0;
            int numFiles = 0;
            ResultsForm rform = new ResultsForm();
            string oldValue, newValue = null;
            //only do it for selected cars
            foreach (ListViewItem lvi in lvCars.CheckedItems)
            {
                string car3 = lvi.Text;

                //load XML
                XmlDocument doc = new XmlDocument();
                string filename = getPathToCameraFileEditable(car3);
                doc.Load(filename);

                numFiles++;

                //only do it for selected cameras
                foreach (ListViewItem lvi2 in lvCameras.CheckedItems)
                {
                    string CameraName = lvi2.Text;

                    //find View Tag in XML
                    XmlNode view = doc.SelectNodes("//View[@ident='" + CameraName + "']")[0];
                    if (view == null) continue;

                    //check UI which attributes need to be changed
                    foreach (DataGridViewRow row in dgAttributes.Rows)
                    {
                        //if user didn't enter anything, skip
                        if (row.Cells[1].Value == null) continue;
                        //get the attribute to change
                        XmlNode Attribute = view.Attributes.GetNamedItem(row.Cells[0].Value.ToString());
                        //if it couldn't be found, skip
                        if (Attribute == null) continue;
                        //change the camera attribute
                        oldValue = Attribute.Name + " = " + Attribute.Value;
                        Attribute.Value = row.Cells[1].Value.ToString();
                        newValue = Attribute.Name + " = " + Attribute.Value;
                        numChanges++;
                        rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                    }
                    //check UI which Bool parameters need to be changed
                    foreach (DataGridViewRow row in dgBoolValues.Rows)
                    {
                        //if user didn't enter anything, skip
                        if (row.Cells[1].Value == null) continue;
                        //get the Parameter to change
                        XmlNode Parameter = view.SelectNodes("Parameter[@name='" + row.Cells[0].Value.ToString() + "']")[0];
                        //if it couldn't be found, skip
                        if (Parameter == null) continue;
                        //change the Parameter value
                        oldValue = Parameter.Attributes.GetNamedItem("name").Value + " = " + Parameter.Attributes.GetNamedItem("value").Value;
                        Parameter.Attributes.GetNamedItem("value").Value = row.Cells[1].Value.ToString();
                        newValue = Parameter.Attributes.GetNamedItem("name").Value + " = " + Parameter.Attributes.GetNamedItem("value").Value;
                        numChanges++;
                        rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                    }
                    //check UI which Vector3 parameters need to be changed
                    foreach (DataGridViewRow row in dgVector3Values.Rows)
                    {
                        if (row.Cells[1].Value == null && row.Cells[2].Value == null && row.Cells[3].Value == null) continue;
                        XmlNode Parameter = view.SelectNodes("Parameter[@name='" + row.Cells[0].Value.ToString() + "']")[0];
                        if (Parameter == null) continue;
                        if (row.Cells[1].Value != null)
                        {
                            oldValue = Parameter.Attributes.GetNamedItem("name").Value + ".x = " + Parameter.Attributes.GetNamedItem("x").Value;
                            Parameter.Attributes.GetNamedItem("x").Value = getNewValue(Parameter.Attributes.GetNamedItem("x").Value, row.Cells[1].Value.ToString());
                            newValue = Parameter.Attributes.GetNamedItem("name").Value + ".x = " + Parameter.Attributes.GetNamedItem("x").Value;
                            numChanges++;
                            rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                        }
                        if (row.Cells[2].Value != null)
                        {
                            oldValue = Parameter.Attributes.GetNamedItem("name").Value + ".y = " + Parameter.Attributes.GetNamedItem("y").Value;
                            Parameter.Attributes.GetNamedItem("y").Value = getNewValue(Parameter.Attributes.GetNamedItem("y").Value, row.Cells[2].Value.ToString());
                            newValue = Parameter.Attributes.GetNamedItem("name").Value + ".y = " + Parameter.Attributes.GetNamedItem("y").Value;
                            numChanges++;
                            rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                        }
                        if (row.Cells[3].Value != null)
                        {
                            oldValue = Parameter.Attributes.GetNamedItem("name").Value + ".z = " + Parameter.Attributes.GetNamedItem("z").Value;
                            Parameter.Attributes.GetNamedItem("z").Value = getNewValue(Parameter.Attributes.GetNamedItem("z").Value, row.Cells[3].Value.ToString());
                            newValue = Parameter.Attributes.GetNamedItem("name").Value + ".z = " + Parameter.Attributes.GetNamedItem("z").Value;
                            numChanges++;
                            rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                        }

                    }
                    //check UI which Scalar parameters need to be changed
                    foreach (DataGridViewRow row in dgScalarValues.Rows)
                    {
                        if (row.Cells[1].Value == null) continue;
                        XmlNode Parameter = view.SelectNodes("Parameter[@name='" + row.Cells[0].Value.ToString() + "']")[0];
                        if (Parameter == null) continue;
                        string value = row.Cells[1].Value.ToString();
                        oldValue = Parameter.Attributes.GetNamedItem("name").Value + " = " + Parameter.Attributes.GetNamedItem("value").Value;
                        Parameter.Attributes.GetNamedItem("value").Value = getNewValue(Parameter.Attributes.GetNamedItem("value").Value, row.Cells[1].Value.ToString());
                        newValue = Parameter.Attributes.GetNamedItem("name").Value + " = " + Parameter.Attributes.GetNamedItem("value").Value;
                        numChanges++;
                        rform.dgResults.Rows.Add(car3, getCarName(car3) ?? "", CameraName, oldValue, newValue);
                    }
                }

                //save changes to XML
                XmlTextWriter w = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                w.Formatting = Formatting.Indented;
                w.Indentation = 1;
                w.IndentChar = '\t';
                doc.Save(w);
                w.Close();

                if (BinaryXML) ConvertPlainXMLToBinXML(filename, getPathToCameraFile(car3));

                if (GameName == "DIRTRALLY2") putCameraFileBackToNEFS(car3);
            }
            rform.lbMessage.Text = "There were " + numChanges + " changes in " + numFiles + " file(s).";
            rform.ShowDialog();
            btApply.Enabled = true;
        }

        private void btCarsSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvCars.Items) lvi.Checked = true;

        }

        private void btCarsSelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvCars.Items) lvi.Checked = false;

        }

        private void btCamerasSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvCameras.Items) lvi.Checked = true;
        }

        private void btCamerasSelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvCameras.Items) lvi.Checked = false;
        }

        private void btClearAttributes_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAttributes.Rows) row.Cells["Value"].Value = null;
        }

        private void btClearBool_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgBoolValues.Rows) row.Cells["boolValue"].Value = null;
        }

        private void btClearVector3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgVector3Values.Rows) row.Cells["X"].Value = row.Cells["Y"].Value = row.Cells["Z"].Value = null;
        }

        private void btClearScalar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgScalarValues.Rows) row.Cells["scalarValue"].Value = null;
        }

        private void datagridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            if (dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "") dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
        }

        private void datagridview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                DataGridView dg = sender as DataGridView;
                dg.SelectedCells[0].Value = null;
            }
        }
        private void btBackup_Click(object sender, EventArgs e)
        {
            if (BackupExists())
            {
                DialogResult dr = MessageBox.Show("There is already an existing backup of the camera files. Are you sure you want to overwrite the existing backup with the current camera files?", "Overwrite Backup?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }
            int numFiles = 0;
            foreach (ListViewItem lvi in lvCars.Items)
            {
                string CarName = lvi.Text;
                string filename = getPathToCameraFile(CarName);
                FileInfo fi = new FileInfo(filename);
                fi.CopyTo(getBackupFilename(filename), true);
                numFiles++;
            }
            MessageBox.Show("Successfully backed up " + numFiles + " files.");
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to restore the current backup? This will undo any changes since the backup.", "Restore Backup?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            int numFiles = 0;
            foreach (ListViewItem lvi in lvCars.Items)
            {
                string CarName = lvi.Text;
                string filename = getPathToCameraFile(CarName);
                FileInfo fi = new FileInfo(getBackupFilename(filename));
                fi.CopyTo(filename, true);
                if (GameName == "DIRTRALLY2") putCameraFileBackToNEFS(CarName);
                numFiles++;
            }
            MessageBox.Show("Successfully restored " + numFiles + " files.");
        }

        private void btClearAll_Click(object sender, EventArgs e)
        {
            btClearAttributes_Click(null, null);
            btClearBool_Click(null, null); 
            btClearVector3_Click(null, null);
            btClearScalar_Click(null, null);
        }

        private void btStartGame_Click(object sender, EventArgs e)
        {
            string executable = PathToGame + "\\" + eecmtINI.GetParameterValue(GameName, "executable");
            if (!File.Exists(executable))
            {
                MessageBox.Show("Game executable '" + executable + "' could not be found!");
                return;
            }
            FileInfo fi = new FileInfo(executable);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = fi.DirectoryName;
            psi.FileName = fi.Name;
            //psi.Arguments = "test.txt";
            psi.CreateNoWindow = true;
            Process myProcess = Process.Start(psi);
        }

        private void btPackage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK) return;
            DirectoryInfo dir_package = new DirectoryInfo(fbd.SelectedPath);
            DirectoryInfo dir_modded =  dir_package.CreateSubdirectory("MODDED_FILES" + "\\" + SubPathToCars);
            DirectoryInfo dir_original = dir_package.CreateSubdirectory("ORIGINAL_FILES" + "\\" + SubPathToCars);
            foreach (string car3 in Cars)
            {
                dir_modded.CreateSubdirectory(car3);
                dir_original.CreateSubdirectory(car3);
                string modded_filename = getPathToCameraFile(car3);
                string original_filename = getBackupFilename(modded_filename);
                File.Copy(modded_filename, dir_modded.FullName + "\\" + car3 + "\\" + CameraFilename, true);
                File.Copy(original_filename, dir_original.FullName + "\\" + car3 + "\\" + CameraFilename, true);
            }
            MessageBox.Show("Successfully packaged in " + dir_package.FullName);
        }

        private void openCameraFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string car3 = lvCars.SelectedItems[0].Text;
            string filename = getPathToCameraFileEditable(car3);
            System.Diagnostics.Process.Start(@filename);
        }

        private void lvCars_DoubleClick(object sender, EventArgs e)
        {
            lvCars.SelectedItems[0].Checked = !lvCars.SelectedItems[0].Checked;
            openCameraFileToolStripMenuItem_Click(null, null);
        }
    }
    
}
