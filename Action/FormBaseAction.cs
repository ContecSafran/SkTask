using Action.Controls;
using Action.Dlg;
using Action.Info;
using Action.TimerAction;
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
using static Action.Task;

namespace Action
{
    public partial class FormBase : Form
    {
        protected bool isRunning = true;
        protected List<Action.Task> actions = new List<Action.Task>();
        List<Action.Controls.ActionItem> actionItems;
        public Recognize recognizeTask;
        public RecognizeStop recognizeStopTask;
        public TradeCheck tradeCheck;


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
            AddAction(new Action.Invite());
            AddAction(new Action.LocationMove());
            AddAction(new Action.Trade(this));
            AddAction(recognizeTask);
            AddAction(recognizeStopTask);
            AddAction(tradeCheck);
            AddAction(new PcChange(this, tray, System.Windows.Input.Key.F1, KeyCode.KEY_1));
            AddAction(new PcChange(this, tray, System.Windows.Input.Key.F2, KeyCode.KEY_2));
            AddAction(new PcChange(this, tray, System.Windows.Input.Key.F3, KeyCode.KEY_3));
        }
        protected List<Action.Task> GetActions(Constants.TaskType type = Constants.TaskType.Task)
        {
            if(type == Constants.TaskType.Task)
            {
                return this.actions.Where(a => a.TaskType == type).ToList();
            }
            return this.actions.Where(a => (a.TaskType & type) == type).ToList();
        }
        protected void InitAction()
        {
            this.actionItems = new List<Action.Controls.ActionItem>();
            InitAction(this.NetworkList, this.GetActions(Action.Constants.TaskType.NetworkTask));
            InitAction(this.QuickList, this.GetActions(Action.Constants.TaskType.QuickTask));
            InitAction(this.SettingList, this.GetActions());

        }

        protected void InitAction(System.Windows.Forms.Panel panel, List<Action.Task> tasks)
        {
            if (tasks != null)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].isMenuDraw)
                    {
                        ActionItem actionItem = new Action.Controls.ActionItem(tasks[i], true);
                        this.actionItems.Add(actionItem);
                        panel.Controls.Add(actionItem);
                    }
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
