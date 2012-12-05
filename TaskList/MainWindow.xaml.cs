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
            this.ResizeMode = ResizeMode.NoResize;
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
                this.Width = ButtonPanel.ActualWidth;
            } 
            else
            {
                Frame.Visibility = Visibility.Visible;
                this.Width = Frame.ActualWidth;
            }
        }

        private void btnDrag_Click(object sender, RoutedEventArgs e)
        {
            if (this.ResizeMode != ResizeMode.CanResize)
            {
                this.ResizeMode = ResizeMode.CanResize;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            } 
            else
            {
                this.ResizeMode = ResizeMode.NoResize;
                this.WindowStyle = WindowStyle.None;
                this.Height = ButtonPanel.ActualHeight + Frame.ActualHeight;
            }
        }
    }
}
