using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastEntry.Model;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace FastEntry.Helper
{
    public static class UserDataHelper
    {
        private static string XmlPath
        {
            get
            {
                return Application.StartupPath + "\\" + ConfigurationManager.AppSettings["UserDataXMLPath"];
            }
        }

        #region 判断是否存在该网站名称的数据
        /// <summary>
        /// 判断是否存在该网站名称的数据
        /// </summary>
        /// <param name="sitename"></param>
        /// <returns></returns>
        public static bool IsExsitedSiteName(string sitename)
        {
            if (Item(sitename) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 根据sitename属性的值获取该节点
        /// <summary>
        /// 根据sitename属性的值获取该节点
        /// </summary>
        /// <param name="sitename">sitename属性</param>
        /// <returns>node节点</returns>
        private static XmlNode Item(string sitename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath);
            XmlNode root = doc.GetElementsByTagName("UserData")[0];
            foreach(XmlNode node in root.ChildNodes)
            {
                if (node.Attributes["sitename"].Value.ToString() == sitename)
                {
                    return node;
                }
            }
            return null;
        }
        #endregion

        #region 返回由sitename属性所确定的node节点的实体
        /// <summary>
        /// 返回由sitename属性所确定的node节点的实体
        /// </summary>
        /// <param name="sitename">sitename值</param>
        /// <returns>如果存在则返回实体，不存在则返回null</returns>
        public static LoginEntity GetEntityBySiteName(string sitename)
        {
            LoginEntity entity = null;
            XmlNode node = Item(sitename);
            if (node != null)
            {
                PropertyInfo[] pinfo = typeof(LoginEntity).GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    XmlAttribute attr = node.Attributes[p.Name.ToLower()];
                    if (attr != null)
                    {
                        if (entity == null)
                        {
                            entity = new LoginEntity();
                        }
                        p.SetValue(entity, attr.Value.ToString());
                    }
                }
            }

            return entity;

        }

        #endregion

        #region 往userdata.xml文件里写入一行数据
        /// <summary>
        /// 往userdata.xml文件里写入一行数据
        /// </summary>
        /// <param name="entity">要写入的实体</param>
        /// <returns>成功返回true,否则返回false</returns>
        public static bool WriteALine(LoginEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            if(IsExsitedSiteName(entity.SITENAME))
            {
                return false;
            }
            try
            {
                PropertyInfo[] pinfo = entity.GetType().GetProperties();
                XmlDocument xml = new XmlDocument();
                xml.Load(XmlPath);
                XmlNode root = xml.GetElementsByTagName("UserData")[0];
                XmlElement node = xml.CreateElement("add");
                foreach(PropertyInfo p in pinfo)
                {
                    string value = "";
                    if (p.GetValue(entity) != null)
                    {
                        value = p.GetValue(entity).ToString();
                    }
                    XmlAttribute attr = xml.CreateAttribute(p.Name.ToLower());
                    attr.Value = value;
                    node.Attributes.Append(attr);
                }
                root.AppendChild(node);
                xml.Save(XmlPath);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 根据实体更新一行数据
        /// <summary>
        /// 根据实体更新一行数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool UpdateALine(LoginEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            if (!IsExsitedSiteName(entity.SITENAME))
            {
                return false;
            }
            try
            {
                PropertyInfo[] pinfo = entity.GetType().GetProperties();
                XmlDocument xml = new XmlDocument();
                xml.Load(XmlPath);
                XmlNode root = xml.GetElementsByTagName("UserData")[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["sitename"].Value.ToString() == entity.SITENAME)
                    {
                        foreach (PropertyInfo p in pinfo)
                        {
                            string value = "";
                            if (p.GetValue(entity) != null)
                            {
                                value = p.GetValue(entity).ToString();
                            }
                            node.Attributes[p.Name.ToLower()].Value = value;
                        }
                        break;
                    }
                }
                xml.Save(XmlPath);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 移除子节点
        public static bool RemoveItem(string sitename)
        {
            if (!IsExsitedSiteName(sitename))
            {
                return true;
            }
            try
            {
                XmlNode node = Item(sitename);
                node.ParentNode.RemoveChild(node);
                node.OwnerDocument.Save(XmlPath);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
