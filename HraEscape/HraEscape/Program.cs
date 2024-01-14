using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace HraEscape
{
    /*Je to tu strašně chaotický ale přísahám bohu že to dává smysl. Spolužačka se o tom vyjádřila že to není spaghetti kód, ale tortellini kód protože je tam strašně moc úseků:
     * Jsou tu funkce '_Speaks' což jsou jen způsoby vypisování do konzole jinými estetickými vzhledy
     * Dále jsou tu funkce Error, což je... error a Help což je... já nevím jako jestli tohle mám vysvětlovat ono je to docela sebeevidentní....
     * Dále WhatNow která se sepne pokáždé když se "vejde" do nějaké lokace a poté se ptá hráče co chce v lokaci dělat
     * Dále Action která se sepne když chce hráč interagovat s mapou nebo i v rámci inventáře 
     * Proč jsou jen dvě funkce lokací?
     *      -jen knihovna a stůl mají "podlokace" tj. něco s čím můžeme interagovat na ddaném místě (dopis, hrnek, sejf) zatímco s klecí i se skříní iteragujeme jako s takovými.
     */
    internal class Program
    {
        static int location = 0; //funguje na 4 lokace skříň, klec, stůl, knihovna
        static int unterlocation = 0; //používáme jen 2x u knihovny ale jiné jednodušší řešení mě napadlo a to jsem to zkoušela
        static bool[] invState = new bool[5]; //má to v inventáři?
        static string[] invText = { "hodně spravované UV světelko", "miska slunečnicových semínek", "gravírovaná bronzová růže", "cár papíru", "zlatý klíček" };
        /*Máme pět itemů které může Pankrác použít. To jestli hráč má nějaký item řešíme tak že ukládáme bool na pozici itemu. a pro jeho vypsání pak porovnáváme s arrayem invText kde jsou uloženy jména itemů.
                                    * itemy:
                                    *0 - hodně spravované UV světelko
                                    *1 - miska slunečnicových semínek
                                    *2 - gravírovaná bronzová růže
                                    *3 - potrhaný papírek
                                    *4 - zlatý klíček
                                    */


        static void InventoryTextBuilder() //pětkrát opakujeme že koukneme jestli bool pole invState na pozici i je pravda. Pokud ano, vypíšeme pozici z invText. Pokud ne, píšeme -nic
        {
            string memory = "Inventář:";
            for (int i = 0; i < 5; i++)
            {
                if (invState[i] == true)
                {
                    memory += "\n  " + i + "- " + invText[i];
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
                    Thread.Sleep(50); 
                }
                else if (character == '.' || character == '!')
                {
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(12);
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
        static void Action(string input, int location)
        {
            int memory = 0;
            EventSpeaks("Jde o akci:\n1- věcí(z inventáře) s lokací\n2- věcí s věcí");
            while (memory == 0)
            {
                int.TryParse(Console.ReadLine(), out memory);
            }
            switch (memory)
            {
                case 1:
                    int item = 6;
                    EventSpeaks("Kterou věcí chceš interagovat?");
                    while (item == 6)
                    {
                        if (int.TryParse(Console.ReadLine(), out item))
                        {
                            if (item > 4 || item < -1)
                            {
                                PankracSpeaks("Vždyť tolik kapes ani nemam... Zkus něco jiného.\n");
                                item = 6;
                            }
                            else if (invState[item] == false)
                            {
                                PankracSpeaks("Vždyť v téhle kapse ani nic nemam! Zkus něco jiného.\n");
                                item = 6;
                            }
                            else
                            {
                                switch (location)
                                {
                                    case 1:
                                        if (item == 4)
                                        {
                                            PankracSpeaks("JÉ! OTVEVŘELA SE! Ale co to jé?\n");
                                            NarratorSpeaks("Konec Dema, pro plnou verzi mi zaplaťte.");
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                        break;
                                    case 2:
                                        if (item == 1)
                                        {
                                            PankracSpeaks("Ná puťa puťa papoušek, dej si semínka!\n");
                                            NarratorSpeaks("Papoušek upustil bronzovou růži\n");
                                            PankracSpeaks("Ta se mi bude hodit, vezmu si ji!\n");
                                            invState[1] = false;
                                            invState[2] = true;
                                        }
                                        else
                                        {
                                            PankracSpeaks("Teda co s timhle tady mam vykoumat to netuším...\n");
                                        }
                                        break;
                                    case 4:
                                        switch (unterlocation)
                                        {
                                            case 1:
                                                if (item == 2)
                                                {
                                                    PankracSpeaks("Zkusím tomu tanečníkovi tu bronzovou růži vložit do úst.\n");
                                                    NarratorSpeaks("Z pod sošky se vykutálela rulička\n");  
                                                    PankracSpeaks("Co to jé? Nějaká rulička papíru? Píše se na ní něco? Hm, nic. Co teď?\n");
                                                    invState[2] = false;
                                                    invState[3] = true;
                                                }
                                                else
                                                {
                                                    PankracSpeaks("Teda co s timhle tady mam vykoumat to netuším...");
                                                }
                                                break;
                                            case 2:
                                                if (invState[0] == false && item == 3) //víme, že hráč objevil kód, protože se po objevení kódu rozbije UV světlo.
                                                {
                                                    PankracSpeaks("Zkusím tam zadat ta písmenka z toho cáru papíru, třeba se otveře. Otevřel!\n");
                                                    NarratorSpeaks("V sejfu byl zlatý klíček\n");
                                                    PankracSpeaks("Klíček! Asi tuším, od čeho bude. ;)\n");
                                                    invState[4] = true;
                                                }
                                                else
                                                {
                                                    PankracSpeaks("Teda co s timhle tady mam vykoumat to netuším...\n");
                                                }
                                                break;
                                        }
                                        break;
                                }                                
                            }                            
                        }
                        else
                        {
                            Error();
                        }                        
                    }                    
                    break;
                case 2:
                    InterInventoryAction();
                    break;
                default:
                    EventSpeaks("Há há, moc vtipný, teď zkus něco pořádnýho.\n");
                    Action(input, location);
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
                if (itemA > 4 || itemA < 0)
                {
                    PankracSpeaks("Vždyť tolik kapes ani nemam... Zkus něco jiného.\n");
                    itemA = 6;
                }
                else if (invState[itemA] == false)
                {
                    PankracSpeaks("Vždyť v téhle kapse ani nic nemam! Zkus něco jiného.\n");
                    itemA = 6;
                }
            }
            EventSpeaks("Vyber druhý item který chceš kombinovat");
            while (itemB == 6)
            {
                int.TryParse(Console.ReadLine(), out itemB);
                if (itemB > 4 || itemB < 0)
                {
                    PankracSpeaks("Vždyť tolik kapes ani nemam... Zkus něco jiného.\n");
                    itemB = 6;
                }
                else if (invState[itemB] == false)
                {
                    PankracSpeaks("Vždyť v téhle kapse ani nic nemam! Zkus něco jiného.\n");
                    itemB = 6;
                }
            }
            memory = Convert.ToString(itemA) + Convert.ToString(itemB); //jelikož budemeli mixovat kterekoliv itemy mimo UV s papírkem tak se nic stát nemůže tak potřebujeme jen vědět jestli hráč nekombinuje 03 nebo 30 pokud ano tak říkáme jů svítí, pokud ne tak se divíme co s tím měl jako udělat
            if (memory == "03" || memory == "30")
            {
                PankracSpeaks("JŮ! On ten útržek úplně začal svítit! No ale co to-? Něco se tu píše. Ká eR eL É? Co to znamená? Že by Krleš? Ale co to má s Kriste- JAÚ! Jéžiš! Ten zpropadenej UV zmetek mě kopnul a já ho pustil. Tak teď už ho opravdu nezachráním\n");
                invState[0] = false;
                invText[3] = "Cár papíru s písmeny K R L E";
            }
            else
            {
                PankracSpeaks("Teda co s těmahle věcma mam vykoumat to netuším...\n");
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
                        PankracSpeaks("Plno knih... nějaký Jirka Kegel, Lakán, Houmr a dokonce i Džín Žák Rusák! Ale s případem mi nic z toho nepomůže\n");
                        WhatNow(input);
                        break;
                    case "soška":
                        PankracSpeaks("Bronzová soška tančícího páru. Ale že MÁ ten chlapík divně zkroucenou hubu! Skoro jako kdyby mu v ní něco chybělo.\n");
                        unterlocation = 1;
                        WhatNow(input);
                        break;
                    case "sejf":
                        PankracSpeaks("Bytelný litinový sejf. Do něj si nejspíš Alfréd schovává své cenosti.\n");
                        unterlocation = 2;
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
                        Action(input, location);
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
                switch (input) //vybere jednu z lokací, hodí do funkce, buď what now nebo pokud je kostra dané lokace složitější, do vlastní funkce
                {
                    case "skříň":
                        location = 1;
                        PankracSpeaks("Pěkná malovaná skříň. Zajímalo by mě, jestli má Lord Alfréd také zevnitř na dveřích nějaké prasečinky hehehé!\n");
                        while (location == 1)
                        {
                            WhatNow(input);
                        }
                        break;
                    case "klec":
                        location = 2;
                        PankracSpeaks("Jéjé! Nevděl jsem, že Alfréd chová papouška! To je ale fešák! Ale cosi to má v puse. Jakousi bronzovou růži.\n");
                        while (location == 2)
                        {
                            WhatNow(input);
                        }
                        break;
                    case "stůl":
                        location = 3;
                        NarratorSpeaks("Na stole ležely tři věci.");
                        PankracSpeaks("Hm, dopis, miska a šálek s ještě teplou nedopitou kávou. To tu asi musel nechat Alfréd.");
                        EventSpeaks("zPodlokace:\ndopis\nhrnek\nmiska");
                        while (location == 3)
                        {
                            LocationTable(input);
                        }
                        break;
                    case "knihovna":
                        location = 4;
                        NarratorSpeaks("V knihovně bylo plno knížek (kdo by to byl čekal), ale také sejf a bronzová soška.");
                        EventSpeaks("Podlokace:\nsejf\nsoška\nknihy");
                        while (location == 4)
                        {
                            LocationBookcase(input);
                        }
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
