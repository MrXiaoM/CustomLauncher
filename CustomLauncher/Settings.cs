using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CustomLauncher
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent(); 
        }

        public string Java路径
        {
            get
            {
                string javapath = "";
                try//判断异常
                {
                    String[] js = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment").GetSubKeyNames();//读取jre路径。
                    //如果探测无异常才会执行下面的代码
                    javapath = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment\" + js[0]).GetValue("JavaHome") + "\\bin\\javaw.exe";
                }
                catch (Exception jreex)//如果出现异常(如未安装jre而安装了jdk)
                {
                    if (jreex.Message.Contains("未将对象引用设置到对象的实例。"))//读取异常
                    {
                        try//继续判断异常
                        {
                            String[] js = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit").GetSubKeyNames();//读取jdk路径。
                            javapath = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit\" + js[0]).GetValue("JavaHome") + "\\jre\\bin\\javaw.exe";
                        }
                        catch (Exception jdkex)//如果出现异常
                        {
                            MessageBox.Show("未安装Java而导致的:\n\r" + jdkex.Message, "异常");
                        }
                    }
                }
                return javapath;
            }
        }

        #region ini读写前置
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
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, Application.StartupPath + "\\.minecraft\\mlauncher.mc");
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
                long OpStation = WritePrivateProfileString(Section, Key, Value, Application.StartupPath + "\\.minecraft\\mlauncher.mc");
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
        public void LoadForm()
        {
            string 配置节 = "MLauncher";
            /*************************** 
              创建配置
             ***************************/
            if (!File.Exists(Application.StartupPath + "\\.minecraft\\mlauncher.mc"))
            {
                StreamWriter sw = File.CreateText(Application.StartupPath + "\\.minecraft\\mlauncher.mc");
                sw.Close();
                ini_Write(配置节, "MaximumMemory", "786");
                ini_Write(配置节, "Username", "");
                ini_Write(配置节, "JavaPath", Java路径);
                ini_Write(配置节, "OnlineMode", "false");
                ini_Write(配置节, "Online-Email", "");
                ini_Write(配置节, "Online-Password(encrypted)", "");
                ini_Write(配置节, "Fullscreen", "false");
                ini_Write(配置节, "Demo", "false");
                ini_Write(配置节, "Height", "480");
                ini_Write(配置节, "Width", "854");
                //ini_Write(配置节, "Auto_Join_Server_IP","");
            }
            /*************************** 
              读取配置
             ***************************/
            mm.Text = ini_Read(配置节, "MaximumMemory");
            jp.Text = ini_Read(配置节, "JavaPath");
            un.Text = ini_Read(配置节, "Username");
            if (ini_Read(配置节, "OnlineMode") == "true")
            {
                un.Enabled = false;
                checkBox1.Checked = true;
                Email.Enabled = true;
                password.Enabled = true;
            }
            else
            {
                Email.Enabled = false;
                password.Enabled = false;
            }
            Email.Text = ini_Read(配置节, "Online-Email");
            password.Text = EncryptStr(ini_Read(配置节, "Online-Password"), true);
            if (ini_Read(配置节, "Fullscreen") == "true")//后置参数加载部分
            {
                checkBox2.Checked = true;
            }
            if (ini_Read(配置节, "Demo") == "true")
            {
                checkBox3.Checked = true;
            }
            textBox2.Text = ini_Read(配置节, "Height");
            textBox1.Text = ini_Read(配置节, "Width");
            textBox3.Text = ini_Read(配置节, "Auto_Join_Server_IP");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //浏览java
            OpenFileDialog ofd = new OpenFileDialog();//初始化打开文件对话框
            ofd.Title = "请选择您的javaw.exe所在路径";//设置标题
            ofd.RestoreDirectory = true;//不还原路径
            ofd.Multiselect = false;//不允许选择多个
            ofd.Filter = "java|javaw.exe";//设置格式过滤
            if (ofd.ShowDialog() == DialogResult.OK)
            {//显示对话框
                jp.Text = ofd.FileName;//返回路径名
            }
        }
        /*
        WebClient wc = new WebClient();//声明下载对象
        public String rtxt = "";

        private void button4_Click(object sender, EventArgs e)
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
            listBox1.Items.Clear();//清空列表
            foreach (String vi in versions)
            {//为每个项循环
                tmp = vi.IndexOf("id") + "id".Length + 3;//读取id
                tmu = vi.Substring(tmp, vi.IndexOf("\"", tmp) - tmp);//同上
                listBox1.Items.Add(tmu);//添加项
            }
            button3.Text = "下载";
        }

        public String SelVerName = "";

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)//如果用户没选
            {
                return;//返回
            }
            if (button3.Text == "安装")
            {
                String VerName = "";
                String Purevn = this.rtxt.Substring(this.rtxt.IndexOf("&&") + 2);
                String oldVN = this.SelVerName;
                VerName = Purevn + "-LiteLoader" + Purevn + "-" + oldVN;
                String pfWJson = "";
                String rv = listBox1.SelectedItem.ToString();
                int vloc = this.rtxt.IndexOf("\"version\":\"" + rv + "\"");
                int vsta = this.rtxt.LastIndexOf(":{", vloc) + 1;
                int vend = this.rtxt.IndexOf("}", vloc);
                String VerInfo = this.rtxt.Substring(vsta, vend - vsta);
                vsta = VerInfo.IndexOf("\"libraries\":[");
                vend = VerInfo.IndexOf("]");
                String libraries = VerInfo.Substring(vsta, vend - vsta);
                vsta = VerInfo.IndexOf("\"tweakClass\":\"") + "\"tweakClass\":\"".Length;
                String tweakClass = VerInfo.Substring(vsta, VerInfo.IndexOf("\"", vsta) - vsta);
                vsta = VerInfo.IndexOf("\"stream\":\"") + "\"stream\":\"".Length;
                String VType = VerInfo.Substring(vsta, VerInfo.IndexOf("\"", vsta) - vsta);
                String ParJson = File.ReadAllText(Application.StartupPath + "\\.minecraft\\versions\\" + oldVN + "\\" + oldVN + ".json").Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                vsta = ParJson.IndexOf("\"minecraftArguments\":\"") + "\"minecraftArguments\":\"".Length;
                String oldmA = ParJson.Substring(vsta, ParJson.IndexOf("\"", vsta) - vsta).Replace("${", " ${").Replace("}", "} ").Replace("cpw", " cpw").Replace("--tweakClassnet.minecraftforge.fml.common.launcher.FMLTweaker", "--tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker ").Replace("--tweakClasscom.mumfrey.liteloader.launch.LiteLoaderTweaker", "--tweakClass com.mumfrey.liteloader.launch.LiteLoaderTweaker ").Replace("--versionTypeForge", "--versionType Forge ");
                vsta = VerInfo.IndexOf("\"file\":\"") + "\"file\":\"".Length;
                String llfilename = VerInfo.Substring(vsta, VerInfo.IndexOf("\"", vsta) - vsta);
                pfWJson = "{\r\n\"id\":\"" + VerName + "\"\r\n\"type\":\"" + VType + "\"\r\n\"minecraftArguments\":\"--tweakClass " + tweakClass + " " + oldmA + "\"\r\n" + libraries + ",{\"name\": \"com.google.guava:guava:16.0\"},{\"name\": \"com.mumfrey:liteloader:" + Purevn + "\",\"url\": \"http://dl.liteloader.com/versions/\",\"LiteLoaderFileName\":\"" + llfilename + "\"}],\r\n\"mainClass\": \"net.minecraft.launchwrapper.Launch\",\r\n	\"inheritsFrom\": \"" + oldVN + "\",\r\n	\"jar\": \"" + Purevn + "\"\r\n}";
                if (!Directory.Exists(Application.StartupPath + "\\.minecraft\\versions\\" + VerName)) { Directory.CreateDirectory(Application.StartupPath + "\\.minecraft\\versions\\" + VerName); }
                File.WriteAllText(Application.StartupPath + "\\.minecraft\\versions\\" + VerName + "\\" + VerName + ".json", pfWJson);
                Application.Restart();
                return;
            }
            String[] vins = listBox1.SelectedItem.ToString().Split(" ".ToCharArray());//分离出版本和下载地址
            if (vins[1].IndexOf("forge") != -1)
            {
                List<string> tu = new List<string>();
                tu.Add(vins[1] + ":::" + Application.StartupPath + "\\Install_Forge_" + vins[0] + ".jar");
                new ShowDownload().DownloadBL(tu, "installforge");
                return;
            }
            String vdp = Application.StartupPath + "\\.minecraft\\versions\\" + vins[0];//处理下载目标路径
            if (!Directory.Exists(vdp))//如果无文件夹
            {
                Directory.CreateDirectory(vdp);//创建
            }
            wc.DownloadFile(vins[1], vdp + "\\" + vins[0] + ".json");//处理并下载目标文件
            while (!File.Exists(vdp + "\\" + vins[0] + ".json"))//等待下载完成
            {
                System.Threading.Thread.Sleep(10);//休眠
            }
            String rtxt = File.ReadAllText(vdp + "\\" + vins[0] + ".json").Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");//读取数据
            int a = rtxt.IndexOf("downloads");//读取主jar文件下载地址部分
            int b = rtxt.IndexOf("client", a);//读取主jar文件下载地址部分
            int c = rtxt.IndexOf("url", b) + "url".Length + 3;//读取主jar文件下载地址部分
            List<String> cu = new List<string>();//声明下载列表
            cu.Add(rtxt.Substring(c, rtxt.IndexOf("\"", c) - c) + ":::" + vdp + "\\" + vins[0] + ".jar");//加入下载项
            new ShowDownload().DownloadBL(cu, "restart");//执行下载并要求重启启动器
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wc.DownloadFile("http://files.minecraftforge.net/maven/net/minecraftforge/forge/json", Application.StartupPath + "\\tmp.json");//下载数据文件
            rtxt = File.ReadAllText(Application.StartupPath + "\\tmp.json").Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");//读取数据文件
            File.Delete(Application.StartupPath + "\\tmp.json");//删除数据文件
            if (listBox1.SelectedIndex == -1)//如果用户没有选择一个纯净版
            {
                return;//返回
            }
            String rv = listBox1.SelectedItem.ToString().Split(" ".ToCharArray())[0];//读取版本名称
            if (rtxt.IndexOf(rv) == -1)//如果不存在该版本
            {
                return;//返回
            }
            int tmp = rtxt.IndexOf("\"number") + "\"number".Length + 3;//读取json
            String tr = rtxt.Substring(tmp, rtxt.LastIndexOf("},") - tmp);//读取json
            String[] trs = tr.Replace("},", "%").Split("%".ToCharArray());//读取json
            listBox1.Items.Clear();//清空列表框
            foreach (String num in trs)//为每个读取到的项循环
            {
                tmp = num.IndexOf("\"mcversion") + "\"mcversion".Length + 3;//读取json
                String mcv = num.Substring(tmp, num.IndexOf("\"", tmp) - tmp);//读取json
                if (mcv != rv)//如果不是用户请求的版本
                {
                    continue;//下一个循环
                }
                tmp = num.IndexOf("\"version") + "\"version".Length + 3;//读取json
                String fv = num.Substring(tmp, num.IndexOf("\"", tmp) - tmp);//读取json
                tmp = num.IndexOf("\"branch") + "\"branch".Length + 3;//读取json中指定的后缀
                String brc = num.Substring(tmp, num.IndexOf("\"", tmp) - tmp);//读取json中指定的后缀
                if (brc.IndexOf("ull") != -1)//如果后缀是null
                {
                    brc = "";//设空
                }
                else//否则
                {
                    brc = "-" + brc;//加上“-”
                }
                listBox1.Items.Add(fv + " http://files.minecraftforge.net/maven/net/minecraftforge/forge/" + rv + "-" + fv + brc + "/forge-" + rv + "-" + fv + brc + "-installer.jar");//处理版本和下载地址
            }
            button3.Text = "下载并安装";
        }
        */
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                un.Enabled = false;
                Email.Enabled = true;
                password.Enabled = true;
            }
            else
            {
                un.Enabled = true;
                Email.Enabled = false;
                password.Enabled = false;
            }
        }
        /// <summary>
        /// 加解密字符
        /// </summary>
        /// <param name="input">需要输入的字符</param>
        /// <param name="Decrypt">是否解密(默认为否)</param>
        /// <returns>返回被加(解)密后的字符</returns>
        public String EncryptStr(String input, bool Decrypt = false)
        {
            String[] dict = "C，D，E，2，o，p，q，5，6，7，8，9，0，a，b，c，d，e，f，g，h，i，j，1，r，s，t，u，H，I，V，W，X，Y，l，m，n，G，$，%，J，K，L，M，N，O，P，\"，'，<，,，>，.， ，?，Q，R，S，T，U，^，&，*，(，)，-，_，=，+，{，[，}，]，\\，|，:，;，Z，~，!，@，#，v，w，x，y，z，A，B，F，3，4，k，/".Split("，".ToCharArray());//字典
            String inputStr = input;//准备操作输入字符
            String outputStr = "";//声明输出字符
            if (Decrypt == false)//如果要加密
            {
                for (int a = 0; a < inputStr.Length; a++)//为每个字符循环
                {
                    String dfis = inputStr.Substring(a, 1);//截取字符
                    for (int b = 0; b < dict.Length; b++)//为字典中的每个项循环
                    {
                        if (dict[b] == dfis)//如果找到了项
                        {
                            Random r = new Random();//声明随机数
                            int rv = r.Next(b, dict.Length - 1);//获取一个从索引值到字典所有元素数量的随机数
                            outputStr = outputStr + dict[rv] + dict[rv - b];//存储该数对应的字符和该数减去长度的值对应的字符
                        }
                    }
                }
            }
            else//如果要解密
            {
                for (int a = 0; a < (inputStr.Length / 2); a++)//为每两个字符循环
                {
                    String dfis = inputStr.Substring(2 * a, 2);//截取
                    int rm = 0;//声明被减数
                    int fm = 0;//声明减数
                    for (int b = 0; b < dict.Length; b++)//为字典中的每个项循环
                    {
                        if (dict[b] == dfis.Substring(0, 1))//如果找到了被减数对应的字符
                        {
                            rm = b;//赋值为它对应的值
                        }
                        if (dict[b] == dfis.Substring(1, 1))//如果找到了减数对应的字符
                        {
                            fm = b;//赋值为它对应的值
                        }
                    }
                    outputStr = outputStr + dict[rm - fm];//存储相减的结果
                }
            }
            return outputStr;//返回结果
        }
        /*
        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\tmp.json"))//如果临时文件存在
            {
                //File.Delete(Application.StartupPath + "\\tmp.json");//删掉
            }
            if (listBox1.SelectedIndex == -1)//如果用户没有选择一个纯净版
            {
                return;//返回
            }
            wc.DownloadFile("http://dl.liteloader.com/versions/versions.json", Application.StartupPath + "\\tmp.json");//下载版本列表文件
            rtxt = File.ReadAllText(Application.StartupPath + "\\tmp.json").Replace("\n", "").Replace(" ", "");//读取版本列表
            File.Delete(Application.StartupPath + "\\tmp.json");//删除临时文件
            String rv = listBox1.SelectedItem.ToString().Split(" ".ToCharArray())[0];//读取版本名称
            int verStt = rtxt.IndexOf("\"" + rv + "\":{") + rv.Length +3;
            String Verinfo = rtxt.Substring(verStt, rtxt.IndexOf("}}}},", verStt) - verStt + 4);
            int tmp=0;
            listBox1.Items.Clear();
            do
            {
                tmp=Verinfo.IndexOf("\"version\":\"",tmp) + 11;
                String ForAdd = Verinfo.Substring(tmp, Verinfo.IndexOf("\"", tmp) - tmp);
                if (!listBox1.Items.Contains(ForAdd))
                {
                    listBox1.Items.Add(ForAdd);
                }
            } while (Verinfo.IndexOf("\"version\":", tmp) != -1);
            rtxt = Verinfo + "&&" + rv;
            button3.Text = "安装";
        }*/
    }
}