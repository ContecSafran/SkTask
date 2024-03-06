﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Controls
{
    public partial class Log : UserControl
    {

        static public TextBox LogTextBox = null;
        public Log()
        {
            InitializeComponent();
            LogTextBox = this.ContentsTextBox;

        }

        static public void WriteLog(string s)
        {
            if (LogTextBox != null)
            {
                if (LogTextBox.InvokeRequired)
                {
                    LogTextBox.Invoke((System.Action)delegate
                    {
                        WriteLog(LogTextBox, s);
                    });
                }
                else
                {
                    WriteLog(LogTextBox, s);
                }
            }
        }
        static public void Clear()
        {
            if (LogTextBox != null)
            {
                if (LogTextBox.InvokeRequired)
                {
                    LogTextBox.Invoke((System.Action)delegate
                    {
                        LogTextBox.Text = "";
                    });
                }
                else
                {
                    LogTextBox.Text = "";
                }
            }

        }
        static public void WriteLog(TextBox LogTextBox, string _s)
        {
            if (LogTextBox.Text.Length > 10000)
            {
                LogTextBox.Text = "";
            }
            string Time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            LogTextBox.Text = LogTextBox.Text + "\r\n" + Time + "\t" + _s;
            LogTextBox.Select(LogTextBox.Text.Length, 0);
            LogTextBox.ScrollToCaret();
        }
    }
}
