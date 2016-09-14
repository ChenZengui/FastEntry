using System;
using System.Linq;
using System.Windows.Forms;
using Model;
using System.Reflection;
using UDP;

namespace FastEntry
{
    public partial class NewCollection : Form
    {
        private SiteCollectionEntity entity = null;

        public SiteCollectionEntity SCEntity
        {
            get
            {
                if (entity == null)
                {
                    entity = new SiteCollectionEntity();
                }
                return entity;
            }
            set
            {
                entity = value;
            }
        }

        public NewCollection()
        {
            InitializeComponent();
        }

        public NewCollection(SiteCollectionEntity entity)
        {
            InitializeComponent();
            if (entity != null)
            {
                SCEntity = entity;
                PropertyInfo[] pinfo = SCEntity.GetType().GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    Control[] controllist = this.Controls.Find(p.Name, true);
                    if (controllist != null && controllist.Count() > 0)
                    {
                        TextBox t = controllist[0] as TextBox;
                        t.Text = p.GetValue(SCEntity).ToString();
                    }
                }
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            PropertyInfo[] pinfo = typeof(SiteCollectionEntity).GetProperties();
            
            foreach (PropertyInfo p in pinfo)
            {
                Control[] controllist = this.Controls.Find(p.Name, true);
                if (controllist != null && controllist.Count() > 0)
                {
                    TextBox t = controllist[0] as TextBox;
                    p.SetValue(SCEntity, t.Text);
                }
            }
            bool issuccess = false;
            SiteCollectionDataEntry entry = (SiteCollectionDataEntry)EntryFactory.Create(DataType.SiteCollection);
            dynamic condition = new System.Dynamic.ExpandoObject();
            condition.sitename = SCEntity.SITENAME;
            if (entry.GetEntity(condition) != null)
            {
                issuccess = entry.UpdateEntity(SCEntity);
            }
            else
            {
                issuccess = entry.InsertEntity(SCEntity);
            }
            if (issuccess)
            {
                MessageBox.Show("保存成功");
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                parent.Open("CollectionList");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
