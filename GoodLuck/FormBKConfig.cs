using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodLuck
{
    public partial class FormBKConfig : Form
    {
        FormMain fm = new FormMain();
        //private string img = "";
        public FormBKConfig(FormMain f)
        {
            fm = f;
            InitializeComponent();
        }

        private void FormBKConfig_Load(object sender, EventArgs e)
        {
            //ConfigurationManager.AppSettings["BG"].ToString(); 这种方式更改配置文件后 获取不到最新值
            this.textBox1.Text = ConfigHelper.GetValue("BG");
            this.txtBGMusic.Text = ConfigHelper.GetValue("BGMusic");
            this.txtRollMusic.Text = ConfigHelper.GetValue("RollMusic");
            this.txtStopMusic.Text = ConfigHelper.GetValue("StopMusic");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath+ "\\Images";
            var rtn = openFileDialog1.ShowDialog();
            if (rtn == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                this.textBox1.Text = fName;
                this.pictureBox1.Load(fName);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            fm.BackgroundImage = System.Drawing.Image.FromFile(this.textBox1.Text);
            ConfigHelper.SetValue("BG", this.textBox1.Text);

            ConfigHelper.SetValue("BGMusic", this.txtBGMusic.Text);
            ConfigHelper.SetValue("RollMusic", this.txtRollMusic.Text);
            ConfigHelper.SetValue("StopMusic", this.txtStopMusic.Text);
            ConfigHelper.RefreshSection("appSettings");//设置之后刷新配置文件
            fm.LoadMusin();
        }

        private void btnBGMusic_Click(object sender, EventArgs e)
        {
            ofdBGMusic.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Music\\BgMusic";
            var rtn = ofdBGMusic.ShowDialog();
            if (rtn == DialogResult.OK)
                this.txtBGMusic.Text = ofdBGMusic.FileName;
        }

        private void btnRollMusic_Click(object sender, EventArgs e)
        {
            ofdRollMusic.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Music\\RollMusic";
            var rtn = ofdRollMusic.ShowDialog();
            if (rtn == DialogResult.OK)
                this.txtRollMusic.Text = ofdRollMusic.FileName;
        }

        private void btnStopMusic_Click(object sender, EventArgs e)
        {
            ofdStopMusic.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Music\\StopMusic";
            var rtn = ofdStopMusic.ShowDialog();
            if (rtn == DialogResult.OK)
                this.txtStopMusic.Text = ofdStopMusic.FileName;
        }
    }
}
