using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.
            int[] array = { 0, 1, 2, 3, 4 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            Console.WriteLine(sum);


            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = 0;
            int numOfChlivkys = 0;
            foreach (int num in array)
            {
                average += num;
                numOfChlivkys++;
            }
            average = average / numOfChlivkys;
            Console.WriteLine("average je " + average);


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = 0;
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine("max je " + max);


            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = 0;
            foreach (int num in array)
            {
                if (num < min)
                {
                    max = num;
                }
            }
            Console.WriteLine("min je " + min);


            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random rnd = new Random();
            int[] obili = new int[10000];
            for (int i = 0; i < 9999; i++)
            {
                obili[i] = rnd.Next(0,10);
                Console.WriteLine(obili[i]);
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (var item in obili)
            {
                counts[item]++;
            }
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("počet " + i + " je " + obili[i]);
            }


            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            
            
            
            
            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            int index;
            bool bol;
            Console.WriteLine("Zadej index");
            do
            {
                bol = Int32.TryParse(Console.ReadLine(), out index);
                switch (bol)
                {
                    case (true):
                        Console.WriteLine("Nenalezeno, zadej znovu");
                        break;
                    case (false):
                        Console.WriteLine("array na číslu indexu je " + array[index]);
                        break;
                    default:
                        break;
                }
            } while (bol == false);

            Console.ReadKey();
        }
    }
}
