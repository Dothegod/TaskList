using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double OriWidth = 0;
        internal class User32
        {
            public const int SE_SHUTDOWN_PRIVILEGE = 0x13;

            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx,
                int cy, uint uFlags);
        }

        public MainWindow()
        {
            InitializeComponent();
            Window win = System.Windows.Window.GetWindow(this);
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = 0;
//             this.ResizeMode = ResizeMode.NoResize;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TaskManager.Instance().SaveData(this.Frame);
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            TaskManager.Instance().LoadData(this.Frame);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Frame.Visibility != Visibility.Collapsed)
            {
                Frame.Visibility = Visibility.Collapsed;
                OriWidth = this.Width;
                this.Width = btnExpend.ActualWidth;
            } 
            else
            {
                Frame.Visibility = Visibility.Visible;
                this.Width = OriWidth;
            }
        }

        //private void SendFormToBack() //防止窗口最小化
        //{
        //    try
        //    {
        //        if (Environment.OSVersion.Version.Major < 6)
        //        {
        //            base.SendToBack();
        //            IntPtr hWndNewParent = User32.FindWindow("Progman", null);
        //            User32.SetParent(base.Handle, hWndNewParent);
        //        }
        //        else
        //        {
        //            User32.SetWindowPos(base.Handle, 1, 0, 0, 0, 0, User32.SE_SHUTDOWN_PRIVILEGE);
        //        }
        //    }
        //    catch (ApplicationException exx)
        //    {
        //        MessageBox.Show(this, exx.Message, "Pin to Desktop");
        //    }
        //}

    }
}
