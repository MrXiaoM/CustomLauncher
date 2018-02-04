using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace CustomLauncher
{
    class MainClass
    {
        [STAThread]
        public static void Main(String[] args)
        {
            if (!Directory.Exists(Application.StartupPath + "\\.minecraft"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\.minecraft");
            }
            if (!Directory.Exists(Application.StartupPath + "\\.minecraft\\mods"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\.minecraft\\mods");
            }
            if (!Directory.Exists(Application.StartupPath + "\\.minecraft\\versions"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\.minecraft\\versions");
            }
            if (!Directory.Exists(Application.StartupPath + "\\.minecraft"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\.minecraft");
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mf = new MainForm();
            Application.Run(mf);
        }
    }
}
