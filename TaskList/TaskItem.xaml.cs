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
        public string TaskContent
        {
            set
            {
                m_TaskContent.Text = value;
            }
            get
            {
                return m_TaskContent.Text;
            }
        }

        public bool IsCompleted
        {
            set
            {
                m_IsCompleted.IsChecked = value;
            }
            get
            {
                return (bool)m_IsCompleted.IsChecked;
            }
        }

        public TaskItem()
        {
            InitializeComponent();
        }

        public TaskItem(DelTaskItem Deletefun)
        {
            InitializeComponent();
            this.DeleteSelf = Deletefun;
        }

        private void TextBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            m_TaskContent.IsReadOnly = false;
            e.Handled = true;
        }

        private void TaskContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                m_TaskContent.IsReadOnly = true;
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

        private void UserControl_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void m_IsCompleted_IsCheckedChage(object sender, RoutedEventArgs e)
        {
            m_TaskContent.IsHitTestVisible = !((bool)m_IsCompleted.IsChecked);
            this.Opacity = (m_IsCompleted.IsChecked == true) ? 0.5 : 1;
        }


    }
}
