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
    public partial class FormShowWinner : Form
    {
        public FormShowWinner()
        {
            InitializeComponent();
        }

        private void FormShowWinner_Load(object sender, EventArgs e)
        {
            string sqlStr = "select prizeName,winner,winnerPhone,totalNum from prizeinfo A inner join Winners B on A.ID = B.prizeid and B.DateFlag = @DateFlag";
            SQLiteParameter a = new SQLiteParameter("@DateFlag", DateTime.Now.ToString("yyyy-MM-dd"));
            DataTable dt = SQLiteHelper.GetList(sqlStr, a);
            dgvWinners.DataSource = dt;

        }

        private void btnExportWinners_Click(object sender, EventArgs e)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + "获奖名单";
            ExportExcels(fileName, this.dgvWinners);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="myDGV">控件DataGridView</param>
        private void ExportExcels(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "*.xls|*.xlsx";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机器未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("获奖名单保存成功！！ ", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK) return;
            string sqlStr = "delete from winners";
            SQLiteParameter a = new SQLiteParameter("@DateFlag", DateTime.Now.ToString("yyyy-MM-dd"));
            int resultCount = SQLiteHelper.ExecuteNoQuery(sqlStr, null);
            if (resultCount > 0)
            {
                MessageBox.Show("删除成功！共删除" + resultCount + "条记录！！");
                FormShowWinner_Load(sender, e);
            }
            else
                MessageBox.Show("删除失败!");
        }
    }
}
