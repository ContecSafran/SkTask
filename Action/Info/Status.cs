using Action.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Info
{
    public class Setting
    {
        static public event PropertyChangedEventHandler PropertyChanged;
        private class Value
        {   
            public string MainID
            {
                set;
                get;
            }
        }
        private static Value value = new Value();
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        static private void NotifyPropertyChanged(Object o, [CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(o, new PropertyChangedEventArgs(propertyName));
            }
        }
        static private Mode ModeValue = Mode.WAITING;
        static private Boolean MouseLogValue;
        static private Boolean MouseClickValue = true;
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
                return value.MainID;
            }
        }

        public static string StatusTxtFile = "status.txt";
        public static string StatusDirectory = "Status";
        public static string GetStatusTxtFileName()
        {
            return Directory.GetParent(Application.ExecutablePath) + "\\" + StatusDirectory + "\\" + StatusTxtFile;
        }
        public static string GetStatusTxtDirectory()
        {
            return Directory.GetParent(Application.ExecutablePath) + "\\" + StatusDirectory;
        }
        public static void LoadStatus()
        {
            value.MainID = "Kail";
            string s = JsonConvert.SerializeObject(value);



        }
    }
}
