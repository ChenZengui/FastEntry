using FastEntry.Action;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastEntry
{
    public partial class ScaleMain : Form
    {
        public ScaleMain()
        {
            InitializeComponent();
        }

        private void ScaleMain_Load(object sender, EventArgs e)
        {
            Open("Main");
        }

        public void Open(string window, params object[] arg)
        {
            foreach (Control c in this.panel1.Controls)
            {
                this.panel1.Controls.Remove(c);
            }
            Form form = (Form)Activator.CreateInstance(Type.GetType("FastEntry." + window), arg);
            form.MdiParent = this;
            form.Parent = this.panel1;
            form.Show();
            this.panel1.Update();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("NewSite");
        }

        private void 网站登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("Main");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.baidu.com";
            string inputid = "kw";
            string content = BDText.Text.Trim();
            string submitid = "su";
            BaiduSearch baidu = new BaiduSearch();
            baidu.Search(url, inputid, content, submitid);
        }
    }
}
