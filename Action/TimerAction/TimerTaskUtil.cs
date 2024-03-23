using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Action.TimerAction
{
    public class TimerTaskUtil
    {
        public static bool RunningValue = false;
        public static bool Running
        {
            get
            {
                return RunningValue;
            }
            set
            {
                RunningValue = value;
                foreach (TimerTask task in TimerTaskDic.Values)
                {
                    task.SetRestart(RunningValue);
                }
            }
        }
        public static TimerTask Num1TimerTask = new TimerTask(Action.Task.KeyCode.KEY_1, 1000, false);
        public static TimerTask Num2TimerTask = new TimerTask(Action.Task.KeyCode.KEY_2, 1000, false);
        public static TimerTask Num3TimerTask = new TimerTask(Action.Task.KeyCode.KEY_3, 1000, false);
        public static TimerTask Num4TimerTask = new TimerTask(Action.Task.KeyCode.KEY_4, 1000, false);
        public static TimerTask Num5TimerTask = new TimerTask(Action.Task.KeyCode.KEY_5, 1000, false);
        public static TimerTask Num6TimerTask = new TimerTask(Action.Task.KeyCode.KEY_6, 1000, false);
        public static TimerTask Num7TimerTask = new TimerTask(Action.Task.KeyCode.KEY_7, 1000, false);
        public static TimerTask Num8TimerTask = new TimerTask(Action.Task.KeyCode.KEY_8, 1000, false);
        public static TimerTask Num9TimerTask = new TimerTask(Action.Task.KeyCode.KEY_9, 1000, false);
        public static TimerTask Num0TimerTask = new TimerTask(Action.Task.KeyCode.KEY_0, 1000, false);
        public static TimerTask QTimerTask = new TimerTask(Action.Task.KeyCode.KEY_Q, 1000, false);
        public static TimerTask WTimerTask = new TimerTask(Action.Task.KeyCode.KEY_W, 1000, false);
        public static TimerTask ETimerTask = new TimerTask(Action.Task.KeyCode.KEY_E, 1000, false);
        public static TimerTask RTimerTask = new TimerTask(Action.Task.KeyCode.KEY_R, 1000, false);
        public static TimerTask TTimerTask = new TimerTask(Action.Task.KeyCode.KEY_T, 1000, false);
        public static Dictionary<Action.Task.KeyCode, TimerTask> TimerTaskDic = new Dictionary<Action.Task.KeyCode, TimerTask>();
        public static string TimerTaskTxtFile = "timertask.txt";
        public static string TimerTaskDirectory = "TimerTask";
        public static string GetTimerTaskTxtFileName()
        {
            return Directory.GetParent(Application.ExecutablePath) + "\\" + TimerTaskDirectory + "\\" + TimerTaskTxtFile;
        }
        public static string GetTimerTaskTxtDirectory()
        {
            return Directory.GetParent(Application.ExecutablePath) + "\\" + TimerTaskDirectory;
        }
        public static void LoadTimerTask(string loadFileName)
        {
            
            TimerTaskDic = new Dictionary<Action.Task.KeyCode, TimerTask>();
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_1, Num1TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_2, Num2TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_3, Num3TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_4, Num4TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_5, Num5TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_6, Num6TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_7, Num7TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_8, Num8TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_9, Num9TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_0, Num0TimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_Q, QTimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_W, WTimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_E, ETimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_R, RTimerTask);
            TimerTaskDic.Add(Action.Task.KeyCode.KEY_T, TTimerTask);
            string s = loadFileName;
            if (File.Exists(s))
            {
                Dictionary<string, TimerTask> Loaded_Dictionary = JsonConvert.DeserializeObject<Dictionary<string, TimerTask>>(File.ReadAllText(s));
                foreach (KeyValuePair<string, TimerTask> keyValue in Loaded_Dictionary)
                {
                    Action.Task.KeyCode key = (Action.Task.KeyCode)Enum.Parse(typeof(Action.Task.KeyCode), keyValue.Key);
                    TimerTask task;
                    if (TimerTaskDic.TryGetValue(key, out task))
                    {
                        task.Second = keyValue.Value.Second;
                        task.Visible = keyValue.Value.Visible;
                    }
                }
            }
        }
        public static string SelectLoadFile()
        {
            string directory = GetTimerTaskTxtDirectory();
            // 파일 오픈창 생성 및 설정
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 다이얼로그 타이틀 설정
            openFileDialog.Title = "파일 선택";
            openFileDialog.InitialDirectory = directory;
            openFileDialog.Filter = "txt File(*.txt)|*.txt";
            // 파일 오픈창 로드
            string[] pathFiles = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
        public static void SaveTimerTask(bool saveAs = false)
        {
            string directory = GetTimerTaskTxtDirectory();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (saveAs)
            {
                // 파일 오픈창 생성 및 설정
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // 다이얼로그 타이틀 설정
                saveFileDialog.Title = "파일 선택";
                saveFileDialog.InitialDirectory = directory;
                saveFileDialog.OverwritePrompt = false;
                saveFileDialog.Filter = "txt File(*.txt)|*.txt";
                // 파일 오픈창 로드
                string[] pathFiles = null;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Save(saveFileDialog.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Save(directory + "\\" + TimerTaskTxtFile);
            }
        }
        private static void Save(string filename)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(TimerTaskDic));
        }
    }
}
