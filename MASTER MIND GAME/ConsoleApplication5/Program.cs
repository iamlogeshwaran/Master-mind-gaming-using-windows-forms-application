using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_Game
{
    class Program
    {
        public static int[] SystemCodeMaker;
        public static int[,] codebracker;
        public static int size;
        public static int no;
        static void Main(string[] args)
        {
            //initialize an array
            string text = "Welcome To MasterMind Game";
            SystemCodeMaker = new int[4];
            codebracker = new int[10, 4];
            size = codebracker.Length;
            int temp = 1;

            Console.WriteLine(text+"\n");
            TwoDPrintarray(codebracker);
            int[] randomno = GenerateMakerArray();
           // Console.WriteLine(intprintArray(randomno));

            while (size > 0)
            {

                Console.WriteLine("Guess the 4 numbers :) ");
                no = int.Parse(Console.ReadLine());

                TwoDPrintarray(AllocateElements(codebracker, GetDigits(no), temp));

                Console.Write("Keys are:\t");

                Console.WriteLine(charprintArray(compare(randomno, GetDigits(no))));
                compare(GenerateMakerArray(), GetDigits(no));

                size = size - 4;
                temp++;

//determine winner
                if (PrintStateOfWinning(CheckWin(compare(randomno, GetDigits(no))), size) == "UserWin")
                {
                    Console.WriteLine("Code maker is:\t" + intprintArray(randomno));
                    Console.WriteLine("User Win");
                    break;
                }

                else if (size == 0)
                {
                    Console.WriteLine("Code maker is:\t" + intprintArray(randomno));
                    Console.WriteLine("System Win");
                    
                }
                
            }
        }
          public static int[,] AllocateElements(int[,] arr, int[] digits,int temp)
        {
           for (int i = arr.GetLength(0) - temp; i >= 0; i--)
                {
                    for (int j =0; j <arr.GetLength(1); j++)
                    {
                        arr[i, j] = digits[j];
                    }
                    break;
                }

           
            return arr;
        }

        public static int[] GetDigits(int n)
        { 
            int[] digits=new int[SystemCodeMaker.Length];
            int i = SystemCodeMaker.Length-1;
            while (n != 0)
            {
               
                int reminder = n % 10;
                digits[i] = reminder;
                i--;
                n = n / 10;
            }
            return digits;
        }

         public static void TwoDPrintarray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]+"\t");
                }
                Console.WriteLine("\n");
            }
        }

         public static string PrintStateOfWinning(int CheckWin, int size)
         {
             string state = "";
             if (CheckWin == 1)
             {
                 state = "UserWin";
             }
             else if (size == 0)
             {
                 state = "SystemWin";
             }
             return state;
         }

         public static int CheckWin(char[] CharArray)
         {
             int flag = -1;
             int count = 0;
             for (int i = 0; i < CharArray.Length; i++)
             {
                 if (CharArray[i] == 'R')
                 {
                     count++;
                     if (count == CharArray.Length)
                     {
                         flag = 1;
                         break;
                     }
                 }
                 else
                 {
                     count = 0;
                     flag = -1;
                 }
             }
             return flag;
         }

         public static string charprintArray(char[] Array)
         {
             string x = "";
             for (int i = 0; i < Array.Length; i++)
             {
                 x += Array[i] + " ";
             }
             return x;
         }

         public static char[] compare(int[] a, int[] b)
         {
             char[] keys = new char[4];
             char key = '0';
             for (int i = 0; i < a.Length; i++)
             {

                 if (a[i] == b[i])
                 {
                     key = 'R';
                     keys[i] = key;

                 }
                 else if (b.Contains(a[i]))
                 {
                     key = 'W';
                     keys[i] = key;
                 }
                 else
                 {
                     key = 'N';
                     keys[i] = key;

                 }
             }
             return keys;
         }

         public static int[] GenerateMakerArray()
         {
             Random ran = new Random();
             int[] retArray = new int[4];
             for (int i = 0; i < retArray.Length; i++)
             {
                 int next = 0;
                 while (true)
                 {
                     next = ran.Next(1, 8);
                     if (!IsContains(retArray, next))
                     {
                         break;
                     }
                 }
                 retArray[i] = next;
             }
             return retArray;
         }

         public static bool IsContains(int[] Array, int Value)
         {
             for (int i = 0; i < Array.Length; i++)
             {
                 if (Array[i] == Value)
                 {
                     return true;
                 }
             }
             return false;
         }

         public static string intprintArray(int[] Array)
         {
             string x = "";
             for (int i = 0; i < Array.Length; i++)
             {
                 x += Array[i] + " ";
             }
             return x;
         }

        
    }
}
