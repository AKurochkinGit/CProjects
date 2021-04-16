using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LabEvents
{
    class Calculator
    { //нахождение всех делителей кроме себя
        private List<int> FindDividers(int num)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    dividers.Add(i);
                    if (num / i != i)
                    {
                        dividers.Add(num / i);
                    }
                }
            }

            return dividers;
        }
        //проверка на избыточность
        private bool isAbundant(int num)
        {
            List<int> dividers = FindDividers(num);
            int sum = 0;

            for (int i = 0; i < dividers.Count; i++)
            {
                sum += dividers[i];
            }

            if (sum > num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //проверка на полусовершенность
        private bool isSemiPerfect(int num)
        {
            List<int> dividers = FindDividers(num);
            dividers.Sort();
            int cnt = dividers.Count;

            bool[,] subset = new bool[cnt + 1, num + 1];

            for (int i = 0; i <= cnt; i++)
            {
                subset[i, 0] = true;
            }

            for (int i = 1; i <= num; i++)
            {
                subset[0, i] = false;
            }

            for (int i = 1; i <= cnt; i++)
            {
                for (int j = 1; j <= num; j++)
                {
                    if (j < dividers[i - 1])
                    {
                        subset[i, j] = subset[i - 1, j];
                    }
                    else
                    {
                        subset[i, j] = subset[i - 1, j] || subset[i - 1, j - dividers[i - 1]];
                    }
                }
            }

            if ((subset[cnt, num]) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //проверка на странность
        private bool isWeird(int num)
        {
            if (isAbundant(num) && !isSemiPerfect(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        public int restTime;
        public bool iswork = true;

        public Calculator(int _restTime)
        {
            restTime = _restTime;
        }

        public Calculator()
        {
            restTime = 0;
        }
        //проверка завершения вычислений
        public void isWork(bool iw)
        {
            iswork = iw;
        }
        //предпросчёт до 150000, тк долго считает
        static private List<int> weirdNumbers = new List<int>{70, 836, 4030, 5830, 7192, 7912, 9272, 10430, 10570, 10792, 10990, 11410, 11690,
        12110, 12530, 12670, 13370, 13510, 13790, 13930, 14770, 15610, 15890, 16030, 16310, 16730, 16870,
        17272, 17570, 17990, 18410, 18830, 18970, 19390, 19670, 19810, 20510, 21490, 21770, 21910, 22190,
        23170, 23590, 24290, 24430, 24710, 25130, 25690, 26110, 26530, 26810, 27230, 27790, 28070, 28630,
        29330, 29470, 30170, 30310, 30730, 31010, 31430, 31990, 32270, 32410, 32690, 33530, 34090, 34370,
        34930, 35210, 35630, 36470, 36610, 37870, 38290, 38990, 39410, 39830, 39970, 40390, 41090, 41510,
        41930, 42070, 42490, 42910, 43190, 43330, 44170, 44870, 45010, 45290, 45356, 45710, 46130, 46270,
        47110, 47390, 47810, 48370, 49070, 49630, 50330, 50890, 51310, 51730, 52010, 52570, 52990, 53270,
        53830, 54110, 55090, 55790, 56630, 56770, 57470, 57610, 57890, 58030, 58730, 59710, 59990, 60130,
        60410, 61390, 61670, 61810, 62090, 63490, 63770, 64330, 65030, 65590, 65870, 66290, 66710, 67690,
        67970, 68390, 68810, 69370, 69790, 70630, 70910, 71330, 71470, 72170, 72310, 72730, 73430, 73570,
        73616, 74270, 74410, 74830, 76090, 76370, 76510, 76790, 77210, 77630, 78190, 78610, 79030, 80570,
        80710, 81410, 81970, 82670, 83090, 83312, 83510, 84070, 84910, 85190, 85610, 86030, 86170, 86590,
        87430, 88130, 89390, 89530, 89810, 90230, 90370, 90790, 91070, 91210, 91388, 91490, 92330, 92470,
        92890, 95270, 95690, 96110, 96670, 97930, 98630, 99610, 99890, 100030, 100310, 100730, 101290, 101570,
        101710, 102130, 102970, 103670, 103810, 104090, 104230, 104510, 104930, 105770, 106610, 107170, 108010,
        108430, 108710, 109130, 109690, 109970, 110530, 110810, 111790, 112070, 112490, 112630, 112910, 113072,
        113330, 113470, 113890, 114590, 115990, 116410, 116690, 116830, 118510, 118790, 118930, 119630, 120470,
        120610, 121310, 121870, 122290, 122710, 123130, 124390, 124810, 125090, 125230, 126070, 126770, 127610,
        128170, 129290, 130270, 130690, 130970, 131110, 131390, 131530, 132230, 133070, 133490, 133910, 135170,
        135310, 136430, 136570, 138110, 138530, 139090, 139510, 139790, 139930, 140210, 140770, 141190, 141890,
        142030, 142730, 143710, 144410, 144830, 145670, 145810, 146090, 146230, 146930, 147770, 147910, 149030,
        149170, 149590, 149870 };
        //выбор максимального в границах
        private int calculate(int bottomBorder, int upperBorder)
        {
            int result = 0;
            foreach (int weirdNumber in weirdNumbers)
            {
                if (weirdNumber >= bottomBorder && weirdNumber <= upperBorder)
                {
                    if (weirdNumber > result)
                    {
                        result = weirdNumber;
                    }
                }
            }
            /* for(int i = bottomBorder; i < upperBorder; i++)
              {
                  if(isWeird(i))
                  {
                      result = i;
                  }
              }*/
            return result;
        }

        public delegate void CalculationFinished(int _result, int bb, int ub);
        public event CalculationFinished calculationFinished;

        static private Random rnd = new Random(1);
        //создание границ, передача результата событием, сон
        public void Work()
        {
            int bottomBorder = rnd.Next(2, 149999);
            int upperBorder = rnd.Next(bottomBorder, 150000);
            /*while (bottomBorder >= upperBorder)
            {
                upperBorder = rnd.Next(3, 150000);
            }*/

            calculationFinished?.Invoke(calculate(bottomBorder, upperBorder), bottomBorder, upperBorder);
            Thread.Sleep(restTime);
        }
    }
    //класс для аргументов события
    class CalculatorEventArgs : EventArgs
    {
        public int result;
        public int bb;
        public int ub;
        public CalculatorEventArgs(int _result, int _bb, int _ub)
        {
            result = _result;
            bb = _bb;
            ub = _ub;
        }
    }
}
