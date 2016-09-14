using Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Windows.Forms;
using UDP;
using EPL;

namespace FastEntry
{
    public partial class LoginSiteList : Form
    {
        public LoginSiteList()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
            if (treeWebsite.SelectedNode != null)
            {
                string sitename = this.treeWebsite.SelectedNode.Name;

                LoginEntity entity = new LoginEntity();
                dynamic condition = new ExpandoObject();
                condition.sitename = sitename;
                entity = loginentry.GetEntity(condition);

                Thread thread = new Thread(new ThreadStart(() => RunLogin(entity)));
                thread.Start();
            }
        }

        private void RunLogin(LoginEntity entity)
        {
            CommSiteLoginIEHelper login = new CommSiteLoginIEHelper();
            
            login.Login(entity);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WebsiteLoad();
            this.treeWebsite.ExpandAll();
        }

        public void WebsiteLoad()
        {
            LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
            dynamic condition = new ExpandoObject();
            condition.sitename = "";
            IList<LoginEntity> list = (List<LoginEntity>)loginentry.GetEntities(condition);

            if (list != null)
            {
                foreach (LoginEntity entity in list)
                {
                    TreeNode node = new TreeNode(entity.SITENAME);
                    node.Name = entity.SITENAME;
                    treeWebsite.Nodes[0].Nodes.Add(node);
                }
            }
        }

        private void treeWebsite_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sitename = this.treeWebsite.SelectedNode.Name;
            LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
            dynamic condition = new ExpandoObject();
            condition.sitename = sitename;
            LoginEntity entity = loginentry.GetEntity(condition);
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
            LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
            dynamic condition = new ExpandoObject();
            condition.sitename = sitename;
            bool issuccess = loginentry.DeleteEntity(condition);
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
                LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
                dynamic condition = new ExpandoObject();
                condition.sitename = treeWebsite.SelectedNode.Name;
                LoginEntity entity = loginentry.GetEntity(condition);
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
