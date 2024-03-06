using SkAffix.Dto;
using SkAffix.Process;
using SkTask.Action;
using SkTask.Property;
using SkTask.Dto;
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

namespace SkTask
{
    public partial class SkTaskFormBase : Form
    {
        protected List<SkTask.Action.Task> actions = new List<SkTask.Action.Task>();
        protected List<SkTask.Action.TimerTask> timerActions = new List<SkTask.Action.TimerTask>();
        protected List<SkTask.Action.TimerTask> NetworkActions = new List<SkTask.Action.TimerTask>();
        List<SkTask.Component.ActionItem> actionItems;

        //알케
        //알터
        //템 버리기
        //템 넣기
        //헥블지
        //speed
        //필터
        //각종 필터 자동
        //아이템 거래소 검색
        //트레이 아이콘
        [Obsolete]
        public SkTaskFormBase()
        {
            InitializeComponent();
            /*
            ItemCsv itemCsv = new SkAffix.Process.ItemCsv();
            List<Item> items = itemCsv.getItems();
            OptionManager optionManager = new OptionManager();
            optionManager.test();
            this.actions = new List<SkTask.Action.Task>(new SkTask.Action.Task[] {
                new Inventory(),
                new Stash(),
                new BlightMap(),
                new Trash(),
                new Alter(),
                new Augmentation(),
                new AlchSco()
            });

            ActionItemVisible.ReadActionItemVisible(this.actions);
            this.actionItems = new List<Component.ActionItem>();
            for(int i = 0; i < this.actions.Count; i++)
            {
                this.actionItems.Add(new Component.ActionItem(this.actions[i], true));
                this.MainPanel.ContentPanel.Controls.Add(this.actionItems[i]);
            }
            */
            SkTask.Setting.Status.Mode = Constants.Mode.WAITING;
            SkTask.Setting.Status.PropertyChanged += Status_PropertyChanged;
            SkTask.Setting.Status.MouseLog = false;

            SkTask.Action.TrayIcon tray = new SkTask.Action.TrayIcon(this);
            tray.ViewModeChanged += Tray_ViewModeChanged;
            SkTask.Action.PopupWindow popupWindow = new SkTask.Action.PopupWindow(this);
            popupWindow.ViewModeChanged += Tray_ViewModeChanged;
            AddAction((SkTask.Action.Task)tray);
            AddAction((SkTask.Action.Task)popupWindow);
            AddAction();
            InitAction();
        }

        [Obsolete]
        private void Tray_ViewModeChanged(object sender, bool isPopup)
        {
            this.trayicon.Visible = !isPopup;
            this.Visible = isPopup;
            if (isPopup)
            {
                TimerTaskThread.Suspend();
            }
            else
            {
                TimerTaskThread.Resume();
            }
        }

        private void Status_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PositionList.Visible != SkTask.Setting.Status.MouseLog)
            {
                this.PositionList.Visible = SkTask.Setting.Status.MouseLog;
            }
        }

        protected virtual void AddAction()
        {

        }
        protected void InitAction()
        {
            if (this.actions != null)
            {
                ActionItemVisible.ReadActionItemVisible(this.actions);
                this.actionItems = new List<Component.ActionItem>();
                for (int i = 0; i < this.actions.Count; i++)
                {
                    this.actionItems.Add(new Component.ActionItem(this.actions[i], true));
                    this.MainPanel.ContentPanel.Controls.Add(this.actionItems[i]);
                }
            }
        }
        protected void AddToolSctipButton(ToolStripItem toolStripItem)
        {
            MainToolSctip.Items.Insert(0,toolStripItem);
        }
        protected bool isRunning = true;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void MainThread()
        {
            while (this.isRunning)
            {

                Thread.Sleep(40); //minimum CPU usage
                try
                {
                    if (SkTask.Setting.Status.Mode == Constants.Mode.WAITING && actions != null)
                    {
                        var select = from action in actions
                                     where action.StartCondition() == true
                                     select action;
                        if (select.Count() > 0)
                        {
                            SkTask.Action.Task t = select.First();
                            SkTask.Setting.Status.Mode = Constants.Mode.RUNNING;
                            t.task();
                        }
                    }
                }
                catch (Exception e) 
                { 
                }
            }
        }

        //Main 창이 띄워지면 중지 한다.
        //키 입력 인식 Thread와 같이 돌면 Sleep에 영향이 있으므로 별도로 둔다.
        //대신에 Waiting일때에만 동작하고 
        //한번에 하나의 동작만 해야한다.
        void TimerThread()
        {
            while (this.isRunning)
            {
                Thread.Sleep(40); //minimum CPU usage
                try
                {
                    if (SkTask.Setting.Status.Mode == Constants.Mode.WAITING && timerActions != null)
                    {
                        foreach(SkTask.Action.TimerTask task in timerActions)
                        {
                            //process에서 동작할거 시간 계산하고 그대로 입력 하면됨
                            task.Process();
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        private void FormClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("close?", "close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainPanel_TopToolStripPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected void AddAction(SkTask.Action.Task task)
        {
            this.actions.Add(task);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            SkTask.Property.SettingDlg setting = new Property.SettingDlg(this.actions);
            setting.Show();
            setting.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            setting.FormClosed += Setting_FormClosed;
            SkTask.Setting.Status.Mode = Constants.Mode.SETTING;
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            SkTask.Setting.Status.Mode = Constants.Mode.WAITING;
        }
        private void AddNetworkAction()
        {
            //NetworkActions.Add(Follow)
        }
    }
}
