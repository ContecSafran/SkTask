using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Follow.MonitorInfo
{
    public class SelectMonitor
    {
        public static int index = 0;
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
            SelectMonitorButton.SelectedIndex = 0;
            SelectMonitorButton.DropDownStyle = ComboBoxStyle.DropDownList;
            //SelectMonitorButton.SelectedIndexChanged(new )
            return SelectMonitorButton;
        }
    }
}
