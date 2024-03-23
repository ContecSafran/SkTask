using Action.Controls;
using Action.Dlg;
using Action.Info;
using Action.TimerAction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Action
{
    public partial class FormBase : Form
    {
        Thread TaskThread = null;
        Thread FormThread = null;
        protected List<Thread> threads = new List<Thread>();
        public System.Windows.Input.Key[] ForcedCloseKey = new System.Windows.Input.Key[] {
            System.Windows.Input.Key.Escape,
            System.Windows.Input.Key.LeftShift
        };

        void InitThread()
        {
            CheckForIllegalCrossThreadCalls = false;
            TaskThread = new Thread(MainThread);
            TaskThread.SetApartmentState(ApartmentState.STA);
            TaskThread.Start();
            FormThread = new Thread(FormThreadFunction);
            FormThread.SetApartmentState(ApartmentState.STA);
            FormThread.Start();
            threads.Add(TaskThread);
            threads.Add(FormThread);
            /*
            TimerTaskThread = new Thread(TimerThread);
            TimerTaskThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TimerTaskThread.Start();*/
        }


        void MainThread()
        {
            while (this.isRunning)
            {

                Thread.Sleep(40); //minimum CPU usage
                try
                {
                    if (Setting.Mode == Action.Constants.Mode.WAITING && actions != null)
                    {
                        foreach(Action.Task curTask in actions)
                        {
                            if (curTask.StartCondition())
                            {
                                Task.ProcessTask.Enqueue(curTask);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.WriteLog(e.Message);
                    Setting.Mode = Action.Constants.Mode.WAITING;
                }
                Task task;
                while (Task.ProcessTask.TryDequeue(out task))
                {
                    if(!SendNetworkTask(task))
                    {
                        Setting.Mode = Action.Constants.Mode.RUNNING;
                        task.task();
                        Thread.Sleep(50);
                    }
                }

                //Main 창이 띄워지면 중지 한다.
                //키 입력 인식 Thread와 같이 돌면 Sleep에 영향이 있으므로 별도로 둔다.
                //대신에 Waiting일때에만 동작하고 
                //한번에 하나의 동작만 해야한다.
                //일단 메인 쓰레드에서 하는것으로 변경함 혹시 모르니 냅둠
                if (Action.TimerAction.TimerTaskUtil.Running)
                {
                    foreach (Action.TimerAction.TimerTask timerTask in TimerTaskUtil.TimerTaskDic.Values)
                    {
                        //process에서 동작할거 시간 계산하고 그대로 입력 하면됨
                        timerTask.Process();
                    }
                }
            }
        }
        void FormThreadFunction()
        {
            while (this.isRunning)
            {

                bool check = true;

                for (int i = 0; i < ForcedCloseKey.Length; i++)
                {
                    check &= ((Keyboard.GetKeyStates(ForcedCloseKey[i]) & KeyStates.Down) > 0);
                }
                if (check)
                {
                    break;
                }
                Thread.Sleep(1000); //minimum CPU usage
            }
        }


        /**
         * 메인 쓰레드 처리하고 각틱마다 호출됨
         */
        protected virtual void MainThreadProcessed()
        {

        }
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            if(FormThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                this.Close();
            }
        }
    }
}
