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
            int betPC; //sázka hráče 1
            int betU; //sázka hráče 2
            int player = 1; //který hráč je na tahu 
            int round = 1; //které je kolo
            Random rnd = new Random(); //random promněnná
            string input = "";

         

            if ( round == 1)
            {
                betPC = rnd.Next(0, 500);
                if (betPC > goldsPC)
                {
                    while (betPC > goldsPC)
                    {
                        betPC = rnd.Next(0, 500);
                    }
                }
                Console.WriteLine("ŠMAJDALF : Vítej, poutníče! Zahraj si se mnou smrtelný rachot! Oba na začátku začínáme s měšcem s 1000 zlaťáky. Já na první kolo sázím " + betPC + ". Kolik zlaťáků sázíš ty? \n");
                input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                bool JeToCislo = int.TryParse(input, out betU);
                if (JeToCislo)
                {
                    Console.WriteLine("Poznámka pro programátora: " + input + " konvertováno na: " + betU);
                }
                else
                {
                    Console.WriteLine("ŠMAJDALF : Chuligáne! Tomu říkáš sázka!? Vyber něco pořádného! " + input + " konvertováno nebylo.");
                }
                Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
