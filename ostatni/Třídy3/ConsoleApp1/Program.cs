using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        class Animal
        {
            public string name;
            public int maxAge;

            public virtual void MakeNoise()
            {
                Console.WriteLine("UAAAA");
            }
        }
        class Dog : Animal
        {
            public string race;
            public override void MakeNoise()
            {
                Console.WriteLine("Haf");
            }
        }
        class Cat : Animal
        {
            public string race;
            public override void MakeNoise()
            {
                Console.WriteLine("Mňau");
            }
        }
        static void Main(string[] args)
        {
            Animal newAnimal = new Animal();
            newAnimal.MakeNoise();

            Dog newDog = new Dog();
            newDog.name = "Alík";
            newDog.maxAge = 16;
            newDog.race = "Jezevčík";
            Console.WriteLine($"{ newDog.name} is { newDog.maxAge} years old and a { newDog.race}");
            newDog.MakeNoise();
            Console.ReadKey();

            Cat newCat = new Cat();
            newCat.name = "Míca";
            newCat.maxAge = 21;
            newCat.race = "Siamka";
            Console.WriteLine($"{newCat.name} is {newCat.maxAge} years old and a {newCat.race}");
            newCat.MakeNoise();
            Console.ReadKey();




        }
    }
}
