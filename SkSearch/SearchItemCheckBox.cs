using SkAffix.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkSearch
{
    public partial class SearchItemCheckBox : UserControl
    {
        DtoBase dtoBaseValue;
        public delegate void CheckedSearchItem(DtoBase dtoBaseValue);
        public event CheckedSearchItem Checked;
        public DtoBase dtoBase
        {
            get
            {
                return dtoBaseValue;
            }
            set
            {
                dtoBaseValue = value;
                this.NameCheckBox.Text = dtoBase.Name;
                NameCheckBox.Checked = dtoBase.enable;
            }
        }
        public SearchItemCheckBox()
        {
            InitializeComponent();

        }


        private void NameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dtoBase != null)
            {
                dtoBase.enable = NameCheckBox.Checked;
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlDark;

        }

    }
}
