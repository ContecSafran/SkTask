using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.TimerAction
{
    public class TimerTask : Task
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
        public float Second
        {
            get;
            set;
        }
        public System.Windows.Input.Key key
        {
            get;
            set;
        }
        public TimerTask(System.Windows.Input.Key key, float second, bool visible)
        {
            StartKey.Add(key);
            Name = key.ToString();
            Second = second;
            Visible = visible;
            TaskType = Constants.TaskType.TimerTask;
        }
        public override void Process()
        {
            base.Process();
        }
        public static List<TimerTask> LoadTimerTask()
        {
            return null;
        }
        public static void SaveTimerTask(List<TimerTask> tasks)
        {
        }
    }
}
