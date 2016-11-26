namespace CommonTools.SQLlite
{
    partial class DBinterface
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
            this.btnNonQry = new System.Windows.Forms.Button();
            this.rtxtQry = new System.Windows.Forms.RichTextBox();
            this.btnReader = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNonQry
            // 
            this.btnNonQry.Location = new System.Drawing.Point(402, 99);
            this.btnNonQry.Name = "btnNonQry";
            this.btnNonQry.Size = new System.Drawing.Size(116, 25);
            this.btnNonQry.TabIndex = 0;
            this.btnNonQry.Text = "Execute Only (F10)";
            this.btnNonQry.UseVisualStyleBackColor = true;
            this.btnNonQry.Click += new System.EventHandler(this.btnNonQry_Click);
            // 
            // rtxtQry
            // 
            this.rtxtQry.Location = new System.Drawing.Point(13, 3);
            this.rtxtQry.Name = "rtxtQry";
            this.rtxtQry.Size = new System.Drawing.Size(747, 87);
            this.rtxtQry.TabIndex = 1;
            this.rtxtQry.Text = "";
            this.rtxtQry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtQry_KeyDown);
            // 
            // btnReader
            // 
            this.btnReader.Location = new System.Drawing.Point(210, 96);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(109, 25);
            this.btnReader.TabIndex = 0;
            this.btnReader.Text = "Read Result (F9)";
            this.btnReader.UseVisualStyleBackColor = true;
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(13, 130);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(747, 274);
            this.dgvResult.TabIndex = 2;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(604, 97);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "btnCheck";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // DBinterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 416);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.rtxtQry);
            this.Controls.Add(this.btnReader);
            this.Controls.Add(this.btnNonQry);
            this.Name = "DBinterface";
            this.Text = "DBinterface";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNonQry;
        private System.Windows.Forms.RichTextBox rtxtQry;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnCheck;
    }
}