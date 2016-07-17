namespace Line_draw
{
    partial class Drawing
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
            this.PnlDraw = new System.Windows.Forms.Panel();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPolyGon = new System.Windows.Forms.Button();
            this.BtnClearAll = new System.Windows.Forms.Button();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.BtnBackGrdColor = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlDraw
            // 
            this.PnlDraw.BackColor = System.Drawing.Color.Black;
            this.PnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDraw.Location = new System.Drawing.Point(3, 29);
            this.PnlDraw.Name = "PnlDraw";
            this.PnlDraw.Size = new System.Drawing.Size(484, 336);
            this.PnlDraw.TabIndex = 1;
            this.PnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDraw_Paint);
            this.PnlDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlDraw_MouseDown);
            this.PnlDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlDraw_MouseMove);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(493, 69);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 2;
            this.btnLine.Text = "Draw Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(493, 116);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(75, 23);
            this.btnCircle.TabIndex = 2;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(139, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(493, 157);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(75, 23);
            this.btnSquare.TabIndex = 2;
            this.btnSquare.Text = "Rectangle";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fleToolStripMenuItem
            // 
            this.fleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fleToolStripMenuItem.Name = "fleToolStripMenuItem";
            this.fleToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.fleToolStripMenuItem.Text = "Fle";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(494, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPolyGon
            // 
            this.btnPolyGon.Location = new System.Drawing.Point(493, 205);
            this.btnPolyGon.Name = "btnPolyGon";
            this.btnPolyGon.Size = new System.Drawing.Size(75, 23);
            this.btnPolyGon.TabIndex = 4;
            this.btnPolyGon.Text = "PolyGon";
            this.btnPolyGon.UseVisualStyleBackColor = true;
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.Location = new System.Drawing.Point(239, 393);
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(75, 23);
            this.BtnClearAll.TabIndex = 2;
            this.BtnClearAll.Text = "ClearAll";
            this.BtnClearAll.UseVisualStyleBackColor = true;
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // btnPenColor
            // 
            this.btnPenColor.BackColor = System.Drawing.Color.Red;
            this.btnPenColor.Location = new System.Drawing.Point(494, 244);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(73, 34);
            this.btnPenColor.TabIndex = 5;
            this.btnPenColor.Text = "Change PenColor";
            this.btnPenColor.UseVisualStyleBackColor = false;
            this.btnPenColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // BtnBackGrdColor
            // 
            this.BtnBackGrdColor.BackColor = System.Drawing.Color.White;
            this.BtnBackGrdColor.Location = new System.Drawing.Point(493, 284);
            this.BtnBackGrdColor.Name = "BtnBackGrdColor";
            this.BtnBackGrdColor.Size = new System.Drawing.Size(76, 52);
            this.BtnBackGrdColor.TabIndex = 5;
            this.BtnBackGrdColor.Text = "Change BackGround Color";
            this.BtnBackGrdColor.UseVisualStyleBackColor = false;
            this.BtnBackGrdColor.Click += new System.EventHandler(this.BtnBackGrdColor_Click);
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 428);
            this.Controls.Add(this.BtnBackGrdColor);
            this.Controls.Add(this.btnPenColor);
            this.Controls.Add(this.btnPolyGon);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSquare);
            this.Controls.Add(this.BtnClearAll);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.PnlDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Drawing";
            this.Text = "Drawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlDraw;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPolyGon;
        private System.Windows.Forms.Button BtnClearAll;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Button BtnBackGrdColor;
    }
}