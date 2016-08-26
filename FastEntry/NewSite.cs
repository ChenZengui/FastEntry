using FastEntry.Helper;
using FastEntry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            if (UserDataHelper.IsExsitedSiteName(entity.SITENAME))
            {
                issuccess = UserDataHelper.UpdateALine(entity);
            }
            else
            {
                issuccess = UserDataHelper.WriteALine(entity);
            }
            if (issuccess)
            {
                MessageBox.Show("保存成功");
                ScaleMain parent = (ScaleMain)this.Parent.Parent;
                parent.Open("Main");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
