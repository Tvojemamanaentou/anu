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
        static int goldsPC = 10000; //peněženka hráče 1
        static int goldsU = 10000; //peněženka hráče 2
        static int betPC; //sázka počítače
        static int betU; //sázka hráče
        static int betFinal = 1000; //finalni částka na které se hráči dohodli
        static int numberOfRolls = 0; //kolikrát se házelo, abychom si mohli utahvoat z hráče když hodil 1 na první pokus
        static int step = 0; //které je kolo
        static int counter = 0; // counter = Procdeural Step Counter, použitý na počítání kroků, abychom využívali na hile apod.
        static bool jeToInput = false;
        static bool winPC = false;
        static bool continueRunning = true;
        static string input = ""; 
        static void AnoNe()//pokud ano, pokračuje znovu od začátku, pokud ne, končí program
        {
            input = Console.ReadLine();
            if (input == "ano")
            {
                step = 2;
            }
            else if (input == "ne")
            {
                Console.WriteLine("\nŠMAJDALF : Dobrá Fritóšórku! Zatím nashledanou!\n");
                Console.ReadKey();
                continueRunning = false;//ukončuje program
            }
            else
            {
                Console.WriteLine("\nŠMAJDALF : Řekl jsem, chceš si zahrát!? (ano/ne)\n");
            }
        }
        static void Main(string[] args)
        {
            {
                Random rnd = new Random(); //random promněnná
                //úvod k sázecí části (přehraje se pouze po začatí programu)
                betPC = rnd.Next(2, goldsPC); //generace prvního návrhu na sázku, mezi 2 a all in
                Console.WriteLine("ŠMAJDALF : Vítej, poutníče! Zahraj si se mnou smrtirachot! Oba na začátku začínáme s měšcem s 10 000 zlaťáky. Já na první kolo sázím " + betPC + ". Líbí se ti tahle částka? (ano/ne)\n"); //Vybídka k dohodnutí se na sázce
                //sázecí část
                while (continueRunning == true)
                {
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
                                    Console.WriteLine("\nŠMAJDALF : Chuligáne! Tomu říkáš sázka!? Nemel blbosti a vyber něco pořádného!\n"); //vybídka ke znovunastavení sázky uživatele 
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nŠMAJDALF : Neruzumím jayzku tvého kmene. Zkus to znovu, byla to ano ne otázka.\n");
                        }
                    }
                    roll = betFinal; //nasatví roll na max sázku
                    while (step == 1) //pokud je první kolo
                    {
                        while (counter == 1) //opakujeme dokud šikulka za klávesnicí nenapíše hod :) zároveň funguje jako každý hod pro hráče
                        {
                            input = Console.ReadLine(); //nastaví INPUT na to co napíše user
                            if (input == "hod") //pokud je input hod, pokračujeme na rollování
                            {
                                roll = rnd.Next(1, roll); //náhodné číslo od 1 do hodnoty předchozího rollu
                                if (roll > 1) //pokud je hod víc jak jedna, 
                                {
                                    Console.WriteLine("\nHodil jsi " + roll + "\n");
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
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nŠMAJDALF : Jedna! No, tak jsi prohrál no, nic si z toho nedělej... Chceš si zahrát znovu? (ano/ne)\n");
                                        AnoNe();
                                        winPC = true;
                                        break;
                                    }
                                }
                            
                            }
                            else
                            {
                                Console.WriteLine("\nŠMAJDALF : Řekl jsem hod! Co to tu žblebtáš!? Zkus to znovu.\n");
                            }
                        }
                        while (counter == 2) //házení PC
                        {
                            roll = rnd.Next(1, roll); //náhodné číslo od 1 do hodnoty předchozího rollu
                            if (roll > 1) //pokud je hod víc jak jedna, 
                            {
                                Console.WriteLine("\nŠMAJDALF : Hodil jsem " + roll + ", teď je řada na tobě. (napiš hod)\n");
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
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nŠMAJDALF : Světluško v baterce já prohrál! Jedna! No, tak jsem prohrál no...Tady máš ty goldy. Chceš si zahrát znovu? (ano/ne)\n");
                                    AnoNe();
                                    winPC = false;
                                    break;
                                }
                            }
                        }
                    }
                    while (step == 2)//transakce goldů v hodnotě sázky od prohraného, výherci, pouze pokud chce hráč pokračovat
                    {
                        if (goldsU < 20) //ať má hra nějaký konec může tady buď hráč či PC být kompletně odrbán 
                        {
                            Console.WriteLine("\nŠMAJDALF : HÁ HÁ! Tomu říkám hráč. Ani vyndru už nemáš! O všechno jsem tě odrbal!\n\n\nGAME OVER!");
                            Console.ReadKey();
                            continueRunning = false;
                        }
                        else if (goldsPC < 20)
                        {
                            Console.WriteLine("\nŠMAJDALF : NO TEDA! ÚPLNĚ JSI MĚ ZRUINOVAL!!! TEĎ UŽ NEMÁM ANI NA STAROU BELU! Jdi se vytrsat na nějaký techno a mě už na oči ani nelez!\n\n\nGAME OVER!");
                            Console.ReadKey();
                            continueRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("\nŠMAJDALF : Dobrá tedy! Další kolo!\n");
                            if (winPC == true)
                            {
                                goldsU = goldsU - betFinal;
                                goldsPC = goldsPC + betFinal;
                            }
                            else
                            {
                                goldsU = goldsU + betFinal;
                                goldsPC = goldsPC - betFinal;
                            }
                            Console.WriteLine("    Bilanc Šmajdalfa:" + goldsPC + "\n    Bilanc tebe:" + goldsU);
                            step = 0;
                            while (betPC > goldsU) //opakujeme generaci nové částky dokud je větší než množství goldů na účtě usera, jinak by to byl infinite money glitch
                            {
                                if (goldsU > 50)
                                {
                                    betPC = rnd.Next(2, goldsPC); //tahle generace nové sázky musí být tady protože předchozí je ještě před prvním whilem
                                    Console.WriteLine("\nŠMAJDALF : Já sázím " + betPC + ". Líbí se ti tahle částka? (ano/ne)\n");
                                }
                                else 
                                {
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
