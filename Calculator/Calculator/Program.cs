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
            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n  odečti: odečte dvě zadaná čísla;\n  sečti: sečte dvě zadaná čísla;\n  znásob: znásobí dvě zadaná čísla;\n  vyděl: vydělí dvě zadaná čísla;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou;\n  odmocni: zadáno-li po výběru čísla, nastaví číslo jako odmocninu sama sebe; \n\n A teď zadej druhé číslo, nebo operativní příkaz");
        }
        static void Main(string[] args)
        {
            /* STRUKTURA:
             * 
             * Definice potřebných promněých
             * představení programu
             * 
             * input prvního čísla
             *      jestli je help, print help a opakujeme žádost
             *      
             *      
             * input druhého čísla
             *      jestli je help, print help a opakujeme žádost
             *      jestli je odmocni/nadruhou, efektujeme 1. číslo a opakujeme žádost o input 2. čísla
             *      
             * input operace
             *      příkazy, včetně pojistky dělění nulou
             *          jestli je help, print help a opakujeme žádost
             *          jestli je odmocni/nadruhou, efektujeme 2. číslo a opakujeme žádost o input příkazu
             * 
             * ReadKey
             * KONEC PROGRAMU
             */
            bool jeToInput;
            string input;
            float numberOne = 0;
            float numberTwo = 0;
            int counter = 0;
            float result = 0;
            int krok = 0;
            int baseChange = 0;

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
                        if (input == "help")
                        {
                            HelpPrikaz();
                        }
                        else if (input == "nadruhou")
                        {
                            numberOne = numberOne * numberOne;
                            Console.WriteLine("\nPrvní číslo bylo dáno nadruhou. Číslo nyní činí: " + numberOne + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                        }
                        else if (input == "odmocni")
                        {
                            numberOne = (float)Math.Sqrt(numberOne);
                            Console.WriteLine("\nPrvní číslo bylo odmocněno. Číslo nyní činí: " + numberOne + "\nZadejte činnost druhé číslo, nebo operativní příkaz.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení hodnoty uživatelem
                        }
                    }
                }
                if (counter == 2)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    switch (input)//nejspíš nejvýznamější část celé kalkulačky
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
                        case "poděl":
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
                        default:
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n");
                            break;
                    }

                }
                if (counter == 3)
                {
                    Console.WriteLine("\nPřevést do nějaké soustavy?\nAno/Ne? V případě ne ukončuji kód");
                    input = Console.ReadLine();
                    if (input == "Ano")
                    {
                        Console.WriteLine("Do které? K dispozici (1-32)");
                        baseChange = Convert.ToInt32(Console.ReadLine());
                        Convert.ToInt32(result);
                        Convert.ToString(result, baseChange);
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