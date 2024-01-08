using SkTask.action;
using SkTask.dto;
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
            Inventory Inventory = new Inventory();
            Stash Stash = new Stash();
            MultiPoint multipoint = new MultiPoint();
            MultiPointInsert insert = new MultiPointInsert();
            MultiPointMove move = new MultiPointMove(insert);
            MultiPointClear clear = new MultiPointClear(insert);
            while (this.isRunning)
            {
                Thread.Sleep(40); //minimum CPU usage
                if(Status.mode == constants.Mode.WAITING)
                {
                    /*
                    if (multipoint.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        multipoint.task();
                    }*/
                    if (Inventory.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        Inventory.task();
                    }
                    if (Stash.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        Stash.task();
                    }
                    if (move.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        move.task();
                    }
                    if (insert.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        insert.task();
                    }
                    if (clear.StartCondition())
                    {
                        Status.mode = constants.Mode.RUNNING;
                        clear.task();
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
