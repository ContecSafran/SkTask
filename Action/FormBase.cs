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

namespace Action
{
    public partial class FormBase : Form
    {

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

            CloseTimer.Enabled = true;
        }

        protected virtual void Form_Load(object sender, EventArgs e)
        {
           // InitForm();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Thread TimerTaskThread = null;


        protected virtual void InitForm()
        {

            Setting.Mode = Action.Constants.Mode.WAITING;
            Setting.PropertyChanged += Status_PropertyChanged;
            Setting.MouseLog = true;

            AddAction();
            InitAction();
            InitThread();
            Action.Info.Setting.LoadStatus();
            //TimerTaskUtil.SaveTimerTask();
        }

    }
}
