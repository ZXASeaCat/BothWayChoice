using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace BLL
{
    /// <summary>
    /// 文件操作流
    /// </summary>
    public class FileXmlIO
    {
        //序列化存储文件
        public static void saveDat(Model.AdminAccount model)
        {
            Stream s = File.Open("user.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, model);
            s.Close();
        }

        //序列化读取文件
        public static object readDat()
        {
            if (!File.Exists("user.dat"))
            {
                return null;
            }
            Stream fs = File.Open("user.dat", FileMode.Open);
            if (fs == null || fs.Length == 0)
            {
                return null;
            }
            BinaryFormatter bf = new BinaryFormatter();
            object o = bf.Deserialize(fs);
            fs.Close();
            if (o is Model.AdminAccount || o is Model.StudentAccount || o is Model.TeacherAccount)
            {
                return o;
            }
            return null;
        }

        /// <summary>
        /// 保存当前登录用户的用户名和密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void saveUser(string username, string password)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("User.xml");
            XmlNode rootNode = xmlDoc.SelectSingleNode(@"Users/UserInfo");
            string targetParm = string.Format("user[@username='{0}']", username);
            XmlNode x = rootNode.SelectSingleNode(targetParm);
            //之前保存过的user节点删除
            if (x != null)
                rootNode.RemoveChild(x);
            //将user节点保存到UserInfo子节点列表的最前面 
            XmlElement userElement = xmlDoc.CreateElement("user");
            XmlAttribute userNameElement = xmlDoc.CreateAttribute("username");
            XmlAttribute passwordElement = xmlDoc.CreateAttribute("password");
            userNameElement.Value = username;
            passwordElement.Value = password;
            userElement.Attributes.Append(userNameElement);
            userElement.Attributes.Append(passwordElement);
            rootNode.PrependChild(userElement);
            xmlDoc.Save(@"User.xml");
        }

        /// <summary>
        /// 读取上一次登录的用户，如果Remember节点为false，则只读取用户名
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void readUser(out string username, out string password)
        {
            username = ""; password = "";
            //不存在User.xml就创建
            if (!System.IO.File.Exists("User.xml"))
            {
                XmlDocument xmlNewDoc = new XmlDocument();
                XmlDeclaration xmlDeclare = xmlNewDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement rootElement = xmlNewDoc.CreateElement("Users");
                XmlElement child1 = xmlNewDoc.CreateElement("UserInfo");
                XmlElement child2 = xmlNewDoc.CreateElement("Remember");
                rootElement.InnerText = "";
                child1.InnerText = "";
                child2.InnerText = "false";
                xmlNewDoc.AppendChild(rootElement);
                rootElement.AppendChild(child1);
                rootElement.AppendChild(child2);
                xmlNewDoc.Save(@"User.xml");
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("User.xml");
            XmlNode x = xmlDoc.SelectSingleNode(@"Users/UserInfo").FirstChild;
            if (x != null)
            {
                username = x.Attributes["username"].Value;
                //如果Remember节点为false，则只读取用户名
                if (xmlDoc.SelectSingleNode(@"Users/Remember").InnerText == "true")
                    password = x.Attributes["password"].Value;
            }
        }

        /// <summary>
        /// 读取所有账户的用户名
        /// </summary>
        /// <returns></returns>
        public static object[] readAllUser()
        {
            //不存在User.xml就创建
            if (!System.IO.File.Exists("User.xml"))
            {
                XmlDocument xmlNewDoc = new XmlDocument();
                XmlDeclaration xmlDeclare = xmlNewDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement rootElement = xmlNewDoc.CreateElement("Users");
                XmlElement child1 = xmlNewDoc.CreateElement("UserInfo");
                XmlElement child2 = xmlNewDoc.CreateElement("Remember");
                rootElement.InnerText = "";
                child1.InnerText = "";
                child2.InnerText = "false";
                xmlNewDoc.AppendChild(rootElement);
                rootElement.AppendChild(child1);
                rootElement.AppendChild(child2);
                xmlNewDoc.Save(@"User.xml");
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("User.xml");
            XmlNodeList nodes = xmlDoc.SelectSingleNode(@"Users/UserInfo").ChildNodes;
            int count = nodes.Count;
            object[] xList = new object[count];
            for (int i = 0; i < count; i++)
            {
                xList[i] = nodes[i].Attributes["username"].Value;
            }
            return xList;
        }

        /// <summary>
        /// 设置记住密码
        /// </summary>
        /// <param name="s">值只有"true"和"false"</param>
        public static void setRemember(string s)
        {
            try
            {
                if (s != "true" && s != "false")
                    return;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("User.xml");
                XmlNode rootNode = xmlDoc.SelectSingleNode(@"Users/Remember");
                rootNode.InnerText = s;
                xmlDoc.Save(@"User.xml");
            }
            catch{}
        }

        /// <summary>
        /// 判断上一次登录是否设置过记住密码
        /// </summary>
        /// <returns></returns>
        public static bool getRemember()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("User.xml");
                XmlNode rootNode = xmlDoc.SelectSingleNode(@"Users/Remember");
                if (rootNode.InnerText == "true")
                    return true;
                return false;
            }
            catch { return false; }
        }

        //登录时选了check的话，再加上动过文本=false，直接登录，否则给该节点赋值；没有记住密码的话，查找节点，更改属性remember为false；

        //删除节点

        public static void deleteUser(string user, string password)
        {

        }
    }
}
