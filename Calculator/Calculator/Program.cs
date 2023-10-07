using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void HelpPrikaz()
        {
            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n  odečti: odečte dvě zadaná čísla;\n  sečti: sečte dvě zadaná čísla;\n  znásob: znásobí dvě zadaná čísla;\n  vyděl: vydělí dvě zadaná čísla;\n  procenta: ukáže kolik procent tvoří první číslo z druhého;\n  loga(b): vytvoří logaritmus z čísla jedna o základu čísla dva.\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou;\n  odmocni: zadáno-li po výběru čísla, nastaví číslo jako odmocninu sama sebe;\n  ln:vytvoří přirozený logaritmus z posledního zadaného čísla;\n  log10:vytvoří logaritmus o zákaldu deset z posledního zadaného čísla;  \n\n A teď zadej, první nebo druhé číslo, nebo operativní příkaz, či činnost, dependeing on co jsi zadal jako poslední.");
        }
        static void Main(string[] args)
        {
            bool jeToInput;
            string input;
            float numberOne = 0;
            double doubleEquivalentOne = 0;
            double doubleEquivalentTwo = 0;
            float numberTwo = 0;
            int counter = 0;
            float result = 0;
            int bases = 0;
            int storage = 0;

            Console.WriteLine("ISIINA PRĎÁCKÁ KALKUALČKA\nZadej první číslo.\n");
            while (counter < 4)
            {

                if (counter == 0)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    jeToInput = float.TryParse(input, out numberOne); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírováno z mého deathrollu)
                    if (jeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz\n");
                        counter++;
                    }
                    else
                    {
                        if (input == "help")
                        {
                            HelpPrikaz();
                        }
                        else
                        {
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného! " + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení ínputu
                        }
                    }
                }
                if (counter == 1)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    jeToInput = float.TryParse(input, out numberTwo); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírován oz mého deathrollu)
                    if (jeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + numberTwo + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz\n");
                        counter++;
                    }
                    else
                    {
                        switch (input)
                        {
                            case "help":
                                HelpPrikaz();
                                break;
                            case "nadruhou":
                                numberOne = numberOne * numberOne;
                                Console.WriteLine("\nPrvní číslo bylo dáno nadruhou. Číslo nyní činí: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                                break;
                            case "odmocni":
                                numberOne = (float)Math.Sqrt(numberOne);
                                Console.WriteLine("\nPrvní číslo bylo odmocněno. Číslo nyní činí: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                                break;
                            case "ln":
                                numberOne = (float)Math.Log(numberOne);
                                Console.WriteLine("\nPrvní číslo bylo překonvertováno na přirozený logaritmus. Číslo nyní činí: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                                break;
                            case "log10":
                                numberOne = (float)Math.Log10(numberOne);
                                Console.WriteLine("\nPrvní číslo bylo překonvertováno na jeho logaritmus 10. Číslo nyní činí: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                                break;
                            default:
                                Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n");
                                break;
                        }
                    }
                }
                if (counter == 2)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    switch (input)//nejspíš nejvýznamější část celé kalkulačky!!! dělá jednotlivé operace
                    {
                        case "sečti":
                            result = numberOne + numberTwo;
                            Console.WriteLine("\n Výsledek činní: " + result);
                            counter++;
                            break;
                        case "odečti":
                            result = numberOne - numberTwo;
                            Console.WriteLine("\n Výsledek činní: " + result);
                            counter++;
                            break;
                        case "znásob":
                            result = numberOne * numberTwo;
                            Console.WriteLine("\n Výsledek činní: " + result);
                            counter++;
                            break;
                        case "vyděl":
                            if (numberTwo == 0)
                            {
                                Console.WriteLine("\nNulou dělit nelze. Vyber nové druhé číslo.\n");
                                counter = 1;
                            }
                            else
                            {
                                result = numberOne / numberTwo;
                                Console.WriteLine("\n Výsledek činní: " + result);
                                counter++;
                            }
                            break;
                        case "poděl": //To samé jako vyděl, ale velice funni
                            if (numberTwo == 0)
                            {
                                Console.WriteLine("\nNulou dělit nelze. Vyber nové druhé číslo.\n");
                                counter = 1;
                            }
                            else
                            {
                                result = numberOne / numberTwo;
                                Console.WriteLine("\nSám seš poděl! ( ´･･)ﾉ(._.`) Ale pokud jsi chtěl VYDĚLIT tak výsledek je: " + result);
                                counter++;
                            }
                            break;
                        case "procenta":
                                result = (numberOne / numberTwo) * 100;
                                Console.WriteLine("\n Výsledek činní: " + result + " %");
                            break;
                        case "loga(b)":
                                doubleEquivalentOne = Convert.ToDouble(numberOne);
                                doubleEquivalentTwo = Convert.ToDouble(numberTwo);
                                result = (float)Math.Log(doubleEquivalentOne, doubleEquivalentTwo); //logaritmus z čísla jedna o zákaldu dva
                                Console.WriteLine("\n Výsledek činní: " + result);
                            break;
                        case "help":
                            HelpPrikaz();
                            break;
                        case "nadruhou":
                            numberTwo = numberTwo * numberTwo;
                            Console.WriteLine("\nDruhé číslo bylo dáno nadruhou. Nyní činní: " + numberTwo + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                            break;
                        case "odmocni":
                            numberTwo = (float)Math.Sqrt(numberTwo);
                            Console.WriteLine("\nDruhé číslo bylo odmocněno. Číslo nyní činí: " + numberTwo + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                            break;
                        case "ln":
                            numberTwo = (float)Math.Log(numberTwo);
                            Console.WriteLine("\nDruhé číslo bylo překonvertováno na přirozený logaritmus. Číslo nyní činí: " + numberTwo + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                            break;
                        case "log10":
                            numberTwo = (float)Math.Log10(numberTwo);
                            Console.WriteLine("\nDruhé číslo bylo překonvertováno na logaritmus deseti. Číslo nyní činí: " + numberTwo + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                            break;
                        default:
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n");
                            break;
                    }

                }
                if (counter == 3)
                {
                    Console.WriteLine("\nPřevést do nějaké soustavy?\nAno/Ne? V případě ne ukončuji kód\n(Note:Číslo bude převedeno na int, tudíž bude zaokrouhleno na nejbližší celé číslo\n");
                    input = Console.ReadLine();
                    if (input == "Ano")
                    {
                        Console.WriteLine("\nDo které? K dispozici (1-16)\n"); //Jen já a bůh víme jak tohle funguje
                        input = Console.ReadLine();
                        jeToInput = int.TryParse(input, out bases); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírován oz mého deathrollu)
                        if (jeToInput)
                        {
                            storage = Convert.ToInt32(result);
                            Console.WriteLine("\nVýsledek:\n" + Convert.ToString(storage, bases) + "\n");//teď už jen bůh (Ne, vezme to int ve storage, a převede to na string tak aby to bylo ve 'bases' soustavě
                        }
                        else
                        {
                            if (input == "help")
                            {
                                HelpPrikaz();
                            }
                            else
                            {
                                Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení hodnoty uživatelem
                            }
                        }

                    }
                    else if (input != "Ne")
                    {
                        if (input != "ne")
                        {
                            Console.WriteLine("Buď napiš Ano nebo Ne, žádné pitominy");
                        }
                    }
                    else
                    {
                        counter++;
                    }
                }

            }
            Console.ReadKey();
        }
    }
}