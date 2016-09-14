using System;
using System.Windows.Forms;
using EPL;

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
            Open("CollectionList");
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
        
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string url = "https://www.baidu.com";
            string inputid = "kw";
            string content = BDText.Text.Trim();
            string submitid = "su";
            IBaiduSearch baidu = new IEBaiduSearch();
            baidu.Search(url, inputid, content, submitid);
        }

        private void 收藏站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("NewCollection");
        }

        private void 登录站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("NewSite");
        }

        private void NewCollectionSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("NewCollection");
        }

        private void NewLoginSiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Open("NewSite");
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open("CollectionList");
        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Open("LoginSiteList");
        }


    }
}
