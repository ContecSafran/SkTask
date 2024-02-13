using SkAffix.Dto;
using SkAffix.Process;
using SkTask.Action;
using SkTask.Data;
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
    public partial class SkTaskForm : SkTaskFormBase
    {
        Image image = new Image();
        //알케
        //알터
        //템 버리기
        //템 넣기
        //헥블지
        //speed
        //필터
        //각종 필터 자동
        //아이템 거래소 검색
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
        }
        protected override void AddAction()
        {
            this.actions = new List<SkTask.Action.Task>(new SkTask.Action.Task[] {
                new Inventory(),
                new Stash(),
                new BlightMap(),
                new Trash(),
                new Alter(),
                new Augmentation(),
                new AlchSco()
            });
        }
    }
}
