using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkTask.Property
{
    public class ActionItemVisible
    {
        static string filename = "ActionItemVisible.txt";
        static Dictionary<string, bool> dic = new Dictionary<string, bool>();
        static void WriteActionItemVisible()
        {
            string s = "";
            foreach (KeyValuePair<string, bool> item in dic)
            {
                s += item.Key + "," + (item.Value ? "true" : "false") + "\r\n";
            }
            System.IO.File.WriteAllText(filename, s, Encoding.Default);
        }
        static public void ReadActionItemVisible(List<SkTask.Action.Task> actions)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] data = s.Split(',');
                    if (data.Length != 2)
                    {
                        break;
                    }
                    dic[data[0]] = data[1].Equals("true");
                }
                sr.Close();

                if (dic.Count == 0)
                {
                    newFile(actions);
                }
            }
            catch(FileNotFoundException ex)
            {
                newFile(actions);
            }
        }
        static public void newFile(List<SkTask.Action.Task> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                dic.Add(actions[i].GetType().Name, false);
            }
        }
        static public void set(string key, bool value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            WriteActionItemVisible();
        }
        static public bool get(string key)
        {
            bool result = false;
            if(!dic.TryGetValue(key, out result))
            {
                return false;
            }
            return result;
        }
    }
}
