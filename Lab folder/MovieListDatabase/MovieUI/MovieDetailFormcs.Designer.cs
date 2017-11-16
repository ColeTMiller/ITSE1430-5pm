namespace MovieUI
{
    partial class MovieDetailFormcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this._txtTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._chkOwn = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._txtEpisode = new System.Windows.Forms.TextBox();
            this._txtTime = new System.Windows.Forms.TextBox();
            this._btSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtTitle
            // 
            this._txtTitle.AutoSize = true;
            this._txtTitle.Location = new System.Drawing.Point(13, 13);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(33, 13);
            this._txtTitle.TabIndex = 0;
            this._txtTitle.Text = "Title: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Episode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time";
            // 
            // _chkOwn
            // 
            this._chkOwn.AutoSize = true;
            this._chkOwn.Location = new System.Drawing.Point(69, 141);
            this._chkOwn.Name = "_chkOwn";
            this._chkOwn.Size = new System.Drawing.Size(57, 17);
            this._chkOwn.TabIndex = 3;
            this._chkOwn.Text = "Own? ";
            this._chkOwn.UseVisualStyleBackColor = true;
            this._chkOwn.CheckedChanged += new System.EventHandler(this._chkOwn_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _txtEpisode
            // 
            this._txtEpisode.Location = new System.Drawing.Point(69, 46);
            this._txtEpisode.Multiline = true;
            this._txtEpisode.Name = "_txtEpisode";
            this._txtEpisode.Size = new System.Drawing.Size(192, 40);
            this._txtEpisode.TabIndex = 5;
            this._txtEpisode.TextChanged += new System.EventHandler(this._txtEpisode_TextChanged);
            // 
            // _txtTime
            // 
            this._txtTime.Location = new System.Drawing.Point(69, 99);
            this._txtTime.Name = "_txtTime";
            this._txtTime.Size = new System.Drawing.Size(100, 20);
            this._txtTime.TabIndex = 6;
            this._txtTime.TextChanged += new System.EventHandler(this._txtTime_TextChanged);
            // 
            // _btSave
            // 
            this._btSave.Location = new System.Drawing.Point(83, 226);
            this._btSave.Name = "_btSave";
            this._btSave.Size = new System.Drawing.Size(75, 23);
            this._btSave.TabIndex = 7;
            this._btSave.Text = "Save";
            this._btSave.UseVisualStyleBackColor = true;
            this._btSave.Click += new System.EventHandler(this._btSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(197, 226);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 8;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // MovieDetailFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btSave);
            this.Controls.Add(this._txtTime);
            this.Controls.Add(this._txtEpisode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._chkOwn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtTitle);
            this.Name = "MovieDetailFormcs";
            this.Text = "MovieDetailFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _chkOwn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox _txtEpisode;
        private System.Windows.Forms.TextBox _txtTime;
        private System.Windows.Forms.Button _btSave;
        private System.Windows.Forms.Button _btnCancel;
    }
}