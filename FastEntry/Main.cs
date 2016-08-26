using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using FastEntry.Model;
using FastEntry.Action;
using System.Xml;
using System.IO;
using FastEntry.Helper;

namespace FastEntry
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if(treeWebsite.SelectedNode!=null)
            { 
                string sitename = this.treeWebsite.SelectedNode.Name;

                LoginEntity entity = new LoginEntity();
                entity = UserDataHelper.GetEntityBySiteName(sitename);
                CommonLogin login = new CommonLogin();
                login.Login(entity);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WebsiteLoad();
            this.treeWebsite.ExpandAll();
        }

        public void WebsiteLoad()
        {
            XmlDocument xml = new XmlDocument();
            string xmlpath = Application.StartupPath + "\\" + ConfigurationManager.AppSettings["UserDataXMLPath"].ToString();
            xml.Load(xmlpath);
            XmlNodeList xe = xml.GetElementsByTagName("UserData");
            foreach (XmlNode x in xe[0].ChildNodes)
            {
                TreeNode node = new TreeNode(x.Attributes["sitename"].Value);
                node.Name = x.Attributes["sitename"].Value;
                treeWebsite.Nodes[0].Nodes.Add(node);
            }
        }

        private void treeWebsite_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sitename = this.treeWebsite.SelectedNode.Name;
            LoginEntity entity = new LoginEntity();
            entity = UserDataHelper.GetEntityBySiteName(sitename);
            if (entity != null)
            {
                UserName.Text = entity.USERNAME;
                Password.Text = entity.PASSWORD;
            }
        }
        
        private void Delete_Click(object sender, EventArgs e)
        {
            if (treeWebsite.SelectedNode != null)
            {
                RemoveItem(treeWebsite.SelectedNode.Name);
            }
        }

        public void RemoveItem(string sitename)
        {
            bool issuccess = UserDataHelper.RemoveItem(sitename);
            if (issuccess)
            {
                MessageBox.Show("删除成功");
                treeWebsite.Nodes[0].Nodes[sitename].Remove();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void ModifyItem_Click(object sender, EventArgs e)
        {
            if (treeWebsite.SelectedNode.Level != 0)
            {
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                LoginEntity entity = UserDataHelper.GetEntityBySiteName(treeWebsite.SelectedNode.Name);
                if (entity != null)
                {
                    parent.Open("NewSite", entity);
                    this.Close();
                }
            }
        }

        private void PwdShow_CheckedChanged(object sender, EventArgs e)
        {
            this.Password.UseSystemPasswordChar = !this.Password.UseSystemPasswordChar;
        }
    }
}
