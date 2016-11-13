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
        bool PauseRendering = false;

        #endregion

        #region Constructor

        public Drawing()
        {
            InitializeComponent();
            RenderInfo = new RenderInfo(PnlDraw);
        }

        #endregion


        #region default events
        private void PnlDraw_Paint(object sender, PaintEventArgs e)
        {
            if (!PauseRendering)
            {
                if (DrawMode)
                    RenderInfo.DrawSavedShapes();
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Line;
            DrawMode = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawMode)
            {
                if (ClicksCount % 2 == 1)
                {
                    Pt2 = e.Location;
                    RenderInfo.AddEntity(Pt1, Pt2, Mode, true);

                    //switch (Mode)
                    //{
                    //    case EntityType.Line:
                    //        RenderInfo.Graphics.DrawLine(RenderInfo.PenDraw, Pt1, Pt2);
                    //        break;

                    //    case EntityType.Ellipse:
                    //        RenderInfo.Graphics.DrawEllipse(RenderInfo.PenDraw, CommonHelper.GetRect(Pt1, Pt2));
                    //        Pen GoustPen = new Pen(Color.LawnGreen, 1f);
                    //        RenderInfo.Graphics.DrawRectangle(GoustPen, CommonHelper.GetRect(Pt1, Pt2));
                    //        break;

                    //    case EntityType.Rectangle:
                    //        RenderInfo.Graphics.DrawRectangle(RenderInfo.PenDraw, CommonHelper.GetRect(Pt1, Pt2));

                    //        break;
                    //    default:
                    //        throw new NotImplementedException();
                    //}

                }
            }
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Ellipse;
            DrawMode = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DrawMode = true;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Mode = EntityType.Rectangle;
            DrawMode = false;
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
            PauseRendering = true;
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                RenderInfo.PenColor = ColorDlg.Color;

                btnPenColor.BackColor = RenderInfo.PenColor;
            }
            PauseRendering = false;
        }

        private void BtnBackGrdColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            PauseRendering = true;
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                RenderInfo.BackgrdColor = ColorDlg.Color;
                BtnBackGrdColor.BackColor = RenderInfo.BackgrdColor;
            }
            PauseRendering = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderInfo.OpenFile();
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
        #endregion

        private void Drawing_Load(object sender, EventArgs e)
        {

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
            MessageBox.Show(RenderInfo.ShapesData.GetSaveLog());
        }
    }
}
