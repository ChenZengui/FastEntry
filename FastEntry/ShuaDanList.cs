using EPL;
using Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Windows.Forms;
using UDP;

namespace FastEntry
{
    public partial class ShuaDanList : Form
    {
        public ShuaDanList()
        {
            InitializeComponent();
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            ShuaDanDataEntry entry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
            if (treeView1.SelectedNode != null)
            {
                string sitename = this.treeView1.SelectedNode.Name;

                ShuaDanEntity entity = new ShuaDanEntity();
                dynamic condition = new ExpandoObject();
                condition.sitename = sitename;
                entity = entry.GetEntity(condition);

                Thread thread = new Thread(new ThreadStart(() => RunShuaDan(entity)));
                thread.Start();
            }
        }

        private void RunShuaDan(ShuaDanEntity entity)
        {
            IExplorerShuaDan shuadan = new CommSiteShuaDanIEHelper();

            shuadan.BeginShuaDan(entity,2000,1);
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level != 0)
            {
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                ShuaDanDataEntry loginentry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
                dynamic condition = new ExpandoObject();
                condition.sitename = treeView1.SelectedNode.Name;
                ShuaDanEntity entity = loginentry.GetEntity(condition);
                if (entity != null)
                {
                    parent.Open("NewShuaDan", entity);
                    this.Close();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                RemoveItem(treeView1.SelectedNode.Name);
            }
        }

        public void RemoveItem(string sitename)
        {
            ShuaDanDataEntry loginentry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
            dynamic condition = new ExpandoObject();
            condition.sitename = sitename;
            bool issuccess = loginentry.DeleteEntity(condition);
            if (issuccess)
            {
                MessageBox.Show("删除成功");
                treeView1.Nodes[0].Nodes[sitename].Remove();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void ShuaDan_Load(object sender, EventArgs e)
        {
            WebsiteLoad();
            this.treeView1.ExpandAll();
        }

        public void WebsiteLoad()
        {
            ShuaDanDataEntry entry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
            dynamic condition = new ExpandoObject();
            condition.sitename = "";
            IList<ShuaDanEntity> list = (List<ShuaDanEntity>)entry.GetEntities(condition);

            if (list != null)
            {
                foreach (ShuaDanEntity entity in list)
                {
                    TreeNode node = new TreeNode(entity.SITENAME);
                    node.Name = entity.SITENAME;
                    this.treeView1.Nodes[0].Nodes.Add(node);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sitename = this.treeView1.SelectedNode.Name;
            ShuaDanDataEntry entry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
            dynamic condition = new ExpandoObject();
            condition.sitename = sitename;
            ShuaDanEntity entity = entry.GetEntity(condition);
            if (entity != null)
            {
                this.sitename.Text = entity.SITENAME;
                this.url.Text = entity.URL;
            }
        }
    }
}
