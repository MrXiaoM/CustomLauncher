namespace CustomLauncher
{
    partial class DebugWiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWiz));
            this.button1 = new System.Windows.Forms.Button();
            this.arge = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mode = new System.Windows.Forms.CheckedListBox();
            this.fasa = new System.Windows.Forms.CheckBox();
            this.mesa = new System.Windows.Forms.CheckBox();
            this.genOp = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.genPath = new System.Windows.Forms.TextBox();
            this.bat = new System.Windows.Forms.RadioButton();
            this.vbs = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.Brs = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.genOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "调试游戏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // arge
            // 
            this.arge.CheckOnClick = true;
            this.arge.FormattingEnabled = true;
            this.arge.HorizontalScrollbar = true;
            this.arge.Items.AddRange(new object[] {
            "-Xincgc",
            "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.h" +
                "eapdump",
            "-XX:+UseG1GC",
            "-XX:-UseAdaptiveSizePolicy",
            "-XX:-OmitStackTraceInFastThrow",
            "-XX:+HeapDumpOnOutOfMemoryError",
            "-Xint",
            "-Xdiag",
            "-Xnoclassgc",
            "-Xbatch",
            "-Xprof",
            "-Xfuture",
            "-Xrs",
            "-Xcheck:jni",
            "-Xshare:auto",
            "-Xshare:on",
            "-Xshare:off"});
            this.arge.Location = new System.Drawing.Point(12, 38);
            this.arge.Name = "arge";
            this.arge.Size = new System.Drawing.Size(207, 132);
            this.arge.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "将加入的附加参数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(229, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "启用的mod";
            // 
            // mode
            // 
            this.mode.CheckOnClick = true;
            this.mode.FormattingEnabled = true;
            this.mode.HorizontalScrollbar = true;
            this.mode.Location = new System.Drawing.Point(225, 38);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(207, 132);
            this.mode.TabIndex = 4;
            this.mode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.mode_ItemCheck);
            // 
            // fasa
            // 
            this.fasa.AutoSize = true;
            this.fasa.Location = new System.Drawing.Point(13, 177);
            this.fasa.Name = "fasa";
            this.fasa.Size = new System.Drawing.Size(48, 16);
            this.fasa.TabIndex = 5;
            this.fasa.Text = "全选";
            this.fasa.UseVisualStyleBackColor = true;
            this.fasa.CheckedChanged += new System.EventHandler(this.faamasa_CheckedChanged);
            // 
            // mesa
            // 
            this.mesa.AutoSize = true;
            this.mesa.Location = new System.Drawing.Point(225, 177);
            this.mesa.Name = "mesa";
            this.mesa.Size = new System.Drawing.Size(48, 16);
            this.mesa.TabIndex = 6;
            this.mesa.Text = "全选";
            this.mesa.UseVisualStyleBackColor = true;
            this.mesa.CheckedChanged += new System.EventHandler(this.mesa_CheckedChanged);
            // 
            // genOp
            // 
            this.genOp.Controls.Add(this.Brs);
            this.genOp.Controls.Add(this.button2);
            this.genOp.Controls.Add(this.vbs);
            this.genOp.Controls.Add(this.bat);
            this.genOp.Controls.Add(this.genPath);
            this.genOp.Controls.Add(this.label3);
            this.genOp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genOp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.genOp.Location = new System.Drawing.Point(13, 210);
            this.genOp.Name = "genOp";
            this.genOp.Size = new System.Drawing.Size(419, 137);
            this.genOp.TabIndex = 7;
            this.genOp.TabStop = false;
            this.genOp.Text = "生成到外部文件启动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "路径：";
            // 
            // genPath
            // 
            this.genPath.Location = new System.Drawing.Point(62, 20);
            this.genPath.Name = "genPath";
            this.genPath.Size = new System.Drawing.Size(307, 23);
            this.genPath.TabIndex = 1;
            // 
            // bat
            // 
            this.bat.AutoSize = true;
            this.bat.Checked = true;
            this.bat.Location = new System.Drawing.Point(10, 53);
            this.bat.Name = "bat";
            this.bat.Size = new System.Drawing.Size(214, 18);
            this.bat.TabIndex = 2;
            this.bat.TabStop = true;
            this.bat.Text = "Windows命令提示符批处理文件";
            this.bat.UseVisualStyleBackColor = true;
            // 
            // vbs
            // 
            this.vbs.AutoSize = true;
            this.vbs.Location = new System.Drawing.Point(10, 78);
            this.vbs.Name = "vbs";
            this.vbs.Size = new System.Drawing.Size(186, 18);
            this.vbs.TabIndex = 3;
            this.vbs.Text = "Visual Basic Script脚本";
            this.vbs.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Brs
            // 
            this.Brs.Location = new System.Drawing.Point(375, 19);
            this.Brs.Name = "Brs";
            this.Brs.Size = new System.Drawing.Size(37, 23);
            this.Brs.TabIndex = 5;
            this.Brs.Text = "...";
            this.Brs.UseVisualStyleBackColor = true;
            this.Brs.Click += new System.EventHandler(this.Brs_Click);
            // 
            // sfd
            // 
            this.sfd.Filter = "所有文件(*.*)|*.*|支持的文件(*.bat,*.vbs)|*.bat;*.vbs";
            this.sfd.Title = "生成为";
            // 
            // DebugWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 599);
            this.Controls.Add(this.genOp);
            this.Controls.Add(this.mesa);
            this.Controls.Add(this.fasa);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arge);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugWiz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "调试模式向导";
            this.Load += new System.EventHandler(this.DebugWiz_Load);
            this.genOp.ResumeLayout(false);
            this.genOp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox arge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox mode;
        private System.Windows.Forms.CheckBox fasa;
        private System.Windows.Forms.CheckBox mesa;
        private System.Windows.Forms.GroupBox genOp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton vbs;
        private System.Windows.Forms.RadioButton bat;
        private System.Windows.Forms.TextBox genPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Brs;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}