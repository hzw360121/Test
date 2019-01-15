using GoodLuck.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoodLuck
{
    public partial class FormMain : Form
    {
        private Font labFont = new System.Drawing.Font("微软雅黑", 25, System.Drawing.FontStyle.Bold);

        private List<string> listStr = null;
        DataTable dtPrize = null;
        private bool b = false;
        private string obj = "start";
        public FormMain()
        {
            InitializeComponent();
        }

        internal void LoadMusin()
        {
            axMusicPlay.URL = ConfigHelper.GetValue("BGMusic");
            axMusicPlay.Ctlcontrols.play();
            //axMusicPlay.settings.setMode("loop", true);//循环播放
            axMusicPlay.Visible = false;

            axMusicRoll.URL = ConfigHelper.GetValue("RollMusic");
            axMusicRoll.settings.setMode("loop", true);//循环播放
            axMusicRoll.Ctlcontrols.stop();
            axMusicRoll.Visible = false;
        }


        internal void InitData()
        {
            listStr = new List<string>();
            string sqlUser = "Select ID,UserName,UserPhone from UserInfo";
            DataTable dtUser = SQLiteHelper.GetList(sqlUser, null);
            foreach (DataRow row in dtUser.Rows)//得到所有的抽奖名单
            {
                listStr.Add(row["UserName"].ToString());
            }
            timesCurrent = 1;//重置当前次数与奖项
            prizeCurrent = 0;
            string sqlPrize = null;
            if (ConfigHelper.GetValue("Orderby") == "ASC")
                 sqlPrize = "Select ID,PrizeName,TotalNum,EveryNum FROM PrizeInfo order by ID ASC";
            else
                 sqlPrize = "Select ID,PrizeName,TotalNum,EveryNum FROM PrizeInfo order by ID DESC";
            dtPrize = SQLiteHelper.GetList(sqlPrize, null);
            
            totalNum = Convert.ToInt32(dtPrize.Rows[0]["TotalNum"]);
            everyNum = Convert.ToInt32(dtPrize.Rows[0]["EveryNum"]);
            times = Math.Ceiling((decimal)totalNum / everyNum);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {

            LoadMusin();//加载音乐

            #region 标题不要，注释
            //this.label1.Text = ConfigHelper.GetValue("LuckTitle");
            //int x = (int)(0.5 * (this.Width - this.label1.Width));
            //int y = this.label1.Location.Y;
            //this.label1.Location = new System.Drawing.Point(x, y);
            #endregion


            //Config.datafile = $"{Environment.CurrentDirectory}\\Data\\goodluckdata.db";
            //this.Text = ConfigHelper.GetValue("CompanyName");
            this.BackgroundImage = System.Drawing.Image.FromFile(ConfigHelper.GetValue("BG"));

            int x = 50;
            int y = this.prizeName.Location.Y;
            this.prizeName.Location = new System.Drawing.Point(50, y);


            x = (int)(0.5 * (this.Width - this.btnStartOrStop.Width));
            y = this.btnStartOrStop.Location.Y;
            this.btnStartOrStop.Location = new Point(x, y);

            Control.CheckForIllegalCrossThreadCalls = false;
            InitData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        #region 开始摇奖

        private Thread[] ths = null;
        private List<string>[] listn = null;
        private byte seed;
        decimal times;//抽奖的次数
        private int timesCurrent = 1;//当前次数（用来记录抽奖的）
        private int prizeCurrent = 0;//当前抽的奖项（奖项表DataTable中的行数）
        private int totalNum;
        private int everyNum;



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (listStr == null || listStr.Count <= 0)
            {
                MessageBox.Show("没有抽奖名单，请先导入名单再进行抽奖！！");
                return;
            }
            //contextMenuStrip1.Enabled = false;

            if (prizeCurrent >= dtPrize.Rows.Count)
            {
                MessageBox.Show("所有奖项已抽取完毕！！");
                btnStartOrStop.Text = "开始";
                btnStartOrStop.Visible = false;
                InitData();
                //contextMenuStrip1.Enabled = true;//只有在本次所有抽奖完成 菜单才能可用
                return;
            }

            LuckMethod(dtPrize.Rows[prizeCurrent], timesCurrent);

            btnStartOrStop.Visible = true;

            this.BackgroundImage = System.Drawing.Image.FromFile("Images\\无文字背景.jpg");


            axMusicRoll.Ctlcontrols.play();
            axMusicPlay.Ctlcontrols.stop();

        }

        private void LuckMethod(DataRow row, int current)
        {

            this.prizeName.Visible = true;
            this.prizeName.Text = row["PrizeName"].ToString();

            totalNum = Convert.ToInt32(row["TotalNum"]);
            everyNum = Convert.ToInt32(row["EveryNum"]);
            times = Math.Ceiling((decimal)totalNum / everyNum);
            int everyListCount = listStr.Count / everyNum;
            listn = new List<string>[everyNum];
            CreateLabel(everyNum);//创建label
            CreateTextBox(everyNum);

            ths = new Thread[everyNum];
            for (int j = 0; j < everyNum; j++)
            {
                //根据每次抽的个数创建list
                listn[j] = new List<string>();
                if (j != everyNum - 1)
                {
                    listn[j].AddRange(listStr.GetRange(j * everyListCount, everyListCount));
                }
                else
                    listn[j].AddRange(listStr.GetRange(j * everyListCount, listStr.Count - j * everyListCount));
                //根据每次抽的个数创建线程
                ths[j] = new Thread(new ThreadStart(trunlab));
                //ths[j] = new Thread(() => trunlab(j));

            }
            timesCurrent++;
            if (current >= (int)times)
            {
                timesCurrent = 1;
                prizeCurrent++;
            }

            b = true;
            for (int k = 0; k < ths.Length; k++)
            {
                ths[k].Name = k.ToString();
                ths[k].IsBackground = true;
                ths[k].Start();
            }
        }

        #endregion

        #region 名单管理
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormShowUser showUser = new FormShowUser(this);
            showUser.ShowDialog();
        }
        #endregion

        #region 设置
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormBKConfig bk = new FormBKConfig(this);
            bk.ShowDialog();
        }

        #endregion


        #region 奖项设置
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FormPrizeSetting setting = new FormPrizeSetting(this);
            setting.ShowDialog();
        }
        #endregion

        #region 退出程序
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; ths != null && i < ths.Length; i++)
            {
                if (ths[i] != null && ths[i].IsAlive) ths[i].Abort();
            }
            Application.Exit();
        }
        #endregion


        private void CreateLabel(int everyNum)
        {
            if (everyNum > 5)//&& everyNum % 5 == 0
            {
                for (int i = 0; i < everyNum; i++)
                {
                    Label lab = GetNewlabel(i.ToString(), "");
                    //位置算法
                    int x = (int)(0.5 * (this.Width - (lab.Width * 5)));
                    lab.Location = new Point(x + (lab.Width) * (i % 5), this.Height / 2 + 100 + 70 * (i / 5));
                    this.Controls.Add(lab);
                }
            }
            else
            {
                for (int i = 0; i < everyNum; i++)
                {
                    Label lab = GetNewlabel(i.ToString(), "");
                    //位置算法
                    int x = (int)(0.5 * (this.Width - (lab.Width * everyNum)));
                    lab.Location = new Point(x + (lab.Width) * i, this.Height/2 + 100);
                    this.Controls.Add(lab);
                }
            }

        }


        private void ClearLabel(int every)
        {
            for (int i = 0; i < every; i++)
            {
                Control c = FindControl(i.ToString());
                this.Controls.Remove(c);
                c.Dispose();
            }
        }


        private void btnStartOrStop_Click(object sender, EventArgs e)
        {
            if (btnStartOrStop.Text == "继续摇奖")
            {
                ClearLabel(everyNum);
                btnStartOrStop.Text = "停止";
                toolStripMenuItem1_Click(sender, e);
                //b = true;
                axMusicPlay.Ctlcontrols.stop();
            }
            else
            {
                //取值插入数据库
                b = false;
                for (int i = 0; i < everyNum; i++)
                {
                    if (ths != null && ths[i] != null) ths[i].Abort();
                }

                using (SQLiteConnection connection = new SQLiteConnection(SQLiteHelper.Conn))
                {
                    connection.Open();
                    using (DbTransaction dbTrans = connection.BeginTransaction())
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            try
                            {
                                for (int j = 0; j < everyNum; j++)
                                {
                                    Label label = FindControl(j.ToString()) as Label;
                                    WinnerInfo winnerInfo = new WinnerInfo();

                                    if (prizeCurrent == 0)
                                        winnerInfo.PrizeID = Convert.ToInt32(dtPrize.Rows[prizeCurrent]["ID"]);
                                    else
                                        winnerInfo.PrizeID = Convert.ToInt32(dtPrize.Rows[prizeCurrent - 1]["ID"]);//prizeCurrent有++操作，所以此处要-1

                                    winnerInfo.WinnerName = label.Text;
                                    winnerInfo.WinnerPhone = string.Empty;

                                    cmd.CommandText = "INSERT INTO Winners(PrizeID,Winner,WinnerPhone) VALUES (@PrizeID,@Winner,@WinnerPhone)";
                                    cmd.Parameters.Add(new SQLiteParameter("@PrizeID", winnerInfo.PrizeID));
                                    cmd.Parameters.Add(new SQLiteParameter("@Winner", winnerInfo.WinnerName));
                                    cmd.Parameters.Add(new SQLiteParameter("@WinnerPhone", winnerInfo.WinnerPhone));
                                    cmd.ExecuteNonQuery();
                                    listStr.Remove(winnerInfo.WinnerName);
                                }
                                dbTrans.Commit();
                                btnStartOrStop.Text = "继续摇奖";

                            }
                            catch (Exception ex)
                            {
                                dbTrans.Rollback();
                                MessageBox.Show("该次名单保存失败！！" + ex.Message);
                            }
                        }
                    }
                }
                axMusicPlay.URL = ConfigHelper.GetValue("StopMusic");//ConfigurationManager.AppSettings["StopMusic"].ToString();
                axMusicRoll.Ctlcontrols.pause();
            }

        }

        private void trunlab()
        {
            do
            {
                lock (obj)
                {
                    Random ran = new Random(Guid.NewGuid().GetHashCode());
                    string name = Thread.CurrentThread.Name;
                    seed = Convert.ToByte(name);
                    if(listn[seed]!=null&& listn[seed].Count>0)
                    {
                        int index = ran.Next(0, listn[seed].Count);
                        FindControl(name).Text = listn[seed][index];
                    }
                }
                Thread.Sleep(25);
            } while (b);
        }

        private Control FindControl(string controlName)
        {
            foreach (Control c in this.Controls)
            { if (c.Name == controlName) { return c; } }
            return null;
        }

        private Label GetNewlabel(string labelName, string labelText)
        {
            //Control c = FindControl(labelName);
            //if (c != null) return (Label)c;

            Label lab = new Label();
            //lab.AutoSize = true;//自动大小的话，背景颜色明显
            lab.Width = 180;
            lab.Height = 60;
            lab.BackColor = Color.Transparent;
            lab.FlatStyle = FlatStyle.Flat;
            lab.Font = labFont;
            lab.ForeColor = Color.Gold;
            lab.Name = labelName;
            lab.Text = labelText;
            return lab;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FormShowWinner f = new FormShowWinner();
            f.ShowDialog();
        }



        private void CreateTextBox(int everyNum)
        {
            if (everyNum > 5)//&& everyNum % 5 == 0
            {
                for (int i = 0; i < everyNum; i++)
                {
                    TextBox tx = GetNewTextBox("0"+i.ToString(), "");
                    //位置算法
                    int x = (int)(0.5 * (this.Width - (tx.Width * 5)));
                    tx.Location = new Point(x + (tx.Width) * (i % 5), 50 + 70 * (i / 5));
                    this.Controls.Add(tx);
                }
            }
            else
            {
                for (int i = 0; i < everyNum; i++)
                {
                    TextBox tx = GetNewTextBox("0" + i.ToString(), "");
                    //位置算法
                    int x = (int)(0.5 * (this.Width - (tx.Width * everyNum)));
                    tx.Location = new Point(x + (tx.Width) * i, 50);
                    this.Controls.Add(tx);
                }
            }

        }

        private TextBox GetNewTextBox(string labelName, string labelText)
        {
            //Control c = FindControl(labelName);
            //if (c != null) return (Label)c;

            TextBox tx = new TextBox();
            //lab.AutoSize = true;//自动大小的话，背景颜色明显
            tx.Width = 180;
            tx.Height = 60;
            tx.BackColor =
            tx.BorderStyle = BorderStyle.None;
            tx.Font = labFont;
            tx.ForeColor = Color.Gold;
            tx.Name = labelName;
            tx.Text = labelText;
            return tx;
        }


    }
}
