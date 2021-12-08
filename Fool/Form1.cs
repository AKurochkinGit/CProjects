using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Fool
{

    enum cursor { DownLeft, Left, UpLeft, Up, UpRight, Right, DownRight, Down };
    public partial class Form1 : Form
    {
        int CursorX = MousePosition.X;
        int CursorY = MousePosition.Y;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(620, 410);
            SoundPlayer sp = new SoundPlayer(@"C:\music\Durak.wav");
            sp.PlayLooping();
        }




        private void buttonNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Думаю, Вы всё же дурак. Вы отчислены.");
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Однако, действительно дурак... Вы отчислены.");

        }

        private void buttonNo_Enter(object sender, EventArgs e)
        {
            buttonYes.Focus();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X - this.Location.X;
            int y = MousePosition.Y - this.Location.Y;
            if (ShortDistance(buttonNo))
            {
                buttonNo.Location = new Point(buttonNo.Location.X + x - CursorX, buttonNo.Location.Y + y - CursorY);
                if (CloseToBorder(buttonNo))
                {
                    buttonNo.Location = new Point(270, 200);
                }
            }
            CursorX = x;
            CursorY = y;
        }





        private bool ShortDistance(Button But)
        {
            int X = MousePosition.X - this.Location.X;
            int Y = MousePosition.Y - this.Location.Y;
            return Math.Abs(But.Location.X - X) < 100 && Math.Abs(But.Location.Y - Y) < 100;
        }

        private bool CloseToBorder(Button But)
        {
            return buttonNo.Location.X > 610 || buttonNo.Location.Y > 400 || buttonNo.Location.Y < -10 || buttonNo.Location.X < -30;
        }


        private void label2_Click(object sender, EventArgs e)
        {
            SoundPlayer spwin = new SoundPlayer(@"C:\music\Pobeda.wav");
            spwin.Play();
            MessageBox.Show("Вы нашли секретный путь. Добро пожаловать в Google!");
        }
    }

}

