using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodLuck
{
    public partial class FormPrizeSetting : Form
    {
        public FormPrizeSetting()
        {
            InitializeComponent();
        }
        FormMain fm = new FormMain();
        public FormPrizeSetting(FormMain f)
        {
            fm = f;
            InitializeComponent(); 
        }

        private void FormPrizeSetting_Load(object sender, EventArgs e)
        {
            DataSet dt = SQLiteHelper.ExecuteDataSet(SQLiteHelper.Conn, "Select ID,PrizeName,TotalNum,EveryNum FROM PrizeInfo", null);
            this.dgvPrize.DataSource = dt.Tables[0];
            int index = 0;

            dgvPrize.Columns[index].HeaderText = "编号";
            dgvPrize.Columns[index].Width = 80;

            index++;
            dgvPrize.Columns[index].HeaderText = "奖项名称";
            dgvPrize.Columns[index].Width = 80;

            index++;
            dgvPrize.Columns[index].HeaderText = "抽奖总数";
            dgvPrize.Columns[index].Width = 80;


            index++;
            dgvPrize.Columns[index].HeaderText = "每次抽奖数";
            dgvPrize.Columns[index].Width = 80;
            dgvPrize.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPrize.AllowUserToAddRows = false;
            dgvPrize.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            //dgvPrize.ScrollBars = ScrollBars.None;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string prizeName = txtName.Text;
            if(string.IsNullOrEmpty(txtTotalNum.Text.Trim())||string.IsNullOrEmpty(txtEveryNum.Text))
            {
                MessageBox.Show("请输入抽奖总数及每次抽奖数！！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            int totalNum = Convert.ToInt32(txtTotalNum.Text);
            int everyNum = Convert.ToInt32(txtEveryNum.Text);

            if (totalNum % everyNum != 0)
            {
                MessageBox.Show("请输入两个能整除的数！！", "信息提示", MessageBoxButtons.OK);
                return;
            }
                
            if (btnSave.Text == "添加")
            {
                string sqlStr = "INSERT INTO PrizeInfo(PrizeName,TotalNum,EveryNum) values(@PrizeName,@TotalNum,@EveryNum)";
                SQLiteParameter[] parms =
                {
                new SQLiteParameter("@PrizeName", prizeName),
                new SQLiteParameter("@TotalNum", totalNum),
                new SQLiteParameter("@EveryNum", everyNum),
                };
                if (SQLiteHelper.ExecuteNoQuery(sqlStr, parms) > 0)
                {
                    btnCancel_Click(sender, e);
                    FormPrizeSetting_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("添加失败！！");
                    return;
                }
            }
            else
            {
                //如果是修改，则需要主键id
                int id = Convert.ToInt32(txtId.Text);
                string sqlStr = "UPDATE PrizeInfo SET PrizeName = @PrizeName,TotalNum = @TotalNum,EveryNum = @EveryNum WHERE ID=@ID";
                SQLiteParameter[] parms =
                {
                    new SQLiteParameter("@ID",id),
                    new SQLiteParameter("@PrizeName",prizeName),
                    new SQLiteParameter("@TotalNum", totalNum),
                    new SQLiteParameter("@EveryNum", everyNum)
                };
            
                if (SQLiteHelper.ExecuteNoQuery(sqlStr, parms) > 0)
                {
                    btnCancel_Click(null, null);
                    FormPrizeSetting_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("修改失败");
                    return;
                }
            }
            fm.InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtName.Text = "";
            txtTotalNum.Text = "";
            txtEveryNum.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvPrize_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //得到选中行DataGridViewRowCollection rows
            DataGridViewRow rows = dgvPrize.Rows[e.RowIndex];
            //双击单元格时，将选中的数据显示到右边的文本框中
            txtId.Text = rows.Cells["ID"].Value.ToString();
            txtName.Text = rows.Cells["PrizeName"].Value.ToString();
            txtTotalNum.Text = rows.Cells["TotalNum"].Value.ToString();
            txtEveryNum.Text = rows.Cells["EveryNum"].Value.ToString();
            btnSave.Text = "编辑";
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            DataGridViewSelectedRowCollection rows = dgvPrize.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells["ID"].Value);
                    string sqlStr = "delete from PrizeInfo where ID=@ID";
                    SQLiteParameter param = new SQLiteParameter("@ID", id);
                    if (SQLiteHelper.ExecuteNoQuery(sqlStr, param) > 0)
                    {
                        //删除成功，刷新数据
                        FormPrizeSetting_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选中任何行");
                return;
            }
            fm.InitData();
        }
    }
}
