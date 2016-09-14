namespace FastEntry
{
    partial class LoginSiteList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("网站");
            this.Login = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.treeWebsite = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.ModifyItem = new System.Windows.Forms.Button();
            this.PwdShow = new System.Windows.Forms.CheckBox();
            this.LoginPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(80, 104);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 0;
            this.Login.Text = "登录";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.AutoScroll = true;
            this.LoginPanel.Controls.Add(this.treeWebsite);
            this.LoginPanel.Controls.Add(this.panel1);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(412, 250);
            this.LoginPanel.TabIndex = 2;
            // 
            // treeWebsite
            // 
            this.treeWebsite.BackColor = System.Drawing.SystemColors.Control;
            this.treeWebsite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeWebsite.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeWebsite.Location = new System.Drawing.Point(3, 3);
            this.treeWebsite.Name = "treeWebsite";
            treeNode2.Name = "websites";
            treeNode2.Text = "网站";
            this.treeWebsite.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeWebsite.Size = new System.Drawing.Size(102, 221);
            this.treeWebsite.TabIndex = 1;
            this.treeWebsite.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeWebsite_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PwdShow);
            this.panel1.Controls.Add(this.ModifyItem);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Login);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserName);
            this.panel1.Location = new System.Drawing.Point(111, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 221);
            this.panel1.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(80, 51);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(201, 21);
            this.Password.TabIndex = 3;
            this.Password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(80, 14);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(201, 21);
            this.UserName.TabIndex = 0;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(206, 152);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "删除选中项";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ModifyItem
            // 
            this.ModifyItem.Location = new System.Drawing.Point(80, 152);
            this.ModifyItem.Name = "ModifyItem";
            this.ModifyItem.Size = new System.Drawing.Size(75, 23);
            this.ModifyItem.TabIndex = 7;
            this.ModifyItem.Text = "修改选中项";
            this.ModifyItem.UseVisualStyleBackColor = true;
            this.ModifyItem.Click += new System.EventHandler(this.ModifyItem_Click);
            // 
            // PwdShow
            // 
            this.PwdShow.AutoSize = true;
            this.PwdShow.Location = new System.Drawing.Point(80, 79);
            this.PwdShow.Name = "PwdShow";
            this.PwdShow.Size = new System.Drawing.Size(72, 16);
            this.PwdShow.TabIndex = 8;
            this.PwdShow.Text = "显示密码";
            this.PwdShow.UseVisualStyleBackColor = true;
            this.PwdShow.CheckedChanged += new System.EventHandler(this.PwdShow_CheckedChanged);
            // 
            // Main
            // 
            this.AcceptButton = this.Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(412, 237);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速登录";
            this.Load += new System.EventHandler(this.Main_Load);
            this.LoginPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.FlowLayoutPanel LoginPanel;
        private System.Windows.Forms.TreeView treeWebsite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button ModifyItem;
        private System.Windows.Forms.CheckBox PwdShow;
    }
}

