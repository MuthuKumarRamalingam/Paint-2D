using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using CommonTools;


namespace MyPaint
{
    public partial class Drawing : Form
    {
        #region private variables

        RenderInfo RenderInfo;
        EntityType Mode;

        Point Pt1;
        Point Pt2;

        bool DrawMode = true;
        long ClicksCount = 0;

        #endregion

        #region Constructor

        public Drawing()
        {
            InitializeComponent();
            RenderInfo = new RenderInfo(PnlDraw);
        }

        #endregion


        private void PnlDraw_Paint(object sender, PaintEventArgs e)
        {
            if (DrawMode)
                RenderInfo.DrawSavedShapes();

        }

        private void PnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (!DrawMode)
            {
                ClicksCount++;
                if (ClicksCount % 2 == 1)
                {
                    Pt1 = e.Location;
                }
                else
                {
                    Pt2 = e.Location;
                    RenderInfo.AddEntity(Pt1, Pt2, Mode);
                }
            }
        }

        private void PnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawMode)
            {
                if (ClicksCount % 2 == 1)
                {
                    Pt2 = e.Location;
                    RenderInfo.AddEntity(Pt1, Pt2, Mode, true);
                }
            }
        }


        private void btnLine_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Line;
            DrawMode = false;

        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Ellipse;
            DrawMode = false;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Rectangle;
            DrawMode = false;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DrawMode = true;
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure Clear All Shapes", "Warning", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                RenderInfo.ClearAll();
                DrawMode = true;
                ClicksCount = 0;
            }
        }



        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();

            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                RenderInfo.PenColor = ColorDlg.Color;

                btnPenColor.BackColor = RenderInfo.PenColor;
            }

        }

        private void BtnBackGrdColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();

            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                RenderInfo.BackgrdColor = ColorDlg.Color;
                BtnBackGrdColor.BackColor = ColorDlg.Color;
            }

        }




        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderInfo.OpenFile();
            ClicksCount = 0;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderInfo.SaveFile();
            ClicksCount = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About aboutObj = new About())
            {
                aboutObj.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RenderInfo.fileDatas.GetSaveLog());
        }

        private void feedBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mailer.ShowFeedback();
        }

        private void Drawing_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mailer.ShowFeedback();
        }
    }
}
