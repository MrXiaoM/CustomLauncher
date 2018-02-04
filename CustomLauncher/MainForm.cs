using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;

namespace CustomLauncher
{
    public partial class MainForm : ExForm
    {
        public WMPLib.WindowsMediaPlayer bgmusic;//声明音乐播放器变量
        public MainForm()
        {
            InitializeComponent();
            if (!File.Exists(Path.GetTempPath() + "\\mlbgm.mp3"))
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();//释放bgmusic.mp3部分
                Stream stream = assembly.GetManifestResourceStream("CustomLauncher.bgmusic.mp3");//释放bgmusic.mp3部分
                byte[] bytes = new byte[stream.Length];//释放bgmusic.mp3部分
                stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));//释放bgmusic.mp3部分
                File.WriteAllBytes(Path.GetTempPath() + "\\mlbgm.mp3", bytes);//释放bgmusic.mp3部分
                stream.Close();
            }
            bgmusic = new WMPLib.WindowsMediaPlayer();//给音乐播放器变量赋值
            bgmusic.URL = Path.GetTempPath() + "\\mlbgm.mp3";//在此输入背景音乐(.mp3)所在的路径
            bgmusic.settings.volume = 50;//设置音量
            bgmusic.settings.autoStart = true;//开启自动播放
            bgmusic.settings.setMode("loop", true);
            settings1.LoadForm();
            Control.CheckForIllegalCrossThreadCalls = false;
            if (ini_Read(配置节, "Username") == string.Empty)//如果用户名为空字符
            {
                button2_Click(null, null);//打开设置
            }
            try
            {
                //读取版本
                listBox1.Items.Clear();
                String[] vers = Directory.GetDirectories(Application.StartupPath + "\\.minecraft\\versions");
                for (int i = 0; i < vers.Length; i++)
                {
                    listBox1.Items.Add(vers[i].Replace(Application.StartupPath + "\\.minecraft\\versions\\", ""));
                    if (File.Exists(vers[i] + "\\JLSelVer.sym"))
                    {
                        listBox1.SelectedIndex = i;
                        File.Delete(vers[i] + "\\JLSelVer.sym");
                    }
                }
            }
            catch (Exception)
            {

            }
            if (listBox1.Items.Count == 0)
            {
                //MessageBox.Show(
                     //"没有找到版本哦~~\n是否前往下载版本？",
                     //"提示",
                     //MessageBoxButtons.YesNo,
                     //MessageBoxIcon.Exclamation);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowSetting.Enabled = true;//打开设置
        }
        #region ini读写前置
        public string 配置节 = "MLauncher";
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion
        #region 读Ini文件
        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="Section">节</param>
        /// <param name="Key">键</param>
        /// <returns>读取完成的内容</returns>
        public string ini_Read(string Section, string Key)
        {
            string NoText = "";
            if (File.Exists(Application.StartupPath + "\\.minecraft\\mlauncher.mc"))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, Application.StartupPath + "\\config.ini");
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion
        #region 写Ini文件
        /// <summary>
        /// 写或修改ini文件
        /// </summary>
        /// <param name="Section">节</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        /// <returns>是否写入成功</returns>
        public bool ini_Write(string Section, string Key, string Value)
        {
            if (File.Exists(Application.StartupPath + "\\.minecraft\\mlauncher.mc"))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, Application.StartupPath + "\\config.ini");
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            //启动
            Launcher launcher = new Launcher();
            if (listBox1.SelectedIndex == -1)//如果没有选择版本
            {
                listBox1.SelectedIndex = 0;//自动给你选择
            }
            String emca = "";//以下是后置参数加载部分
            if (ini_Read(配置节, "Fullscreen") == "true")
            {
                emca = emca + " --fullscreen";
            }
            if (ini_Read(配置节, "Demo") == "true")
            {
                emca = emca + " --demo";
            }
            if (ini_Read(配置节, "Width") != "")
            {
                emca = emca + " --width " + ini_Read(配置节, "Width");
            }
            if (ini_Read(配置节, "Height") != "")
            {
                emca = emca + " --height " + ini_Read(配置节, "Height");
            }/*
            if (ini_Read(配置节, "Auto_Join_Server_IP").IndexOf(":") != -1)//直入地址服务器
            {
                emca = emca + " --server " + TCfg[10].Split(":".ToCharArray())[0] + " --port " + TCfg[10].Split(":".ToCharArray())[1];
            }*/
            launcher.Launch(//启动游戏
                ini_Read(配置节, "MaximumMemory"),//最大内存
                ini_Read(配置节, "JavaPath"),//Javaw.exe路径
                ini_Read(配置节, "Username"),//用户名
                listBox1.SelectedItem.ToString(),//选择的版本名称
                0, false, emca);//参数
        }
        #region 按钮动画
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DarkBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepSkyBlue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightBlue;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkBlue;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DeepSkyBlue;
        }

        private void shbar_Click(object sender, EventArgs e)
        {
            if (shbar.Text == ">")
            {
                listBox1.Width = 130;
                shbar.Text = "<";
                shbar.Left = 130;
            }
            else
            {
                listBox1.Width = 0;
                shbar.Text = ">";
                shbar.Left = 0;
            }
        }

        private void shbar_MouseEnter(object sender, EventArgs e)
        {
            shbar.BackColor = Color.FromArgb(253, 244, 83);
        }

        private void shbar_MouseDown(object sender, MouseEventArgs e)
        {
            shbar.BackColor = Color.FromArgb(231, 219, 3);
        }

        private void shbar_MouseUp(object sender, MouseEventArgs e)
        {
            shbar.BackColor = Color.FromArgb(253, 244, 83);
        }

        private void shbar_MouseLeave(object sender, EventArgs e)
        {
            shbar.BackColor = Color.Yellow;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DeepSkyBlue;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightBlue;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DarkBlue;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DeepSkyBlue;
        }

        bool mdd = false;
        int w_x = 0;
        int w_y = 0;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mdd = true;
            w_x = e.X;
            w_y = e.Y;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mdd = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdd == true)
            {
                this.Left = this.Left + e.X - w_x;
                this.Top = this.Top + e.Y - w_y;
            }
        }
        #endregion
        public void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //存储选择的版本
            try
            {
                if (listBox1.SelectedIndex != -1)
                {//不为空
                    File.CreateText(Application.StartupPath + "\\.minecraft\\versions\\" + listBox1.SelectedItem + "\\JLSelVer.sym").Close();
                }
            }
            catch
            {

            }
        }

        private void 调试模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugWiz dWiz = new DebugWiz();
            MainForm_FormClosed(sender, null);
            dWiz.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            /* 卸载设置面板移动 */
            this.settings1.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.settings1.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.settings1.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            设置关闭.Visible = false;//隐藏关闭按钮
            保存.Visible = false;//隐藏保存按钮
            HideSetting.Enabled = true;//开始隐藏设置
        }

        public void 保存配置()
        {
            ini_Write(配置节, "MaximumMemory", settings1.mm.Text);
            ini_Write(配置节, "Username", settings1.un.Text);
            ini_Write(配置节, "JavaPath", settings1.jp.Text);
            if (settings1.checkBox1.Checked == true)
            {
                ini_Write(配置节, "OnlineMode", "true");
            }
            else
            {
                ini_Write(配置节, "OnlineMode", "false");
            }
            ini_Write(配置节, "Online-Email", settings1.Email.Text);
            ini_Write(配置节, "Online-Password(encrypted)", settings1.EncryptStr(settings1.password.Text, true));
            if (settings1.checkBox2.Checked == true)
            {
                ini_Write(配置节, "Fullscreen", "true");
            }
            else
            {
                ini_Write(配置节, "Fullscreen", "false");
            }
            if (settings1.checkBox3.Checked == true)
            {
                ini_Write(配置节, "Demo", "true");
            }
            else
            {
                ini_Write(配置节, "Demo", "false");
            }
            ini_Write(配置节, "Height", settings1.textBox2.Text);
            ini_Write(配置节, "Width", settings1.textBox1.Text);
        }

        private void ShowSetting_Tick(object sender, EventArgs e)
        {
            if (settings1.Location != new Point(0, 132))//如果没显示完毕
            {
                settings1.Location = new Point(0, settings1.Location.Y - 10);//继续显示
            }
            else//显示完毕后
            {
                设置关闭.Visible = true;//显示关闭按钮
                保存.Visible = true;//显示保存按钮
                ShowSetting.Enabled = false;//显示完毕
                /* 安装设置面板移动 */
                this.settings1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
                this.settings1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
                this.settings1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            }
        }

        private void HideSetting_Tick(object sender, EventArgs e)
        {
            if (settings1.Location != new Point(0, 532))//如果没隐藏完毕
            {
                settings1.Location = new Point(0, settings1.Location.Y + 10);//继续隐藏
            }
            else//隐藏完毕后
            {
                HideSetting.Enabled = false;//隐藏完毕
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            保存配置();
            /* 卸载设置面板移动 */
            this.settings1.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.settings1.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.settings1.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            设置关闭.Visible = false;
            保存.Visible = false;
            HideSetting.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DownloadGame dlg = new DownloadGame();
            dlg.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string ip = null;
            IPHostEntry iph = Dns.GetHostEntry("127.0.0.1");//<--IP
            foreach (IPAddress ip1 in iph.AddressList)
            {
                ip = ip1.ToString();
                break;
            }
            eMZi.Gaming.Minecraft.MinecraftServerInfo a = null;
            IPAddress c = null;
            c = IPAddress.Parse(ip);
            IPEndPoint b = new IPEndPoint(c, 25565);//<--端口
            //a = eMZi.Gaming.Minecraft.MinecraftServerInfo.GetServerInformation(b);//需要获取服务器信息的请把这行的注释去掉
            /*
                在线人数：   a.CurrentPlayerCount.ToString()
                最大人数：   a.MaxPlayerCount.ToString()
                服务器Motd:  a.ServerMotdHtml.ToString()
                版本：       a.MinecraftVersion.ToString
             */
        }
    }
}