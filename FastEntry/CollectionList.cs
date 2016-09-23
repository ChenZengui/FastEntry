using Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using UDP;
using EPL;
using System.Threading;

namespace FastEntry
{
    public partial class CollectionList : Form
    {
        public delegate void InvokMinilizeForm();
        public CollectionList()
        {
            InitializeComponent();
            Bind();
        }

        public void Bind()
        {
            SiteCollectionDataEntry entry = (SiteCollectionDataEntry)EntryFactory.Create(DataType.SiteCollection);
            dynamic condition = new ExpandoObject();
            condition.sitename = "";
            IList<SiteCollectionEntity> list = (List<SiteCollectionEntity>)entry.GetEntities(condition);
            list = list.OrderByDescending(p => p.CLICKCOUNT).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_OpenURLClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].GetType() != typeof(DataGridViewLinkColumn))
            {
                return;
            }

            string url = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            IList<SiteCollectionEntity> list = (IList<SiteCollectionEntity>)this.dataGridView1.DataSource;
            SiteCollectionEntity entity = list.First(p => p.SITENAME == this.dataGridView1.Rows[e.RowIndex].Cells["SITENAME"].Value.ToString());
            Thread thread = new Thread(() => OpenALink(entity));
            thread.Start();
        }

        private void dataGridView1_ModifyClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            string bottontext = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            switch (bottontext)
            {
                case "修改":
                    {
                        IList<SiteCollectionEntity> list = (IList<SiteCollectionEntity>)this.dataGridView1.DataSource;
                        SiteCollectionEntity entity = list.First(p => p.SITENAME == this.dataGridView1.Rows[e.RowIndex].Cells["SITENAME"].Value.ToString());
                        ScaleMain parent = (ScaleMain)this.Parent.Parent;
                        if (entity != null)
                        {
                            parent.Open("NewCollection", entity);
                            this.Close();
                        }
                    }
                    break;
            }
        }

        private void OpenALink(SiteCollectionEntity entity)
        {            
            if (entity == null)
            {
                return;
            }

            //增加点击量
            entity.CLICKCOUNT = (Int32.Parse(entity.CLICKCOUNT) + 1).ToString();
            SiteCollectionDataEntry entry = (SiteCollectionDataEntry)EntryFactory.Create(DataType.SiteCollection);
            dynamic condition = new System.Dynamic.ExpandoObject();
            condition.sitename = entity.SITENAME;
            entry.UpdateEntity(entity);

            Invoke(new InvokMinilizeForm(delegate()
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }));

            IExplorerOpen open = new CommSiteOpenIEHelper();
            
            open.OpenLink(entity.URL);
        }
    }
}
