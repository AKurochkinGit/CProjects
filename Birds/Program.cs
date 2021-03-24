using System;
using Birdies;
namespace Birdies
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird Johnatan = new Parrot("Johnatan");
            if (Johnatan.fly)
                Johnatan.Fly();
            if (Johnatan.swim)
                Johnatan.Swim();
            Bird Morris = new Duck("Morris");
            if (Morris.fly)
                Morris.Fly();
            if (Morris.swim)
                Morris.Swim();

            Bird Lolo = new Pinguin();
            if (Lolo.fly)
                Lolo.Fly();
            if (Lolo.swim)
                Lolo.Swim();

            Bird Zhora = new Kiwi("Zhora");
            if (Zhora.fly)
                Morris.Fly();
            if (Zhora.swim)
                Morris.Swim();
            Zhora.MakeNoise();


        }
    }
}
