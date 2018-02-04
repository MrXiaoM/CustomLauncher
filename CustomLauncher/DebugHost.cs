using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CustomLauncher
{
    public partial class DebugHost : Form
    {
        public LauncherReturn lr;
        public delegate void DelReadStdOutput(string result);
        public event DelReadStdOutput ReadStdOutput;
        public Object[] DebugArgs;//初始化

        public DebugHost()
        {
            InitializeComponent();
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);//异步执行
        }

        public void button1_Click(object sender, EventArgs e)
        {
            DebugGame(DebugArgs);//调用
        }

        public void DebugGame(Object[] DebugOptions) { 
            
            //启动
            String[] TCfg = System.IO.File.ReadAllLines(Application.StartupPath + "\\JLConfig.JLConfig");//读取配置
            Launcher launcher = new Launcher();
            String emca = "";//以下是后置参数加载部分
            if (TCfg[6] == "1")
            {
                emca = emca + " --fullscreen";
            }
            if (TCfg[7] == "1")
            {
                emca = emca + " --demo";
            }
            if (TCfg[8] != "")
            {
                emca = emca + " --width " + TCfg[8];
            }
            if (TCfg[9] != "")
            {
                emca = emca + " --height " + TCfg[9];
            }
            if (TCfg[10].IndexOf(":") != -1)
            {
                emca = emca + " --server " + TCfg[10].Split(":".ToCharArray())[0] + " --port " + TCfg[10].Split(":".ToCharArray())[1];
            } 
            String[] vers = Directory.GetDirectories(Application.StartupPath + "\\.minecraft\\versions");//读取版本
            int m = 0;//读取版本
            for (int i = 0; i < vers.Length; i++)//读取版本
            {
                if (File.Exists(vers[i] + "\\JLSelVer.sym"))//读取版本
                {
                    m = i;//读取版本
                }
            }
            lr = launcher.Launch(TCfg[0], TCfg[1], TCfg[2], vers[m].Replace(Application.StartupPath + "\\.minecraft\\versions\\",""), 3, false, emca,DebugOptions[0].ToString());//启动
            if (lr.LP == null)
            {
                lr.LP = lr.sdd.plr.LP;//为空就用代存的值
            }
            lr.LP.OutputDataReceived += new DataReceivedEventHandler(this.onRD);//注册事件
            lr.LP.BeginOutputReadLine();//开始异步读写
        }

        public void onRD(object sender, DataReceivedEventArgs e)
        {
            this.Invoke(ReadStdOutput, new object[] { e.Data }); //异步读写
        }
        private void ReadStdOutputAction(string result)  
        {
            this.richTextBox1.Text = this.richTextBox1.Text + result + "\n";//异步读写
            richTextBox1.Select(richTextBox1.Text.Length, 0);//异步读写
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";//清空
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lr.LP.Kill();//结束进程（强制）
            }
            catch { }
        }
    }
}
