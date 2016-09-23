namespace FastEntry
{
    partial class NewShuaDan
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
            this.label1 = new System.Windows.Forms.Label();
            this.sitename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.submitinputid = new System.Windows.Forms.TextBox();
            this.submitinputclass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "站名：";
            // 
            // sitename
            // 
            this.sitename.Location = new System.Drawing.Point(79, 6);
            this.sitename.Name = "sitename";
            this.sitename.Size = new System.Drawing.Size(161, 21);
            this.sitename.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "地址：";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(79, 47);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(308, 21);
            this.url.TabIndex = 3;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(34, 160);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "下单按钮ID：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "下单按钮class：";
            // 
            // submitinputid
            // 
            this.submitinputid.Location = new System.Drawing.Point(115, 80);
            this.submitinputid.Name = "submitinputid";
            this.submitinputid.Size = new System.Drawing.Size(161, 21);
            this.submitinputid.TabIndex = 7;
            // 
            // submitinputclass
            // 
            this.submitinputclass.Location = new System.Drawing.Point(133, 116);
            this.submitinputclass.Name = "submitinputclass";
            this.submitinputclass.Size = new System.Drawing.Size(161, 21);
            this.submitinputclass.TabIndex = 8;
            // 
            // NewShuaDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 250);
            this.Controls.Add(this.submitinputclass);
            this.Controls.Add(this.submitinputid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sitename);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewShuaDan";
            this.Text = "NewShuaDan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sitename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox submitinputid;
        private System.Windows.Forms.TextBox submitinputclass;
    }
}