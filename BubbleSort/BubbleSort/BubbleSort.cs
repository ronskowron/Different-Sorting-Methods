/*
* FILE : BubbleSort.cs
* PROJECT : Different DataStructures
* PROGRAMMER : Ronnie Skowron
* FIRST VERSION : 2018-07-09
* DESCRIPTION :
* The functions of this file are used to sort an array
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class BubbleSort
    {
        static void Main()
        {
            int[] arrayOfNumbers = new int[] { 12, 13, 6, 27, 26, 4, 11, 12};

            SortArray(arrayOfNumbers);

            Console.ReadKey();

        }


        static void SortArray(int[] arrayOfNumbers)
        {
            int arraySize = arrayOfNumbers.Count();
            bool endOfArray = false;
            int firstCheck = 0;
            int secondCheck = 0;

            int offset = 1;

            // Display contents of Array
            PrintArray(arrayOfNumbers);


            // start at the first number in the array
            for (int x = 0; x < arraySize; x++)
            {
                // iterate through the rest of the numbers
                for (int i = 0; i < arraySize; i++)
                {
                    // grab the first number to check in the array
                    firstCheck = arrayOfNumbers[i];

                    //check if you're not at the end of the array
                    // so you can continue to iterate without throwing an exception
                    if ((i + offset) != arraySize)
                    {
                        // get the next number beside the first obtained element
                        secondCheck = arrayOfNumbers[i + offset];
                        endOfArray = false;
                    }
                    else
                    {
                        // if you're at the end of the for-loop then you are at 
                        endOfArray = true;
                    }

                    // Compare if the first number is larger than the second number next in the iteration
                    if (firstCheck > secondCheck)
                    {
                        // if we are at the end of the array
                        if (endOfArray == false)
                        {
                            // then switch the to elements in the area
                            arrayOfNumbers[i] = secondCheck;
                            arrayOfNumbers[i + offset] = firstCheck;
                        }
                        else
                        {
                            // if we are at the end of the area then break from the loop
                            break;
                        }

                    }
                }

                // display newly sorted array
                PrintArray(arrayOfNumbers);

                // Once the sorting is complete end the bubble sort
                if (IsArrayValid(arrayOfNumbers))
                {
                    // break from the loop if it is finished
                    break;
                }
            }
        }


        //
        // FUNCTION : IsArrayValid
        // DESCRIPTION : This method is used to determine if the array has finished sorting
        // PARAMETERS : int[] array - The array we are checking if it is fully sorted
        // RETURNS :   bool isValid - returns true if the array has finished sorting
        //
        static bool IsArrayValid(int[] array)
        {
            bool isValid = false;
            List<int> validElements = new List<int>();
            int offset = 1;
            int sum = 0;
            // clear the list so it is empty when assigned values
            if (validElements.Count != 0)
            {
                validElements.Clear();
            }

            // iterate through the array
            for (int i = 0; i < array.Length; i++)
            {
                // check if we are at the end of the array to prevent out of range exception
                if ((i + offset) != array.Length)
                {
                    //check if the first element is less than the next element to be checked
                    if (array[i + offset] >= array[i])
                    {
                        // if it is less than the next number then add 1 to the list
                        // the number one represents that the current sorted value is correct 
                        validElements.Add(1);
                    }
                    else
                    {
                        // using zero represents that the number checked is still in the wrong spot
                        validElements.Add(0);
                    }
                }
            }

            // get the total sum of correctly positioned elements
             sum = validElements.Sum();

            // if all of the values are in their correct position, then the sum of all the ones
            // will be equal to the original size of the array 
            if (sum == array.Count()- offset)
            {
                isValid = true;
            }

            // return if the array is valid and finished
            return isValid;
        }

        //
        // FUNCTION : PrintArray
        // DESCRIPTION : This method is used to display the contents of the array
        // PARAMETERS : int[] array - array to display to the console
        // RETURNS : N/A
        //
        static void PrintArray(int[] array)
        {
            string str = "";

            // iterate through the array and append each value to a string
            foreach(int value in array)
            {
                str += value.ToString() + " ";
            }

            // display contents of the string
            Console.WriteLine(str);
        }


        

    }
}


