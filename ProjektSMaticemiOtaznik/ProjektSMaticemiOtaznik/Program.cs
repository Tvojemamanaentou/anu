using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchPlayground
{
    internal class Program

    {
        //Vytvoření matice a * b, kde a a b zadává uživatel + naplnění buď náhodnými čísly, nebo
        //postupně od 1 do a* b
        //- 5 bodů
        //
        //Přidání operací ze cvičení
        //- prohazování prvků, řádků a sloupců po 2,5 bodech(celkově 7,5 bodu)
        //- otáčení pořadí prvků na diagonálách po 2,5 bodech(celkově 5 bodů)
        //
        //Vynásobení matice číslem(každý prvek vynásobit číslem)
        //- 5 bodů + 2,5 bodu za možnost násobit pouze daný řádek/sloupec
        //
        //Sčítání/Odčítání dvou matic(po prvcích)
        //- po 5 bodech(Za sčítání a odčítání dohromady 8 bodů)
        //
        //Transpozice matice(převrácení kolem hlavní diagonály)
        //- 10 bodů
        //
        //Násobení dvou matic
        //- 15 bodů
        //
        //S čím přijdete vy :)
        //- tolik bodů, na kolik se domluvíme
        //
        //5 bodů -input array
        //5 bodů -prohazování

        static int a = 0;
        static int b = 0;
        static int input = 0;
        static int[,] mainArray;

        static void AskForNumbers()
        {
            bool parse;
            int counter = 0;
            //STRUKTURA:
            //opakuj dokud counter menší než jedna 
            //zkus A je číslo?
            //  je
            //      zkus B je číslo?
            //          je
            //              counter = 3 -> konec funkce
            //          není
            //              opakuj
            //  není
            //      opakuj
            do
            {
                Console.WriteLine("\nNapiš hodnotu a:");
                parse = int.TryParse(Console.ReadLine(), out a); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako a (funkce out) (zkopírováno z mého deathrollu/kalkulačky)
                if (parse)
                {
                    if (a >= 1)
                    {
                        do
                        {
                            Console.WriteLine("Napiš hodnotu b:");
                            parse = int.TryParse(Console.ReadLine(), out b);
                            if (parse)
                            {
                                Console.WriteLine();
                                counter = 3;
                            }
                            else
                            {
                                Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna.");
                            }
                        } while (b < 1);
                    }
                    else
                    {
                        Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna.");
                    }
                }
                else
                {
                    Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna."); //vybídka ke znovunastavení ínputu
                }
            } while (counter < 1);
        }


        static void AskForNumbersPlus(int[,] array)
        {
            do
            {
                Console.WriteLine("Pokud tuto zprávu vidíš podruhé, zadej menší hodnoty, jsi mimo pole.");
                AskForNumbers();
                a--;
                b--;
            } while (a >= array.GetLength(1) || b >= array.GetLength(1) || a >= array.GetLength(0) || b >= array.GetLength(0));
        }


        static void WriteArray(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int f = 0; f < array.GetLength(1); f++)
                {
                    Console.Write(array[i, f] + "  ");
                    if (array[i, f] >= 0 && array[i, f] < 10)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FillArrayRandom(int[,] array)
        {
            Random rng = new Random();
            int lastNumber = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int f = 0; f < array.GetLength(1); f++)
                {
                    array[i, f] = lastNumber + rng.Next(1, 10);
                    lastNumber = array[i, f];
                }
            }
        }
        static void FillArrayConsecutive(int[,] array)
        {
            int lastNumber = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int f = 0; f < array.GetLength(1); f++)
                {
                    array[i, f] = lastNumber + 1;
                    lastNumber = array[i, f];
                }
            }
        }


        static void RowSwap(int[,] array)
        {
            Console.WriteLine("Hodnota a je pro řádek 1, hodnota b pro řádek 2.");
            do
            {
                Console.WriteLine("Pokud tuto zprávu vidíš podruhé, zadej menší hodnoty, jsi mimo pole.");
                AskForNumbers();
                a--;
                b--;
            } while (a >= array.GetLength(0) || b >= array.GetLength(0));
            int[] swapArray = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                swapArray[i] = array[a, i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[a, i] = array[b, i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[b, i] = swapArray[i];
            }
        }

        static void ColumnSwap(int[,] array)
        {
            Console.WriteLine("Hodnota a je pro sloupec 1, hodnota b pro sloupec 2.");
            AskForNumbersPlus(mainArray);
            int[] swapArray = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                swapArray[i] = array[i, a];
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, a] = array[i, b];
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, b] = swapArray[i];
            }
        }


        static void PositionSwap(int[,] array)
        {
            Console.WriteLine("Hodnota a je pro Xovou souřadnici prvního čísla, hodnota b je pro Yovou souřadnici prvního čísla.");
            AskForNumbersPlus(mainArray);
            int xFirst = a;
            int yFirst = b;
            Console.WriteLine("Hodnota a je pro Xovou souřadnici druhého čísla, hodnota b je pro Yovou souřadnici druhého čísla.");
            AskForNumbersPlus(mainArray);
            int xSecond = a;
            int ySecond = b;
            int memory;
            memory = array[xFirst, yFirst];
            array[xFirst, yFirst] = array[xSecond, ySecond];
            array[xSecond, ySecond] = memory;
        }


    static void Main(string[] args)
        {
            Console.WriteLine("Hodnota a je pro počet řádků, Hodnota b pro počet sloupců.");
            AskForNumbers();
            mainArray = new int[a, b];
            a = 0;
            b = 0;
            do //konvertuje input na int a opakuje loop dokud user nenapíše 0/1
            {
                Console.WriteLine("Naplnit náhodnými čísly, každé o něco větší než to poslední?(0) Nebo postupkou o intervallu 1?(1)\n");
                int.TryParse(Console.ReadLine(), out input);
                if (input == 0)
                {
                    FillArrayRandom(mainArray);
                    break;
                }
                else if (input == 1)
                {
                    FillArrayConsecutive(mainArray);
                    break;
                }
            } while (input != 0 || input != 1);
            WriteArray(mainArray);
            do
            {
                Console.WriteLine("CO BUDE TVÁ DALŠÍ ČINNOST?\nProhazovat čísla (1)\nProhazovat řádky (2)\nProhazovat sloupce (3)\nOtočit vedlejší diagonálu (4)\nOtočit hlavní diagonálu (5)\nUkončit program (0)\n");
                int.TryParse(Console.ReadLine(),out input);
                if (input == 0) //tenhle if tu musí být, neboť switch využívá break k ukončení code snippetu. v prípadě že input je 0 tak breakujeme do cyklus a ukočujeme program
                {
                    break;
                }
                else
                {
                    switch (input)
                    {
                        case 1:
                            PositionSwap(mainArray);
                            break;
                        case 2:
                            RowSwap(mainArray);
                            break;
                        case 3:
                            ColumnSwap(mainArray);
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        default:
                            break;
                    }
                    WriteArray(mainArray);
                }
            } while (true);
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
