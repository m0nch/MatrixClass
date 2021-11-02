using System;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter height for array: ");
            int height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter width for array: ");
            int width = int.Parse(Console.ReadLine());            

            Console.WriteLine("Enter MAX value for random number: ");
            int rndMax = int.Parse(Console.ReadLine());

            ArrayManager arrManager = new ArrayManager();
            PrintManager prntManager = new PrintManager();
            int[,] matrix = arrManager.CreateArray(height, width, rndMax);
            prntManager.Print(matrix);
            Console.WriteLine(string.Empty);
            int[] diagonal = arrManager.GetDiagonal(matrix);
            if (diagonal != null)
            {
                prntManager.Print(diagonal);
            }
            Console.WriteLine(string.Empty);

            prntManager.Print("Maximum of two dimension array is ", arrManager.GetMax(matrix));
            prntManager.Print("Minimum of two dimension array is ", arrManager.GetMin(matrix));

            if (diagonal != null)
            {
                prntManager.Print("Maximum of one dimension array (diagonal) is ", arrManager.GetMax(diagonal));
            }
            prntManager.Print("Maximim element indexes is ", arrManager.GetIndexOne(matrix, arrManager.GetMax(matrix)), arrManager.GetIndexTwo(matrix, arrManager.GetMax(matrix)));
            prntManager.Print("Minimum element indexes is ", arrManager.GetIndexOne(matrix, arrManager.GetMin(matrix)), arrManager.GetIndexTwo(matrix, arrManager.GetMin(matrix)));
            //Console.WriteLine($"Maximum is {GetMax(matrix)}");

            int[,] arr = arrManager.Swap(matrix, arrManager.GetMax(matrix), arrManager.GetMin(matrix));
            prntManager.Print(arr);
            Console.WriteLine();

            prntManager.Print(matrix);
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ArrayManager
    {
        /// <summary>
        /// Creates a two-dimensional array with user-specified dimensions 
        /// and with Int32 elements that are randomly generated and less than 
        /// the specified maximum value    
        /// </summary>
        /// <param name="width">First dimension of array</param>
        /// <param name="height">Second dimension of array</param>
        /// <param name="rndMax">specified maximum value for random elements</param>
        /// <returns>returns two-dimensional array with Int32 values</returns>
        public int[,] CreateArray(int width, int height, int rndMax)
        {
            Random rnd = new Random();
            int[,] matrix = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = rnd.Next(rndMax);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Gets a two-dimensional square array and returns a diagonal of it as a one-dimensional array
        /// </summary>
        /// <param name="array">given two-dimensional Int32 square array</param>
        /// <returns>returns a diagonal as a one-dimensional Int32 array</returns>
        public int[] GetDiagonal(int[,] array)
        {
            if (array.GetLength(0) == array.GetLength(1))
            {
                int[] diagonal = new int[array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    diagonal[i] = array[i, i];
                }
                return diagonal;
            }
            else
            {
                Console.WriteLine("This array hasn't diagonal!");
                return null;
            }
        }
        /// <summary>
        /// Gets a maximum element of the given Int32 array
        /// </summary>
        /// <param name="array">given two-dimensional Int32 square array</param>
        /// <returns>returns Int32 value</returns>
        public int GetMax(int[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            return max;
        }
        /// <summary>
        /// Gets a maximum element of the given Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <returns>returns Int32 value</returns>
        public int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        /// <summary>
        /// Gets a minimum element of the given Int32 two-dimensional square array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <returns>returns Int32 value</returns>
        public int GetMin(int[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                        min = array[i, j];
                }
            }
            return min;
        }
        /// <summary>
        /// Gets a minimum element of the given Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <returns>returns Int32 value</returns>
        public int GetMin(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }

        /// <summary>
        /// Gets the first index of an element of the given two-dimensional Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <param name="element">given any Int32 value</param>
        /// <returns>returns Int32 value</returns>
        public int GetIndexOne(int[,] array, int element)
        {
            int index = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == element)
                    {
                        index = i;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// Gets the second index of an element of the given two-dimensional Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <param name="element">given any Int32 value</param>
        /// <returns>returns Int32 value</returns>
        public int GetIndexTwo(int[,] array, int element)
        {
            int index = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == element)
                    {
                        index = j;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// Swaps a given two elements of the given two-dimensional Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <param name="element1">given any Int32 value</param>
        /// <param name="element2">given any Int32 value</param>
        /// <returns>returns new two dimensional Int32 array with swapped elements</returns>
        public int[,] Swap(int[,] array, int element1, int element2)
        {
            int[,] arr = (int[,])array.Clone();
            int el1IndexOne = GetIndexOne(arr, element1);
            int el1IndexTwo = GetIndexTwo(arr, element1);
            int el2IndexOne = GetIndexOne(arr, element2);
            int el2IndexTwo = GetIndexTwo(arr, element2);

            int temp = arr[el1IndexOne, el1IndexTwo];
            arr[el1IndexOne, el1IndexTwo] = arr[el2IndexOne, el2IndexTwo];
            arr[el2IndexOne, el2IndexTwo] = temp;

            return arr;
        }
    }

    public class PrintManager
    {
        /// <summary>
        /// Prints string result from given parameters
        /// </summary>
        /// <param name="str">given any string</param>
        /// <param name="value">given any Int32 value</param>
        public void Print(string str, int value)
        {
            Console.WriteLine($"{str}{value}");
        }

        /// <summary>
        /// Prints string result from given parameters
        /// </summary>
        /// <param name="str">given any string</param>
        /// <param name="value1">given any Int32 value</param>
        /// <param name="value2">given any Int32 value</param>
        public void Print(string str, int value1, int value2)
        {
            Console.WriteLine($"{str} {value1}, {value2}");
        }
        /// <summary>
        /// Prints a two-dimensional array elements in console
        /// </summary>
        /// <param name="array">given two-dimensional array</param>
        public void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Prints a one-dimensional array elements in console
        /// </summary>
        /// <param name="array">given one-dimensional array</param>
        public void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }

    }


}
