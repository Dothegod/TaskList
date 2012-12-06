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
using System.Windows.Shapes;

namespace TaskList
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private Window win;
        public Color BackgroundColor
        {
            get
            {
                return ((SolidColorBrush)win.Background).Color;
            }
            set
            {
                ((SolidColorBrush)win.Background).Color = value;
            }
        }

        public double winpacity
        {
            get
            {
                return win.Opacity;
            }
            set
            {
                win.Opacity = value;
            }
        }
        public void SetWindow(Window w)
        {
            win = w;
        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            win.Opacity = e.NewValue;
        }
    }
}
