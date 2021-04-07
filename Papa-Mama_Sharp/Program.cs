using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Papa_Mama
{
    class Program
    {
        static void Main(string[] args)
        {
            Message.n_rep = 5;
            Message papa = new Message("papa", 3, 2000);
            Message mama = new Message("mama", 2, 3000);
            Thread tp = new Thread(papa.ToSay);
            Thread tm = new Thread(mama.ToSay);
            tp.Start();
            tm.Start();
            tp.Join();
            tm.Join();
        }
    }
}
