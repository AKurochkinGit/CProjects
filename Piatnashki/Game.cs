using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piatnashki
{
    class Game  // в этом классе описываются методы, необходимые для проведения игры
    {
        private int seed; //переменная для случайных значений
        public int[,] Table  // таблица
        {
            get;
            private set;
        }
        public Game() //конструктор создает таблицу
        {
            Table = new int[4, 4];
            StartGame();
        }
        public void StartGame(bool isNew = true) //функция запуска игры
        {
            if (isNew) //проверка: новая сборка или повторить игру
            {
                Random rnd = new Random();
                seed = rnd.Next();
            }
            Random random = new Random(seed);
            for (int i = 0; i < 4; i++) //заполнение таблицы числами от 1 до 16 в хронологическом порядке
            {
                for (int j = 0; j < 4; j++)
                {
                    Table[i, j] = i * 4 + j;
                }
            }

            for (int i = 0; i < 4; i++) // перемешивание чисел в таблице случайным образом
            {
                for (int j = 0; j < 4; j++)
                {
                    int pos = random.Next(16);
                    swap( ref Table[i, j], ref Table[pos / 4, pos % 4]);
                }
            }
        }
        public void swap(ref int i, ref int j) // функция, меняющая местами два элемента
        {
            int tmp = i;
            i = j;
            j = tmp;
        }
        public bool IsPlayable() // проверка игры на собираемость
        {
            int N;
            N = countN() + getZeroRow() + 1;
            if (N % 2 != 0) //проверяем собираемость согласно известному правилу
                return false;
            return true;
        }
        int countN() // подсчитываем количество инверсий
        {
            int N = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = i * 4 + j + 1; k < 16; k++) // k показывает количество элементов, стоящих до текущего
                    {
                        if (Table[i, j] > Table[k / 4, k % 4] & Table[k / 4, k % 4] > 0)// сравниваем текущий с каждым после текущего
                        {
                            N++;
                        }
                    }
                }
            }
            return N;
        }
        public int getZeroRow() //функция, ищущая строку с пустой клеткой
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Table[i, j] == 0)
                        return i;
                }
            }
            return -1;
        }
        public int getZeroColumn() //функция, ищущая столбец с нулувой клеткой
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Table[i, j] == 0)
                        return j;
                }
            }
            return -1;
        }
        public bool IsFinished() // проверка, завершилась ли игра после хода
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 & j == 3)
                    {
                        break;
                    }
                    if (Table[i, j] != 4 * i + j + 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
