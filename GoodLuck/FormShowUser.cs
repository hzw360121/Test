using GoodLuck.Model;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodLuck
{
    public partial class FormShowUser : Form
    {
        public FormShowUser()
        {
            InitializeComponent();
        }
        FormMain fm = new FormMain();
        public FormShowUser(FormMain f)
        {
            fm = f;
            InitializeComponent();
        }

        private void FormShowUser_Load(object sender, EventArgs e)
        {


            DataSet dt = SQLiteHelper.ExecuteDataSet(SQLiteHelper.Conn, "Select ID,UserName,UserPhone from UserInfo", null);

            this.dgvUser.DataSource = dt.Tables[0];

            int index = 0;

            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
            colCB.HeaderCell = cbHeader;
            colCB.HeaderText = "全选";
            colCB.Name = "AllSelect";
            cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            dgvUser.Columns.Insert(index, colCB);

            index++;
            dgvUser.Columns[index].HeaderText = "编号";
            dgvUser.Columns[index].Width = 80;
            dgvUser.Columns[index].Visible = false;

            index++;
            dgvUser.Columns[index].HeaderText = "姓名";
            dgvUser.Columns[index].Width = 120;

            index++;
            dgvUser.Columns[index].HeaderText = "手机号";
            dgvUser.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUser.AllowUserToAddRows = false;
        }

        private void btnImportUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFilePath.Text))
            {
                MessageBox.Show("请选择要导入的名单文件");
                return;
            }
            int iRecords = 0;

            iRecords = FastInsertUser(this.txtFilePath.Text);

            MessageBox.Show("本次共导入记录数：" + iRecords.ToString());
            fm.InitData();
            FormShowUser_Load(sender, e);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            StringBuilder sbUserId = new StringBuilder(20);
            if (dgvUser.Rows.Count > 0)
            {
                for (int i = 0; i < dgvUser.Rows.Count; i++)
                {
                    string _selectValue = dgvUser.Rows[i].Cells["AllSelect"].EditedFormattedValue.ToString();
                    if (_selectValue == "True") sbUserId.Append(dgvUser.Rows[i].Cells["ID"].Value + ",");
                }
            }
            if (sbUserId.Length > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) return;

                sbUserId.Replace(",", string.Empty, sbUserId.Length - 1, 1);//移除最后一个,
                string sqlStr = "DELETE FROM UserInfo WHERE ID IN (" + sbUserId.ToString() + ")";
                int id = SQLiteHelper.ExecuteNoQuery(sqlStr, null);
                FormShowUser_Load(sender, e);
            }
            else
            {
                MessageBox.Show("没有选择要删除的项！！");
                return;
            }
            fm.InitData();
        }

        private void cbHeader_OnCheckBoxClicked(bool state)
        {
            //这一句很重要结束编辑状态
            dgvUser.EndEdit();
            dgvUser.Rows.OfType<DataGridViewRow>().ToList().ForEach(t => t.Cells[0].Value = state);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            DialogResult rtn = openFileDialog1.ShowDialog();

            if (rtn == DialogResult.OK)
            {

                string fName = openFileDialog1.FileName;
                this.txtFilePath.Text = fName;
                //this.pictureBox1.Load(fName);
                //img = openFileDialog1.FileName;
            }
        }

        /// <summary> 
        /// 读一个文件写入到数据库 
        /// </summary> 
        /// <param name="filePath">要导入的文件名</param> 
        /// <returns>导入成功的记录数</returns>        
        public int FastInsertUser(string filePath)
        {
            int iRecords = 0;
            var excelfile = new ExcelQueryFactory(filePath);
            var excel = excelfile.Worksheet(0);
            var query = from p in excel
                        select p;
            using (SQLiteConnection connection = new SQLiteConnection(SQLiteHelper.Conn))
            {
                connection.Open();
                //采用显式事务，插入快很多！
                using (DbTransaction dbTrans = connection.BeginTransaction())
                {
                    using (DbCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            string sql = "INSERT INTO UserInfo(";
                            string sqlPrm = "";
                            foreach (var propertyName in typeof(UserInfo).GetProperties()) //注意：按照属性的顺序取值
                            {
                                sql = sql + propertyName.Name + ",";
                                sqlPrm = sqlPrm + "?,";
                            }
                            cmd.CommandText = sql.Remove(sql.Length - 1, 1) + ") VALUES(" + sqlPrm.Remove(sqlPrm.Length - 1, 1) + ")";

                            DbParameter[] fild = new DbParameter[typeof(UserInfo).GetProperties().Count()];
                            for (int i = 0; i < typeof(UserInfo).GetProperties().Count(); i++)
                            {
                                fild[i] = cmd.CreateParameter();
                                cmd.Parameters.Add(fild[i]);
                            }
                            foreach (var record in query)
                            {
                                fild[0].Value = record[0];
                                fild[1].Value = record[1];
                                fild[2].Value = record[2];
                                cmd.ExecuteNonQuery();
                                iRecords++;
                            }
                            dbTrans.Commit();
                        }
                        catch(Exception ex)
                        {
                            iRecords = 0;
                            dbTrans.Rollback();
                            MessageBox.Show("导入失败！！" + ex.Message);
                        }

                    }
                }
            }



            foreach (var item in query)
            {
                // Console.WriteLine("Name is {0}", item[0].Value.ToString());
            }
            return iRecords;
        }
    }


    public delegate void CheckBoxClickedHandler(bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }
    }
}
