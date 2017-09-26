namespace Nile.Windows
{
    partial class ProductDeatailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtPrice = new System.Windows.Forms.TextBox();
            this._txtDisconnected = new System.Windows.Forms.CheckBox();
            this._txtCancel = new System.Windows.Forms.Button();
            this._txtSaved = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtName.Location = new System.Drawing.Point(88, 13);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(100, 20);
            this._txtName.TabIndex = 4;
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(88, 70);
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(100, 20);
            this._txtDescription.TabIndex = 5;
            // 
            // _txtPrice
            // 
            this._txtPrice.Location = new System.Drawing.Point(88, 123);
            this._txtPrice.Name = "_txtPrice";
            this._txtPrice.Size = new System.Drawing.Size(100, 20);
            this._txtPrice.TabIndex = 6;
            // 
            // _txtDisconnected
            // 
            this._txtDisconnected.AutoSize = true;
            this._txtDisconnected.Location = new System.Drawing.Point(88, 185);
            this._txtDisconnected.Name = "_txtDisconnected";
            this._txtDisconnected.Size = new System.Drawing.Size(104, 17);
            this._txtDisconnected.TabIndex = 7;
            this._txtDisconnected.Text = "is Discontinued?";
            this._txtDisconnected.UseVisualStyleBackColor = true;
            // 
            // _txtCancel
            // 
            this._txtCancel.Location = new System.Drawing.Point(208, 215);
            this._txtCancel.Name = "_txtCancel";
            this._txtCancel.Size = new System.Drawing.Size(75, 23);
            this._txtCancel.TabIndex = 8;
            this._txtCancel.Text = "cancel ";
            this._txtCancel.UseVisualStyleBackColor = true;
            this._txtCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _txtSaved
            // 
            this._txtSaved.Location = new System.Drawing.Point(313, 215);
            this._txtSaved.Name = "_txtSaved";
            this._txtSaved.Size = new System.Drawing.Size(75, 23);
            this._txtSaved.TabIndex = 9;
            this._txtSaved.Text = "Saved";
            this._txtSaved.UseVisualStyleBackColor = true;
            this._txtSaved.Click += new System.EventHandler(this.OnSave);
            // 
            // ProductDeatailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 245);
            this.Controls.Add(this._txtSaved);
            this.Controls.Add(this._txtCancel);
            this.Controls.Add(this._txtDisconnected);
            this.Controls.Add(this._txtPrice);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDeatailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductDeatails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtPrice;
        private System.Windows.Forms.CheckBox _txtDisconnected;
        private System.Windows.Forms.Button _txtCancel;
        private System.Windows.Forms.Button _txtSaved;
    }
}