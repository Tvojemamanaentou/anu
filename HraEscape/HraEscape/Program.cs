using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HraEscape
{
    /*  Únikovka
     * 
     *potřeba:
     *  definovat inventář jako pole
     *  
     *  definovat itemy
     *          
     *      zlatý klíč
     *          "Zlatý klíček! Má krásné zoubky... Od čeho asi je?"
     *          
     *      papírek s šifrou
     *          "Nějakej papírek
     *          "(posvícený) Jůhuhů! Ten papírek nějak začal svítit! Něco se tu píše. Ká eR eL É?           Co to znamená? Že by Krleš? JAÚ! Ten zpropadenej UV zmetek mě kopnul a já ho              pustil. Tak teď už ho opravdu nezachráním"
     *          
     *          
     *      gravírovaná ozdobná růže
     *          "To je teprve krásný tentononc! No počkat! To je z mosazi!"
     *      
     *      spravované UV světelko
     *          "Můj věrný UV bazmek! Doufám, že se mu nic nestane."
     *          
     *          
     *          
     *  definovat location
     *      skříň
     *          needs - klíč
     *          bez - "Hm... zamčená... Asi nevím, co jsem čekal. Že to bude tak jednoduché? To                     bych musel být asi už opravdu blbej..."
     *          // NarratorSpeaks("Pankrác se vehementně, ale bezútěšně snaží otevřít zamklou skříň.");
                // PankracSpeaks("Kdepak, ta se nehne... Musím někde najít klíček od toho zámku.");
     *          
     *      psací stůl
     *          podlocation - dopis
     *              "Je tu nějaký dopis! 'Milý Pankráci. Omluv prosím nepořádek, musel jsem odejít ve spěchu. Jdou po mě. Další stopa je ve skříni.' No to jsem z toho Jelen... Chudák Alfréd Takže další stopa je ve skříni. No ale, jak se do ní dostanu?"
     *          podlocation - šálek s ještě teplou kávou
     *              "Obyčejný hrnek s pozlaceným okrajem. Nic Zvláštního..."
     *          item - miska se slunečnicovými semínky
     *              "Miska se semíky zdobená podobně jako tady ten hrnek. Vezmu si ji. Třeba                    dostanu hlad"
     *          
     *      knihovna
     *          podlocation - sejf
     *              needs - šifra
     *              
     *              bez - "
     *              item -  klíč
     *          podlocation - mosazná soška
     *              "Krásná mosazná sožka tančícího páru! Slečna se na svého partnera dívá                       skutečně zamilovaně. Ale co to jehehé?! Tak ten její milý se na ní kouká                  opravdu zděšeně. Má nějak zvláštně zkroucenou hubu."
     *              
     *      klec
     *          needs - miska se 
     *          bez - ""
     *      
     *  definovat interakci dvou itemů
     *  
     *  hráč může
     * 
     * 
     * 
     * 
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


        static void InventoryTextBuilder() //pětkrát opakujeme že koukneme jestli bool na pozici i-1 (abychom mohli použít na indexování v outputu) je pravda. Pokud ano, vypíšeme pozici z invText. Pokud ne, píšeme -nic
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
            foreach (char character in speech)
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
        static void Action()
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
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        static void WhatNow()
        {
            string input = "";
            NarratorSpeaks("Co teď?");
            while (location != 0)
            { 
                input = Convert.ToString(Console.ReadLine());
                switch (input)
                {
                    case "pomoc":
                        Help();
                        break;
                    case "inv":
                        InventoryTextBuilder();
                        break;
                    case "akce":
                        Action();
                        break;
                    case "zpět":
                        location = 0;
                        break;
                    default:
                        Error();
                        break;
                }
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
                        WhatNow();
                        break;
                    case "klec":
                        location = 2;
                        WhatNow();
                        break;
                    case "stůl":
                        location = 3;
                        WhatNow();
                        break;
                    case "knihovna":
                        location = 4;
                        WhatNow();
                        break;
                    default:
                        Error();
                        break;
                }
            };
            InventoryTextBuilder();
            Console.ReadKey();
            
        }
    }
}
