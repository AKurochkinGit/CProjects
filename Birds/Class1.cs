using System;
using System.Collections.Generic;
using System.Text;

namespace Birdies
{

     class Bird : IBirdieFly, IBirdieSwim, IBirdieNoise
    {
        protected string name;
        public bool fly, swim;
        protected Bird() { }
        protected Bird(string aname) { name = aname; }
        virtual public void MakeNoise()
        {

        }

        virtual public void Fly()
        {
            if(this.fly == true)
            Console.WriteLine("{0} flies well! ", name);
            else
            Console.WriteLine("{0} doesn't fly! ", name);
        }

        virtual public void Swim()
        {
            if (this.swim == true)
                Console.WriteLine("{0} swims well! ", name);
            else
                Console.WriteLine("{0} doesn't swim! ", name);
        }


        public string GetName()
        {
            return name;
        }

        public void SetName(string aname)
        {
            name = aname;
        }
    }

    class Kiwi : Bird 
    {
        public Kiwi()
        {
            name = "Chuchaka";
        }
        public Kiwi(string aname) { name = aname; }
        public override void  MakeNoise()
        {

            Console.WriteLine("Kiwi {0} says Squiii Squiii", name);
        }
        public override void Fly()
        {

            Console.WriteLine("Kiwi {0} doesn't fly!", name);
        }
        public override void Swim()
        {

            Console.WriteLine("Kiwi {0} doesn't swim!", name);
        }

    }

    class Duck : Bird
    {
        
        public Duck()
        {
            fly = true;
            swim = true;
            name = "Kryakva";
        }
        public Duck(string aname)
        {
            fly = true;
            swim = true; 
            name = aname; 
        }
        public override void MakeNoise()
        {

            Console.WriteLine("{0} says Crya Crya...   (* __ *)", name);
        }
        public override void Fly()
        {
            
            Console.WriteLine("Duck {0} swims well!", name);
        }
        public override void Swim()
        {
            swim = true;
            Console.WriteLine("Duck {0} flies well!", name);
        }
    }

    class Pinguin : Bird
    {
        public Pinguin()
        {
            swim = true;
            name = "Lolo";
        }
        public Pinguin(string aname) {
            swim = true;
            name = aname; 
        }
        public override void MakeNoise()
        {

            Console.WriteLine("{0} says that he is a pinguin...   (* __ *)", name);
        }
        public override void Fly()
        {
            
            Console.WriteLine("Pinguin {0} doesn't fly!", name);
        }
        public override void Swim()
        {

            Console.WriteLine("Pinguin {0} swims well!", name);
        }
    }

    class Parrot : Bird
    {
        public Parrot()
        {
            fly = true;
            name = "Bibka";
        }
        public Parrot(string aname) 
        {
            fly = true;
            name = aname; 
        }
        public override void MakeNoise()
        {

            Console.WriteLine("{0} says 'Geeeetter', 'Seeeeeetter', 'OOP'", name);
        }
        public override void Fly()
        {

            Console.WriteLine("Parrot {0} flies well!", name);
        }
        public override void Swim()
        {

            Console.WriteLine("Parrot {0} doesn't swim!", name);
        }
    }
}
