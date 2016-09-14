using Model;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using UDP;

namespace FastEntry
{
    public partial class NewSite : Form
    {
        public NewSite()
        {
            InitializeComponent();
        }

        public NewSite(LoginEntity entity)
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
            LoginEntity entity = new LoginEntity();
            PropertyInfo[] pinfo = entity.GetType().GetProperties();
            foreach(PropertyInfo p in pinfo)
            {
                Control[] controllist = this.Controls.Find(p.Name, true);
                if (controllist != null && controllist.Count() > 0)
                {
                    TextBox t = controllist[0] as TextBox;
                    p.SetValue(entity, t.Text);
                }
            }
            bool issuccess=false;
            LoginDataEntry loginentry = (LoginDataEntry)EntryFactory.Create(DataType.Login);
            dynamic condition = new System.Dynamic.ExpandoObject();
            condition.sitename = entity.SITENAME;
            if (loginentry.GetEntity(condition) != null)
            {
                issuccess = loginentry.UpdateEntity(entity);
            }
            else
            {
                issuccess = loginentry.InsertEntity(entity);
            }
            if (issuccess)
            {
                MessageBox.Show("保存成功");
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                parent.Open("LoginSiteList");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
