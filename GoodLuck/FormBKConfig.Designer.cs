namespace GoodLuck
{
    partial class FormBKConfig
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBGMusic = new System.Windows.Forms.TextBox();
            this.btnBGMusic = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRollMusic = new System.Windows.Forms.TextBox();
            this.btnRollMusic = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStopMusic = new System.Windows.Forms.TextBox();
            this.btnStopMusic = new System.Windows.Forms.Button();
            this.ofdBGMusic = new System.Windows.Forms.OpenFileDialog();
            this.ofdRollMusic = new System.Windows.Forms.OpenFileDialog();
            this.ofdStopMusic = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片(*.jpg)|*.jpg|所有文件(*.*)|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "背景图片：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(251, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 21);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(86, 186);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "背景音乐：";
            // 
            // txtBGMusic
            // 
            this.txtBGMusic.Location = new System.Drawing.Point(86, 58);
            this.txtBGMusic.Margin = new System.Windows.Forms.Padding(2);
            this.txtBGMusic.Name = "txtBGMusic";
            this.txtBGMusic.ReadOnly = true;
            this.txtBGMusic.Size = new System.Drawing.Size(251, 21);
            this.txtBGMusic.TabIndex = 1;
            // 
            // btnBGMusic
            // 
            this.btnBGMusic.Location = new System.Drawing.Point(372, 58);
            this.btnBGMusic.Margin = new System.Windows.Forms.Padding(2);
            this.btnBGMusic.Name = "btnBGMusic";
            this.btnBGMusic.Size = new System.Drawing.Size(56, 20);
            this.btnBGMusic.TabIndex = 2;
            this.btnBGMusic.Text = "浏览";
            this.btnBGMusic.UseVisualStyleBackColor = true;
            this.btnBGMusic.Click += new System.EventHandler(this.btnBGMusic_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "抽奖音乐：";
            // 
            // txtRollMusic
            // 
            this.txtRollMusic.Location = new System.Drawing.Point(86, 101);
            this.txtRollMusic.Margin = new System.Windows.Forms.Padding(2);
            this.txtRollMusic.Name = "txtRollMusic";
            this.txtRollMusic.ReadOnly = true;
            this.txtRollMusic.Size = new System.Drawing.Size(251, 21);
            this.txtRollMusic.TabIndex = 1;
            // 
            // btnRollMusic
            // 
            this.btnRollMusic.Location = new System.Drawing.Point(372, 101);
            this.btnRollMusic.Margin = new System.Windows.Forms.Padding(2);
            this.btnRollMusic.Name = "btnRollMusic";
            this.btnRollMusic.Size = new System.Drawing.Size(56, 20);
            this.btnRollMusic.TabIndex = 2;
            this.btnRollMusic.Text = "浏览";
            this.btnRollMusic.UseVisualStyleBackColor = true;
            this.btnRollMusic.Click += new System.EventHandler(this.btnRollMusic_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "停止音乐：";
            // 
            // txtStopMusic
            // 
            this.txtStopMusic.Location = new System.Drawing.Point(86, 144);
            this.txtStopMusic.Margin = new System.Windows.Forms.Padding(2);
            this.txtStopMusic.Name = "txtStopMusic";
            this.txtStopMusic.ReadOnly = true;
            this.txtStopMusic.Size = new System.Drawing.Size(251, 21);
            this.txtStopMusic.TabIndex = 1;
            // 
            // btnStopMusic
            // 
            this.btnStopMusic.Location = new System.Drawing.Point(372, 144);
            this.btnStopMusic.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopMusic.Name = "btnStopMusic";
            this.btnStopMusic.Size = new System.Drawing.Size(56, 20);
            this.btnStopMusic.TabIndex = 2;
            this.btnStopMusic.Text = "浏览";
            this.btnStopMusic.UseVisualStyleBackColor = true;
            this.btnStopMusic.Click += new System.EventHandler(this.btnStopMusic_Click);
            // 
            // ofdBGMusic
            // 
            this.ofdBGMusic.FileName = "openFileDialog2";
            // 
            // ofdRollMusic
            // 
            this.ofdRollMusic.FileName = "openFileDialog3";
            // 
            // ofdStopMusic
            // 
            this.ofdStopMusic.FileName = "openFileDialog2";
            // 
            // FormBKConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 352);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStopMusic);
            this.Controls.Add(this.btnRollMusic);
            this.Controls.Add(this.btnBGMusic);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtStopMusic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRollMusic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBGMusic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBKConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "背景设置";
            this.Load += new System.EventHandler(this.FormBKConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBGMusic;
        private System.Windows.Forms.Button btnBGMusic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRollMusic;
        private System.Windows.Forms.Button btnRollMusic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStopMusic;
        private System.Windows.Forms.Button btnStopMusic;
        private System.Windows.Forms.OpenFileDialog ofdBGMusic;
        private System.Windows.Forms.OpenFileDialog ofdRollMusic;
        private System.Windows.Forms.OpenFileDialog ofdStopMusic;
    }
}