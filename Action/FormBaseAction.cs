using Action.Controls;
using Action.Dlg;
using Action.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action
{
    public partial class FormBase : Form
    {
        protected bool isRunning = true;
        protected List<Action.Task> actions = new List<Action.Task>();
        protected List<Action.TimerAction.TimerTask> timerActions = new List<Action.TimerAction.TimerTask>();
        protected List<Action.Task> NetworkActions = new List<Action.Task>();
        List<Action.Controls.ActionItem> actionItems;
        public Recognize recognizeTask;
        public RecognizeStop recognizeStopTask;
        public TradeCheck tradeCheck;
        bool TimerTaskRunning = false;


        protected virtual void AddAction()
        {

            Action.TrayIcon tray = new Action.TrayIcon(this);
            tray.ViewModeChanged += Tray_ViewModeChanged;
            Action.PopupWindow popupWindow = new Action.PopupWindow(this);
            popupWindow.ViewModeChanged += Tray_ViewModeChanged;
            AddAction((Action.Task)tray);
            AddAction((Action.Task)popupWindow);
            recognizeTask = new Action.Recognize();
            recognizeStopTask = new Action.RecognizeStop();
            tradeCheck = new TradeCheck();
            AddAction(recognizeTask);
            AddAction(recognizeStopTask);
            AddAction(tradeCheck);

            this.NetworkActions.Add(recognizeTask);
            this.NetworkActions.Add(recognizeStopTask);
            this.NetworkActions.Add(tradeCheck);
        }
        protected void InitAction()
        {
            if (this.actions != null)
            {
                this.actionItems = new List<Action.Controls.ActionItem>();
                for (int i = 0; i < this.actions.Count; i++)
                {
                    this.actionItems.Add(new Action.Controls.ActionItem(this.actions[i], true));
                    this.NetworkList.Controls.Add(this.actionItems[i]);
                }
            }

        }


        protected void AddAction(Action.Task task)
        {
            this.actions.Add(task);
        }

        protected virtual bool SendNetworkTask(Action.Task task)
        {
            return false;
        }
    }
}
