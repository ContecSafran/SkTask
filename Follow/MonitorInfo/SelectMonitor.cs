using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Follow.MonitorInfo
{

    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
    public class SelectMonitor
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public static int Index = 1;
        public static int OtherIndex = 0;
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
            SelectMonitorButton.SelectedIndex = 1;
            SelectMonitorButton.DropDownStyle = ComboBoxStyle.DropDownList;


            Process[] processes = Process.GetProcessesByName("PathOfExile_KG");
            if (processes.Length > 0)
            {
                Process p = processes[0];
                IntPtr ptr = p.MainWindowHandle;
                Rect ProcessRect = new Rect();
                GetWindowRect(ptr, ref ProcessRect);
                System.Drawing.Rectangle rc = new System.Drawing.Rectangle
                {
                    X = ProcessRect.Left,
                    Y = ProcessRect.Top,
                    Width = ProcessRect.Right - ProcessRect.Left,
                    Height = ProcessRect.Bottom - ProcessRect.Top
                };
            }
            return SelectMonitorButton;
        }
        public static int GetProcessIndex()
        {

            //Process[] processes = Process.GetProcessesByName("MSPaint");
            Process[] processes = Process.GetProcessesByName("PathOfExile_KG");
            if (processes.Length > 0)
            {
                Process p = processes[0];
                IntPtr ptr = p.MainWindowHandle;
                Rect ProcessRect = new Rect();
                GetWindowRect(ptr, ref ProcessRect);
                System.Drawing.Rectangle rc = new System.Drawing.Rectangle
                {
                    X = ProcessRect.Left,
                    Y = ProcessRect.Top,
                    Width = ProcessRect.Right - ProcessRect.Left,
                    Height = ProcessRect.Bottom - ProcessRect.Top
                };
                return Screen.AllScreens.ToList().FindIndex(x => x.WorkingArea.Contains(rc));
            }
            return 0;
        }
    }
}
