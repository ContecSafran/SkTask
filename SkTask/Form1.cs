using SkTask.Action;
using SkTask.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SkTask
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();

        }
        bool isRunning = true;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void MainThread()
        {
            List<SkTask.Action.Task> actions = new List<SkTask.Action.Task>(new SkTask.Action.Task[] {
                new Inventory(),
                new Stash(),
                new BlightMap(),
                new Trash(),
                new Alter()
            });
            while (this.isRunning)
            {
                Thread.Sleep(40); //minimum CPU usage
                if(Status.mode == Constants.Mode.WAITING)
                {
                    var select = from action in actions
                                 where action.StartCondition() == true
                                 select action;
                    if(select.Count() > 0)
                    {
                        SkTask.Action.Task t = select.First();
                        Status.mode = Constants.Mode.RUNNING;
                        t.task();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Thread TH = new Thread(MainThread);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }
    }
}
