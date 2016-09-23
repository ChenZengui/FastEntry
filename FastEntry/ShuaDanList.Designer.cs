namespace FastEntry
{
    partial class ShuaDanList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("网站");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblname = new System.Windows.Forms.Label();
            this.sitename = new System.Windows.Forms.Label();
            this.lblurl = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.Label();
            this.Begin = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "site";
            treeNode1.Text = "网站";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(121, 250);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(142, 13);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(65, 12);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "网站名称：";
            // 
            // sitename
            // 
            this.sitename.AutoSize = true;
            this.sitename.Location = new System.Drawing.Point(213, 13);
            this.sitename.Name = "sitename";
            this.sitename.Size = new System.Drawing.Size(0, 12);
            this.sitename.TabIndex = 2;
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Location = new System.Drawing.Point(142, 57);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(35, 12);
            this.lblurl.TabIndex = 3;
            this.lblurl.Text = "url：";
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Location = new System.Drawing.Point(178, 57);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(0, 12);
            this.url.TabIndex = 4;
            // 
            // Begin
            // 
            this.Begin.Location = new System.Drawing.Point(144, 115);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(75, 23);
            this.Begin.TabIndex = 5;
            this.Begin.Text = "刷单";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Begin_Click);
            // 
            // Modify
            // 
            this.Modify.Location = new System.Drawing.Point(144, 171);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(75, 23);
            this.Modify.TabIndex = 6;
            this.Modify.Text = "修改选中";
            this.Modify.UseVisualStyleBackColor = true;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(275, 171);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "删除选中";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ShuaDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 250);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.Begin);
            this.Controls.Add(this.url);
            this.Controls.Add(this.lblurl);
            this.Controls.Add(this.sitename);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShuaDan";
            this.Text = "ShuaDan";
            this.Load += new System.EventHandler(this.ShuaDan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label sitename;
        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Delete;
    }
}