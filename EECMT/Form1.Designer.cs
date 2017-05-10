namespace DirtCameraMod
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGameLocation = new System.Windows.Forms.TextBox();
            this.btGameLocationChange = new System.Windows.Forms.Button();
            this.btCarsSelectAll = new System.Windows.Forms.Button();
            this.btCarsSelectNone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btCamerasSelectAll = new System.Windows.Forms.Button();
            this.btCamerasSelectNone = new System.Windows.Forms.Button();
            this.btBackup = new System.Windows.Forms.Button();
            this.btRestore = new System.Windows.Forms.Button();
            this.dgAttributes = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgScalarValues = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scalarValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBoolValues = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boolValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgVector3Values = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btApply = new System.Windows.Forms.Button();
            this.btClearAttributes = new System.Windows.Forms.Button();
            this.btClearBool = new System.Windows.Forms.Button();
            this.btClearVector3 = new System.Windows.Forms.Button();
            this.btClearScalar = new System.Windows.Forms.Button();
            this.btClearAll = new System.Windows.Forms.Button();
            this.lvCars = new System.Windows.Forms.ListView();
            this.dir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.car = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openCamraFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvCameras = new System.Windows.Forms.ListView();
            this.camera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btPackage = new System.Windows.Forms.Button();
            this.btStartGame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgScalarValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoolValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVector3Values)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Location";
            // 
            // tbGameLocation
            // 
            this.tbGameLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameLocation.Location = new System.Drawing.Point(98, 19);
            this.tbGameLocation.Name = "tbGameLocation";
            this.tbGameLocation.Size = new System.Drawing.Size(541, 20);
            this.tbGameLocation.TabIndex = 1;
            // 
            // btGameLocationChange
            // 
            this.btGameLocationChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGameLocationChange.Location = new System.Drawing.Point(645, 17);
            this.btGameLocationChange.Name = "btGameLocationChange";
            this.btGameLocationChange.Size = new System.Drawing.Size(75, 23);
            this.btGameLocationChange.TabIndex = 2;
            this.btGameLocationChange.Text = "Change";
            this.btGameLocationChange.UseVisualStyleBackColor = true;
            this.btGameLocationChange.Click += new System.EventHandler(this.btChangeGameLocation_Click);
            // 
            // btCarsSelectAll
            // 
            this.btCarsSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCarsSelectAll.Location = new System.Drawing.Point(12, 691);
            this.btCarsSelectAll.Name = "btCarsSelectAll";
            this.btCarsSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btCarsSelectAll.TabIndex = 5;
            this.btCarsSelectAll.Text = "Select All";
            this.btCarsSelectAll.UseVisualStyleBackColor = true;
            this.btCarsSelectAll.Click += new System.EventHandler(this.btCarsSelectAll_Click);
            // 
            // btCarsSelectNone
            // 
            this.btCarsSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCarsSelectNone.Location = new System.Drawing.Point(93, 691);
            this.btCarsSelectNone.Name = "btCarsSelectNone";
            this.btCarsSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btCarsSelectNone.TabIndex = 5;
            this.btCarsSelectNone.Text = "Select None";
            this.btCarsSelectNone.UseVisualStyleBackColor = true;
            this.btCarsSelectNone.Click += new System.EventHandler(this.btCarsSelectNone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cars:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cameras:";
            // 
            // btCamerasSelectAll
            // 
            this.btCamerasSelectAll.Location = new System.Drawing.Point(282, 448);
            this.btCamerasSelectAll.Name = "btCamerasSelectAll";
            this.btCamerasSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btCamerasSelectAll.TabIndex = 5;
            this.btCamerasSelectAll.Text = "Select All";
            this.btCamerasSelectAll.UseVisualStyleBackColor = true;
            this.btCamerasSelectAll.Click += new System.EventHandler(this.btCamerasSelectAll_Click);
            // 
            // btCamerasSelectNone
            // 
            this.btCamerasSelectNone.Location = new System.Drawing.Point(363, 448);
            this.btCamerasSelectNone.Name = "btCamerasSelectNone";
            this.btCamerasSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btCamerasSelectNone.TabIndex = 5;
            this.btCamerasSelectNone.Text = "Select None";
            this.btCamerasSelectNone.UseVisualStyleBackColor = true;
            this.btCamerasSelectNone.Click += new System.EventHandler(this.btCamerasSelectNone_Click);
            // 
            // btBackup
            // 
            this.btBackup.Location = new System.Drawing.Point(6, 19);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(75, 23);
            this.btBackup.TabIndex = 7;
            this.btBackup.Text = "Backup";
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(87, 19);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(75, 23);
            this.btRestore.TabIndex = 7;
            this.btRestore.Text = "Restore";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // dgAttributes
            // 
            this.dgAttributes.AllowUserToAddRows = false;
            this.dgAttributes.AllowUserToDeleteRows = false;
            this.dgAttributes.AllowUserToResizeRows = false;
            this.dgAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute,
            this.Value});
            this.dgAttributes.Location = new System.Drawing.Point(468, 77);
            this.dgAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.dgAttributes.Name = "dgAttributes";
            this.dgAttributes.RowHeadersVisible = false;
            this.dgAttributes.RowTemplate.Height = 18;
            this.dgAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgAttributes.Size = new System.Drawing.Size(249, 180);
            this.dgAttributes.TabIndex = 8;
            this.dgAttributes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellEndEdit);
            this.dgAttributes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagridview_KeyDown);
            // 
            // Attribute
            // 
            this.Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Attributes:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(723, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Scalar Values:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Bool Values:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 474);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Vector3 Values:";
            // 
            // dgScalarValues
            // 
            this.dgScalarValues.AllowUserToAddRows = false;
            this.dgScalarValues.AllowUserToDeleteRows = false;
            this.dgScalarValues.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.NullValue = null;
            this.dgScalarValues.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgScalarValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgScalarValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScalarValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.scalarValue});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgScalarValues.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgScalarValues.Location = new System.Drawing.Point(726, 77);
            this.dgScalarValues.Margin = new System.Windows.Forms.Padding(0);
            this.dgScalarValues.Name = "dgScalarValues";
            this.dgScalarValues.RowHeadersVisible = false;
            this.dgScalarValues.RowTemplate.Height = 18;
            this.dgScalarValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgScalarValues.Size = new System.Drawing.Size(261, 598);
            this.dgScalarValues.TabIndex = 8;
            this.dgScalarValues.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellEndEdit);
            this.dgScalarValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagridview_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 66F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // scalarValue
            // 
            this.scalarValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.scalarValue.FillWeight = 34F;
            this.scalarValue.HeaderText = "Value";
            this.scalarValue.Name = "scalarValue";
            // 
            // dgBoolValues
            // 
            this.dgBoolValues.AllowUserToAddRows = false;
            this.dgBoolValues.AllowUserToDeleteRows = false;
            this.dgBoolValues.AllowUserToResizeRows = false;
            this.dgBoolValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBoolValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.boolValue});
            this.dgBoolValues.Location = new System.Drawing.Point(468, 284);
            this.dgBoolValues.Margin = new System.Windows.Forms.Padding(0);
            this.dgBoolValues.Name = "dgBoolValues";
            this.dgBoolValues.RowHeadersVisible = false;
            this.dgBoolValues.RowTemplate.Height = 18;
            this.dgBoolValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgBoolValues.Size = new System.Drawing.Size(249, 180);
            this.dgBoolValues.TabIndex = 8;
            this.dgBoolValues.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellEndEdit);
            this.dgBoolValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagridview_KeyDown);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 70F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // boolValue
            // 
            this.boolValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.boolValue.FillWeight = 30F;
            this.boolValue.HeaderText = "Value";
            this.boolValue.Items.AddRange(new object[] {
            "true",
            "false"});
            this.boolValue.Name = "boolValue";
            this.boolValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.boolValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgVector3Values
            // 
            this.dgVector3Values.AllowUserToAddRows = false;
            this.dgVector3Values.AllowUserToDeleteRows = false;
            this.dgVector3Values.AllowUserToResizeRows = false;
            this.dgVector3Values.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgVector3Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVector3Values.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.X,
            this.Y,
            this.Z});
            this.dgVector3Values.Location = new System.Drawing.Point(468, 491);
            this.dgVector3Values.Margin = new System.Windows.Forms.Padding(0);
            this.dgVector3Values.Name = "dgVector3Values";
            this.dgVector3Values.RowHeadersVisible = false;
            this.dgVector3Values.RowTemplate.Height = 18;
            this.dgVector3Values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgVector3Values.Size = new System.Drawing.Size(249, 184);
            this.dgVector3Values.TabIndex = 8;
            this.dgVector3Values.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellEndEdit);
            this.dgVector3Values.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagridview_KeyDown);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 55F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X.FillWeight = 15F;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y.FillWeight = 15F;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Z
            // 
            this.Z.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Z.FillWeight = 15F;
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btApply.Location = new System.Drawing.Point(881, 684);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(106, 37);
            this.btApply.TabIndex = 9;
            this.btApply.Text = "APPLY";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btClearAttributes
            // 
            this.btClearAttributes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btClearAttributes.Location = new System.Drawing.Point(651, 57);
            this.btClearAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.btClearAttributes.Name = "btClearAttributes";
            this.btClearAttributes.Size = new System.Drawing.Size(66, 18);
            this.btClearAttributes.TabIndex = 10;
            this.btClearAttributes.Text = "Clear";
            this.btClearAttributes.UseVisualStyleBackColor = true;
            this.btClearAttributes.Click += new System.EventHandler(this.btClearAttributes_Click);
            // 
            // btClearBool
            // 
            this.btClearBool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btClearBool.Location = new System.Drawing.Point(651, 264);
            this.btClearBool.Margin = new System.Windows.Forms.Padding(0);
            this.btClearBool.Name = "btClearBool";
            this.btClearBool.Size = new System.Drawing.Size(66, 18);
            this.btClearBool.TabIndex = 10;
            this.btClearBool.Text = "Clear";
            this.btClearBool.UseVisualStyleBackColor = true;
            this.btClearBool.Click += new System.EventHandler(this.btClearBool_Click);
            // 
            // btClearVector3
            // 
            this.btClearVector3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btClearVector3.Location = new System.Drawing.Point(651, 471);
            this.btClearVector3.Margin = new System.Windows.Forms.Padding(0);
            this.btClearVector3.Name = "btClearVector3";
            this.btClearVector3.Size = new System.Drawing.Size(66, 18);
            this.btClearVector3.TabIndex = 10;
            this.btClearVector3.Text = "Clear";
            this.btClearVector3.UseVisualStyleBackColor = true;
            this.btClearVector3.Click += new System.EventHandler(this.btClearVector3_Click);
            // 
            // btClearScalar
            // 
            this.btClearScalar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearScalar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btClearScalar.Location = new System.Drawing.Point(921, 56);
            this.btClearScalar.Margin = new System.Windows.Forms.Padding(0);
            this.btClearScalar.Name = "btClearScalar";
            this.btClearScalar.Size = new System.Drawing.Size(66, 18);
            this.btClearScalar.TabIndex = 10;
            this.btClearScalar.Text = "Clear";
            this.btClearScalar.UseVisualStyleBackColor = true;
            this.btClearScalar.Click += new System.EventHandler(this.btClearScalar_Click);
            // 
            // btClearAll
            // 
            this.btClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearAll.Location = new System.Drawing.Point(622, 691);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(75, 23);
            this.btClearAll.TabIndex = 5;
            this.btClearAll.Text = "Clear All";
            this.btClearAll.UseVisualStyleBackColor = true;
            this.btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // lvCars
            // 
            this.lvCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCars.CheckBoxes = true;
            this.lvCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dir,
            this.car});
            this.lvCars.ContextMenuStrip = this.contextMenuStrip1;
            this.lvCars.FullRowSelect = true;
            this.lvCars.Location = new System.Drawing.Point(12, 77);
            this.lvCars.Name = "lvCars";
            this.lvCars.Size = new System.Drawing.Size(251, 598);
            this.lvCars.TabIndex = 11;
            this.lvCars.UseCompatibleStateImageBehavior = false;
            this.lvCars.View = System.Windows.Forms.View.Details;
            this.lvCars.DoubleClick += new System.EventHandler(this.lvCars_DoubleClick);
            // 
            // dir
            // 
            this.dir.Text = "dir";
            this.dir.Width = 50;
            // 
            // car
            // 
            this.car.Text = "car";
            this.car.Width = 190;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCamraFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 26);
            // 
            // openCamraFileToolStripMenuItem
            // 
            this.openCamraFileToolStripMenuItem.Name = "openCamraFileToolStripMenuItem";
            this.openCamraFileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openCamraFileToolStripMenuItem.Text = "Open Camera File";
            this.openCamraFileToolStripMenuItem.Click += new System.EventHandler(this.openCameraFileToolStripMenuItem_Click);
            // 
            // lvCameras
            // 
            this.lvCameras.CheckBoxes = true;
            this.lvCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.camera});
            this.lvCameras.Location = new System.Drawing.Point(282, 77);
            this.lvCameras.Name = "lvCameras";
            this.lvCameras.Size = new System.Drawing.Size(156, 365);
            this.lvCameras.TabIndex = 12;
            this.lvCameras.UseCompatibleStateImageBehavior = false;
            this.lvCameras.View = System.Windows.Forms.View.Details;
            // 
            // camera
            // 
            this.camera.Text = "camera";
            this.camera.Width = 150;
            // 
            // btPackage
            // 
            this.btPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPackage.Location = new System.Drawing.Point(703, 691);
            this.btPackage.Name = "btPackage";
            this.btPackage.Size = new System.Drawing.Size(75, 23);
            this.btPackage.TabIndex = 13;
            this.btPackage.Text = "Package";
            this.btPackage.UseVisualStyleBackColor = true;
            this.btPackage.Click += new System.EventHandler(this.btPackage_Click);
            // 
            // btStartGame
            // 
            this.btStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStartGame.Location = new System.Drawing.Point(784, 691);
            this.btStartGame.Name = "btStartGame";
            this.btStartGame.Size = new System.Drawing.Size(75, 23);
            this.btStartGame.TabIndex = 13;
            this.btStartGame.Text = "Start Game";
            this.btStartGame.UseVisualStyleBackColor = true;
            this.btStartGame.Click += new System.EventHandler(this.btStartGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btBackup);
            this.groupBox1.Controls.Add(this.btRestore);
            this.groupBox1.Location = new System.Drawing.Point(818, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 48);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup";
            // 
            // btReload
            // 
            this.btReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReload.Location = new System.Drawing.Point(726, 17);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 2;
            this.btReload.Text = "Reload";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 728);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btStartGame);
            this.Controls.Add(this.btPackage);
            this.Controls.Add(this.lvCameras);
            this.Controls.Add(this.lvCars);
            this.Controls.Add(this.btClearScalar);
            this.Controls.Add(this.btClearVector3);
            this.Controls.Add(this.btClearBool);
            this.Controls.Add(this.btClearAttributes);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.dgVector3Values);
            this.Controls.Add(this.dgBoolValues);
            this.Controls.Add(this.dgScalarValues);
            this.Controls.Add(this.dgAttributes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCamerasSelectNone);
            this.Controls.Add(this.btClearAll);
            this.Controls.Add(this.btCarsSelectNone);
            this.Controls.Add(this.btCamerasSelectAll);
            this.Controls.Add(this.btCarsSelectAll);
            this.Controls.Add(this.btReload);
            this.Controls.Add(this.btGameLocationChange);
            this.Controls.Add(this.tbGameLocation);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1015, 767);
            this.Name = "Form1";
            this.Text = "Camera Modifying Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgScalarValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoolValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVector3Values)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGameLocation;
        private System.Windows.Forms.Button btGameLocationChange;
        private System.Windows.Forms.Button btCarsSelectAll;
        private System.Windows.Forms.Button btCarsSelectNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCamerasSelectAll;
        private System.Windows.Forms.Button btCamerasSelectNone;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.DataGridView dgAttributes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridView dgScalarValues;
        private System.Windows.Forms.DataGridView dgBoolValues;
        private System.Windows.Forms.DataGridView dgVector3Values;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btClearAttributes;
        private System.Windows.Forms.Button btClearBool;
        private System.Windows.Forms.Button btClearVector3;
        private System.Windows.Forms.Button btClearScalar;
        private System.Windows.Forms.Button btClearAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn boolValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn scalarValue;
        private System.Windows.Forms.ListView lvCars;
        private System.Windows.Forms.ColumnHeader dir;
        private System.Windows.Forms.ColumnHeader car;
        private System.Windows.Forms.ListView lvCameras;
        private System.Windows.Forms.ColumnHeader camera;
        private System.Windows.Forms.Button btPackage;
        private System.Windows.Forms.Button btStartGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openCamraFileToolStripMenuItem;
        private System.Windows.Forms.Button btReload;
    }
}

