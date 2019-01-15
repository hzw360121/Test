namespace GoodLuck
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartOrStop = new System.Windows.Forms.Button();
            this.axMusicRoll = new AxWMPLib.AxWindowsMediaPlayer();
            this.axMusicPlay = new AxWMPLib.AxWindowsMediaPlayer();
            this.prizeName = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMusicRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMusicPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem7,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            this.contextMenuStrip1.Text = "设置";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "开始摇奖";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem7.Text = "查看获奖名单";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "名单管理";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem3.Text = "设置";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem5.Text = "背景设置";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem6.Text = "奖项设置";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem4.Text = "退出程序";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // btnStartOrStop
            // 
            this.btnStartOrStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStartOrStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartOrStop.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartOrStop.ForeColor = System.Drawing.Color.Gold;
            this.btnStartOrStop.Location = new System.Drawing.Point(463, 108);
            this.btnStartOrStop.Name = "btnStartOrStop";
            this.btnStartOrStop.Size = new System.Drawing.Size(153, 51);
            this.btnStartOrStop.TabIndex = 3;
            this.btnStartOrStop.Text = "停止";
            this.btnStartOrStop.UseVisualStyleBackColor = false;
            this.btnStartOrStop.Visible = false;
            this.btnStartOrStop.Click += new System.EventHandler(this.btnStartOrStop_Click);
            // 
            // axMusicRoll
            // 
            this.axMusicRoll.Enabled = true;
            this.axMusicRoll.Location = new System.Drawing.Point(47, 410);
            this.axMusicRoll.Name = "axMusicRoll";
            this.axMusicRoll.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMusicRoll.OcxState")));
            this.axMusicRoll.Size = new System.Drawing.Size(75, 54);
            this.axMusicRoll.TabIndex = 5;
            // 
            // axMusicPlay
            // 
            this.axMusicPlay.Enabled = true;
            this.axMusicPlay.Location = new System.Drawing.Point(47, 340);
            this.axMusicPlay.Name = "axMusicPlay";
            this.axMusicPlay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMusicPlay.OcxState")));
            this.axMusicPlay.Size = new System.Drawing.Size(75, 49);
            this.axMusicPlay.TabIndex = 4;
            // 
            // prizeName
            // 
            this.prizeName.AutoSize = true;
            this.prizeName.BackColor = System.Drawing.Color.Transparent;
            this.prizeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prizeName.Font = new System.Drawing.Font("微软雅黑", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prizeName.ForeColor = System.Drawing.Color.Gold;
            this.prizeName.Location = new System.Drawing.Point(21, 208);
            this.prizeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prizeName.Name = "prizeName";
            this.prizeName.Size = new System.Drawing.Size(0, 62);
            this.prizeName.TabIndex = 1;
            this.prizeName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1164, 732);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.axMusicRoll);
            this.Controls.Add(this.axMusicPlay);
            this.Controls.Add(this.btnStartOrStop);
            this.Controls.Add(this.prizeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMusicRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMusicPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Button btnStartOrStop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private AxWMPLib.AxWindowsMediaPlayer axMusicPlay;
        private AxWMPLib.AxWindowsMediaPlayer axMusicRoll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.Label prizeName;
    }
}

