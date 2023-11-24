using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
        //5     bodů    -input array         možná 7.5? (mám obě možnosti zadání)
        //7.5   bodů    -prohazování
        //5     bodů    -diagonály
        //7     bodů    -coding style?
        //12.5  bodů    -vynásobit : matici(5) sloupec(2.5) řádek(2.5) prvek(2.5)
        //10    bodů    -transpozice
        //15    bodů    -násobení matic
        //57 = 1??? možná? snad?

        static int a = 0;
        static int b = 0;
        static int input = 0;
        static int[,] mainArray;
        static int[,] transposedArray;
        static int memory;
        static bool parse;
        static string index;

        static void AskForNumbers()
        {
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
                                Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna.");//vybídka ke znovunastavení ínputu
                            }
                        } while (b < 1);
                    }
                    else
                    {
                        Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna.");//vybídka ke znovunastavení ínputu
                    }
                }
                else
                {
                    Console.WriteLine("Je nutno zadat číslem, a musí být alsepoň jedna."); //vybídka ke znovunastavení ínputu
                }
            } while (counter < 1);
        }


        static void AskForNumbersPlus(int[,] array) //v podstatě ask for numbers ale je zajištěné aby souřadnice nikdy nepřekročily rozsah pole
        {
            do
            {
                Console.WriteLine("Pokud tuto zprávu vidíš podruhé, zadej menší hodnoty, jsi mimo pole.");
                AskForNumbers();
                a--;
                b--;
            } while (a >= array.GetLength(1) || b >= array.GetLength(1) || a >= array.GetLength(0) || b >= array.GetLength(0));
        }


        static void WriteArray(int[,] array) //vypíše pole do konzole (je tu i posunutí čísel s jednou cifrou aby bylo pole zarovnané
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

        static void FillArrayRandom(int[,] array)//plní pole náhodnýmy postupkami 1-10 (prvek 1A je něco mezi  1-10, prvekk 2A je 1A + 1-10)
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
        static void FillArrayConsecutive(int[,] array) //postupně naplní celé pole postupnými čísly
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


        static void PositionSwap(int[,] array) //zeptá se na dvě ruzné souřadnice 
                {
                    Console.WriteLine("Hodnota a je pro Xovou souřadnici prvního čísla, hodnota b je pro Yovou souřadnici prvního čísla.");
                    AskForNumbersPlus(mainArray);
                    int xFirst = a;
                    int yFirst = b;
                    Console.WriteLine("Hodnota a je pro Xovou souřadnici druhého čísla, hodnota b je pro Yovou souřadnici druhého čísla.");
                    AskForNumbersPlus(mainArray);
                    int xSecond = a;
                    int ySecond = b;
                    memory = array[xFirst, yFirst];
                    array[xFirst, yFirst] = array[xSecond, ySecond];
                    array[xSecond, ySecond] = memory;
                }


        static void RowSwap(int[,] array) //jednoduše postupně prohodí veškeré prvky ve sloupcích x a y
        {
            Console.WriteLine("Hodnota a je pro řádek 1, hodnota b pro řádek 2.");
            AskForNumbersPlus(array);
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

        static void ColumnSwap(int[,] array) //jednoduše postupně prohodí veškeré prvky ve sloupcích x a y
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

        
        static void MainDiagSwap(int[,] array) //prohazuje pole podél hlevní diagonály (hodně volně odvozeno od prohazování vedlejší diagonály)
        {
            int j = 0;
            int depth;
            int length;
            for (int i = 0; i < (array.GetLength(0) / 2); i++, j++)
            {
                if (array.GetLength(0) < array.GetLength(1)) //netuším (vím technicky ale ne proč to nejde jednodušeji) proč ale tohle je jediný způsob jak zajistit že tahle funkce funguje i v různě velkých polích
                {
                    length = array.GetLength(0) - 1 - i;
                    depth = array.GetLength(0) - 1 - j;
                }
                else
                {
                    length = array.GetLength(1) - 1 - i;
                    depth = array.GetLength(1) - 1 - j;
                }
                memory = array[j, i];
                array[j, i] = array[length, depth];
                array[length, depth] = memory;
            }
        }


        static void SideDiagSwap(int[,] array) //s tímhle mi pomohl Tob, pak se to samo a vůbec ne mým přičiněním rozbilo a takhle to vypadá spraveně: vezme levý dolní roh, prohodí s horním koncem, posune se nahoru a vpravo o jedna a pak opakuje proces
        {
            int j = 0;
            for (int i = array.GetLength(1) - 1; i > array.GetLength(1) / 2; i--, j++)
            {
                if (array.GetLength(1) < array.GetLength(0))  //netuším (vím technicky ale ne proč to nejde jednodušeji) proč ale tohle je jediný způsob jak zajistit že tahle funkce funguje i v různě velkých polích
                {
                    i = array.GetLength(1) - 1 - j;
                }
                else
                {
                    i = array.GetLength(0) - 1 - j;
                }
                memory = array[i, j];
                array[i, j] = array[j, i];
                array[j, i] = memory;
            } 
        }

        static void MultiplyArray(int[,] array)//násobí celé pole postupně během čtení
        {
            parse = int.TryParse(Console.ReadLine(), out input);
            if (parse)
            {
                Console.WriteLine();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int f = 0; f < array.GetLength(1); f++)
                    {
                        array[i, f] = array[i, f] * input;
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
            else
            {
                Console.WriteLine("Zkus jiné číslo - OutOfRange");
            }
        }

        static void MultiplyElement(int[,] array) 
        {
            //pokud input 
            // 0
            //násobí řádek
            // 1
            //násobí sloupec
            // 2 
            // zeptá se na souřadnice a nasobí tu
            input = 3;
            parse = false;
            do
            {
                Console.WriteLine("Řádek (0), sloupec(1) nebo prvek (2)?");
                int.TryParse(Console.ReadLine(), out input);
                if (input == 0 || input == 1 || input == 2)
                {
                    parse = true;
                }
            } while (!parse);
            input = -1;
            if (input == 0)
            {
                do
                {
                    Console.WriteLine("Který řádek?");
                    int.TryParse(Console.ReadLine(), out a);
                } while (input >= array.GetLength(1) || input < 0);
                Console.WriteLine("Jakým číslem?");
                do
                {
                    parse = int.TryParse(Console.ReadLine(), out b);
                } while (!parse);                
                for (int i = 0; i < array.GetLength(0); i++)
                {                    
                    for (int f = 0; f < array.GetLength(1); f++)
                    {
                        if (i == a)
                        {
                            array[i, f] = array[i, f] * input;
                        }
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
            if (input == 1)
            {
                do
                {
                    Console.WriteLine("Který sloupec?");
                    int.TryParse(Console.ReadLine(), out a);
                } while (a >= array.GetLength(0) || a < 0);
                Console.WriteLine("Jakým číslem?");
                int.TryParse(Console.ReadLine(), out input);
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int f = 0; f < array.GetLength(1); f++)
                    {
                        if (f == a)
                        {
                            array[i, f] = array[i, f] * input;
                        }
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
            if (input == 2)
            {
                Console.WriteLine("Které číslo? Hodnota a je pro souřadnici x, hodnota b pro souřadnici y.");
                AskForNumbersPlus(mainArray);
                Console.WriteLine("Jakým číslem?");
                int.TryParse(Console.ReadLine(), out input);
                array[a, b] = array[a, b] * input;
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
        }

        static void TransposeMainDiagonal(int[,] array) // Vezme pole a otočí ho po hlavní diagonále
        {
            transposedArray = new int[array.GetLength(1), array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    transposedArray[j, i] = array[i, j];
                }
            }
            WriteArray(transposedArray);
        }
        static void MultiplyMainArrayWithTransposed(int[,] array)
        {
            TransposeMainDiagonal(array);
            int[,] multipliedArray = new int[array.GetLength(0), array.GetLength(0)]; //pro každý prvek (FORy i a j) v poli multiA jedeme FOR k který postupně projede sloupcem "nad" polem multiA například v poli transA a vynásobí je s protějškem v poli mainA a následně všehny sečte
            for (int i = 0; i < multipliedArray.GetLength(0); i++)
            {
                for (int j = 0; j < multipliedArray.GetLength(0); j++)
                {
                    memory = 0;
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        memory += array[i, k] * transposedArray[k, j];
                    }
                    multipliedArray[i, j] = memory;
                }
            }
            WriteArray(multipliedArray);
        
        }

        static int BinarySearchRecursive(int[,] array, int elementToSearch, int lower, int upper) //NEFUNGUJE NENÍ V NABÍDCE
        {
            memory = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                //TODO naimplementuj binární vyhledávání rekurzivním způsobem (Zamysli se nad parametry, které tato funkce přijímá vzpomeň si na přístup Rozděl a Panuj.)
                memory++;
                if (lower > upper)
                {
                    return -1;
                }
                int mid = (lower + upper) / 2;
                if (array[i, mid] == elementToSearch)
                {
                    index += i + ", " + mid;
                    return mid;
                }
                if (array[i, mid] < elementToSearch)
                {
                    index += i + ", " + (mid + 1);
                    return BinarySearchRecursive(array, elementToSearch, mid + 1, upper);
                }
                if (array[i, mid] > elementToSearch)
                {
                    index += i + ", " + (mid - 1);
                    return BinarySearchRecursive(array, elementToSearch, lower, mid - 1);
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hodnota a je pro počet řádků, Hodnota b pro počet sloupců.");
            AskForNumbers();
            mainArray = new int[a, b]; //generuje pole o velikosti a * b
            a = 0;
            b = 0;
            do //konvertuje input na int a opakuje loop dokud user nenapíše 0/1
            {
                Console.WriteLine("Naplnit náhodnými čísly, každé o něco větší než to poslední?(0) Nebo postupkou o intervallu 1?(1)\n");
                int.TryParse(Console.ReadLine(), out input);
                if (input == 0)
                {
                    FillArrayRandom(mainArray); //plní pole náhodnýmy postupkami 1-10 (prvek 1A je něco mezi  1-10, prvekk 2A je 1A + 1-10)
                    break;
                }
                else if (input == 1)
                {
                    FillArrayConsecutive(mainArray);//pní pole postupnými čísly
                    break;
                }
            } while (input != 0 || input != 1);
            WriteArray(mainArray);
            do
            {
                Console.WriteLine("CO BUDE TVÁ DALŠÍ ČINNOST?\nProhazovat čísla (1)\nProhazovat řádky (2)\nProhazovat sloupce (3)\nOtočit vedlejší diagonálu (4)\nOtočit hlavní diagonálu (5)\nVynásobit celé pole jedním číslem (6)\nVynásobit specifický řádek/prvek (7)\nTranspozicovat podél hlavní diagonály (8)(jednorázoavá operace!!!! pole se následně vrátí do předešlého stavu)\nVynásobit matici transpozicí sama sebe (9)(jednorázoavá operace!!!! pole se následně vrátí do předešlého stavu)\nUkončit program (0 nebo Any other key)\n");
                do
                {
                    parse = int.TryParse(Console.ReadLine(), out input);
                } while (!parse);
                if (input == 0) //tenhle if tu musí být, neboť switch využívá break k ukončení code snippetu. v prípadě že input je 0 tak breakujeme DO cyklus a ukočujeme program
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
                            SideDiagSwap(mainArray);
                            break;
                        case 5:
                            MainDiagSwap(mainArray);
                            break;
                        case 6:
                            MultiplyArray(mainArray);
                            break;
                        case 7:
                            MultiplyElement(mainArray);
                            break;
                        case 8:
                            TransposeMainDiagonal(mainArray); 
                            break;
                        case 9:
                            MultiplyMainArrayWithTransposed(mainArray); //tohle je pěkná postupka :) (délka názvů)
                            break;
                        case 10: //nefunguje proto není v nabídce
                            Console.WriteLine("Které číslo hledáme?");
                            do
                            {
                                parse = int.TryParse(Console.ReadLine(), out input);
                            } while (parse);

                            BinarySearchRecursive(mainArray, input, 0, mainArray.GetLength(0));
                            Console.WriteLine($"    Rekurzivní binární vyhledávání našlo prvek {input} na indexu {index} během {memory} kol");
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
