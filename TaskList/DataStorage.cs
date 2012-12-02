using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TaskList
{
    public struct TaskItemlInfo
    {
        public string Content;
        public bool IsCompleted;
    }

    public struct TaskShellInfo
    {
        public string Name;
        public List<TaskItemlInfo> ItemList;
    }


    class DataStorage
    {
        const string Path = @"Data.xml";
        const string Root = "root";
        const string TaskShell = "taskshell";
        const string Task = "task";
        const string Name = "Name";
        const string IsCompleted = "IsCompleted";
        const string Content = "Content";


        public DataStorage()
        {
        }
        public List<TaskShellInfo> GetData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path);
            List<TaskShellInfo> TsList = new List<TaskShellInfo>();
            XmlNodeList list = xmlDoc.SelectNodes(string.Format("{0}/{1}",Root,TaskShell));
            foreach (XmlNode Node in list)
            {
                TaskShellInfo ts = new TaskShellInfo(); ;
                ts.Name = Node.Attributes[Name].Value;
                ts.ItemList = new List<TaskItemlInfo>();
                XmlNodeList ItemList = Node.ChildNodes;
                foreach (XmlNode ItemNode in ItemList)
                {
                    TaskItemlInfo ti = new TaskItemlInfo();
                    ti.Content = ItemNode.Attributes[Content].Value;
                    ti.IsCompleted = Boolean.Parse(ItemNode.Attributes[IsCompleted].Value);
                    ts.ItemList.Add(ti);
                }
                TsList.Add(ts);
            }
            return TsList;

        }

        public void SaveData(List<TaskShellInfo> Data)
        {
            if (Data == null)
            {
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            XmlNode rootNode = xmlDoc.CreateElement(Root);

            foreach (TaskShellInfo ts in Data)
            {
                //创建student子节点
                XmlNode TaskShellNode = xmlDoc.CreateElement(TaskShell);
                //创建一个属性
                XmlAttribute nameAttribute = xmlDoc.CreateAttribute(Name);
                nameAttribute.Value = ts.Name;
                //xml节点附件属性
                TaskShellNode.Attributes.Append(nameAttribute);

                foreach (TaskItemlInfo ti in ts.ItemList)
                {
                    //创建student子节点
                    XmlNode TaskItemNode = xmlDoc.CreateElement(TaskShell);
                    //创建一个属性
                    XmlAttribute ContentAttribute = xmlDoc.CreateAttribute(Content);
                    ContentAttribute.Value = ti.Content;
                    //xml节点附件属性
                    TaskItemNode.Attributes.Append(ContentAttribute);
                    //创建一个属性
                    XmlAttribute IsCompletedAttribute = xmlDoc.CreateAttribute(IsCompleted);
                    IsCompletedAttribute.Value = ti.IsCompleted.ToString();
                    //xml节点附件属性
                    TaskItemNode.Attributes.Append(IsCompletedAttribute);
                    TaskShellNode.AppendChild(TaskItemNode);
                }
                rootNode.AppendChild(TaskShellNode);

            }
            xmlDoc.AppendChild(rootNode);
            xmlDoc.Save(Path);
        }
    }
}
