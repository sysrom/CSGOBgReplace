using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace CSGOBgReplace
{
    public partial class Form1 : Sunny.UI.UIForm
    {
        private static string CSGOPath = "";
        private static string FilePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectCSGO = new FolderBrowserDialog();
            selectCSGO.Description = "选择你的CSGO目录";
            if (selectCSGO.ShowDialog() == DialogResult.OK) {
                CSGOPath = selectCSGO.SelectedPath + @"\";
            }
            uiTextBox1.Text = CSGOPath;
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(uiComboBox1.SelectedIndex.ToString());
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Process[] m_csgoprocess = Process.GetProcessesByName("csgo");
            if (m_csgoprocess.Length > 0) {
                CSGOPath = System.IO.Directory.GetParent(m_csgoprocess[m_csgoprocess.Length - 1].MainModule.FileName).FullName+@"\";
                uiTextBox1.Text = CSGOPath;
            }
            else
                UIMessageBox.Show("游戏呢游戏呢?","喵喵喵???");
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog()
            {
                Filter = "Files (*.webm)|*.webm"//如果需要筛选txt文件（"Files (*.txt)|*.txt"）
            };
            if (selectFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = selectFile.FileName;
            }
            uiTextBox2.Text = FilePath;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            bool backup=false;
            string r1080p,r720p,r540p="";
            if (uiTextBox1.Text == string.Empty) {
                UIMessageBox.Show("笨比没CSGO选目录你换什么（", "喵喵喵?");
                return;
            }
            if (!Directory.Exists(CSGOPath)) {UIMessageBox.Show("笨比你选了一个什么破jb不存在的目录（", "喵喵喵?");return;}
               
            if (uiTextBox2.Text == string.Empty)
            {
                UIMessageBox.Show("笨比你没选要换成什么（","喵喵喵?");
                return;
            }
            if (uiCheckBox1.Checked) {
                backup = true;
                if (!Directory.Exists(CSGOPath + "csgo\\panorama\\videos\\backup\\"))
                    Directory.CreateDirectory(CSGOPath + "csgo\\panorama\\videos\\backup\\");
            }
            switch (uiComboBox1.SelectedIndex) {
                case 0:
                    r1080p = "intro.webm";
                    r720p = "intro720p.webm";
                    break;
                case 1:
                    r1080p = "intro-perfectworld.webm";
                    r720p = "intro-perfectworld720p.webm";
                    break;
                case 2:
                    r1080p = "ancient.webm";
                    r720p = "ancient720.webm";
                    r540p = "ancient540.webm";
                    break;
                case 3:
                    r1080p = "anubis.webm";
                    r720p = "anubis720.webm";
                    r540p = "anubis540.webm";
                    break;
                case 4:
                    r1080p = "blacksite.webm";
                    r720p = "blacksite720p.webm";
                    r540p = "blacksite540p.webm";
                    break;
                case 5:
                    r1080p = "cbble.webm";
                    r720p = "cbble720p.webm";
                    r540p = "cbble540p.webm";
                    break;
                case 6:
                    r1080p = "nuke.webm";
                    r720p = "nuke720p.webm";
                    r540p = "nuke540p.webm";
                    break;
                case 7:
                    r1080p = "sirocco_night.webm";
                    r720p = "sirocco_night720p.webm";
                    r540p = "sirocco_night540p.webm";
                    break;
                case 8:
                    r1080p = "vertigo.webm";
                    r720p = "vertigo720.webm";
                    r540p = "vertigo540.webm";
                    break;
                default:
                    UIMessageBox.Show("笨比你选了个什么玩意?","喵喵喵?");
                    return;
                    break;
            }
            if (uiCheckBox1.Checked)
            {
                backup = true;
                if (!Directory.Exists(CSGOPath + "csgo\\panorama\\videos\\backup\\"))
                    Directory.CreateDirectory(CSGOPath + "csgo\\panorama\\videos\\backup\\");
                if (uiRadioButton4.Checked)
                {
                    File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r1080p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r1080p + ".bak");
                    File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r720p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r720p + ".bak");
                    if (uiComboBox1.SelectedIndex != 0 && uiComboBox1.SelectedIndex != 1)
                        File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r540p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r540p + ".bak");
                }
                else if (uiRadioButton1.Checked)
                {
                    File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r1080p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r1080p + ".bak");
                }
                else if (uiRadioButton2.Checked)
                {
                    File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r720p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r720p + ".bak");
                }
                else if (uiRadioButton3.Checked)
                {
                    File.Move(CSGOPath + "csgo\\panorama\\videos\\" + r540p, CSGOPath + "csgo\\panorama\\videos\\backup\\" + r540p + ".bak");
                }
            }
            else 
            {
                if (uiRadioButton1.Checked)
                {

                    File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r1080p);
                }
                else if (uiRadioButton2.Checked)
                {

                    File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r720p);
                }
                else if (uiRadioButton3.Checked)
                {
                    if (uiComboBox1.SelectedIndex != 0 && uiComboBox1.SelectedIndex != 1)
                        File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r540p);
                }
                
            }

            if (uiRadioButton4.Checked)
            {
                
                File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r1080p);
                File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r720p);
                
                if (uiComboBox1.SelectedIndex != 0 && uiComboBox1.SelectedIndex != 1)
                {
                    
                    File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r540p);
                }
                    
            }
            else if (uiRadioButton1.Checked)
            {
                
                File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r1080p);
            }
            else if (uiRadioButton2.Checked)
            {
                
                File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r720p);
            }
            else if (uiRadioButton3.Checked)
            {
                
                File.Copy(FilePath, CSGOPath + "csgo\\panorama\\videos\\" + r540p);
            }
            //File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r1080p);
            //File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r720p);
            //if (uiComboBox1.SelectedIndex == 0 || uiComboBox1.SelectedIndex == 1)
            //File.Delete(CSGOPath + "csgo\\panorama\\videos\\" + r540p);
            UIMessageBox.Show("替换完成，请前往游戏更换查看效果","喵!");
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex == 0 || uiComboBox1.SelectedIndex == 1)
                uiRadioButton3.Enabled = false;
            else
                uiRadioButton3.Enabled = true;
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", CSGOPath + "csgo\\panorama\\videos\\");
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", CSGOPath + "csgo\\panorama\\videos\\backup\\");
        }

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://cloudconvert.com/");
        }

        private void uiLinkLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.ghxi.com/formatfactory-2.html");
        }

        private void uiLinkLabel3_Click(object sender, EventArgs e)
        {
            new donate().ShowDialog();
        }
    }
}
