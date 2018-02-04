namespace CustomLauncher
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Label();
            this.shbar = new System.Windows.Forms.Label();
            this.settings1 = new CustomLauncher.Settings();
            this.设置关闭 = new System.Windows.Forms.Label();
            this.ShowSetting = new System.Windows.Forms.Timer(this.components);
            this.HideSetting = new System.Windows.Forms.Timer(this.components);
            this.保存 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 132);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(10, 156);
            this.listBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(596, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "开始游戏";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(57, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "设置";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_MouseUp);
            // 
            // shbar
            // 
            this.shbar.BackColor = System.Drawing.Color.Yellow;
            this.shbar.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shbar.Location = new System.Drawing.Point(-2, 132);
            this.shbar.Name = "shbar";
            this.shbar.Size = new System.Drawing.Size(12, 156);
            this.shbar.TabIndex = 6;
            this.shbar.Text = ">";
            this.shbar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shbar.Click += new System.EventHandler(this.shbar_Click);
            this.shbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shbar_MouseDown);
            this.shbar.MouseEnter += new System.EventHandler(this.shbar_MouseEnter);
            this.shbar.MouseLeave += new System.EventHandler(this.shbar_MouseLeave);
            this.shbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shbar_MouseUp);
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.Transparent;
            this.settings1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settings1.BackgroundImage")));
            this.settings1.Location = new System.Drawing.Point(0, 532);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(797, 393);
            this.settings1.TabIndex = 7;
            // 
            // 设置关闭
            // 
            this.设置关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.设置关闭.BackColor = System.Drawing.Color.Transparent;
            this.设置关闭.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.设置关闭.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.设置关闭.Image = ((System.Drawing.Image)(resources.GetObject("设置关闭.Image")));
            this.设置关闭.Location = new System.Drawing.Point(357, 122);
            this.设置关闭.Name = "设置关闭";
            this.设置关闭.Size = new System.Drawing.Size(80, 10);
            this.设置关闭.TabIndex = 8;
            this.设置关闭.Text = "ˇ";
            this.设置关闭.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.设置关闭.Visible = false;
            this.设置关闭.Click += new System.EventHandler(this.label2_Click);
            // 
            // ShowSetting
            // 
            this.ShowSetting.Interval = 1;
            this.ShowSetting.Tick += new System.EventHandler(this.ShowSetting_Tick);
            // 
            // HideSetting
            // 
            this.HideSetting.Interval = 1;
            this.HideSetting.Tick += new System.EventHandler(this.HideSetting_Tick);
            // 
            // 保存
            // 
            this.保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.保存.BackColor = System.Drawing.Color.Transparent;
            this.保存.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.保存.ForeColor = System.Drawing.Color.White;
            this.保存.Image = ((System.Drawing.Image)(resources.GetObject("保存.Image")));
            this.保存.Location = new System.Drawing.Point(358, 379);
            this.保存.Name = "保存";
            this.保存.Size = new System.Drawing.Size(93, 31);
            this.保存.TabIndex = 9;
            this.保存.Text = "保存配置";
            this.保存.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.保存.Visible = false;
            this.保存.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button3.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(126, 447);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "游戏下载";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button3_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(724, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 66);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "服务器人数:null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "BGM:PayPhone 伴奏";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(797, 524);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.保存);
            this.Controls.Add(this.设置关闭);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.shbar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(797, 524);
            this.MinimumSize = new System.Drawing.Size(797, 524);
            this.Name = "MainForm";
            this.Text = "Minecraft启动器";
            this.Title = "MLauncher";
            this.TitleIcon = ((System.Drawing.Image)(resources.GetObject("$this.TitleIcon")));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            this.Controls.SetChildIndex(this.shbar, 0);
            this.Controls.SetChildIndex(this.settings1, 0);
            this.Controls.SetChildIndex(this.设置关闭, 0);
            this.Controls.SetChildIndex(this.保存, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label button2;
        private System.Windows.Forms.Label shbar;
        private Settings settings1;
        private System.Windows.Forms.Label 设置关闭;
        private System.Windows.Forms.Timer ShowSetting;
        private System.Windows.Forms.Timer HideSetting;
        private System.Windows.Forms.Label 保存;
        private System.Windows.Forms.Label button3;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Label button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

