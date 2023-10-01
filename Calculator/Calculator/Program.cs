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
            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * DONE 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * DONE 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * DONE 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * DONE 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * DONE 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            //Tento komentar smaz a misto nej zacni psat svuj prdacky kod.
            bool JeToInput;
            string input;
            float no1 = 0;
            float no2 = 0;
            int ChosenFirst = 0;
            float result = 0;

            Console.WriteLine("ISIINA PRĎÁCKÁ KALKUALČKA\nZadej první číslo.\n");
            while (ChosenFirst < 3) 
            {



                if (ChosenFirst == 0)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    JeToInput = float.TryParse(input, out no1); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírováno z mého deathrollu)
                    if (JeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + no1 + " zadejte druhé číslo, nebo operativní příkaz\n");
                        ChosenFirst++;
                    }




                    else
                    {
                        if (input == "help")
                        {
                            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou; "); //vybídka ke znovunastavení sázky uživatele
                        }
                        else
                        {
                            Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele
                        }
                    }
                }



                if (ChosenFirst == 1)
                {
                    input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                    JeToInput = float.TryParse(input, out no2); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (zkopírován oz mého deathrollu)
                    if (JeToInput)
                    {
                        Console.WriteLine("\n" + input + " bylo konvertováno na: " + no2 + ", zadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz\n");
                        ChosenFirst++;
                    }




                    else
                    {
                        if (input == "help")
                        {
                            Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou; "); //vybídka ke znovunastavení sázky uživatele
                        }
                        else if (input == "nadruhou")
                        {
                            no1 = no1 * no1;
                            Console.WriteLine("\nPrvní číslo bylo dáno nadruhou. Číslo nyní činí: " + no1 + " Zadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
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
                        result = no1 / no2;
                        Console.WriteLine("\n Výsledek činní: " + result);
                        ChosenFirst++;
                    }
                    else if (input == "poděl")
                    {
                        result = no1 / no2;
                        Console.WriteLine("\n Sám seš poděl! Ale pokud jsi chtěl VYDĚLIT tak výsledek: " + result);
                        ChosenFirst++;
                    }
                    else if (input == "help")
                    {
                        Console.WriteLine("\nSEZNAM PŘÍKAZŮ PRO ISIINU PRĎÁCKOU KALKULAČKU!\n\nPŘÍMÉ PŘÍKAZY-\n  help: hádej vole;\n\nOPERATIVNÍ PŘÍKAZY-\n  nadruhou: zadáno-li po výběru čísla, znásobí číslo samo se sebou; "); //vybídka ke znovunastavení sázky uživatele
                    }
                    else if (input == "nadruhou")
                    {
                        no2 = no2 * no2;
                        Console.WriteLine("\nDruhé číslo bylo dáno nadruhou. Nyní činní: " + no2 + " Zadejte činnost (e.g. sečti, znásob, etc.), nebo operativní příkaz.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nChuligáne! Tomu říkáš číslo!? Nemel blbosti a napiš něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
