using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Papa_Mama
{
    class Message
    {
        public static int n_rep;
        private static int delay;
        private static int repeat;
        private static string value;
        public static object l = new object();
        public Message(string _value, int _repeat, int _delay)
        {  
            value = _value;
            repeat = _repeat; 
            delay = _delay; 
        }

        public  void ToSay() 
        {
            int i = 0;
            while( i < repeat && n_rep > 0)
            {
                lock (l)
                {
                    Console.WriteLine(value);
                    n_rep--;
                    i++;
                    Thread.Sleep(delay);
                }

            }
           
        }
    }
}
