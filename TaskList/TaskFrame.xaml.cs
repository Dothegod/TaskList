using System;
using System.Collections.Generic;
using System.Linq;
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
    /// TaskFrame.xaml 的交互逻辑
    /// </summary>
    public partial class TaskFrame : UserControl
    {
        public TaskFrame()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddShell();
        }

        public void AddShell(TaskShell t)
        {
            t.DelSelf = DelTaskShell;
            Pool.Children.Add(t);
        }
        private void AddShell()
        {
            Pool.Children.Add(new TaskShell(DelTaskShell));
        }

        private void DelTaskShell(UIElement shell)
        {
            Pool.Children.Remove(shell);
        }

        public UIElementCollection TaskShellList()
        {
            return Pool.Children;
        }
    }
}
