namespace CustomLauncher
{
    partial class DownloadGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadGame));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.GetClient = new System.Windows.Forms.Button();
            this.DownloadClient = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 24);
            this.tabControl1.MaximumSize = new System.Drawing.Size(600, 361);
            this.tabControl1.MinimumSize = new System.Drawing.Size(600, 361);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DownloadClient);
            this.tabPage1.Controls.Add(this.GetClient);
            this.tabPage1.Controls.Add(this.ClientList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "纯净版";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 12;
            this.ClientList.Location = new System.Drawing.Point(3, 3);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(504, 328);
            this.ClientList.TabIndex = 0;
            // 
            // GetClient
            // 
            this.GetClient.Location = new System.Drawing.Point(511, 5);
            this.GetClient.Name = "GetClient";
            this.GetClient.Size = new System.Drawing.Size(75, 23);
            this.GetClient.TabIndex = 1;
            this.GetClient.Text = "获取";
            this.GetClient.UseVisualStyleBackColor = true;
            this.GetClient.Click += new System.EventHandler(this.button1_Click);
            // 
            // DownloadClient
            // 
            this.DownloadClient.Location = new System.Drawing.Point(511, 34);
            this.DownloadClient.Name = "DownloadClient";
            this.DownloadClient.Size = new System.Drawing.Size(75, 23);
            this.DownloadClient.TabIndex = 2;
            this.DownloadClient.Text = "下载";
            this.DownloadClient.UseVisualStyleBackColor = true;
            this.DownloadClient.Click += new System.EventHandler(this.DownloadClient_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(592, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Forge、Liteloader、optifine下载即将推出";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "M酱正在开发中，敬请期待";
            // 
            // DownloadGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 383);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(602, 383);
            this.MinimumSize = new System.Drawing.Size(602, 383);
            this.Name = "DownloadGame";
            this.Text = "游戏下载";
            this.Title = "游戏下载 - 采用BMCLAPI";
            this.TitleIcon = ((System.Drawing.Image)(resources.GetObject("$this.TitleIcon")));
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button DownloadClient;
        private System.Windows.Forms.Button GetClient;
        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;

    }
}