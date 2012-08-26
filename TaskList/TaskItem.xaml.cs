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
    /// Interaction logic for TaskItem.xaml
    /// </summary>
    public partial class TaskItem : UserControl
    {
        public TaskItem(DelTaskItem Deletefun)
        {
            InitializeComponent();
            this.DeleteSelf = Deletefun;
        }

        private void TextBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            TaskContent.IsReadOnly = false;            
        }

        private void TaskContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TaskContent.IsReadOnly = true;
            }
        }

        public delegate void DelTaskItem(UIElement obj);
        public DelTaskItem DeleteSelf = null;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DeleteSelf != null)
            {
                DeleteSelf((UIElement)this);
            }
            
                        
        }

        private void CheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            TaskContent.IsEnabled = !((bool)cb.IsChecked);
        }
    }
}
