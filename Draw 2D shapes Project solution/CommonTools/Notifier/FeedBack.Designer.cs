namespace CommonTools
{
    partial class FeedBack
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
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rtxtHelp = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtContent
            // 
            this.rtxtContent.Location = new System.Drawing.Point(12, 30);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.Size = new System.Drawing.Size(259, 135);
            this.rtxtContent.TabIndex = 0;
            this.rtxtContent.Text = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(40, 236);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(151, 235);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // rtxtHelp
            // 
            this.rtxtHelp.Location = new System.Drawing.Point(13, 171);
            this.rtxtHelp.Name = "rtxtHelp";
            this.rtxtHelp.ReadOnly = true;
            this.rtxtHelp.Size = new System.Drawing.Size(259, 59);
            this.rtxtHelp.TabIndex = 2;
            this.rtxtHelp.Text = "Your Feedback is valuable for us.\nPlease Submit  or\nEmail us : muthu.comp@yahoo.c" +
                "om\nContact : 9698067098";
            // 
            // FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.rtxtHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rtxtContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FeedBack";
            this.Text = "FeedBack";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox rtxtHelp;
    }
}