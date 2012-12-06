using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TaskList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<TaskShellInfo> tsList = null;
        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            try
            {
	            DataStorage ds = new DataStorage();
	            tsList = ds.GetData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据文件损坏，无法读取！");
            }
        }

        private void Application_Exit_1(object sender, ExitEventArgs e)
        {
            if (tsList == null)
            {
                MessageBox.Show("数据文件损坏，无法保存!");
            }
            DataStorage ds = new DataStorage();
            ds.SaveData(tsList);
        }
    }
}
