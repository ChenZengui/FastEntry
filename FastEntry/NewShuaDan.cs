using Model;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using UDP;

namespace FastEntry
{
    public partial class NewShuaDan : Form
    {
        public NewShuaDan()
        {
            InitializeComponent();
        }

        public NewShuaDan(ShuaDanEntity entity)
        {
            InitializeComponent();
            if (entity != null)
            {
                PropertyInfo[] pinfo = entity.GetType().GetProperties();
                foreach (PropertyInfo p in pinfo)
                {
                    Control[] controllist = this.Controls.Find(p.Name, true);
                    if (controllist != null && controllist.Count() > 0)
                    {
                        TextBox t = controllist[0] as TextBox;
                        t.Text = p.GetValue(entity).ToString();
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ShuaDanEntity entity = new ShuaDanEntity();
            PropertyInfo[] pinfo = entity.GetType().GetProperties();
            foreach (PropertyInfo p in pinfo)
            {
                Control[] controllist = this.Controls.Find(p.Name, true);
                if (controllist != null && controllist.Count() > 0)
                {
                    TextBox t = controllist[0] as TextBox;
                    p.SetValue(entity, t.Text);
                }
            }
            bool issuccess = false;
            ShuaDanDataEntry entry = (ShuaDanDataEntry)EntryFactory.Create(DataType.ShuaDan);
            dynamic condition = new System.Dynamic.ExpandoObject();
            condition.sitename = entity.SITENAME;
            if (entry.GetEntity(condition) != null)
            {
                issuccess = entry.UpdateEntity(entity);
            }
            else
            {
                issuccess = entry.InsertEntity(entity);
            }
            if (issuccess)
            {
                MessageBox.Show("保存成功");
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                parent.Open("ShuaDanList");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
