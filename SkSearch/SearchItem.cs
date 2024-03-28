using SkAffix.Constants;
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
    public partial class SearchItem : UserControl
    {
        public delegate void SelectedSearchItem(DtoBase dtoBaseValue);
        public event SelectedSearchItem Select;
        public DtoBase dtoBaseValue;
        BaseType baseType;
        public DtoBase dtoBase
        {
            get
            {
                return dtoBaseValue;
            }
            set
            {
                dtoBaseValue = value;
                if(dtoBaseValue.GetType().Name == "Item")
                {
                    this.NameLabel.Text = dtoBase.Name;
                }

                if (dtoBaseValue.GetType().Name == "Affix")
                {
                    this.NameLabel.Text = ((Affix)dtoBase).Option;
                }
            }
        }
        public SearchItem()
        {
            InitializeComponent();

        }


        private void Control_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlDark;

        }

        private void NameLabel_MouseUp(object sender, MouseEventArgs e)
        {
            Select(dtoBase);
        }
    }
}
