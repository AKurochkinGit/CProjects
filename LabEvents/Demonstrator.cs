using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace LabEvents
{

    class Demonstrator
    {
        public Calculator calculator = new Calculator();
        public int delay;
        public int radius;
        public int maxX;
        public int maxY;
        public bool isShooting = true;
        public int x = 0, y = 0;

       

        public Demonstrator(int _restTime)
        {
            this.calculator.restTime = _restTime;
            this.stopCalculation += calculator.isWork; //когда вычисления прекращены вызывается isWork  с параметром false
            calculator.calculationFinished += this.Display;//подписываем вывод демонстратора на работу калькулятора
        }
         public delegate void StopShooting(bool ish);
        public event StopShooting stopShooting;
        public Demonstrator(int _delay, int _radius, int _maxX, int _maxY)
        {
            this.stopShooting += this.IsShooting;
            delay = _delay;
            radius = _radius;
            maxX = _maxX;
            maxY = _maxY;
        }

       
        //передача форме результатов вычислений
        public delegate void DisplayThis(string text);
        public event DisplayThis display;
        public void Display(int _result, int bb, int ub)
        {
            if (_result != 0)
            {
                display?.Invoke("Максимальное странное число на интервале [" + bb.ToString() + ", " + ub.ToString() + "]: " + _result.ToString() + ".");
            }
            else
            {
                display?.Invoke("На интервале [" + bb.ToString() + ", " + ub.ToString() + "] нет странных чисел.");
            }
        }
        //передача калькулятору события завершения вычислений
        public delegate void StopCalculation(bool iw);
        public event StopCalculation stopCalculation;
       
        public void StopWork()
        {
            stopCalculation?.Invoke(false);
        }

        /// ///////////////////////////////////////////////////////////////////////////////
       
       
        public int TranslateX(int _x, PictureBox pictureBox1)
        {
            return _x + pictureBox1.Width / 2;
        }

        public int TranslateY(int _y, PictureBox pictureBox1)
        {
            return _y + pictureBox1.Height / 2;
        }
        public void Shoot(Graphics g, PictureBox pictureBox1)
        {
            Random rnd = new Random();
             x = TranslateX(rnd.Next(-maxX, maxX), pictureBox1);
             y = TranslateY(rnd.Next(-maxY, maxY), pictureBox1);
           // Thread.Sleep((int)delay);
        }
        public void IsShooting(bool ish)
        {
            isShooting = ish;
        }


        public void StopShoot()
        {
            stopShooting?.Invoke(false);
        }


        public void DrawHit(Graphics g, PictureBox pictureBox1, int propW, int propH)
        {
            int H = pictureBox1.Height;
            int W = pictureBox1.Width;
            SolidBrush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(brush);


            g.FillRectangle(brush, W / 2, H / 2 - radius / propH, propW * radius, radius / propH);
            Color brushColor = Color.FromArgb(250, 0, 0, 0);
            SolidBrush brush2 = new SolidBrush(Color.White);
            g.FillEllipse(brush2, W / 2 - radius, H / 2 - radius, radius * 2 + 1, radius * 2 + 1);
            g.DrawEllipse(pen, W / 2 - radius, H / 2 - radius, radius * 2, radius * 2);
            g.DrawRectangle(pen, W / 2 - propW * radius, H / 2 - radius / propH, 2 * propW * radius, 2 * radius / propH);

            Point A = new Point(W / 2 - radius, H / 2);
            int cross1 = W / 2 - radius;
            int cross2 = W / 2 - radius;
            for (int i = W / 2 - radius; i < W / 2; i++)
            {
                cross1 = i;
                if ((i - W / 2) * (i - W / 2) + (radius / propH) * (radius / propH) < radius * radius)
                {
                    break;
                }
            }
            for (int i = W / 2 - radius; i < W / 2; i++)
            {
                cross2 = i;
                if ((i - W / 2) * (i - W / 2) + (radius / (2 * propH)) * (radius / (2 * propH)) < radius * radius)
                {
                    break;
                }
            }
            Point B = new Point(cross2, H / 2 + radius / (2 * propH) + 1);
            Point C = new Point(cross1, H / 2 + radius / propH + 1);
            Point D = new Point(W / 2, H / 2 + radius / propH);
            Point O = new Point(W / 2, H / 2);
            Point[] zone2 = new Point[5];
            zone2[0] = A; zone2[1] = B; zone2[2] = C; zone2[3] = D; zone2[4] = O;
            g.FillPolygon(brush, zone2);
            SolidBrush brush3 = new SolidBrush(Color.Red);
            g.FillEllipse(brush3, x-5, y-5, 10, 10);
        }

        public void DrawDPSK(Graphics g, PictureBox pictureBox1)
        {
            int H = pictureBox1.Height;
            int W = pictureBox1.Width;
            Point O = new Point(W / 2, H / 2);
            Point A = new Point(W / 2, 0);
            Point B = new Point(W, H / 2);
            Point C = new Point(W / 2, H);
            Point D = new Point(0, H / 2);
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            g.DrawLine(pen, A, C);
            g.DrawLine(pen, B, D);
        }

    }
}
