using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace CustomLauncher
{
    public partial class DebugWiz : Form
    {
        public DebugWiz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DebugHost host = new DebugHost();
            String FrArgs = "";//初始化
            foreach (String ait in arge.CheckedItems)
            {
                FrArgs = FrArgs + ait + " ";//循环加入附加参数
            }
            host.DebugArgs = new Object[] {FrArgs };
            host.Show();
            host.button1_Click(null, null);//立即执行
            this.Close();
        }

        private void faamasa_CheckedChanged(object sender, EventArgs e)
        {
            if (fasa.Checked == true)
            {
                for (int i = 0; i < arge.Items.Count; i++)
                {
                    arge.SetItemChecked(i, true);//全选
                }
            }
            else
            {
                for (int i = 0; i < arge.Items.Count; i++)
                {
                    arge.SetItemChecked(i, false);//全不选
                }
            }
        }

        private void mesa_CheckedChanged(object sender, EventArgs e)
        {
            if (mesa.Checked == true)
            {
                for (int i = 0; i < mode.Items.Count; i++)
                {
                    mode.SetItemChecked(i, true);//全选
                }
            }
            else
            {
                for (int i = 0; i < mode.Items.Count; i++)
                {
                    mode.SetItemChecked(i, false);//全不选
                }
            }
        }

        private void DebugWiz_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\.minecraft\\mods"))
            {
                string[] modf = Directory.GetFiles(Application.StartupPath + "\\.minecraft\\mods");//加载已启用/禁用的mod
                for (int i = 0; i < modf.Length; i++)
                {
                    String tmp = modf[i].Replace(Application.StartupPath + "\\.minecraft\\mods\\", "").Replace(".jar", "").Replace("_disabled", "");//加载已启用/禁用的mod
                    mode.Items.Add(tmp);//加载已启用/禁用的mod
                    if (!modf[i].Contains("_disabled"))//加载已启用/禁用的mod
                    {
                        mode.SetItemChecked(i, true);//加载已启用/禁用的mod
                    }
                }
            }
        }

        private void mode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (!mode.GetItemChecked(e.Index))//如果勾选
                {
                    File.Move(Application.StartupPath + "\\.minecraft\\mods\\" + mode.Items[e.Index].ToString() + ".jar_disabled", Application.StartupPath + "\\.minecraft\\mods\\" + mode.Items[e.Index].ToString() + ".jar");//启用
                }
                else//否则
                {
                    File.Move(Application.StartupPath + "\\.minecraft\\mods\\" + mode.Items[e.Index].ToString() + ".jar", Application.StartupPath + "\\.minecraft\\mods\\" + mode.Items[e.Index].ToString() + ".jar_disabled");//禁用
                }
            }
            catch
            {

            }
        }

        private void Brs_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                genPath.Text = sfd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //启动
            LauncherReturn lr = new LauncherReturn();
            String FrArgs = "";//初始化
            foreach (String ait in arge.CheckedItems)
            {
                FrArgs = FrArgs + ait + " ";//循环加入附加参数
            }
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
            lr = launcher.Launch(TCfg[0], TCfg[1], TCfg[2], vers[m].Replace(Application.StartupPath + "\\.minecraft\\versions\\", ""),2, false, emca, FrArgs);//启动
            if (bat.Checked == true)//生成bat
            {
                File.WriteAllText(genPath.Text, "@echo off\r\nset appdata=\"" + Application.StartupPath + "\\.minecraft\"\r\n" + lr.rtv, Encoding.Default);
            }
            if (vbs.Checked == true) {//生成vbs
                File.WriteAllText(genPath.Text, "Set Wsl = CreateObject(\"Wscript.Shell\")\r\nWsl.Run \"" + lr.rtv.Replace("\"","\"\"") + "\"", Encoding.Default);
            }
        }
    }
}
