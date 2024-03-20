using Search;
using SkAffix.Dto;
using SkAffix.Process;
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
using Action;

namespace SkTask
{
    public partial class SkTaskForm : FormBase
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

        Action.Network.TaskServer taskServer = new Action.Network.TaskServer();
        public SkTaskForm() : base()
        {
            Action.Info.Setting.IsServer = true;
            /*
             * 
             * 물약 검색 
            ItemCsv itemCsv = new SkAffix.Process.ItemCsv();
            List<Item> items = itemCsv.getItems();
            OptionManager optionManager = new OptionManager();
            optionManager.test();
            */
            /*
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
            // image.Show();



            
            

        }

        protected override void AddAction()
        {
            AddAction(new Action.Inventory());
            AddAction(new Action.Stash());
           // AddAction(new Action.BlightMap());
            AddAction(new Action.Trash());
            AddAction(new Action.Alter());
            AddAction(new Action.MouseLog());


            AddAction(new Action.ServerLocationMove());
            //AddAction(new Action.Trade(this));
            AddAction(new Action.ServerInviteAccept());
            //AddAction(new Action.Invite());
            // AddAction(new Action.Augmentation());
            // AddAction(new Action.AlchSco());
            base.AddAction();
        }

        protected override bool SendNetworkTask(Action.Task task)
        {
            //서버 역할을 해줘야 한다.
            int index = this.GetActions(Action.Constants.TaskType.NetworkTask).IndexOf(task);
            if(index == -1)
            {
                return false;
            }
            taskServer.SendCommand(index);
            return true;
        }

        private void InitializeComponent()
        {
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(125, 351);
            // 
            // SkTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(224, 470);
            this.Name = "SkTaskForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        protected override void Form_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        protected override void InitForm()
        {
            base.InitForm();
            taskServer.ServerStart();
        }
    }
}
