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
        protected List<Action.Task> actions = new List<Action.Task>();
        protected List<Action.TimerAction.TimerTask> timerActions = new List<Action.TimerAction.TimerTask>();
        protected List<Action.Task> NetworkActions = new List<Action.Task>();
        List<Action.Controls.ActionItem> actionItems;

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
        public FormBase()
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
            Setting.Mode = Action.Constants.Mode.WAITING;
            Setting.PropertyChanged += Status_PropertyChanged;
            Setting.MouseLog = false;

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
                TimerTaskThread.Resume();
            }
            else
            {
                TimerTaskThread.Suspend();
            }
        }

        private void Status_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PositionList.Visible != Setting.MouseLog)
            {
                this.PositionList.Visible = Setting.MouseLog;
            }
        }

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
            AddAction(recognizeTask);
            AddAction(recognizeStopTask);

            this.NetworkActions.Add(recognizeTask);
            this.NetworkActions.Add(recognizeStopTask);
        }
        protected void InitAction()
        {
            if (this.actions != null)
            {
                this.actionItems = new List<Action.Controls.ActionItem>();
                for (int i = 0; i < this.actions.Count; i++)
                {
                    this.actionItems.Add(new Action.Controls.ActionItem(this.actions[i], true));
                    this.MainPanel.ContentPanel.Controls.Add(this.actionItems[i]);
                }
            }

        }
        protected void AddToolSctipButton(ToolStripItem toolStripItem)
        {
            MainToolSctip.Items.Insert(0, toolStripItem);
        }
        protected bool isRunning = true;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Recognize recognizeTask;
        public RecognizeStop recognizeStopTask;
        Thread TaskThread = null;
        Thread TimerTaskThread = null;

        private void Form1_Load(object sender, EventArgs e)
        {


            TaskThread = new Thread(MainThread);
            TaskThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TaskThread.Start();

            TimerTaskThread = new Thread(TimerThread);
            TimerTaskThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TimerTaskThread.Start();
            InitForm();
        }

        protected virtual void InitForm()
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
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
                        var select = from action in actions
                                     where action.StartCondition() == true
                                     select action;
                        if (select.Count() > 0)
                        {
                            Action.Task t = select.First();
                            Setting.Mode = Action.Constants.Mode.RUNNING;
                            t.task();
                            CurrentTask(t);
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.WriteLog(e.Message);
                    Setting.Mode = Action.Constants.Mode.WAITING;
                }
                MainThreadProcessed();
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
                    if (Setting.Mode == Action.Constants.Mode.WAITING && timerActions != null)
                    {
                        foreach (Action.TimerAction.TimerTask task in timerActions)
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
            if (MessageBox.Show("close?", "close", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        protected void AddAction(Action.Task task)
        {
            this.actions.Add(task);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            SettingDlg setting = new SettingDlg(this.actions);
            setting.Show();
            setting.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            setting.FormClosed += Setting_FormClosed;
            Setting.Mode = Action.Constants.Mode.SETTING;
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setting.Mode = Action.Constants.Mode.WAITING;
        }
        protected virtual void CurrentTask(Action.Task task)
        {

        }
        /**
         * 메인 쓰레드 처리하고 각틱마다 호출됨
         */
        protected virtual void MainThreadProcessed()
        {

        }
    }
}
