using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using System.Threading;

namespace Action.TimerAction
{
    public class TimerTask
    {

        public string Name
        {
            get;
            set;
        }
        public bool Visible
        {
            get;
            set;
        }
        public int Second
        {
            get;
            set;
        }
        public Action.Task.KeyCode key
        {
            get;
            set;
        }
        bool RestartValue = false;
        public void SetRestart(bool value)
        {
            RestartValue = value;
            if (!RestartValue)
            {
                st.Reset();
            }
        }
        Stopwatch st = new Stopwatch();
        public TimerTask(Action.Task.KeyCode key, int second, bool visible)
        {
            //StartKey.Add(key);
            this.key = key;
            Name = key.ToString();
            Second = second;
            Visible = visible;
           // TaskType = Constants.TaskType.TimerTask;
        }
        public void Process()
        {
            if (this.Visible)
            {
                bool bProcess = false;
                if (RestartValue)
                {
                    RestartValue = false;
                    st.Start();
                    bProcess = true;
                }
                else if(st.ElapsedMilliseconds > Second)
                {
                    st.Restart();
                    bProcess = true;
                }
                if (bProcess)
                {
                    Task.SendKeyDown(key);
                    Thread.Sleep(10);
                    Task.SendKeyUp(key);
                    Thread.Sleep(10);
                }
            }
            //base.Process();
        }

        public string toJson()
        {
            return JsonSerializer.Serialize<TimerTask>(this);
        }
    }
}
