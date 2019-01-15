namespace GoodLuck
{
    partial class FormShowWinner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvWinners = new System.Windows.Forms.DataGridView();
            this.PrizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Winner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinnerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportWinners = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinners)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWinners
            // 
            this.dgvWinners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrizeName,
            this.Winner,
            this.WinnerPhone,
            this.TotalNum});
            this.dgvWinners.Location = new System.Drawing.Point(12, 30);
            this.dgvWinners.Name = "dgvWinners";
            this.dgvWinners.ReadOnly = true;
            this.dgvWinners.RowHeadersVisible = false;
            this.dgvWinners.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvWinners.RowTemplate.Height = 23;
            this.dgvWinners.Size = new System.Drawing.Size(424, 398);
            this.dgvWinners.TabIndex = 0;
            // 
            // PrizeName
            // 
            this.PrizeName.DataPropertyName = "PrizeName";
            this.PrizeName.HeaderText = "奖项";
            this.PrizeName.Name = "PrizeName";
            this.PrizeName.ReadOnly = true;
            // 
            // Winner
            // 
            this.Winner.DataPropertyName = "Winner";
            this.Winner.HeaderText = "获奖人";
            this.Winner.Name = "Winner";
            this.Winner.ReadOnly = true;
            // 
            // WinnerPhone
            // 
            this.WinnerPhone.DataPropertyName = "WinnerPhone";
            this.WinnerPhone.HeaderText = "手机号";
            this.WinnerPhone.Name = "WinnerPhone";
            this.WinnerPhone.ReadOnly = true;
            // 
            // TotalNum
            // 
            this.TotalNum.DataPropertyName = "TotalNum";
            this.TotalNum.HeaderText = "总数";
            this.TotalNum.Name = "TotalNum";
            this.TotalNum.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrizeName";
            this.dataGridViewTextBoxColumn1.HeaderText = "奖项";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Winner";
            this.dataGridViewTextBoxColumn2.HeaderText = "获奖人";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TotalNum";
            this.dataGridViewTextBoxColumn3.HeaderText = "总数";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnExportWinners
            // 
            this.btnExportWinners.Location = new System.Drawing.Point(442, 30);
            this.btnExportWinners.Name = "btnExportWinners";
            this.btnExportWinners.Size = new System.Drawing.Size(95, 39);
            this.btnExportWinners.TabIndex = 1;
            this.btnExportWinners.Text = "导出获奖名单";
            this.btnExportWinners.UseVisualStyleBackColor = true;
            this.btnExportWinners.Click += new System.EventHandler(this.btnExportWinners_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(442, 96);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 39);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除所有记录";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormShowWinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 455);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExportWinners);
            this.Controls.Add(this.dgvWinners);
            this.Name = "FormShowWinner";
            this.Text = "FormShowWinner";
            this.Load += new System.EventHandler(this.FormShowWinner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinners)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWinners;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnExportWinners;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Winner;
        private System.Windows.Forms.DataGridViewTextBoxColumn WinnerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNum;
        private System.Windows.Forms.Button btnDelete;
    }
}