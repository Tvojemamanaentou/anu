using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Deathroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                /*
                 * Jednoduchy program na procviceni podminek a cyklu (lze udelat i rekurzi).
                 * 
                 * Vytvor program, kde bude uzivatel hrat s pocitacem deathroll.
                 * Pravidla deathrollu: Prvni hrac navrhne cislo (puvodne ve wowku pocet goldu, o ktere se hraci vsadi) a "rollne" navrhnute cislo, jinak receno je to stejne,
                 * jako kdyby si hodil kostkou s tolika stenami, jako je navrhnute cislo. Prvnimu hraci "padne" nejake cislo a druhy hrac si "rollne" padnute cislo.
                 * Prohrava ten hrac, kteremu padne 1 jako prvnimu.
                 * Ukazka hry: Hraci se shodnou na cisle 1000. Prvni hrac rollne 0-1000, padne mu 920. Druhy hrac rolluje 0-920, padne mu 235 atd. atd. az jednomu z hracu padne 1
                 * a ten prohrava.
                 * 
                 * Struktura:
                 * 
                 * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy aktualne rollovane cislo a stav "goldu" uzivatele i pocitace (oba zacinaji treba s 1000 goldu)
                 * 
                 * - uzivatel zada prvotni sazku, ktera musi byt maximalne tolik, kolik ma goldu
                 * 
                 * Opakuj dokud nepadne jednomu z hracu 1:
                 * {
                 *      Pokud je sude kolo:
                 *      {
                 *          - uzivatel zada hodnotu, kterou rolluje
                 *          - kontroluj, ze uzivatel zadal spravnou hodnotu
                 *          - uloz rollnute cislo
                 *          - vypis uzivateli, co rollnul
                 *      }
                 *      Pokud je liche kolo:
                 *      {
                 *          - pocitac rollne nahodne cislo mezi 0 a aktualne rollovanym cislem
                 *          - vypis uzivateli, co rollnul pocitac
                 *      }
                 * }
                 * 
                 * 
                 * - posledni hrajici hrac prohral, protoze mu padla 1 a sazku bere druhy hrac
                 * - vypis uzivateli kdo vyhral a stav goldu uzivatele i pocitace
                 * 
                 * ROZSIRENI:
                 * - umozni uzivateli opakovat deathroll dokud ma nejake goldy
                 */
                //Definice hodnot
                int roll = 0; //kolik bylo hozeno
                int goldsPC = 1000; //peněženka hráče 1
                int goldsU = 1000; //peněženka hráče 2
                int betPC; //sázka počítače
                int betU; //sázka hráče
                int betfinal = 1000; //finalni částka na které se hráči dohodli
                int player = 1; //který hráč je na tahu 
                int round = 0; //které je kolo
                int PSC = 0; // PSC = Procdeural Step Counter, použitý na počítání kroků, abychom využívali na hile apod.
                Random rnd = new Random(); //random promněnná
                bool JeToInput;
                string input = "";


                //úvod k sázecí části (přehraje se pouze po začatí programu)

                betPC = rnd.Next(10, 700); //generace prvního návrhu na sázku, mezi 10 a 700
                if (betPC > goldsPC) //pokud je sázka větší než hodnota naší peněženky tak sázíme znovu dokud není menší nebo rovna než počet goldů
                {
                    while (betPC > goldsPC)
                    {
                        betPC = rnd.Next(0, 400); //tentokrát zahrnujeme i nulu, abychom později zabránili tomu že se nedostaneme pod 10 a můžeme kompletně zbankrotovat
                    }
                }
                Console.WriteLine("ŠMAJDALF : Vítej, poutníče! Zahraj si se mnou smrtelný rachot! Oba na začátku začínáme s měšcem s 1000 zlaťáky. Já na první kolo sázím " + betPC + ". Líbí se ti tahle částka?(Y/N)\n"); //Vybídka k dohodnutí se na sázce

                //sázecí část

                while (round == 0)//pro opakování, aby se otázky opakovaly, dokud není dohodnuto.
                {
                    input = Convert.ToString(Console.ReadLine()); //přečtení inputu
                    if (input == "Y") //v případě že odpoví ano, jde se do druhého kola.
                    {
                        round++;
                        betfinal = betPC;
                        Console.WriteLine("\nŠMAJDALF : Tedy dobrá! Jdeme hrát! Začni házet. Maximální možná hodnota hodu je " + betfinal + " (Napiš: hod) \n");
                    }
                    else if (input == "N") //v případě že odpoví ne, šmajdalf vybízí aby si hráč vybral vlastní částku. to se dále dělí na "je to číslo?" "je to dostatečně velká částka?" "je to super číslo, jde se do dalšího kola"
                    {
                        Console.WriteLine("\nŠMAJDALF : Ne? Tak tedy navrhni vlastní! (Napiš číslo)\n");
                        while (PSC == 0)
                        {
                            input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                            JeToInput = int.TryParse(input, out betU); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (inspirováno z W3 schools ale VÝRAZNĚ upraveno)(je to už v podstatě úplně jiný kód)
                            if (JeToInput)
                            {
                                Console.WriteLine("Poznámka pro programátora: " + input + " konvertováno na: " + betU); //tenhle writeline se může na poslední iteraci programu smazat, funguje jako debug když kód jede
                                if (betU < 10)
                                {
                                    Console.WriteLine("\nHora porodila myš! Tož ty si nějako nevěříš ne? Zkus trochu větší číslo...\n");
                                }
                                else
                                {
                                    betfinal = betU;
                                    PSC = 1;
                                    round++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nŠMAJDALF : Chuligáne! Tomu říkáš sázka!? Nemel blbosti a vyber něco pořádného!" + input + " konvertováno nebylo. \n"); //vybídka ke znovunastavení sázky uživatele 
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nŠMAJDALF : Neruzumím jayzku tvého kmene. Zkus to znovu, byla to ano ne otázka.\n");
                    }
                }



                while (round == 1) //pokud je první kolo
                {
                    roll = rnd.Next(1, betfinal);

                }

            }

        }
    }
}
