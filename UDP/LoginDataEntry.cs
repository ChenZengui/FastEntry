using Model;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Xml;

namespace UDP
{
    public class LoginDataEntry : BaseEntry<LoginEntity>
    {
        private delegate dynamic ManipulateXMLDelegate(XmlDocument xml);

        public LoginDataEntry(string path)
            : base(path)
        {
 
        }

        private XmlDocument xmldocument = null;

        public XmlDocument XML
        {
            get
            {
                if (xmldocument == null)
                {
                    xmldocument = new XmlDocument();
                    xmldocument.Load(Path);
                }
                return xmldocument;
            }
        }

        /// <summary>
        /// 通用的打开
        /// </summary>
        /// <param name="_delegate"></param>
        /// <returns></returns>
        private object Exe(ManipulateXMLDelegate _delegate)
        {
            object result = null;
            try
            {
                result = _delegate(XML);
            }
            finally
            {
                if (XML != null)
                {
                    xmldocument.Save(Path);
                }
            }

            return result;
        }

        public override LoginEntity GetEntity(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return null;
            }
            return (LoginEntity)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc){
                XmlNode root = xmldoc.GetElementsByTagName("UserData")[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["sitename"].Value.ToString() == condition.sitename)
                    {
                       return ParseToEntity(node);
                    }
                }
                return null;
            }));
        }

        public override IList<LoginEntity> GetEntities(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return null;
            }
            return (IList<LoginEntity>)Exe(new ManipulateXMLDelegate((XmlDocument xmldoc) =>
            {
                IList<LoginEntity> list = new List<LoginEntity>();
                XmlNode root = xmldoc.GetElementsByTagName("UserData")[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["sitename"].Value.ToString().Contains(condition.sitename))
                    {
                        list.Add(ParseToEntity(node));
                    }
                }

                return list;
            }));
        }

        public override bool InsertEntity(LoginEntity t)
        {
            if (t == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                if (IsExsitedSiteName(t.SITENAME))
                {
                    return false;
                }
                try
                {
                    PropertyInfo[] pinfo = t.GetType().GetProperties();
                    XmlNode root = xmldoc.GetElementsByTagName("UserData")[0];
                    XmlElement node = xmldoc.CreateElement("add");
                    foreach (PropertyInfo p in pinfo)
                    {
                        string value = "";
                        if (p.GetValue(t) != null)
                        {
                            value = p.GetValue(t).ToString();
                        }
                        XmlAttribute attr = xmldoc.CreateAttribute(p.Name.ToLower());
                        attr.Value = value;
                        node.Attributes.Append(attr);
                    }
                    root.AppendChild(node);
                }
                catch
                {
                    return false;
                }

                return true;
            }));
        }

        public override bool InsertEntities(IList<LoginEntity> list)
        {
            if (list == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                try
                {
                    foreach (LoginEntity entity in list)
                    {
                        InsertEntity(entity);
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }));
        }

        public override bool DeleteEntity(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                if (!IsExsitedSiteName(condition.sitename))
                {
                    return true;
                }
                try
                {
                    XmlNode root = xmldoc.GetElementsByTagName("UserData")[0];
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["sitename"].Value.ToString() == condition.sitename)
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }));
        }

        public override bool DeleteEntities(IList<LoginEntity> list)
        {
            return false;
        }

        public override bool UpdateEntity(LoginEntity t)
        {
            if (t == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                if (!IsExsitedSiteName(t.SITENAME))
                {
                    return false;
                }
                try
                {
                    PropertyInfo[] pinfo = typeof(LoginEntity).GetProperties();
                    XmlNode root = xmldoc.GetElementsByTagName("UserData")[0];
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["sitename"].Value.ToString() == t.SITENAME)
                        {
                            foreach (PropertyInfo p in pinfo)
                            {
                                string value = "";
                                if (p.GetValue(t) != null)
                                {
                                    value = p.GetValue(t).ToString();
                                }
                                node.Attributes[p.Name.ToLower()].Value = value;
                            }
                            break;
                        }
                    }
                }
                catch
                {
                    return false;
                }

                return true;
            }));
        }

        public override bool UpdateEntities(IList<LoginEntity> list)
        {
            if (list == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                try
                {
                    foreach (LoginEntity entity in list)
                    {
                        UpdateEntity(entity);
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }));
        }

        #region 判断是否存在该网站名称的数据
        /// <summary>
        /// 判断是否存在该网站名称的数据
        /// </summary>
        /// <param name="sitename"></param>
        /// <returns></returns>
        private bool IsExsitedSiteName(string sitename)
        {
            dynamic condition = new ExpandoObject();
            condition.sitename = sitename;
            if (GetEntity(condition) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private LoginEntity ParseToEntity(XmlNode node)
        {
            LoginEntity entity = null;
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
    }
}
