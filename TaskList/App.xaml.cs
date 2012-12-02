using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<TaskShellInfo> tsList;
        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            try
            {
	            DataStorage ds = new DataStorage();
	            tsList = ds.GetData();
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void Application_Exit_1(object sender, ExitEventArgs e)
        {
            DataStorage ds = new DataStorage();
            ds.SaveData(tsList);
        }
    }
}
