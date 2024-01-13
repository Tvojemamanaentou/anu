using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HraEscape
{
    /*Je to tu strašně chaotický ale přísahám bohu že to dává smysl:
     * Jsou tu funkce '_Speaks' což jsou jen způsoby vypisování do konzole jinými estetickými vzhledy
     * Dále jsou tu funkce Error, což je... error a Help což je... já nevím jako jestli tohle mám vysvětlovat ono je to docela sebeevidentní....
     * Dále WhatNow která se sepne pokáždé když se "vejde" do nějaké lokace a poté se ptá hráče co chce v lokaci dělat
     * Dále Action která se sepne když chce hráč interagovat s mapou nebo i v rámci inventáře 
     * Proč jsou jen dvě funkce lokací?
     *      -jen knihovna a stůl mají "podlokace" tj. něco s čím můžeme interagovat na ddaném místě (dopis, hrnek, sejf) zatímco s klecí i se skříní iteragujeme jako s takovými.
     */
    internal class Program
    {
        static int location = 0;
        static bool[] invState = new bool[5];
        static string[] invText = { "hodně spravované UV světelko", "miska slunečnicových semínek", "gravírovaná bronzová růže", "potrhaný papírek", "zlatý klíček" };
        /*Máme pět itemů které může Pankrác použít. To jestli hráč má nějaký item řešíme tak že ukládáme bool na pozici itemu. a pro jeho vypsání pak porovnáváme s arrayem invText kde jsou uloženy jména itemů.
                                    * itemy:
                                    *0 - hodně spravované UV světelko
                                    *1 - miska slunečnicových semínek
                                    *2 - gravírovaná bronzová růže
                                    *3 - potrhaný papírek
                                    *4 - zlatý klíček
                                    */


        static void InventoryTextBuilder() //pětkrát opakujeme že koukneme jestli bool pole invState na pozici i-1 (abychom mohli použít na indexování v outputu) je pravda. Pokud ano, vypíšeme pozici z invText. Pokud ne, píšeme -nic
        {
            string memory = "Inventář:";
            for (int i = 1; i < 6; i++)
            {
                if (invState[i - 1] == true)
                {
                    memory += "\n  " + i + "- " + invText[i - 1];
                }
                else
                {
                    memory += "\n  " + i + "- nic";
                }
            }
            memory += "\n";
            EventSpeaks(memory);
        }
        static void PankracSpeaks(string speech)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; 
            foreach (char character in speech)//tbh idea není moje, to mám ze stack overflow a tohle bylo s pomocí C# učebních pomůcek od microsoftu ale je to moje implementace co dělá věttší pauzy s mezerama a ještě větší s tečkamam a vykřičníky
            {
                Console.Write(character);
                if (character == ' ')
                {
                    Thread.Sleep(0); //100
                }
                else if (character == '.' || character == '!')
                {
                    Thread.Sleep(0); //200
                }
                else
                {
                    Thread.Sleep(0); //25
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EventSpeaks(string speech)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" + speech);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void NarratorSpeaks(string speech)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(speech);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Action(string input)
        {
            int memory = 0;
            EventSpeaks("Jde o akci:\n1- holou rukou s lokací\n2- věcí(z inventáře) s lokací\n3- věcí s věcí");
            while (memory == 0)
            {
                int.TryParse(Console.ReadLine(), out memory);
            }
            switch (memory)
            {
                case 1:
                    switch (location)
                    {
                        case 1: //u skříně 
                            break;
                        case 2: //u klece
                            break;
                        case 3: //u stolu
                            while (location == 3)
                            {
                                WhatNow(input);
                            }
                            break;
                        case 4: //u knihovny
                            break;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    InterInventoryAction();
                    break;
            }
        }
        static void InterInventoryAction()
        {
            int itemA = 6;
            int itemB = 6;
            string memory = "";
            EventSpeaks("Vyber první item který chceš kombinovat");
            while (itemA == 6)
            {
                int.TryParse(Console.ReadLine(),out itemA);
                if (itemA > 4)
                {
                    PankracSpeaks("Vždyť tolik kapes ani nemam... Zkus něco jiného.");
                    itemA = 6;
                }
                else if (invState[itemA] == false)
                {
                    PankracSpeaks("Vždyť v téhle kapse ani nic nemam! Zkus něco jiného.");
                    itemA = 6;
                }
            }
            EventSpeaks("Vyber druhý item který chceš kombinovat");
            while (itemB == 6)
            {
                int.TryParse(Console.ReadLine(), out itemB);
                if (itemB > 4)
                {
                    PankracSpeaks("Vždyť tolik kapes ani nemam... Zkus něco jiného.");
                    itemB = 6;
                }
                else if (invState[itemB] == false)
                {
                    PankracSpeaks("Vždyť v téhle kapse ani nic nemam! Zkus něco jiného.");
                    itemB = 6;
                }
            }
            memory = Convert.ToString(itemA) + Convert.ToString(itemB); //jelikož budemeli mixovat kterekoliv itemy mimo UV s papírkem tak se nic stát nemůže tak potřebujeme jen vědět jestli hráč nekombinuje 03 nebo 30 pokud ano tak říkáme jů svítí, pokud ne tak se divíme co s tím měl jako udělat
            if (memory == "O3" || memory == "30")
            {
                PankracSpeaks("JŮ! On ten útržek úplně začal svítit! No ale co to-? Něco se tu píše. Ká eR eL É? Co to znamená? Že by Krleš? Ale co to má s Kriste- JAÚ! Jéžiš! Ten zpropadenej UV zmetek mě kopnul a já ho pustil. Tak teď už ho opravdu nezachráním");
                invState[0] = false;
            }
            else
            {
                PankracSpeaks("Teda co s těmahle věcma mam vykoumat to netuším...");
            }
        }
        static void LocationTable(string input)
        {
            while (location == 3)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "dopis":
                        PankracSpeaks("Je tu nějaký dopis! 'Milý Pankráci. Omluv prosím nepořádek, musel jsem odejít ve spěchu. Jdou po mě. Další stopa je ve skříni.' No to jsem z toho Jelen... Chudák Alfréd. Takže další stopa je ve skříni. No ale, jak se do ní dostanu?\n");
                        break;
                    case "hrnek":
                        PankracSpeaks("Obyčejný hrnek s pozlaceným okrajem. Nic Zvláštního...\n");
                        break;
                    case "miska":
                        if (invState[1] == true)
                        {
                            PankracSpeaks("Misku už jsem si vzal.\n");
                        }
                        else
                        {
                            PankracSpeaks("Miska se semíky, zdobená podobně jako tady ten hrnek. Vezmu si ji. Třeba dostanu hlad.\n");
                            invState[1] = true;
                        }
                        break;
                    default:
                        if (input == "inv" || input == "pomoc" || input == "akce" || input == "zpět")
                        {
                            WhatNow(input);
                        }
                        else
                        {
                            Error();
                        }
                        break;
                }
            }
        }
        static void LocationBookcase(string input)
        {
            while (location == 4)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "knihy":
                        PankracSpeaks("Je tu nějaký dopis! 'Milý Pankráci. Omluv prosím nepořádek, musel jsem odejít ve spěchu. Jdou po mě. Další stopa je ve skříni.' No to jsem z toho Jelen... Chudák Alfréd. Takže další stopa je ve skříni. No ale, jak se do ní dostanu?\n");
                        break;
                    case "soška":
                        PankracSpeaks("Obyčejný hrnek s pozlaceným okrajem. Nic Zvláštního...\n");
                        break;
                    case "sejf":
                        if (invState[0] == false) //víme, že hráč objevil kód, protože se po objevení kódu rozbije světlo.
                        {
                            PankracSpeaks("Zkusím tam zadat ta písmenka z toho cáru papíru, třeba se otveře. Otevřel!\n");
                            NarratorSpeaks("V sejfu byl zlatý klíček");
                            PankracSpeaks("Klíček! Asi tuším, od čeho bude. ;)");
                            invState[3] = true;
                        }
                        else
                        {
                            PankracSpeaks("");
                        }
                        break;
                    default:
                        if (input == "inv" || input == "pomoc" || input == "akce" || input == "zpět")
                        {
                            WhatNow(input);
                        }
                        else
                        {
                            Error();
                        }
                        break;
                }
            }
        }

        static void WhatNow(string input)
        {
            if (input == "inv" || input == "pomoc" || input == "akce" || input == "zpět")
            {
                switch (input)
                {
                    case "pomoc":
                        Help();
                        input = "";
                        break;
                    case "inv":
                        InventoryTextBuilder();
                        input = "";
                        break;
                    case "akce":
                        Action(input);
                        input = "";
                        break;
                    case "zpět":
                        NarratorSpeaks("Pankrác se postavil doprostřed místnosti.");
                        location = 0;
                        input = "";
                        break;
                    default:
                        Error();
                        input = "";
                        break;
                }
            }
            else
            {
                NarratorSpeaks("Co teď?");
                input = Convert.ToString(Console.ReadLine());
                WhatNow(input);
            }
        }
        static void Error()
        {
            EventSpeaks("To cos tu vyblil není validní input. Vyber jeden z příkazů.");
        }
        static void Help()
        {
            EventSpeaks("Možné příkazy jsou:\npomoc - hádej hádej hádači\ninv - otevře inventář\nakce - interagovat buď v rámci inventáře nebo s mapou\nzpět - vrátí tě na předchozí lokaci");
        }









        static void Main(string[] args)
        {
            invState[0] = true; //hráč začíná s UV světlem 
            string input = "";
            NarratorSpeaks("Pankrác vstoupil do Lordovy pracovny.");
            PankracSpeaks("To je mi ale bordel. Nějak mě ten stesk po domově hnedka přešel! Hehehé! To tu asi někdo hodně dlouho neuklízel.");
            while (location != 5)
            {
                EventSpeaks("Lokace:\nskříň\nklec\nstůl\nknihovna ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "skříň":
                        location = 1;
                        while (location == 1)
                        {
                            WhatNow(input);
                        }
                        break;
                    case "klec":
                        location = 2;
                        while (location == 2)
                        {
                            WhatNow(input);
                        }
                        break;
                    case "stůl":
                        location = 3;
                        NarratorSpeaks("Na stole ležely tři věci.");
                        PankracSpeaks("Hm, dopis, miska a šálek s ještě teplou nedopitou kávou. To tu asi musel nechat Alfréd.");
                        EventSpeaks("Podlokace:\ndopis\nhrnek\nmiska");
                        while (location == 3)
                        {
                            
                            LocationTable(input);
                        }
                        break;
                    case "knihovna":
                        location = 4;
                        WhatNow(input);
                        break;
                    default:
                        Error();
                        break;
                }
            };
            Console.ReadKey();
            
        }
    }
}
