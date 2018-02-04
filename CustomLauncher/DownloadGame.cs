using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace CustomLauncher
{
    public partial class DownloadGame : ExForm
    {
        public DownloadGame()
        {
            InitializeComponent();
        }
        WebClient wc = new WebClient();
        public String rtxt = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\tmp.json"))//如果临时文件存在
            {
                File.Delete(Application.StartupPath + "\\tmp.json");//删掉
            }
            wc.DownloadFile("https://launchermeta.mojang.com/mc/game/version_manifest.json", Application.StartupPath + "\\tmp.json");//下载版本列表文件
            rtxt = File.ReadAllText(Application.StartupPath + "\\tmp.json").Replace("\n", "").Replace(" ", "");//读取版本列表
            File.Delete(Application.StartupPath + "\\tmp.json");//删除临时文件
            int tmp = rtxt.IndexOf("versions") + "versions".Length + 3;//读取objects数组数据
            String versions_S = rtxt.Substring(tmp, rtxt.LastIndexOf("]", rtxt.Length - 1) - tmp);//同上
            String[] versions = versions_S.Replace("},{", "$").Split("$".ToCharArray());//分割数组
            String tmu = "";//声明并初始化tmu
            ClientList.Items.Clear();//清空列表
            foreach (String vi in versions)
            {//为每个项循环
                tmp = vi.IndexOf("id") + "id".Length + 3;//读取id
                tmu = vi.Substring(tmp, vi.IndexOf("\"", tmp) - tmp);//同上
                ClientList.Items.Add(tmu);//添加项
            }
        }

        private void DownloadClient_Click(object sender, EventArgs e)
        {
            if (ClientList.SelectedIndex == -1)
                return;
            else
            {
                string version = ClientList.SelectedItem.ToString();
                String vdp = Application.StartupPath + "\\.minecraft\\versions\\" + version;//处理下载目标路径
                List<String> cu = new List<string>();//声明下载列表
                cu.Add("https://bmclapi2.bangbang93.com/version/" + version + "/Client" + ":::" + vdp + "\\" + version + ".jar");//加入下载项
                cu.Add("https://bmclapi2.bangbang93.com/version/" + version + "/Client" + ":::" + vdp + "\\" + version + ".json");//加入下载项
                new ShowDownload().DownloadBL(cu, "restart");//执行下载并要求重启启动器
            }
        }
    }
}
