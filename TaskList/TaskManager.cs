using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskList
{
    class TaskManager
    {
        public static TaskManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new TaskManager();
            }
            
            return m_Instance;
           
        }
        private TaskManager()
        {
            
        }
        public void LoadData(TaskFrame Frame)
        {
            List<TaskShellInfo> tsList = App.tsList;
            if (tsList == null)
            {
                return;
            }
            foreach (TaskShellInfo tsInfo in tsList)
            {
                TaskShell ts = new TaskShell();
                foreach (TaskItemlInfo tiInfo in tsInfo.ItemList)
                {
                    TaskItem ti = new TaskItem();
                    ti.Margin = new System.Windows.Thickness(2);
                    ti.TaskContent = tiInfo.Content;
                    ti.IsCompleted = tiInfo.IsCompleted;
                    ts.AddTask(ti);
                }
                ts.TaskShellName = tsInfo.Name;
                Frame.AddShell(ts);
            }
        }
        public void SaveData(TaskFrame Frame)
        {
            if (App.tsList == null)
            {
                App.tsList = new List<TaskShellInfo>();
            }
            List<TaskShellInfo> tsList = App.tsList;
            tsList.Clear();
            var list = Frame.TaskShellList();
            foreach (TaskShell ts in list)
            {
                TaskShellInfo tsInfo;
                tsInfo.Name = ts.TaskShellName;
                tsInfo.ItemList = new List<TaskItemlInfo>();
                var TaskItemList = ts.TaskItemList();
                foreach (TaskItem ti in TaskItemList)
                {
                    TaskItemlInfo tiInfo;
                    tiInfo.Content = ti.TaskContent;
                    tiInfo.IsCompleted = ti.IsCompleted;
                    tsInfo.ItemList.Add(tiInfo);
                }
                tsList.Add(tsInfo);
            }
            DataStorage ds = new DataStorage();
            ds.SaveData(tsList);
        }
        private static TaskManager m_Instance = null;
    }
}
