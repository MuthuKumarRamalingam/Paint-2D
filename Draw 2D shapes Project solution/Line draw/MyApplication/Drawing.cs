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

namespace Line_draw
{
    public partial class Drawing : Form
    {
        #region private variables

        ShapeData ShapeInfo = new ShapeData();
        Drawmode Mode;
        static Color PenColor = Color.Red;
        Color BackgrdColor = Color.White;
        Pen PenDraw = new Pen(PenColor, 2f);
        Point Pt1;
        Point Pt2;
        Graphics Graphics;
        Bitmap bmp;

        bool DrawMode = true;
        long ClicksCount = 0;
        bool PauseRendering = false;
        #endregion

        #region Constructor

        public Drawing()
        {
            InitializeComponent();
            bmp = new Bitmap(PnlDraw.Size.Width, PnlDraw.Size.Height);
        }

        #endregion

        #region private methods
        public static Rectangle GetRect(Point _Point1, Point _Point2)
        {
            int Width = _Point2.X - _Point1.X;
            int Height = _Point2.Y - _Point1.Y;
            if (Width < 0)
                _Point1 = new Point((_Point1.X + Width), _Point1.Y);
            if (Height < 0)
                _Point1 = new Point(_Point1.X, (_Point1.Y + Height));

            Height = Math.Abs(Height);
            Width = Math.Abs(Width);

            return new Rectangle(_Point1, new Size(Width, Height));
        }

        private void ClearGraphicsPanel()
        {
            PnlDraw.BackColor = BackgrdColor;
            bmp = new Bitmap(PnlDraw.Size.Width, PnlDraw.Size.Height);
            Graphics = Graphics.FromImage(bmp);
            //grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            //grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
        }

        private void DrawSavedShapes()
        {
            ClearGraphicsPanel();
            for (int i = 0; i < ShapeInfo.ObjLine.Point1.Count; i++)
            {
                PenDraw = new Pen(ShapeInfo.ObjLine.Color[i]);
                Graphics.DrawLine(PenDraw, ShapeInfo.ObjLine.Point1[i], ShapeInfo.ObjLine.Point2[i]);

            }

            for (int i = 0; i < ShapeInfo.ObjEllipse.Point1.Count; i++)
            {
                PenDraw = new Pen(ShapeInfo.ObjEllipse.Color[i]);
                Graphics.DrawEllipse(PenDraw, ShapeInfo.ObjEllipse.Rect(i));
            }

            for (int i = 0; i < ShapeInfo.ObjRectangle.Point1.Count; i++)
            {
                PenDraw = new Pen(ShapeInfo.ObjRectangle.Color[i]);
                Graphics.DrawRectangle(PenDraw, ShapeInfo.ObjRectangle.Rect(i));
            }
            PnlDraw.BackgroundImage = bmp;

            PenDraw = new Pen(PenColor, 2f);
        }
        #endregion

        #region default events
        private void PnlDraw_Paint(object sender, PaintEventArgs e)
        {
            if (!PauseRendering)
            {
                if (DrawMode)
                    DrawSavedShapes();
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            Mode = Drawmode.Line;
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
                    switch (Mode)
                    {
                        case Drawmode.Line:
                            ShapeInfo.ObjLine.Add(Pt1, Pt2, PenColor);
                            break;

                        case Drawmode.Ellipse:
                            ShapeInfo.ObjEllipse.Add(Pt1, Pt2, PenColor);
                            break;

                        case Drawmode.Rectangle:
                            ShapeInfo.ObjRectangle.Add(Pt1, Pt2, PenColor);
                            break;

                        case Drawmode.PolyGon:
                            break;
                    }
                    DrawSavedShapes();
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ClearGraphicsPanel();
        }

        private void PnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawMode)
            {
                if (ClicksCount % 2 == 1)
                {
                    Pt2 = e.Location;
                    DrawSavedShapes();
                    switch (Mode)
                    {
                        case Drawmode.Line:
                            Graphics.DrawLine(PenDraw, Pt1, Pt2);
                            break;

                        case Drawmode.Ellipse:
                            Graphics.DrawEllipse(PenDraw, GetRect(Pt1, Pt2));
                            Pen GoustPen = new Pen(Color.LawnGreen, 1f);
                            Graphics.DrawRectangle(GoustPen, GetRect(Pt1, Pt2));
                            break;

                        case Drawmode.Rectangle:
                            Graphics.DrawRectangle(PenDraw, GetRect(Pt1, Pt2));

                            break;

                        case Drawmode.PolyGon:
                            break;
                    }
                    PnlDraw.BackgroundImage = bmp;
                }
            }
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            Mode = Drawmode.Ellipse;
            DrawMode = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DrawMode = true;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Mode = Drawmode.Rectangle;
            DrawMode = false;
        }


        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure Clear All Shapes", "Warning", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                ShapeInfo.Clear();
                DrawMode = true;
                DrawSavedShapes();
                ClicksCount = 0;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            PauseRendering = true;
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {

                PenColor = ColorDlg.Color;
                PenDraw = new Pen(PenColor, 2f);
                btnPenColor.BackColor = PenColor;
            }
            PauseRendering = false;
        }

        private void BtnBackGrdColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            PauseRendering = true;
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                BackgrdColor = ColorDlg.Color;
                BtnBackGrdColor.BackColor = BackgrdColor;
                ClearGraphicsPanel();
            }
            PauseRendering = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeInfo.OpenFile();
            DrawSavedShapes();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeInfo.SaveFile();

            ShapeInfo.Clear();
            DrawSavedShapes();
            ClicksCount = 0;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }


}
