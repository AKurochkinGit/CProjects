using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flags
{
    public partial class Form1 : Form
    {
        const int ProportionX = 2, ProportionY = 3;
        public Form1()
        {
            InitializeComponent();
        }
        private bool SARflag = true;
        protected override void OnPaint(PaintEventArgs e)  //Переопределяем метод, рисующий окно
        {
            base.OnPaint(e); 
            if (SARflag)
                DrawFlag_SAR(ClientRectangle, e.Graphics);
            else
                DrawFlag_Pakistan(ClientRectangle, e.Graphics);
        }
        private void DrawFlag_SAR(Rectangle r, Graphics g) 
        {
            
            g.Clear(Color.White);

            int H = r.Height, W = r.Width; //W и H - длина и ширина окна, от которых будут зависеть координаты всех точек
            Point WN = new Point(0, 0);
            // Обработка случаев, когда окно непропорционально растянуто
           if (ProportionX * r.Width > ProportionY * r.Height) 
            {
                W = H * ProportionY / ProportionX;
                WN.X = (r.Width - W) / 2;
            }
            else if (ProportionX * r.Width < ProportionY * r.Height) 
            {
                H = W * ProportionX / ProportionY;
                WN.Y = (r.Height - H) / 2;
            }
          
           //Задаю точки, обазначающие углы фигур на флагах
             Point WS = new Point(WN.X, WN.Y + H);
           Point ES = new Point(WN.X + W, WN.Y + H);
             Point EN = new Point(WN.X + W, WN.Y);
            Point A = new Point(WN.X, ES.Y - 3 * H / 25);
            Point B = new Point(WN.X, ES.Y - H / 5);
           Point C = new Point(WN.X, WN.Y + H/5);
            Point D = new Point(WN.X, WN.Y + 3 * H / 25);
            Point E = new Point(WN.X + 3 * W / 25, WN.Y);
            Point F = new Point(WN.X + W / 5, WN.Y);
            Point L = new Point(WN.X + 3 * W / 25, ES.Y);
            Point K = new Point(WN.X + W / 5, ES.Y);
            Point O = new Point(WN.X + 3 * W / 10, WN.Y + H / 2);
            Point P = new Point(WN.X + 19 * W / 50, WN.Y + H / 2);
            Point N = new Point(WN.X + 13 * W / 25, WN.Y + 2 * H / 5);
            Point Q = new Point(WN.X + 13 * W / 25, ES.Y - 2 * H / 5);
            Point M = new Point(ES.X - 7 * W / 15, WN.Y + H / 3);
            Point R = new Point(ES.X - 7 * W / 15, ES.Y - H / 3);
            Point G = new Point(ES.X, WN.Y + H / 3);
            Point J = new Point(ES.X, ES.Y - H / 3);
            Point T = new Point(ES.X, WN.Y + 2 * H / 5);
            Point I = new Point(ES.X, ES.Y - 2 * H / 5);

            //создаю массивы, которые будут содержать углы соответствующих фигур и потом заливаться по границам
            Point[] black_part = new Point[3];
            Point[] blue_part = new Point[4];
            Point[] red_part = new Point[4];
            Point[] green_part = new Point[11];
            Point[] yellow_part = new Point[6];
            //Заношу углы в массивы
            black_part[0] = C; black_part[1] = O; black_part[2] = B;
            blue_part[0] = K; blue_part[1] = R; blue_part[2] = J; blue_part[3] = ES;
            red_part[0] = F; red_part[1] = EN; red_part[2] = G; red_part[3] = M;
            green_part[0] = T; green_part[1] = N; green_part[2] = E; green_part[3] = WN;
            green_part[4] = D; green_part[5] = P; green_part[6] = A; green_part[7] = WS;
            green_part[8] = L; green_part[9] = Q; green_part[10] = I;
            yellow_part[0] = D; yellow_part[1] = P; yellow_part[2] = A; yellow_part[3] = B;
            yellow_part[4] = O; yellow_part[5] = C;
            SolidBrush brush = new SolidBrush(Color.Gray);   
            Pen pen = new Pen(brush);// создаю перо 
            g.FillRectangle(brush, WN.X, WN.Y, W, H); // заливаем фон флага
            brush.Color = Color.Black;
            g.FillPolygon(brush, black_part); // заливаем массивы по границам, определённым занесёнными в них точками
            brush.Color = Color.FromArgb(224, 60, 49);
            g.FillPolygon(brush, red_part);
            brush.Color = Color.FromArgb(0, 20, 137);
            g.FillPolygon(brush, blue_part);
            brush.Color = Color.FromArgb(0, 119, 73);
            g.FillPolygon(brush, green_part);
            brush.Color = Color.FromArgb(255, 184, 28);
            g.FillPolygon(brush, yellow_part);
          
        }
        private void DrawFlag_Pakistan(Rectangle r, Graphics g)
        {
            g.Clear(Color.White);

            int H = r.Height, W = r.Width;
            Point WN = new Point(0, 0);
            // Обработка случаев, когда окно непропорционально растянуто
            if (ProportionX * r.Width > ProportionY * r.Height) 
            {
                W = H * ProportionY / ProportionX;
                WN.X = (r.Width - W) / 2;
            }
            else if (ProportionX * r.Width < ProportionY * r.Height) 
            {
                H = W * ProportionX / ProportionY;
                WN.Y = (r.Height - H) / 2;
            }

            
            Point WS = new Point(WN.X, WN.Y + H);     
            Point ES = new Point(WN.X + W, WN.Y + H);
            Point EN = new Point(WN.X + W, WN.Y);
            Point C1 = new Point(WN.X + 5 * W / 8, WN.Y + H / 2);
           //часть, нужная для вычисления угла наклона звезды
            double alpha = Math.Atan2(8, 9);
            double cosal = Math.Cos(alpha);
            double sinal = Math.Sin(alpha);
            double C2x = WN.X + W - cosal * 13 * H / 20;
            double C2y = WN.Y + sinal * 13 * H / 20;
            float RadC2 = (float)11 * H / 40; // для полумесяца нужно два круга, здесь их радиусы
            float RadC1 = (float)3 * H / 10; 
            float RadC3 = (float)H / 10; 
            double RecC2x = C2x - RadC2;
            double RecC2y = C2y - RadC2;
            double RecC1x = C1.X - RadC1;
            double RecC1y = C1.Y - RadC1;
            double RotY = 11 * H / 20 * sinal; //углы поворота звезды
            double RotX = W - 11 * H / 20 * cosal; 

            alpha += 21 * Math.PI / 20;

            Point A = new Point((int)Math.Round(WN.X - RadC3 * Math.Sin(alpha) + RotX), (int)Math.Round(WN.Y + RadC3 * Math.Cos(alpha) + RotY));
            Point B = new Point((int)Math.Round(WN.X - RadC3 * Math.Sin(4 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y + RadC3 * Math.Cos(4 * Math.PI / 10 + alpha) + RotY));
            Point C = new Point((int)Math.Round(WN.X - RadC3 * Math.Sin(8 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y + RadC3 * Math.Cos(8 * Math.PI / 10 + alpha) + RotY));
            Point D = new Point((int)Math.Round(WN.X - RadC3 * Math.Sin(12 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y + RadC3 * Math.Cos(12 * Math.PI / 10 + alpha) + RotY));
            Point E = new Point((int)Math.Round(WN.X - RadC3 * Math.Sin(16 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y + RadC3 * Math.Cos(16 * Math.PI / 10 + alpha) + RotY));
            double m = RadC3 * Math.Sin(Math.PI / 10) / Math.Cos(2 * Math.PI / 10);
            Point F = new Point((int)Math.Round(WN.X + m * Math.Sin(12 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y - m * Math.Cos(12 * Math.PI / 10 + alpha) + RotY));
            Point G = new Point((int)Math.Round(WN.X + m * Math.Sin(16 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y - m * Math.Cos(16 * Math.PI / 10 + alpha) + RotY));
            Point I = new Point((int)Math.Round(WN.X + m * Math.Sin(alpha) + RotX), (int)Math.Round(WN.Y - m * Math.Cos(alpha) + RotY));
            Point J = new Point((int)Math.Round(WN.X + m * Math.Sin(4 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y - m * Math.Cos(4 * Math.PI / 10 + alpha) + RotY));
            Point K = new Point((int)Math.Round(WN.X + m * Math.Sin(8 * Math.PI / 10 + alpha) + RotX), (int)Math.Round(WN.Y - m * Math.Cos(8 * Math.PI / 10 + alpha) + RotY));

            Point[] star = new Point[10];  // создаём массив и заносим точки звезды
            star[0] = A; star[1] = F; star[2] = B; star[3] = G; star[4] = C; star[5] = I; star[6] = D;
            star[7] = J; star[8] = E; star[9] = K;


            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(brush);
            brush.Color = Color.FromArgb(1, 65, 28);
            g.FillRectangle(brush, WN.X, WN.Y, W, H);
            brush.Color = Color.White;
            g.FillRectangle(brush, WN.X, WN.Y, W / 4, H);
            
            g.FillEllipse(brush, (float)RecC1x, (float)RecC1y, 2 * RadC1, 2 * RadC1); // рисуем белый круг
            brush.Color = Color.FromArgb(1, 65, 28);
            pen.Color = Color.FromArgb(1, 65, 28);
  
            g.FillEllipse(brush, (float)RecC2x, (float)RecC2y, 2 * RadC2, 2 * RadC2); //рисуем зелёный круг
            brush.Color = Color.White;
            g.FillPolygon(brush, star); //заполняем звезду
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void buttonSAR_Click(object sender, EventArgs e)
        {
            SARflag = true;
            Invalidate();
        }

        private void buttonPakistan_Click(object sender, EventArgs e)
        {
            SARflag = false;
            Invalidate();
        }
    }
}
