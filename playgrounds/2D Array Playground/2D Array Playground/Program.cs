using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] array = new int[5, 5];
            int cislenko = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = cislenko;
                    cislenko++;
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");


            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 4;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write(array[nRow, i] + " ");
            }
            Console.WriteLine("\n");


            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, nColumn] + " ");
            }
            Console.WriteLine("\n");


            //BONUS TODO hlavní diagonála
            nColumn = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, nColumn] + " ");
                nColumn++;
            }
            Console.WriteLine("\n");


            //BONUS TODO vedlejší diagonála
            nRow = 4;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write(array[nRow, i] + " ");
                nRow--;
            }
            Console.WriteLine("\nBudeš můj výpočet pro vedlejší diagonálu? Protože chci abys mi zvětšil jéčko...");
            Console.WriteLine("\n");

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst = 0;
            int yFirst = 0;
            int xSecond = 4;
            int ySecond = 4;

            int memory;
            for (int i = 0; i < 2; i++)
            {
                memory = array[xFirst, yFirst];
                array[xFirst, yFirst] = array[xSecond, ySecond];
                array[xSecond, ySecond] = memory;
                for (int k = 0; k < array.GetLength(0); k++)
                {
                    for (int l = 0; l < array.GetLength(1); l++)
                    {
                        Console.Write(array[k, l] + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("\n");
            }
            


            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            int[] swapArray = { 0, 0, 0, 0, 0, };
            for (int i = 0; i < 4; i++)
            {
                swapArray[i] = array[nRowSwap,i];
            }
            for (int i = 0; i < 4; i++)
            {
                array[nRowSwap, i] = array[mRowSwap, i];
            }
            for (int i = 0; i < 4; i++)
            {
                array[mRowSwap, i] = swapArray[i];
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");


            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            int nDiagSwap = 0;
            int mDiagSwap = 0;
            for (int i = 0; i < 3; i++)
            {
                mDiagSwap = array[i, i];
                array[i, i] = array[array.GetLength(0) - i, array.GetLength(1) - i];
                array[array.GetLength(0) - i, array.GetLength(1) - i] = mDiagSwap;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.
            int kDiagSwap = 0;
            int lDiagSwap = 0;
            for (int i = 0; i < 3; i++)
            {
                lDiagSwap = array[i, array.GetLength(1) - i];
                array[i, array.GetLength(1) - i] = array[array.GetLength(0) - i, i];
                array[array.GetLength(0) - i, i] = lDiagSwap;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
