using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool paint = false, circle = false, rectangle = false, triangle = false;
        float x = 0, y = 0, eX, eY;
        Point LastPoint = new Point();
        Point NewPoint = new Point();
        Graphics graphics;
        Pen myPen = new Pen(Color.Black, 1);
        Brush myBrush = new SolidBrush(Color.Black); 
        ColorDialog dlg;
        public Form1()
        {
            InitializeComponent();
            graphics = panelPlatno.CreateGraphics();
            myPen = new Pen(Color.Black, 7);
            
        }

        private void panelPlatno_Paint(object sender, PaintEventArgs e)
        {
            if (sender == buttonClear)
            {
                myPen.Color = Color.Empty;
                graphics.DrawRectangle(myPen, 0, 0, 900, 620);
                myPen.Color = buttonColor.BackColor;
            }

        }

        private void panelPlatno_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panelPlatno_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            x = e.X; 
            y = e.Y;
            
        }

        private void panelPlatno_MouseUp(object sender, MouseEventArgs e)
        {
            if (circle == true && paint == true)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (e.X - x > e.Y - y)
                    {
                        graphics.DrawEllipse(myPen, x, y, e.X - x, e.X - x);
                    }
                    else
                    {
                        graphics.DrawEllipse(myPen, x, y, e.Y - y, e.Y - y);
                    }
                }
                else
                {
                    graphics.DrawEllipse(myPen, x, y, e.X - x, e.Y - y);
                }
            }
            else if (rectangle == true && paint == true)
            {
                 if (Control.ModifierKeys == Keys.Shift)
                 {
                    if (e.X - x > e.Y - y)
                    {
                        graphics.DrawRectangle(myPen, x, y, e.X - x, e.X - x);
                    }
                    else
                    {
                        graphics.DrawRectangle(myPen, x, y, e.Y - y, e.Y - y);
                    }
                 }
                 else
                 {
                    graphics.DrawRectangle(myPen, x, y, e.X - x, e.Y - y);
                 }
            }
            paint = false;
        }
        private void panelPlatno_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X;
            eY = e.Y;
            if (paint== true && x!=0 && y!=0 && circle == false && rectangle == false && triangle == false)
            {
                graphics.DrawLine(myPen, x, y, e.X, e.Y);
                graphics.FillEllipse(myBrush, x-trackBar1.Value*2, y-trackBar1.Value*2, trackBar1.Value*4, trackBar1.Value*4);
                x = e.X;
                y = e.Y;
            }
        }

        private void buttonPen_Click(object sender, EventArgs e)
        {
            circle = false;
            rectangle = false;
            triangle = false;
            myPen.Color = buttonColor.BackColor;
            myBrush = new SolidBrush(buttonColor.BackColor);

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            dlg = new ColorDialog();
            dlg.AllowFullOpen = true;
            dlg.Color = buttonColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = dlg.Color;
            }
            myPen.Color = dlg.Color;
            myBrush = new SolidBrush(dlg.Color);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            panelPlatno.Refresh();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(panelPlatno .Width, panelPlatno.Height);
            panelPlatno.DrawToBitmap(bm, new Rectangle(0, 0, panelPlatno.Width, panelPlatno.Height));
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sf.ShowDialog();
            var path = sf.FileName;
            try
            {
                bm.Save(path, ImageFormat.Bmp);
            }
            catch (Exception)
            {
                MessageBox.Show("Neplatný formát");
                throw;
            }
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            circle = true;
            rectangle = false; 
            triangle = false;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            circle = false;
            rectangle = true;
            triangle = false;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            circle = false;
            rectangle = false;
            triangle = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            myPen.Width = trackBar1.Value*4;
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            circle = false;
            rectangle = false;
            triangle = false;
            myPen.Color = Color.White;
            myBrush = new SolidBrush(Color.White);
        }

        private void buttonPencil_Click(object sender, EventArgs e)
        {
            circle = false;
            rectangle = false;
            triangle = false;
        }
    }
}
