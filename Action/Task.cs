﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using Action.Constants;
using System.Windows.Forms;
using Action.Controls;
using Action.Info;
using System.Collections.Concurrent;

namespace Action
{
    public class Task
    {
        #region MouseEvent
        static private int interval_;
        static private readonly ManualResetEvent stoppeing_event_ = new ManualResetEvent(false); //System.Threading;

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        static public void Move(System.Drawing.Point CurrentPosition)
        {
            Move(CurrentPosition.X, CurrentPosition.Y);
        }

        static public void Move(int x, int y)
        {
            Random rand = new Random();
            SetCursorPos(x + rand.Next(1, 5), y + rand.Next(1, 5));
            stoppeing_event_.WaitOne(interval_);
        }
        static public void Click(System.Drawing.Point CurrentPosition, InputEvent input = InputEvent.LEFT)
        {
            Click(CurrentPosition.X, CurrentPosition.Y, input);
        }

        static public void Click(int x, int y, InputEvent input)
        {
            if (!Setting.MouseClick || MonitorArea.getProcess().Length == 0)
            {
                Move(x, y);
                return;
            }
            try
            {

                Random rand = new Random();
                SetCursorPos(x + rand.Next(1, 5), y + rand.Next(1, 5));
                // stoppeing_event_.WaitOne(interval_);
                MouseClick_now(input);
            }
            catch (Exception e)
            {
                Log.WriteLog("MouseSetPosNclick\r\n" + e.Message);
            }
        }
        static public void Click_NoRandom(int x, int y, InputEvent input)
        {
            if (!Setting.MouseClick)
            {
                Move(x, y);
                return;
            }
            try
            {
                SetCursorPos(x, y);
                // stoppeing_event_.WaitOne(interval_);
                MouseClick_now(input);
            }
            catch (Exception e)
            {
                Log.WriteLog("MouseSetPosNclick\r\n" + e.Message);
            }
        }
        static public void MouseDown(InputEvent input)
        {
            try
            {
                if (input == InputEvent.LEFT)
                {
                    mouse_event((int)Event.MouseEV_LeftDown, 0, 0, 0, 0);
                }
                else if (input == InputEvent.RIGHT)
                {
                    mouse_event((int)Event.MouseEV_RightDown, 0, 0, 0, 0);
                }
                stoppeing_event_.WaitOne(10);
            }
            catch (Exception e)
            {
                Log.WriteLog("MouseClick_now\r\n" + e.Message);
            }
        }

        static public void MouseUp(InputEvent input)
        {
            try
            {
                if (input == InputEvent.LEFT)
                {
                    mouse_event((int)Event.MouseEV_LeftUp, 0, 0, 0, 0);
                }
                else if (input == InputEvent.RIGHT)
                {
                    mouse_event((int)Event.MouseEV_RightUp, 0, 0, 0, 0);
                }
                stoppeing_event_.WaitOne(10);
            }
            catch (Exception e)
            {
                Log.WriteLog("MouseClick_now\r\n" + e.Message);
            }
        }
        static public void MouseClick_now(InputEvent input)
        {
            try
            {
                if (input == InputEvent.LEFT)
                {
                    mouse_event((int)Event.MouseEV_LeftDown, 0, 0, 0, 0);
                    mouse_event((int)Event.MouseEV_LeftUp, 0, 0, 0, 0);
                }
                else if (input == InputEvent.RIGHT)
                {
                    mouse_event((int)Event.MouseEV_RightDown, 0, 0, 0, 0);
                    mouse_event((int)Event.MouseEV_RightUp, 0, 0, 0, 0);
                }
                stoppeing_event_.WaitOne(10);
            }
            catch (Exception e)
            {
                Log.WriteLog("MouseClick_now\r\n" + e.Message);
            }
        }
        #endregion
        #region KeyboardEvent
        // Sending Keystrokes to Other Apps with Windows API and C# 
        // ; https://dzone.com/articles/sending-keys-other-apps

        // inputsimulator/WindowsInput/
        // ; https://github.com/michaelnoonan/inputsimulator/tree/master/WindowsInput
        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            public ushort Vk;
            public ushort Scan;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT
        {
            public uint Msg;
            public ushort ParamL;
            public ushort ParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public HARDWAREINPUT Hardware;
            [FieldOffset(0)]
            public KEYBDINPUT Keyboard;
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            public uint Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        public static void SendKeyPress(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT()
            {
                Vk = (ushort)keyCode,
                Scan = 0,
                Flags = 0,
                Time = 0,
                ExtraInfo = IntPtr.Zero,
            };

            INPUT input2 = new INPUT
            {
                Type = 1
            };
            input2.Data.Keyboard = new KEYBDINPUT()
            {
                Vk = (ushort)keyCode,
                Scan = 0,
                Flags = 2,
                Time = 0,
                ExtraInfo = IntPtr.Zero
            };
            INPUT[] inputs = new INPUT[] { input, input2 };
            if (SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception();
        }


        /// <summary>
        /// Send a key down and hold it down until sendkeyup method is called
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyDown(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = 0;
            input.Data.Keyboard.Flags = 0;
            input.Data.Keyboard.Time = 0;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Release a key that is being hold down
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyUp(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = 0;
            input.Data.Keyboard.Flags = 2;
            input.Data.Keyboard.Time = 0;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception();

        }

        #endregion
        #region KeyCode

        public enum KeyCode : ushort
        {
            #region Media

            /// <summary>
            /// Next track if a song is playing
            /// </summary>
            MEDIA_NEXT_TRACK = 0xb0,

            /// <summary>
            /// Play pause
            /// </summary>
            MEDIA_PLAY_PAUSE = 0xb3,

            /// <summary>
            /// Previous track
            /// </summary>
            MEDIA_PREV_TRACK = 0xb1,

            /// <summary>
            /// Stop
            /// </summary>
            MEDIA_STOP = 0xb2,

            #endregion

            #region math

            /// <summary>Key "+"</summary>
            ADD = 0x6b,
            /// <summary>
            /// "*" key
            /// </summary>
            MULTIPLY = 0x6a,

            /// <summary>
            /// "/" key
            /// </summary>
            DIVIDE = 0x6f,

            /// <summary>
            /// Subtract key "-"
            /// </summary>
            SUBTRACT = 0x6d,

            #endregion

            #region Browser
            /// <summary>
            /// Go Back
            /// </summary>
            BROWSER_BACK = 0xa6,
            /// <summary>
            /// Favorites
            /// </summary>
            BROWSER_FAVORITES = 0xab,
            /// <summary>
            /// Forward
            /// </summary>
            BROWSER_FORWARD = 0xa7,
            /// <summary>
            /// Home
            /// </summary>
            BROWSER_HOME = 0xac,
            /// <summary>
            /// Refresh
            /// </summary>
            BROWSER_REFRESH = 0xa8,
            /// <summary>
            /// browser search
            /// </summary>
            BROWSER_SEARCH = 170,
            /// <summary>
            /// Stop
            /// </summary>
            BROWSER_STOP = 0xa9,
            #endregion

            #region Numpad numbers
            /// <summary>
            /// 
            /// </summary>
            NUMPAD0 = 0x60,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD1 = 0x61,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD2 = 0x62,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD3 = 0x63,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD4 = 100,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD5 = 0x65,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD6 = 0x66,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD7 = 0x67,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD8 = 0x68,
            /// <summary>
            /// 
            /// </summary>
            NUMPAD9 = 0x69,

            #endregion

            #region Fkeys
            /// <summary>
            /// F1
            /// </summary>
            F1 = 0x70,
            /// <summary>
            /// F10
            /// </summary>
            F10 = 0x79,
            /// <summary>
            /// 
            /// </summary>
            F11 = 0x7a,
            /// <summary>
            /// 
            /// </summary>
            F12 = 0x7b,
            /// <summary>
            /// 
            /// </summary>
            F13 = 0x7c,
            /// <summary>
            /// 
            /// </summary>
            F14 = 0x7d,
            /// <summary>
            /// 
            /// </summary>
            F15 = 0x7e,
            /// <summary>
            /// 
            /// </summary>
            F16 = 0x7f,
            /// <summary>
            /// 
            /// </summary>
            F17 = 0x80,
            /// <summary>
            /// 
            /// </summary>
            F18 = 0x81,
            /// <summary>
            /// 
            /// </summary>
            F19 = 130,
            /// <summary>
            /// 
            /// </summary>
            F2 = 0x71,
            /// <summary>
            /// 
            /// </summary>
            F20 = 0x83,
            /// <summary>
            /// 
            /// </summary>
            F21 = 0x84,
            /// <summary>
            /// 
            /// </summary>
            F22 = 0x85,
            /// <summary>
            /// 
            /// </summary>
            F23 = 0x86,
            /// <summary>
            /// 
            /// </summary>
            F24 = 0x87,
            /// <summary>
            /// 
            /// </summary>
            F3 = 0x72,
            /// <summary>
            /// 
            /// </summary>
            F4 = 0x73,
            /// <summary>
            /// 
            /// </summary>
            F5 = 0x74,
            /// <summary>
            /// 
            /// </summary>
            F6 = 0x75,
            /// <summary>
            /// 
            /// </summary>
            F7 = 0x76,
            /// <summary>
            /// 
            /// </summary>
            F8 = 0x77,
            /// <summary>
            /// 
            /// </summary>
            F9 = 120,

            #endregion

            #region Other
            /// <summary>
            /// 
            /// </summary>
            OEM_1 = 0xba,
            /// <summary>
            /// 
            /// </summary>
            OEM_102 = 0xe2,
            /// <summary>
            /// 
            /// </summary>
            OEM_2 = 0xbf,
            /// <summary>
            /// 
            /// </summary>
            OEM_3 = 0xc0,
            /// <summary>
            /// 
            /// </summary>
            OEM_4 = 0xdb,
            /// <summary>
            /// 
            /// </summary>
            OEM_5 = 220,
            /// <summary>
            /// 
            /// </summary>
            OEM_6 = 0xdd,
            /// <summary>
            /// 
            /// </summary>
            OEM_7 = 0xde,
            /// <summary>
            /// 
            /// </summary>
            OEM_8 = 0xdf,
            /// <summary>
            /// 
            /// </summary>
            OEM_CLEAR = 0xfe,
            /// <summary>
            /// 
            /// </summary>
            OEM_COMMA = 0xbc,
            /// <summary>
            /// 
            /// </summary>
            OEM_MINUS = 0xbd,
            /// <summary>
            /// 
            /// </summary>
            OEM_PERIOD = 190,
            /// <summary>
            /// 
            /// </summary>
            OEM_PLUS = 0xbb,

            #endregion

            #region KEYS

            /// <summary>
            /// 
            /// </summary>
            KEY_0 = 0x30,
            /// <summary>
            /// 
            /// </summary>
            KEY_1 = 0x31,
            /// <summary>
            /// 
            /// </summary>
            KEY_2 = 50,
            /// <summary>
            /// 
            /// </summary>
            KEY_3 = 0x33,
            /// <summary>
            /// 
            /// </summary>
            KEY_4 = 0x34,
            /// <summary>
            /// 
            /// </summary>
            KEY_5 = 0x35,
            /// <summary>
            /// 
            /// </summary>
            KEY_6 = 0x36,
            /// <summary>
            /// 
            /// </summary>
            KEY_7 = 0x37,
            /// <summary>
            /// 
            /// </summary>
            KEY_8 = 0x38,
            /// <summary>
            /// 
            /// </summary>
            KEY_9 = 0x39,
            /// <summary>
            /// 
            /// </summary>
            KEY_A = 0x41,
            /// <summary>
            /// 
            /// </summary>
            KEY_B = 0x42,
            /// <summary>
            /// 
            /// </summary>
            KEY_C = 0x43,
            /// <summary>
            /// 
            /// </summary>
            KEY_D = 0x44,
            /// <summary>
            /// 
            /// </summary>
            KEY_E = 0x45,
            /// <summary>
            /// 
            /// </summary>
            KEY_F = 70,
            /// <summary>
            /// 
            /// </summary>
            KEY_G = 0x47,
            /// <summary>
            /// 
            /// </summary>
            KEY_H = 0x48,
            /// <summary>
            /// 
            /// </summary>
            KEY_I = 0x49,
            /// <summary>
            /// 
            /// </summary>
            KEY_J = 0x4a,
            /// <summary>
            /// 
            /// </summary>
            KEY_K = 0x4b,
            /// <summary>
            /// 
            /// </summary>
            KEY_L = 0x4c,
            /// <summary>
            /// 
            /// </summary>
            KEY_M = 0x4d,
            /// <summary>
            /// 
            /// </summary>
            KEY_N = 0x4e,
            /// <summary>
            /// 
            /// </summary>
            KEY_O = 0x4f,
            /// <summary>
            /// 
            /// </summary>
            KEY_P = 80,
            /// <summary>
            /// 
            /// </summary>
            KEY_Q = 0x51,
            /// <summary>
            /// 
            /// </summary>
            KEY_R = 0x52,
            /// <summary>
            /// 
            /// </summary>
            KEY_S = 0x53,
            /// <summary>
            /// 
            /// </summary>
            KEY_T = 0x54,
            /// <summary>
            /// 
            /// </summary>
            KEY_U = 0x55,
            /// <summary>
            /// 
            /// </summary>
            KEY_V = 0x56,
            /// <summary>
            /// 
            /// </summary>
            KEY_W = 0x57,
            /// <summary>
            /// 
            /// </summary>
            KEY_X = 0x58,
            /// <summary>
            /// 
            /// </summary>
            KEY_Y = 0x59,
            /// <summary>
            /// 
            /// </summary>
            KEY_Z = 90,

            #endregion

            #region volume
            /// <summary>
            /// Decrese volume
            /// </summary>
            VOLUME_DOWN = 0xae,

            /// <summary>
            /// Mute volume
            /// </summary>
            VOLUME_MUTE = 0xad,

            /// <summary>
            /// Increase volue
            /// </summary>
            VOLUME_UP = 0xaf,

            #endregion


            /// <summary>
            /// Take snapshot of the screen and place it on the clipboard
            /// </summary>
            SNAPSHOT = 0x2c,

            /// <summary>Send right click from keyboard "key that is 2 keys to the right of space bar"</summary>
            RightClick = 0x5d,

            /// <summary>
            /// Go Back or delete
            /// </summary>
            BACKSPACE = 8,

            /// <summary>
            /// Control + Break "When debuging if you step into an infinite loop this will stop debug"
            /// </summary>
            CANCEL = 3,
            /// <summary>
            /// Caps lock key to send cappital letters
            /// </summary>
            CAPS_LOCK = 20,
            /// <summary>
            /// Ctlr key
            /// </summary>
            CONTROL = 0x11,

            /// <summary>
            /// Alt key
            /// </summary>
            ALT = 18,

            /// <summary>
            /// "." key
            /// </summary>
            DECIMAL = 110,

            /// <summary>
            /// Delete Key
            /// </summary>
            DELETE = 0x2e,


            /// <summary>
            /// Arrow down key
            /// </summary>
            DOWN = 40,

            /// <summary>
            /// End key
            /// </summary>
            END = 0x23,

            /// <summary>
            /// Escape key
            /// </summary>
            ESC = 0x1b,

            /// <summary>
            /// Home key
            /// </summary>
            HOME = 0x24,

            /// <summary>
            /// Insert key
            /// </summary>
            INSERT = 0x2d,

            /// <summary>
            /// Open my computer
            /// </summary>
            LAUNCH_APP1 = 0xb6,
            /// <summary>
            /// Open calculator
            /// </summary>
            LAUNCH_APP2 = 0xb7,

            /// <summary>
            /// Open default email in my case outlook
            /// </summary>
            LAUNCH_MAIL = 180,

            /// <summary>
            /// Opend default media player (itunes, winmediaplayer, etc)
            /// </summary>
            LAUNCH_MEDIA_SELECT = 0xb5,

            /// <summary>
            /// Left control
            /// </summary>
            LCONTROL = 0xa2,

            /// <summary>
            /// Left arrow
            /// </summary>
            LEFT = 0x25,

            /// <summary>
            /// Left shift
            /// </summary>
            LSHIFT = 160,

            /// <summary>
            /// left windows key
            /// </summary>
            LWIN = 0x5b,


            /// <summary>
            /// Next "page down"
            /// </summary>
            PAGEDOWN = 0x22,

            /// <summary>
            /// Num lock to enable typing numbers
            /// </summary>
            NUMLOCK = 0x90,

            /// <summary>
            /// Page up key
            /// </summary>
            PAGE_UP = 0x21,

            /// <summary>
            /// Right control
            /// </summary>
            RCONTROL = 0xa3,

            /// <summary>
            /// Return key
            /// </summary>
            ENTER = 13,

            /// <summary>
            /// Right arrow key
            /// </summary>
            RIGHT = 0x27,

            /// <summary>
            /// Right shift
            /// </summary>
            RSHIFT = 0xa1,

            /// <summary>
            /// Right windows key
            /// </summary>
            RWIN = 0x5c,

            /// <summary>
            /// Shift key
            /// </summary>
            SHIFT = 0x10,

            /// <summary>
            /// Space back key
            /// </summary>
            SPACE_BAR = 0x20,

            /// <summary>
            /// Tab key
            /// </summary>
            TAB = 9,

            /// <summary>
            /// Up arrow key
            /// </summary>
            UP = 0x26,

        }
        #endregion

        #region Property
        private TaskType TypeValue = TaskType.Task;
        public TaskType TaskType
        {
            get
            {
                return TypeValue;
            }
            set
            {
                TypeValue = value;
            }
        }
        private bool Active = true;
        public bool TaskActive
        {
            get
            {
                return Active && isActive();
            }
            set
            {
                Active = value;
            }
        }
        private bool isMenuDrawValue = true;
        public bool isMenuDraw
        {
            get
            {
                return isMenuDrawValue;
            }
            set
            {
                isMenuDrawValue = value;
            }
        }
        #endregion

        static public void Sleep()
        {
            Sleep(100);
        }
        static public void Sleep(int value)
        {
            int margin = value / 10;
            Random rand = new Random();
            Thread.Sleep(rand.Next(value - margin, value + margin));
        }


        public List<System.Windows.Input.Key> StartKey = new List<Key>();
        public List<System.Windows.Input.Key> EndKey = new List<Key>();
        public List<KeyCode[]> EnterKey = new List<KeyCode[]>();
        bool isStartKeyPress = false;


        public static ConcurrentQueue<Task> ProcessTask = new ConcurrentQueue<Task>();
        public Controls.ActionItem actionItem;
        public static bool WindowPopup = false;
        public bool useMiddleMousebutton = false;
        protected virtual bool isActive()
        {
            return true;
        }
        public bool CheckKeyCondition(List<System.Windows.Input.Key> Key)
        {

            bool check = true;
            /*
            if (Key[0] == System.Windows.Input.Key.LeftCtrl && Key[1] == System.Windows.Input.Key.A)
            {
                
                Trace.Write(((Keyboard.GetKeyStates(Key[0]) & KeyStates.Down) > 0) ? "true " : "false ");
                Trace.WriteLine(((Keyboard.GetKeyStates(Key[1]) & KeyStates.Down) > 0) ? "true" : "false");
            }*/
            if(Key.Count == 0)
            {
                check = false;
            }
            for (int i = 0; i < Key.Count; i++)
            {
                if (((Keyboard.GetKeyStates(Key[i]) & KeyStates.Down) > 0))
                {
                    Console.WriteLine(Key[i].ToString());
                }
                check &= ((Keyboard.GetKeyStates(Key[i]) & KeyStates.Down) > 0);
            }
            if(((Control.MouseButtons & MouseButtons.Middle) == MouseButtons.Middle))
            {
                if (this.GetType().Name == "PopupWindow")
                {
                    check = true;
                }
            }
            if (check && !isStartKeyPress)
            {
                isStartKeyPress = true;
                return false;
            }
            if (!check && isStartKeyPress)
            {
                Console.WriteLine(this.GetType().Name);
                isStartKeyPress = false;
                return true;
            }
            return false;
        }
        public bool StartCondition()
        {
            if (!isActive())
            {
                return false;
            }
            return CheckKeyCondition(StartKey);
        }

        public bool EndCondition()
        {
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                return true;
            }
            return CheckKeyCondition(EndKey);
        }

        public void task()
        {
            Start();
            while (Setting.Mode == Constants.Mode.RUNNING)
            {
                Process();
                if (EndKey.Count == 0)
                {
                    break;
                }
                if (EndCondition())
                {
                    break;
                }
            }
            End();
            Setting.Mode = Constants.Mode.WAITING;
        }
        public virtual void Start()
        {

        }
        public virtual void Process()
        {

        }

        public virtual void End()
        {

        }
        public void ForcedStop()
        {
            Setting.Mode = Constants.Mode.WAITING;
        }
        public static System.Drawing.Point toPoint(System.Drawing.PointF input)
        {
            return new System.Drawing.Point(
                (int)((float)Screen.PrimaryScreen.Bounds.Width * input.X),
                (int)((float)Screen.PrimaryScreen.Bounds.Height * input.Y));
        }
        public static System.Drawing.PointF toPointF(System.Drawing.Point input)
        {
            float x = (float)Position.CurrentPosition.X / (float)Screen.PrimaryScreen.Bounds.Width;
            float y = (float)Position.CurrentPosition.Y / (float)Screen.PrimaryScreen.Bounds.Height;
            return new System.Drawing.PointF(x, y);
        }
        public void EnterKeyProcess()
        {
            foreach(KeyCode [] codes in EnterKey)
            {
                foreach (KeyCode code in codes)
                {
                    SendKeyDown(code);
                    Task.Sleep(15);
                }

                foreach (KeyCode code in codes)
                {
                    SendKeyUp(code);
                    Task.Sleep(15);
                }
            }
        }
    }
}
