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
    /// Interaction logic for TaskShell.xaml
    /// </summary>
    public partial class TaskShell : UserControl
    {
        public string TaskShellName
        {
            set
            {
                groupboxShell.Header = value;
            }
            get
            {
                return (string)groupboxShell.Header;
            }
        }
        public void AddTask(TaskItem t)
        {
            t.DeleteSelf = DelTask;            
            Pool.Children.Add(t);
        }
        public TaskShell()
        {
            InitializeComponent();
        }

        public TaskShell(DelTaskShell DelSelf)
        {
            InitializeComponent();
            AddTaskItem();
            this.DelSelf = DelSelf;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskItem();
        }

        private void AddTaskItem()
        {
            TaskItem item = new TaskItem(DelTask);
            item.Margin = new System.Windows.Thickness(2);
            Pool.Children.Add(item);
        }

        private void DelTask(UIElement item)
        {
            Pool.Children.Remove(item);
            if (Pool.Children.Count == 0)
            {
                if (DelSelf != null)
                {
                    DelSelf((UIElement)this);
                }
            }
        }

        public delegate void DelTaskShell(UIElement obj);
        public DelTaskShell DelSelf;

        private void GroupBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            textboxHeader.Text = (string)groupboxShell.Header;
            textboxHeader.Visibility = Visibility.Visible;
        }

        private void textboxHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textboxHeader.Visibility = Visibility.Collapsed;
                groupboxShell.Header = textboxHeader.Text;
            }
        }
        public UIElementCollection TaskItemList()
        {
            return Pool.Children;
        }

    }
}
