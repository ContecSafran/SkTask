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



            /*
            string refStr = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"pseudo.pseudo_number_of_empty_prefix_mods\"},{\"disabled\":false,\"id\":\"explicit.stat_962725504\",\"value\":{\"max\":39,\"min\":39}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            q_Stats_filters prefixFilter = Search.OptionParser.GetOptionFilter("효과 #% 증가",25);
            q_Stats_filters suffixFilter = Search.OptionParser.GetOptionFilter("효과를 받는 동안 추가 원소 저항 #%", 36);
            string output = Search.Search.toJson("자수정 플라스크", "flask", prefixFilter, suffixFilter);
           // string ss = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"explicit.stat_1582728645\",\"value\":{\"max\":3,\"min\":3}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            List<SkAffix.Dto.Currency> price = Search.Search.UpdatePrice("Affliction", 0, output, 5);*/

        }

        protected override void AddAction()
        {
            AddAction(new Action.Inventory());
            AddAction(new Action.Stash());
           // AddAction(new Action.BlightMap());
            AddAction(new Action.Trash());
            AddAction(new Action.Alter());
            AddAction(new Action.MouseLog());
            
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
