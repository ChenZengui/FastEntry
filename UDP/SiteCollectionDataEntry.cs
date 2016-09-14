using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Xml;
using System.Reflection;
using System.Dynamic;

namespace UDP
{
    public class SiteCollectionDataEntry : BaseEntry<SiteCollectionEntity>
    {
        private delegate dynamic ManipulateXMLDelegate(XmlDocument xml);

        public SiteCollectionDataEntry(string path)
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

        public override SiteCollectionEntity GetEntity(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return null;
            }
            return (SiteCollectionEntity)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                XmlNode root = xmldoc.GetElementsByTagName("SiteCollection")[0];
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

        public override IList<SiteCollectionEntity> GetEntities(dynamic condition)
        {
            if (condition.sitename == null)
            {
                return null;
            }
            return (IList<SiteCollectionEntity>)Exe(new ManipulateXMLDelegate(delegate(XmlDocument xmldoc)
            {
                IList<SiteCollectionEntity> list = new List<SiteCollectionEntity>();
                XmlNode root = xmldoc.GetElementsByTagName("SiteCollection")[0];
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

        public override bool InsertEntity(SiteCollectionEntity entity)
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
                    XmlNode root = xmldoc.GetElementsByTagName("SiteCollection")[0];
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

        public override bool InsertEntities(IList<SiteCollectionEntity> list)
        {
            return false;
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
                    return false;
                }
                try
                {
                    XmlNode root = xmldoc.GetElementsByTagName("SiteCollection")[0];
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

        public override bool DeleteEntities(IList<SiteCollectionEntity> list)
        {
            return false;
        }

        public override bool UpdateEntity(SiteCollectionEntity entity)
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
                    PropertyInfo[] pinfo = typeof(SiteCollectionEntity).GetProperties();
                    XmlNode root = xmldoc.GetElementsByTagName("SiteCollection")[0];
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

        public override bool UpdateEntities(IList<SiteCollectionEntity> list)
        {
            return false;
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

        private SiteCollectionEntity ParseToEntity(XmlNode node)
        {
            SiteCollectionEntity entity = null;
            if (node != null)
            {
                PropertyInfo[] pinfo = typeof(SiteCollectionEntity).GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    XmlAttribute attr = node.Attributes[p.Name.ToLower()];
                    if (attr != null)
                    {
                        if (entity == null)
                        {
                            entity = new SiteCollectionEntity();
                        }
                        p.SetValue(entity, attr.Value);
                    }
                }
            }

            return entity;

        }
    }
}
