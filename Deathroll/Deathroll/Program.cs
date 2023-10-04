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
        static int roll = 0; //kolik bylo hozeno
        static int goldsPC = 1000; //peněženka hráče 1
        static int goldsU = 1000; //peněženka hráče 2
        static int betPC; //sázka počítače
        static int betU; //sázka hráče
        static int betFinal = 1000; //finalni částka na které se hráči dohodli
        static int numberOfRolls = 0; //kolikrát se házelo, abychom si mohli utahvoat z hráče když hodil 1 na první pokus
        static int step = 0; //které je kolo
        static int counter = 0; // counter = Procdeural Step Counter, použitý na počítání kroků, abychom využívali na hile apod.
        static bool jeToInput = false;
        static bool winPC = false;
        static string input = ""; 
        static void AnoNe()
        {
            input = Console.ReadLine();
            if (input == "ano")
            {
                step = 2;
            }
            else if (input == "ne")
            {
                Console.WriteLine("\nŠMAJDALF : Dobrá Fritóšórku! Zatím nashledanou!\n");
                step = 69;//naprosto náhodné číslo které není v žádném whilu a tudíž ukončuje program
            }
            else
            {
                Console.WriteLine("\nŠMAJDALF : Řekl jsem, chceš si zahrát!? (ano/ne)\n");
            }
        }
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
                Random rnd = new Random(); //random promněnná
                //úvod k sázecí části (přehraje se pouze po začatí programu)
                betPC = rnd.Next(2, goldsPC); //generace prvního návrhu na sázku, mezi 2 a all in
                Console.WriteLine("ŠMAJDALF : Vítej, poutníče! Zahraj si se mnou smrtirachot! Oba na začátku začínáme s měšcem s 1000 zlaťáky. Já na první kolo sázím " + betPC + ". Líbí se ti tahle částka?(ano/ne)\n"); //Vybídka k dohodnutí se na sázce
                //sázecí část
                while (step == 0)//pro opakování, aby se otázky opakovaly, dokud není dohodnuto.
                {
                    input = Convert.ToString(Console.ReadLine()); //přečtení inputu
                    if (input == "ano") //v případě že odpoví ano, jde se do druhého kola.
                    {
                        betFinal = betPC;
                        Console.WriteLine("\nŠMAJDALF : Tedy dobrá! Jdeme hrát! Začni házet. Maximální možná hodnota hodu je " + betFinal + " (Napiš: hod)\n");
                        step = 1;
                        counter = 1;
                    }
                    else if (input == "ne") //v případě že odpoví ne, šmajdalf vybízí aby si hráč vybral vlastní částku. to se dále dělí na "je to číslo?" "je to dostatečně velká částka?" "je to super číslo, jde se do dalšího kola"
                    {
                        Console.WriteLine("\nŠMAJDALF : Ne? Tak tedy navrhni vlastní! (Napiš číslo)\n");
                        while (counter == 0)
                        {
                            input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                            jeToInput = int.TryParse(input, out betU); //nový bool podle kterého určíme zda se jedná o číslo nebo nějakou blbost, pokud to není blbost, nastavíme jako betU (funkce out) (inspirováno z W3 schools ale VÝRAZNĚ upraveno)(je to už v podstatě úplně jiný kód)
                            if (jeToInput)
                            {
                                Console.WriteLine("\nPoznámka pro programátora: " + input + " konvertováno na: " + betU + "\n"); //tenhle writeline se může na poslední iteraci programu smazat, funguje jako debug když kód jede
                                if (betU <= goldsU) //pro případ že sází víc než má, říkáme ať vybere menší číslo
                                {
                                    if (betU < 10)
                                    {
                                        Console.WriteLine("\nŠMAJDALF : Hora porodila myš! Tož ty si nějako nevěříš ne? Zkus trochu větší částku...\n");
                                    }
                                    else
                                    {
                                        betFinal = betU;
                                        counter = 1;
                                        step = 1;
                                        Console.WriteLine("\nŠMAJDALF : Krásná částka. Mě se líbí! Dobrá, jedeme dál s maximálním hodem " + betFinal + " (Napiš: hod)\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nŠMAJDALF : Vždyť tolik ani nemáš ve šrajtofli! Vyber si menší číslo!\n");
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
                while (step == 1) //pokud je první kolo
                {
                    roll = betFinal; //nasatví roll na max sázku
                    while (counter == 1) //opakujeme dokud šikulka za klávesnicí nenapíše hod :) zároveň funguje jako každý hod pro hráče
                    {
                        input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                        if (input == "hod") //pokud je input hod, pokračujeme na rollování
                        {
                            roll = rnd.Next(1, roll); //náhodné číslo od 1 do hodnoty předchozího rollu
                            if (roll > 1) //pokud je hod víc jak jedna, 
                            {
                                Console.WriteLine("\nŠMAJDALF : Hodil jsi" + roll + ", teď je řada na mě.\n");
                                numberOfRolls ++; //počítá kolikrát se házelo abychom se mohli vysmívat pokud hodí 1 na prvním hodu.
                                counter = 2;
                            }
                            else if (roll == 1)
                            {
                                if(numberOfRolls == 0) 
                                {
                                    Console.WriteLine("\nŠMAJDALF : JEJE! Tady má dneska někdo šťastnej den. Hodit jedna už na prvním hodu? Skoro lepší podívaná jak trik se špičatým kloboukem. Skoro. No nic, nedá se nic dělat. Tvé goldy? Moje nyní.╰(*°▽°*)╯ Chceš si zahrát znovu? (ano/ne)\n");
                                    AnoNe();
                                    winPC = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nŠMAJDALF : Jedna! No, tak jsi prohrál no, nic si z toho nedělej... Chceš si zahrát znovu? (ano/ne)\n");
                                    AnoNe();
                                    winPC = true;
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("\nŠMAJDALF : Řekl jsem hod! Co to tu žblebtáš!? Zkus to znovu.\n");
                        }
                    }
                    while (counter == 2)
                    {
                        roll = rnd.Next(1, roll); //náhodné číslo od 1 do hodnoty předchozího rollu
                        if (roll > 1) //pokud je hod víc jak jedna, 
                        {
                            Console.WriteLine("\nŠMAJDALF : Hodil jsem" + roll + ", teď je řada na tobě.\n");
                            numberOfRolls++; //počítá kolikrát se házelo abychom se mohli vysmívat pokud hodí 1 na prvním hodu.
                            counter = 1;
                        }
                        else if (roll == 1)
                        {
                            if (numberOfRolls == 1)
                            {
                                Console.WriteLine("\nŠMAJDALF : JEJE! Tady má dneska někdo šťastnej den. Hodit jedna už na prvním hodu?  No nic, nedá se nic dělat. Mé goldy? Tvoje nyní.(┬┬﹏┬┬) Chceš si zahrát znovu? (ano/ne)\n");
                                AnoNe();
                                winPC = true;
                            }
                            else
                            {
                                Console.WriteLine("\nŠMAJDALF : Jedna! No, tak jsem prohrál no...Tady máš ty goldy. Chceš si zahrát znovu? (ano/ne)\n");
                                AnoNe();
                                winPC = true;
                            }
                        }
                    }
                }
                while (step == 2)
                {
                    Console.WriteLine("\nŠMAJDALF : Dobrá tedy! Další kolo!\n");

                    Console.WriteLine("    Bilanc Šmajdalfa:" + goldsPC + "\n    Bilanc tebe:" +goldsU);
                }

            }

        }
    }
}
