using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace DirtCameraMod
{
    public class INIFile
    {
        const string UNNAMED_SECTION = "root";
        StreamReader reader;
        string filepath;
        Dictionary<string, Dictionary<string, string>> dictionary;

        public INIFile()
        {
            dictionary = new Dictionary<string, Dictionary<string, string>>();
        }

        public INIFile(string path) : this()
        {
            LoadFile(path);
        }

        public void LoadFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Unable to locate " + path);
            filepath = path;
            reader = new StreamReader(path);
            string line;
            string currentSection = UNNAMED_SECTION;
            dictionary.Add(currentSection, new Dictionary<string, string>());
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (IsComment(line) || line.Length == 0) continue;
                if (IsSectionName(line))
                {
                    currentSection = line.Substring(1, line.Length - 2);
                    dictionary.Add(currentSection, new Dictionary<string, string>());
                }
                if (IsParameterDefinition(line))
                {
                    string[] chunks = line.Split('=');
                    string value = null;
                    if (chunks.Length > 1) value = chunks[1].Trim();
                    dictionary[currentSection].Add(chunks[0].Trim(), value);
                }
            }
            reader.Close();
        }
        

        bool IsComment(string line)
        {
            return line.StartsWith("#") || line.StartsWith("//") || line.StartsWith(";");
        }

        bool IsSectionName(string line)
        {
            return line.StartsWith("[") && line.EndsWith("]");
        }

        bool IsParameterDefinition(string line)
        {
            return line.Contains("=");
        }


        public List<string> GetSections()
        {
            return dictionary.Keys.ToList();
        }

        public List<string> GetParameterNames(string SectionName)
        {
            if (!dictionary.ContainsKey(SectionName)) return null;
            return dictionary[SectionName].Keys.ToList();
        }

        public string GetParameterValue(string SectionName, string ParameterName)
        {
            if (!dictionary.ContainsKey(SectionName)) return null;
            if (!dictionary[SectionName].ContainsKey(ParameterName)) return null;
            return dictionary[SectionName][ParameterName];
        }

        public int GetParameterValueInt(string SectionName, string ParameterName)
        {
            return int.Parse(GetParameterValue(SectionName, ParameterName));
        }

        public bool GetParameterValueBool(string SectionName, string ParameterName)
        {
            return bool.Parse(GetParameterValue(SectionName, ParameterName));
        }

        public float GetParameterValueFloat(string SectionName, string ParameterName)
        {
            return float.Parse(GetParameterValue(SectionName, ParameterName));
        }

        public T GetParameterValueEnum<T>(string SectionName, string ParameterName)
        {
            string value = GetParameterValue(SectionName, ParameterName);
            return (T)Enum.Parse(typeof(T), value);
        }

        public void AddParameter(string SectionName, string ParameterName, object Value)
        {
            if (!dictionary.ContainsKey(SectionName))
                dictionary.Add(SectionName, new Dictionary<string, string>());
            if (dictionary[SectionName].ContainsKey(ParameterName)) dictionary[SectionName].Remove(ParameterName);

            dictionary[SectionName].Add(ParameterName, Value.ToString());
        }

        public void AddParameter(string SectionName, string ParameterName)
        {
            AddParameter(SectionName, ParameterName, null);
        }

        public void DeleteParameter(string SectionName, string ParameterName)
        {
            if (dictionary.ContainsKey(SectionName))
                if (dictionary[SectionName].ContainsKey(ParameterName))
                    dictionary[SectionName].Remove(ParameterName);
        }

        public void SaveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            foreach(string section in dictionary.Keys)
            {
                if (section != UNNAMED_SECTION) writer.WriteLine(System.Environment.NewLine + "[" + section + "]");

                foreach (string param in dictionary[section].Keys)
                {
                    string output = param + " = ";
                    if (dictionary[section][param] != null) output += dictionary[section][param];
                    writer.WriteLine(output);
                }
            }

            writer.Close();
        }

        public void SaveFile()
        {
            SaveFile(filepath);
        }

    }
}
