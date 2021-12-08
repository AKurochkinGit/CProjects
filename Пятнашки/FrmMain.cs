using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace Пятнашки
{
    public partial class Пятнашки : Form
    {
        private Game g;
        private string player;
        private string time;
        private DateTime startTime;
        string path = "tag.dat";
        List<GameData> userData;
        BinaryFormatter bf;
        public Пятнашки()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            g.StartGame(true);
            showGrid();
            if (!g.isPlayable())
                MessageBox.Show("Эта игра не соберется. Начните новую игру!");
            timerRestart();
            startTime = DateTime.Now;
            count = 0;
            textBoxMot.Text = count.ToString();
        }
        private void showGrid()
        {
            dataGridView1.ClearSelection();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (g.Table[i, j] > 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = g.Table[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "";
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                    }
        }
        private void timerRestart()
        {
            textBoxTime.Text = "00:00";
            date1 = new DateTime(0, 0);
            gameTimer.Enabled = true;
        }
        private void RepeatGameButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            g.StartGame(false);
            showGrid();
            if (!g.isPlayable())
                MessageBox.Show("Эта игра не соберется. Начните новую игру!");
            timerRestart();
            startTime = DateTime.Now;
            count = 0;
            textBoxMot.Text = count.ToString();
        }

        private void Пятнашки_Load(object sender, EventArgs e)
        {
            userData = new List<GameData>();
            using (FileStream fr = new FileStream(path, FileMode.Open))
            {
                if (fr.Length > 0)
                {
                    bf = new BinaryFormatter();
                    userData = (List<GameData>)bf.Deserialize(fr);
                }
            }
            player = textBoxPlayer.Text;
            g = new Game();
            dataGridView1.RowCount = 4;
            dataGridView1.ColumnCount = 4;
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows[i].Height = 75;
                dataGridView1.Columns[i].Width = 75;
            }
            showGrid();
            if (!g.isPlayable())
                MessageBox.Show("Эта игра не соберется. Начните новую игру!");
            gameTimer.Start();
            startTime = DateTime.Now;
            textBoxMot.Text = count.ToString();
            textBoxTime.Text = "00:00";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        int count = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == g.getZeroRow() & dataGridView1.CurrentCell.ColumnIndex == g.getZeroColumn() + 1)
            {
                g.swap(ref g.Table[g.getZeroRow(), g.getZeroColumn()], ref g.Table[g.getZeroRow(), g.getZeroColumn() + 1]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (dataGridView1.CurrentCell.RowIndex == g.getZeroRow() & dataGridView1.CurrentCell.ColumnIndex == g.getZeroColumn() - 1)
            { 
                g.swap(ref g.Table[g.getZeroRow(), g.getZeroColumn()], ref g.Table[g.getZeroRow(), g.getZeroColumn() - 1]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (dataGridView1.CurrentCell.RowIndex == g.getZeroRow() + 1 & dataGridView1.CurrentCell.ColumnIndex == g.getZeroColumn())
            {
                g.swap(ref g.Table[g.getZeroRow(), g.getZeroColumn()], ref g.Table[g.getZeroRow() + 1, g.getZeroColumn()]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            if (dataGridView1.CurrentCell.RowIndex == g.getZeroRow() - 1 & dataGridView1.CurrentCell.ColumnIndex == g.getZeroColumn())
            {
                g.swap(ref g.Table[g.getZeroRow(), g.getZeroColumn()], ref g.Table[g.getZeroRow() - 1, g.getZeroColumn()]);
                count++;
                textBoxMot.Text = count.ToString();
            }
            showGrid();
            if (g.isFinished())
            {
                gameTimer.Stop();
                time = textBoxTime.Text;
                userData.Add(new GameData(player, startTime, time, count));
                dataGridView1.Enabled = false;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    bf = new BinaryFormatter();
                    bf.Serialize(fs, userData);
                }
                MessageBox.Show("Вы победили!");
            }
        }
        DateTime date1 = new DateTime(0, 0);
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(1);
            textBoxTime.Text = date1.ToString("mm:ss");
        }

        private void Пятнашки_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                bf = new BinaryFormatter();
                bf.Serialize(fs, userData);
            }
            MessageBox.Show("Спасибо за игру! Результаты сохранены в Файл");
        }

        private void textBoxPlayer_TextChanged(object sender, EventArgs e)
        {
            player = textBoxPlayer.Text;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            string lastRes = "";
            var outputData = (userData.Count > 10) ? userData.GetRange(userData.Count - 10, 10) : userData;
            foreach(var x in outputData)
            {
                lastRes += String.Format("Игрок - {0}, Время начала игры - {1}, продолжительность сборки - {2}, количество сделанных ходов - {3}\n", 
                    x.Player, x.StartTime, x.GameTime, x.MoveCount);
            }
            if (lastRes != "")
                MessageBox.Show(lastRes);
            else
                MessageBox.Show("Результатов еще нет. Пройдите игру и станьте первым!");
        }

        private void btnTopTime_Click(object sender, EventArgs e)
        {
            string TopTimeRes = "";
            var SortedData = userData;
            SortedData.Sort((x, y) => (x.GameTime).CompareTo(y.GameTime));
            var outputData = (SortedData.Count > 10) ? SortedData.GetRange(SortedData.Count - 10, 10) : SortedData;
            foreach (var x in outputData)
            {
                TopTimeRes += String.Format("Игрок - {0}, Время начала игры - {1}, продолжительность сборки - {2}, количество сделанных ходов - {3}\n",
                    x.Player, x.StartTime, x.GameTime, x.MoveCount);
            }
            if (TopTimeRes != "")
                MessageBox.Show(TopTimeRes);
            else
                MessageBox.Show("Результатов еще нет. Пройдите игру и станьте первым!");
        }

        private void btnTopMove_Click(object sender, EventArgs e)
        {
            string TopMoveRes = "";
            var SortedData = userData;
            SortedData.Sort((x, y) => (x.MoveCount).CompareTo(y.MoveCount));
            var outputData = (SortedData.Count > 10) ? SortedData.GetRange(SortedData.Count - 10, 10) : SortedData;
            foreach (var x in outputData)
            {
                TopMoveRes += String.Format("Игрок - {0}, Время начала игры - {1}, продолжительность сборки - {2}, количество сделанных ходов - {3}\n",
                    x.Player, x.StartTime, x.GameTime, x.MoveCount);
            }
            if (TopMoveRes != "")
                MessageBox.Show(TopMoveRes);
            else
                MessageBox.Show("Результатов еще нет. Пройдите игру и станьте первым!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userData.RemoveAll(x => (x.StartTime.Date <= dateTimePicker1.Value.Date));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int temp = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.Table[i, j] = temp;
                    temp++;
                }
            }
            g.Table[3, 3] = 0;
            gameTimer.Stop();
            time = textBoxTime.Text;
            userData.Add(new GameData(textBoxPlayer.Text, startTime, time, Convert.ToInt32(textBoxMot.Text)));
            userData.Sort((x, y) => (x.StartTime).CompareTo(y.StartTime));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf = new BinaryFormatter();
                bf.Serialize(fs, userData);
            }
            dataGridView1.Enabled = false;
            showGrid();
            count = 0;
            g.StartGame(true);
            MessageBox.Show("Вы победили!");

        }
    }
}
