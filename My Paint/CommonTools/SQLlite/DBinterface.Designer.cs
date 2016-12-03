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
            this.grpConnectionString = new System.Windows.Forms.GroupBox();
            this.rbtnDBpath = new System.Windows.Forms.RadioButton();
            this.txtDBpath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnConnectionString = new System.Windows.Forms.RadioButton();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.grpConnectionString.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNonQry
            // 
            this.btnNonQry.Location = new System.Drawing.Point(401, 202);
            this.btnNonQry.Name = "btnNonQry";
            this.btnNonQry.Size = new System.Drawing.Size(116, 25);
            this.btnNonQry.TabIndex = 0;
            this.btnNonQry.Text = "Execute Only (F10)";
            this.btnNonQry.UseVisualStyleBackColor = true;
            this.btnNonQry.Click += new System.EventHandler(this.btnNonQry_Click);
            // 
            // rtxtQry
            // 
            this.rtxtQry.Location = new System.Drawing.Point(12, 106);
            this.rtxtQry.Name = "rtxtQry";
            this.rtxtQry.Size = new System.Drawing.Size(747, 87);
            this.rtxtQry.TabIndex = 1;
            this.rtxtQry.Text = "";
            this.rtxtQry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtQry_KeyDown);
            // 
            // btnReader
            // 
            this.btnReader.Location = new System.Drawing.Point(209, 199);
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
            this.dgvResult.Location = new System.Drawing.Point(12, 233);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(747, 274);
            this.dgvResult.TabIndex = 2;
            // 
            // grpConnectionString
            // 
            this.grpConnectionString.Controls.Add(this.btnBrowse);
            this.grpConnectionString.Controls.Add(this.txtConnectionString);
            this.grpConnectionString.Controls.Add(this.rbtnConnectionString);
            this.grpConnectionString.Controls.Add(this.txtDBpath);
            this.grpConnectionString.Controls.Add(this.rbtnDBpath);
            this.grpConnectionString.Location = new System.Drawing.Point(13, 13);
            this.grpConnectionString.Name = "grpConnectionString";
            this.grpConnectionString.Size = new System.Drawing.Size(740, 74);
            this.grpConnectionString.TabIndex = 3;
            this.grpConnectionString.TabStop = false;
            this.grpConnectionString.Text = "Connection";
            // 
            // rbtnDBpath
            // 
            this.rbtnDBpath.AutoSize = true;
            this.rbtnDBpath.Location = new System.Drawing.Point(31, 20);
            this.rbtnDBpath.Name = "rbtnDBpath";
            this.rbtnDBpath.Size = new System.Drawing.Size(64, 17);
            this.rbtnDBpath.TabIndex = 0;
            this.rbtnDBpath.TabStop = true;
            this.rbtnDBpath.Text = "DB path";
            this.rbtnDBpath.UseVisualStyleBackColor = true;
            // 
            // txtDBpath
            // 
            this.txtDBpath.Location = new System.Drawing.Point(137, 19);
            this.txtDBpath.Name = "txtDBpath";
            this.txtDBpath.Size = new System.Drawing.Size(416, 20);
            this.txtDBpath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(567, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Query Here";
            // 
            // rbtnConnectionString
            // 
            this.rbtnConnectionString.AutoSize = true;
            this.rbtnConnectionString.Location = new System.Drawing.Point(31, 40);
            this.rbtnConnectionString.Name = "rbtnConnectionString";
            this.rbtnConnectionString.Size = new System.Drawing.Size(106, 17);
            this.rbtnConnectionString.TabIndex = 0;
            this.rbtnConnectionString.TabStop = true;
            this.rbtnConnectionString.Text = "ConnectionString";
            this.rbtnConnectionString.UseVisualStyleBackColor = true;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(137, 42);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(505, 20);
            this.txtConnectionString.TabIndex = 1;
            // 
            // DBinterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpConnectionString);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.rtxtQry);
            this.Controls.Add(this.btnReader);
            this.Controls.Add(this.btnNonQry);
            this.Name = "DBinterface";
            this.Text = "DBinterface";
            this.Load += new System.EventHandler(this.DBinterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.grpConnectionString.ResumeLayout(false);
            this.grpConnectionString.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNonQry;
        private System.Windows.Forms.RichTextBox rtxtQry;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.GroupBox grpConnectionString;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.RadioButton rbtnConnectionString;
        private System.Windows.Forms.TextBox txtDBpath;
        private System.Windows.Forms.RadioButton rbtnDBpath;
        private System.Windows.Forms.Label label1;
    }
}