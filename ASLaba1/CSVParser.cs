using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ASLaba1
{
    public static class CSVParser
    {
        public static List<Ability> Read(string path)
        {
            List<Ability> Abilities = new List<Ability>();
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            try
            {
                using (TextFieldParser parser = new TextFieldParser(path, Encoding.UTF8))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        Ability ab = new Ability(fields[0], fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
                        Abilities.Add(ab);
                    }
                }
            }
            catch
            {
            }
            return Abilities;
        }

        public static Ability Read(string path, int index)
        {
            List<Ability> Abilities = new List<Ability>();
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            try
            {
                using (TextFieldParser parser = new TextFieldParser(path, Encoding.UTF8))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        Ability ab = new Ability(fields[0], fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
                        Abilities.Add(ab);
                    }
                }
            }
            catch
            {
            }
            if (index >= Abilities.Count || index < 0)
                return null;
            else
                return Abilities[index];
        }

        public static void Write(string path, List<Ability> text)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (var w = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach(var t in text)
                {
                    var line = string.Format("{0};{1};{2};{3};{4};{5}", t.ID, t.Name, t.Desc, t.ManaCost, t.Damage, t.ReloadInSec);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
        }

        public static void Append(string path, Ability ab)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (var w = new StreamWriter(path, true, Encoding.UTF8))
            {
                var line = string.Format("{0};{1};{2};{3};{4};{5}", ab.ID, ab.Name, ab.Desc, ab.ManaCost, ab.Damage, ab.ReloadInSec);
                w.WriteLine(line);
                w.Flush();
            }
        }

        public static bool Delete(string path, int number)
        {
            List<Ability> Abilities = Read(path);
            if (number >= Abilities.Count || number < 0)
                return false;
            Abilities.Remove(Abilities[number]);
            using (var w = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (var t in Abilities)
                {
                    if (t.ID == null)
                    {
                        t.ID = Guid.NewGuid().ToString();
                    }
                    var line = string.Format("{0};{1};{2};{3};{4};{5}", t.ID, t.Name, t.Desc, t.ManaCost, t.Damage, t.ReloadInSec);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
            return true;
        }

        public static bool Change(string path, Ability tochange, int index)
        {
            List<Ability> Abilities = Read(path);
            if (index >= Abilities.Count || index < 0)
                return false;
            Abilities[index] = tochange;
            using (var w = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (var t in Abilities)
                {
                    var line = string.Format("{0};{1};{2};{3};{4};{5}", t.ID, t.Name, t.Desc, t.ManaCost, t.Damage, t.ReloadInSec);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
            return true;
        }
    }
}
