using System;
using FractionCSharp;
namespace FractionCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction d1 = new Fraction(1,2);
            Fraction d2 = new Fraction(2, 6);
            Fraction divide = d1/ d2;
            Fraction mult = d1 * d2;
            Fraction sum = d1 + d2;
            Fraction dif = d1 - d2;
            sum.Out();
            dif.Out();
            mult.Out();
            divide.Out();
            if (d1 == d2)
                Console.WriteLine("d1 = d2");
            else
                Console.WriteLine("d1 != d2");

        }
    }
}
