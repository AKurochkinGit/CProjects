using System;
using System.Collections.Generic;
using System.Text;
namespace FractionCSharp
{
    class Fraction
    {
        private long _x, _y;
        public Fraction()
        {
            _x = 0;
            _y = 1;
        }

        public Fraction(long x, long y)
        {
            this.SetX(x);
            this.SetY(y);
            this.simplify();
        }

        public long GetX()
        {
            return _x;
        }
         
        public void SetX(long x)
        {
            _x = x;
            
        }

        public long GetY()
        {
            return _y;
        }

        public void SetY(long y)
        {
            try
            {
                if (y == 0)
                    throw new DivideByZeroException();
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("No divide by zero");
            }
            _y = y;
            
        }

        public void simplify()
        {
            long a = _x;
            long b = _y;
            while (b != 0)
            {
                long k = a;
                a = b;
                b = k % b;
            }
            _x /= a;
            _y /= a;
        }

        public double value()
        {
            double v = Convert.ToDouble(_x) / Convert.ToDouble(_y);
            return v;
        }


        public static Fraction operator +(Fraction d1, Fraction d2)
        {
            Fraction res = new Fraction();
            res.SetX((d1._x * d2._y) + (d1._y * d2._x));
            res.SetY(d1._y * d2._y);
            res.simplify();
            return res;
        }

        public static Fraction operator -(Fraction d1, Fraction d2)
        {
            Fraction res = new Fraction();
            res.SetX((d1._x * d2._y) - (d1._y * d2._x));
            res.SetY(d1._y * d2._y);
            res.simplify();
            return res;
        }

        public static Fraction operator *(Fraction d1, Fraction d2)
        {
            Fraction res = new Fraction();
            res.SetX(d1._x * d2._x);
            res.SetY( d1._y * d2._y);
            res.simplify();
            return res;
        }

        public static Fraction operator /(Fraction d1, Fraction d2)
        {
            try
            {
                if (d2._x == 0)
                    throw new DivideByZeroException();
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("No divide by zero");
            }
            Fraction res = new Fraction();
            res.SetX(d1._x * d2._y);
            res.SetY(d1._y * d2._x);
            res.simplify();
            return res;
        }

        public static bool operator ==(Fraction d1, Fraction d2)
        {
            return (d1.value() == d2.value());
        }

        public static bool operator !=(Fraction d1, Fraction d2)
        {
            return (d1.value() != d2.value());
        }

       
        public static bool operator >(Fraction d1, Fraction d2)
        {
            return (d1.value() > d2.value());
        }

        public static bool operator <(Fraction d1, Fraction d2)
        {
            return (d1.value() < d2.value());
        }

        public static bool operator >=(Fraction d1, Fraction d2)
        {
            return (d1.value() >= d2.value());
        }

        public static bool operator <=(Fraction d1, Fraction d2)
        {
            return (d1.value() <= d2.value());
        }

        public void Out()
        {
            Console.Write("{0}", this.GetX());
            Console.Write("/{0}", this.GetY());
            Console.WriteLine(" or {0}", this.value());

        }
    }
}



