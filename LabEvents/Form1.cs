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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private Thread threadCalc;
        private Thread threadDraw;
            int restTime;
            int delay = 3000;
            int radius = 75; 
            int maxX = 200;
            int maxY = 100;
        private Demonstrator demonstrator_Counter;
        private Demonstrator demonstrator_Drawer = new Demonstrator (1000, 75, 400, 400);
        //принятие данных
      
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (int.TryParse(textBox1.Text, out restTime))
            {
                if (restTime >= 0)
                {
                    //создание демонстратора с калькулятором внутри, подписка на событие, создание потока
                    button1.Enabled = true;
                    button2.Enabled = false;
                    demonstrator_Counter = new Demonstrator(restTime);
                    demonstrator_Counter.display += this.Display; //подписываем вывод на соытие работы демонстратора

                        threadCalc = new Thread(new ThreadStart(delegate ()
                        {
                            while (demonstrator_Counter.calculator.iswork)    // пока в  через событие stopCalculation не передалось false вычисления не прервутся
                            {
                                demonstrator_Counter.calculator.Work();
                            }
                        }));
                        threadCalc.Start();
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Время отдыха - неотрицательное число!");
                }

            }
            else
            {
                textBox1.Clear();
                MessageBox.Show("Время отдыха - неотрицательное число!");
            }
        }
        //вывод результата вычисления
        private void Display(string text)
        {
            label1.Invoke((MethodInvoker)(() => label1.Text = text));
        }
        //завершение вычислений
        private void button1_Click(object sender, EventArgs e)
        {
            demonstrator_Counter.StopWork(); // Stop Work передает в isWork false и вычисления в потоке прекращаются
            button1.Enabled = false;
            button2.Enabled = true;
            if (threadCalc != null)
            {
                threadCalc.Abort();
            }
        }
        //закрытие треда при закрытии приложения
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (threadCalc != null)
            {
                threadCalc.Abort();
            }
            if (threadDraw != null)
            {
                threadDraw.Abort();
            }
        }

        Bitmap Map;
        Graphics gr;
       
        int propW = 2, propH = 2;

        private bool InHit(int ax, int ay, int H, int W)
        {

            return (ax - W / 2) * (ax - W / 2) + (ay - H / 2) * (ay - H / 2) <= radius * radius;
        }
        private bool InZone1(int ax, int ay, int H, int W)
        {
            return ax > W / 2 && ax < W / 2 + radius * propW && ay < H / 2 && ay > H / 2 - radius / propH;
        }

        private bool InZone2(int ax, int ay, int H, int W)
        {
            return ax < W / 2 && ax > W / 2 - radius * propW && ay > H / 2 - 10 && ay < H / 2 + radius / propH;
        }

        private bool GoodHit(int ax, int ay, int H, int W)
        {

            if (!InHit(ax, ay, H, W) && InZone1(ax, ay, H, W))
            {
                return true;
            }
            if (InHit(ax, ay, H, W) && InZone2(ax, ay, H, W))
            {
                return true;
            }
            return false;
        }
        int n_hits = 0;
        int n_misses = 0;
        private void button_StartShooting_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out delay))
            {
                if (delay >= 0)
                {
                    button_StartShooting.Enabled = false;
                    button_EndShooting.Enabled = true;
                    demonstrator_Drawer = new Demonstrator(delay, radius, maxX, maxY);
                    
                    threadDraw = new Thread(new ThreadStart(delegate ()
                    {  
                       
                        while (demonstrator_Drawer.isShooting) 
                        {
                          
                            demonstrator_Drawer.Shoot(gr, pictureBox1);
                            if(GoodHit(demonstrator_Drawer.x, demonstrator_Drawer.y, pictureBox1.Height, pictureBox1.Width ))
                            {
                                n_hits++;
                            }
                            else
                            {
                                n_misses++;
                            }
                            Thread.Sleep((int)demonstrator_Drawer.delay);
                            Invalidate();
                        }
                    }));
                    threadDraw.Start();
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Время задержки - неотрицательное число!");
                }

            }
            else
            {
                textBox1.Clear();
                MessageBox.Show("Время задержки - неотрицательное число!");
            }
        }

  
        private void button_EndShooting_Click(object sender, EventArgs e)
        {
               // demonstrator_Counter.StopWork();
                button1.Enabled = false;
                button2.Enabled = true;
            if(threadCalc != null)
            {
                threadCalc.Abort();
            }
            button_StartShooting.Enabled = true;
            button_EndShooting.Enabled = false;
            demonstrator_Drawer.StopShoot();
            n_hits = 0;
            n_misses = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // demonstrator_Drawer = new Demonstrator(delay,radius, maxX, maxY);
            Map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(Map);
            base.OnPaint(e);
            demonstrator_Drawer.DrawHit(gr, pictureBox1, propW, propH);

            demonstrator_Drawer.DrawDPSK(gr, pictureBox1);
            pictureBox1.Image = Map;
            SolidBrush brush = new SolidBrush(Color.Black);
            string drawString = "hits: " + n_hits + "  misses: " + n_misses;
            gr.DrawString(drawString, new Font("Arial", 14), brush, 5, 200);
        }
    }
}

