namespace CustomLauncher
{
    partial class ExForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.eb = new System.Windows.Forms.Label();
            this.mb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Controls.Add(this.eb);
            this.panel1.Controls.Add(this.mb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 22);
            this.panel1.TabIndex = 0;
            // 
            // eb
            // 
            this.eb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eb.BackColor = System.Drawing.Color.Red;
            this.eb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.eb.ForeColor = System.Drawing.Color.White;
            this.eb.Location = new System.Drawing.Point(443, 0);
            this.eb.Name = "eb";
            this.eb.Size = new System.Drawing.Size(20, 20);
            this.eb.TabIndex = 1;
            this.eb.Text = "×";
            this.eb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eb.Click += new System.EventHandler(this.eb_Click);
            this.eb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.eb_MouseDown);
            this.eb.MouseEnter += new System.EventHandler(this.eb_MouseEnter);
            this.eb.MouseLeave += new System.EventHandler(this.eb_MouseLeave);
            // 
            // mb
            // 
            this.mb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.mb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mb.ForeColor = System.Drawing.Color.White;
            this.mb.Location = new System.Drawing.Point(422, 0);
            this.mb.Name = "mb";
            this.mb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mb.Size = new System.Drawing.Size(20, 20);
            this.mb.TabIndex = 1;
            this.mb.Text = "_";
            this.mb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mb.Click += new System.EventHandler(this.mb_Click);
            this.mb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mb_MouseDown);
            this.mb.MouseEnter += new System.EventHandler(this.mb_MouseEnter);
            this.mb.MouseLeave += new System.EventHandler(this.mb_MouseLeave);
            this.mb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mb_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewMouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewMouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewMouseUp);
            // 
            // ExForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(463, 336);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label eb;
        private System.Windows.Forms.Label mb;
    }
}