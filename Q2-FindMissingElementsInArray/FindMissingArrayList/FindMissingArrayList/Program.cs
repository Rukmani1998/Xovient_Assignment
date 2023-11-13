// See https://aka.ms/new-console-template for more information
using System;
using System;
using System.Collections;
using System.Globalization;
using System.Xml.Linq;

namespace SortArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] intArray = new int[] { 2, 9, 4, 3, 5, 1, 7, 20};
                printArrayList(intArray, "Current array elements are: ");
                
                int[] SortedArray = SortArrayInAccendingOrder(intArray);
                printMulMissElmtFrmSortedArr(SortedArray, SortedArray.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// sorts the unorderd array
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        private static int[] SortArrayInAccendingOrder(int[] intArray)
        {
            int temp = 0;
            for (int i = 0; i <= intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (intArray[i] > intArray[j])
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }

            printArrayList(intArray, "Asscending order sorted array: ");         
            
            return intArray;
        }

        /// <summary>
        /// Prints missing elemets from array
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="N"></param>
        private static void printMulMissElmtFrmSortedArr(int[] intArray, int N)
        {
            int diff =intArray[0] - 0;
            string str="";
            for (int i = 0; i < N; i++)
            {
                if (intArray[i] - i != diff)
                {
                    while (diff < intArray[i] - i)
                    {
                        //Console.Write(i + diff + ",");
                        if (str == "") str = (i + diff).ToString();
                        else str = str + "," + (i + diff);
                        diff++;
                    }
                }
            }

            Console.WriteLine("Missing elements in array are: " + str);
        }

        /// <summary>
        /// Display the array elements coma separated
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="msg"></param>
        static void printArrayList(int[] intArray, string msg)
        {
            string str = "";
            foreach (var item in intArray)
            {
                if (str == "") str = item.ToString();
                else str = str + "," + item;
            }
            Console.WriteLine(msg + str);
        }


    }
}