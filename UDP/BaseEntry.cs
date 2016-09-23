using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Xml;

namespace UDP
{
    public abstract class BaseEntry<T> where T:class,new()
    {
        protected delegate dynamic ManipulateXMLDelegate(XmlDocument xml);
        private string sourcePath = "";
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
        public BaseEntry(string path)
        {
            this.sourcePath = path;
        }

        public string Path {
            get { return sourcePath; }
            set { sourcePath = value; }
        }

        /// <summary>
        /// 通用的打开
        /// </summary>
        /// <param name="_delegate"></param>
        /// <returns></returns>
        protected object Exe(ManipulateXMLDelegate _delegate)
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

        #region 判断是否存在该网站名称的数据
        /// <summary>
        /// 判断是否存在该网站名称的数据
        /// </summary>
        /// <param name="sitename"></param>
        /// <returns></returns>
        protected bool IsExsitedSiteName(string sitename)
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

        protected T ParseToEntity<T>(XmlNode node)
        {
            T entity = default(T);
            if (node != null)
            {
                PropertyInfo[] pinfo = typeof(T).GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    XmlAttribute attr = node.Attributes[p.Name.ToLower()];
                    if (attr != null)
                    {
                        if (entity == null)
                        {
                            entity = System.Activator.CreateInstance<T>(); ;
                        }
                        p.SetValue(entity, attr.Value.ToString());
                    }
                }
            }

            return entity;

        }


        public virtual T GetEntity(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return default(T);
            }
            return (T)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                XmlNode root = xmldoc.GetElementsByTagName("Data")[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["sitename"].Value.ToString() == condition.sitename)
                    {
                        return ParseToEntity<T>(node);
                    }
                }
                return null;
            }));
        }

        public virtual IList<T> GetEntities(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return null;
            }
            return (IList<T>)Exe(new ManipulateXMLDelegate((XmlDocument xmldoc) =>
            {
                IList<T> list = new List<T>();
                XmlNode root = xmldoc.GetElementsByTagName("Data")[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["sitename"].Value.ToString().Contains(condition.sitename))
                    {
                        list.Add(ParseToEntity<T>(node));
                    }
                }
                return list;
            }));
        }

        public virtual bool InsertEntity(dynamic entity)
        {
            if (entity == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                if (IsExsitedSiteName(entity.SITENAME))
                {
                    return false;
                }
                try
                {
                    PropertyInfo[] pinfo = entity.GetType().GetProperties();
                    XmlNode root = xmldoc.GetElementsByTagName("Data")[0];
                    XmlElement node = xmldoc.CreateElement("add");
                    foreach (PropertyInfo p in pinfo)
                    {
                        string value = "";
                        if (p.GetValue(entity) != null)
                        {
                            value = p.GetValue(entity).ToString();
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

        public virtual bool InsertEntities(IList<T> list)
        {
            if (list == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                try
                {
                    foreach (T entity in list)
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

        public virtual bool DeleteEntity(dynamic condition)
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
                    XmlNode root = xmldoc.GetElementsByTagName("Data")[0];
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

        public virtual bool DeleteEntities(IList<T> list)
        {
            return false;
        }

        public virtual bool UpdateEntity(dynamic entity)
        {
            if (entity == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                if (!IsExsitedSiteName(entity.SITENAME))
                {
                    return false;
                }
                try
                {
                    PropertyInfo[] pinfo = typeof(T).GetProperties();
                    XmlNode root = xmldoc.GetElementsByTagName("Data")[0];
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
                }
                catch
                {
                    return false;
                }

                return true;
            }));
        }

        public virtual bool UpdateEntities(IList<T> list)
        {
            if (list == null)
            {
                return false;
            }
            return (bool)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                try
                {
                    foreach (T entity in list)
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
    }
}
