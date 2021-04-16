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
        static private Demonstrator demonstrator;
        private Thread thread;
        //принятие данных
        private void button2_Click(object sender, EventArgs e)
        {
            int restTime;
            if (int.TryParse(textBox1.Text, out restTime))
            {
                if (restTime >= 0)
                {
                    //создание демонстратора с калькулятором внутри, подписка на событие, создание потока
                    button1.Enabled = true;
                    button2.Enabled = false;
                    demonstrator = new Demonstrator(restTime);
                    demonstrator.display += this.Display; //подписываем вывод на соытие работы демонстратора

                    thread = new Thread(new ThreadStart(delegate ()
                    {
                        while (demonstrator.calculator.iswork)    // пока в isWork через событие stopCalculation не передалось false вычисления не прервутся
                        {
                            demonstrator.calculator.Work();
                        }
                    }));
                    thread.Start();
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
            demonstrator.StopWork(); // Stop Work передает в isWork false и вычисления в потоке прекращаются
            button1.Enabled = false;
            button2.Enabled = true;
            if (thread != null)
            {
                thread.Abort();
            }
        }
        //закрытие треда при закрытии приложения
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }


    }
}
