using Action.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Action.Info
{
    public class Setting
    {
        static public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        static private void NotifyPropertyChanged(Object o,[CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(o, new PropertyChangedEventArgs(propertyName));
            }
        }
        static private Mode ModeValue = Mode.WAITING;
        static private Boolean MouseLogValue;
        static private Boolean MouseClickValue = true;
        static private string MainIDValue = "Kail_Aff";
        static public Mode Mode
        {
            get
            {
                return ModeValue;
            }
            set
            {
                ModeValue = value;
                NotifyPropertyChanged(ModeValue, "Mode");

            }
        }
        static public Boolean MouseLog
        {
            get
            {
                return MouseLogValue;
            }
            set
            {
                MouseLogValue = value;
                NotifyPropertyChanged(MouseLogValue, "MouseLog");

            }
        }
        static public Boolean MouseClick
        {
            get
            {
                return MouseClickValue;
            }
            set
            {
                MouseClickValue = value;
                NotifyPropertyChanged(MouseClickValue, "MouseClick");

            }
        }
        static public string MainID
        {
            get
            {
                return MainIDValue;
            }
            set
            {
                MainIDValue = value;
                NotifyPropertyChanged(MainIDValue, "MainID");

            }
        }
    }
}
