using SkTask.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkTask.Property
{
    public class Status
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Mode ModeValue;
        private bool MouseLogValue;
        private bool MouseClickValue;
        public Mode Mode
        {
            get
            {
                return ModeValue;
            }
            set
            {
                this.ModeValue = value;
                NotifyPropertyChanged();

            }
        }
        public bool MouseLog
        {
            get
            {
                return MouseLogValue;
            }
            set
            {
                this.MouseLogValue = value;
                NotifyPropertyChanged();

            }
        }
        public bool MouseClick
        {
            get
            {
                return MouseClickValue;
            }
            set
            {
                this.MouseClickValue = value;
                NotifyPropertyChanged();

            }
        }
    }
}
