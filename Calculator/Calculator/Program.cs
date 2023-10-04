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
            bool JeToInput;
            string input;
            float no1 = 0;
            float no2 = 0;
            int ChosenFirst = 0;
            float result = 0;
            int krok = 0;
            string basechange = "";

            Console.WriteLine("ISIINA PRĎÁCKÁ KALKUALČKA\nZadej první číslo.\n");
            while (ChosenFirst < 4)
            {



                if (ChosenFirst == 0)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    JeToInput = float.TryParse(input, out no1); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírováno z mého deathrollu)
                    if (JeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + no1 + "\nZadejte druhé číslo, nebo operativní příkaz\n");
                        ChosenFirst++;
                    }
                    else
                    {
                        if (input == "help")
                        {
                            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n  odečti: odečte dvě zadaná čísla;\n  sečti: sečte dvě zadaná čísla;\n  znásob: znásobí dvě zadaná čísla;\n  vyděl: vydělí dvě zadaná čísla;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou;\n  odmocni: zadáno-li po výběru čísla, nastaví číslo jako odmocninu sama sebe;\n\n A teď zadej první číslo");
                        }
                        else
                        {
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného! " + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele
                        }
                    }
                }





                if (ChosenFirst == 1)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    JeToInput = float.TryParse(input, out no2); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírován oz mého deathrollu)
                    if (JeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + no2 + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz\n");
                        ChosenFirst++;
                    }
                    else
                    {
                        if (input == "help")
                        {
                            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n  odečti: odečte dvě zadaná čísla;\n  sečti: sečte dvě zadaná čísla;\n  znásob: znásobí dvě zadaná čísla;\n  vyděl: vydělí dvě zadaná čísla;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou;\n  odmocni: zadáno-li po výběru čísla, nastaví číslo jako odmocninu sama sebe; \n\n A teď zadej druhé číslo, nebo operativní příkaz");
                        }
                        else if (input == "nadruhou")
                        {
                            no1 = no1 * no1;
                            Console.WriteLine("\nPrvní číslo bylo dáno nadruhou. Číslo nyní činí: " + no1 + "\nZadejte druhé číslo, nebo operativní příkaz.\n");
                        }
                        else if (input == "odmocni")
                        {
                            no1 = (float)Math.Sqrt(no1);
                            Console.WriteLine("\nPrvní číslo bylo odmocněno. Číslo nyní činí: " + no1 + "\nZadejte činnost druhé číslo, nebo operativní příkaz.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele
                        }
                    }
                }




                if (ChosenFirst == 2)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    if (input == "sečti")
                    {
                        result = no1 + no2;
                        Console.WriteLine("\n Výsledek činní: " + result);
                        ChosenFirst++;
                    }
                    else if (input == "odečti")
                    {
                        result = no1 - no2;
                        Console.WriteLine("\n Výsledek činní: " + result);
                        ChosenFirst++;
                    }
                    else if (input == "znásob")
                    {
                        result = no1 * no2;
                        Console.WriteLine("\n Výsledek činní: " + result);
                        ChosenFirst++;
                    }
                    else if (input == "vyděl")
                    {
                        if (no2 == 0)
                        {
                            Console.WriteLine("\nNulou dělit nelze. Vyber nové druhé číslo.\n");
                        }
                        else
                        {
                            result = no1 / no2;
                            Console.WriteLine("\n Výsledek činní: " + result);
                            ChosenFirst++;
                        }
                    }
                    else if (input == "poděl")
                    {
                        if (no2 == 0)
                        {
                            Console.WriteLine("\nNulou dělit nelze. Vyber nové druhé číslo.\n");
                        }
                        else
                        {
                            result = no1 / no2;
                            Console.WriteLine("\nSám seš poděl! ( ´･･)ﾉ(._.`) Ale pokud jsi chtěl VYDĚLIT tak výsledek je: " + result);
                            ChosenFirst++;
                        }
                    }
                    else if (input == "help")
                    {
                        Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n  odečti: odečte dvě zadaná čísla;\n  sečti: sečte dvě zadaná čísla;\n  znásob: znásobí dvě zadaná čísla;\n  vyděl: vydělí dvě zadaná čísla;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou;\n  odmocni: zadáno-li po výběru čísla, nastaví číslo jako odmocninu sama sebe; \n\n A teď zadej přímý nebo operativní příkaz");
                    }
                    else if (input == "nadruhou")
                    {
                        no2 = no2 * no2;
                        Console.WriteLine("\nDruhé číslo bylo dáno nadruhou. Nyní činní: " + no2 + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                    }
                    else if (input == "odmocni")
                    {
                        no2 = (float)Math.Sqrt(no2);
                        Console.WriteLine("\nDruhé číslo bylo odmocněno. Číslo nyní činí: " + no2 + "\nZadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele
                    }
                }




                if (ChosenFirst == 3)
                {
                    Console.WriteLine("\nPřevést do nějaké soustavy?\nAno/Ne? V případě ne ukončuji kód");
                    input = Console.ReadLine();
                    if (input == "Ano")
                    {
                        Console.WriteLine("Do které? K dispozici:\n  Šestnáctková\n  Dvojková\n");
                        input = Console.ReadLine();
                        if (input == "Dvojková")
                        {
                            while (krok == 0)
                            {
                                no1 = result / 2;
                                no2 = result % 2;
                                basechange += no2;
                                result = result / 2;
                                if (no1 < 1)
                                {
                                    krok++;
                                }
                                Console.WriteLine("Výsledek v dvojkové sousatvě je: " + basechange);
                            };
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
                        ChosenFirst++;
                    }
                }

            }
            Console.ReadKey();
        }
    }
}