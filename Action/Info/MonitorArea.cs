using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Info
{
    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
    public class MonitorArea
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public static int Index = 0;
        public static int OtherIndex = 0;
        public static string ProcessName = "PathOfExile_KG";
        public static System.Windows.Forms.ToolStripComboBox GetButton()
        {

            // 
            // SelectMonitorButton
            // 
            System.Windows.Forms.ToolStripComboBox SelectMonitorButton;

            SelectMonitorButton = new System.Windows.Forms.ToolStripComboBox();
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                SelectMonitorButton.Items.Add(i);
            }

            /*
            SelectMonitorButton.Items.AddRange(new object[] {
            "1111",
            "2222"});*/
            SelectMonitorButton.Name = "SelectMonitorButton";
            SelectMonitorButton.Size = new System.Drawing.Size(121, 25);
            SelectMonitorButton.SelectedIndex = GetProcessIndex();
            OtherIndex = GetOtherIndex();
            SelectMonitorButton.DropDownStyle = ComboBoxStyle.DropDownList;
            return SelectMonitorButton;
        }
        public static Process[] getProcess()
        {
            return Process.GetProcessesByName(ProcessName);
        }
        public static int GetOtherIndex()
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (!Screen.AllScreens[i].Primary && Index != i)
                {
                    return i;
                }
            }
            return 0;
        }
        public static int GetProcessIndex()
        {

            //Process[] processes = Process.GetProcessesByName("MSPaint");
            Process[] processes = getProcess();
            if (processes.Length == 0)
            {
                processes = Process.GetProcessesByName("MSPaint");
            }
            if (processes.Length > 0)
            {
                Process p = processes[0];
                IntPtr ptr = p.MainWindowHandle;
                Rect ProcessRect = new Rect();
                GetWindowRect(ptr, ref ProcessRect);
                System.Drawing.Rectangle rc = new System.Drawing.Rectangle
                {
                    X = ProcessRect.Left + ((ProcessRect.Right - ProcessRect.Left) / 2) - 100,
                    Y = ProcessRect.Top + ((ProcessRect.Bottom - ProcessRect.Top) / 2) - 100,
                    Width = 200,
                    Height = 200
                };
                return Screen.AllScreens.ToList().FindIndex(x => x.WorkingArea.IntersectsWith(rc));
            }
            return 0;
        }
    }
}
