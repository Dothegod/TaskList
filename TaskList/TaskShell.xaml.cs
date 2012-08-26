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
            Pool.Children.Add(new TaskItem(DelTask));
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
        DelTaskShell DelSelf;

    }
}
