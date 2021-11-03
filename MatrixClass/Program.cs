using System;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayManager arrManager = new ArrayManager();
            PrintManager prntManager = new PrintManager();

            Console.WriteLine("Please enter height for array: ");
            arrManager._height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter width for array: ");
            arrManager._width = int.Parse(Console.ReadLine());            

            Console.WriteLine("Enter MAX value for random number: ");
            arrManager._rndMax = int.Parse(Console.ReadLine());

            int[,] matrix = arrManager.CreateArray();
            prntManager.Print(matrix);
            Console.WriteLine();
            int[] diagonal = arrManager.GetDiagonal(matrix);
            if (diagonal != null)
            {
                prntManager.Print(diagonal);
            }
            Console.WriteLine();

            arrManager._element1 = arrManager.GetMax(matrix);
            arrManager._element2 = arrManager.GetMin(matrix);

            prntManager.Print("Maximum of two dimension array is ", arrManager._element1);
            prntManager.Print("Minimum of two dimension array is ", arrManager._element2);

            int maxDiagonal = arrManager.GetMax(diagonal);
            if (diagonal != null)
            {
                prntManager.Print("Maximum of one dimension array (diagonal) is ", maxDiagonal);
            }

            int ind1 = arrManager.GetIndexOne(matrix, arrManager._element1);
            int ind2 = arrManager.GetIndexTwo(matrix, arrManager._element1);
            prntManager.Print("Maximim element indexes is ", ind1, ind2);

            ind1 = arrManager.GetIndexOne(matrix, arrManager._element2);
            ind2 = arrManager.GetIndexTwo(matrix, arrManager._element2);
            prntManager.Print("Minimum element indexes is ", ind1, ind2);

            int[,] arr = arrManager.Swap(matrix);
            prntManager.Print(arr);
            Console.WriteLine();

            prntManager.Print(matrix);
            Console.ReadKey();
        }
    }
    
    public class ArrayManager
    {
        public int _width;
        public int _height;
        public int _rndMax;

        public int _element1;
        public int _element2;

        /// <summary>
        /// Creates a two-dimensional array with user-specified dimensions 
        /// and with Int32 elements that are randomly generated and less than 
        /// the specified maximum value    
        /// </summary>
        /// <returns>returns two-dimensional array with Int32 values</returns>
        public int[,] CreateArray()
        {
            Random rnd = new Random();
            int[,] matrix = new int[_width, _height];
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    matrix[i, j] = rnd.Next(_rndMax);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Swaps a given two elements of the given two-dimensional Int32 array
        /// </summary>
        /// <param name="array">given any array</param>
        /// <returns>returns new two dimensional Int32 array with swapped elements</returns>
        public int[,] Swap(int[,] array)
        {
            int[,] arr = (int[,])array.Clone();
            int el1IndexOne = GetIndexOne(arr, _element1);
            int el1IndexTwo = GetIndexTwo(arr, _element1);
            int el2IndexOne = GetIndexOne(arr, _element2);
            int el2IndexTwo = GetIndexTwo(arr, _element2);

            int temp = arr[el1IndexOne, el1IndexTwo];
            arr[el1IndexOne, el1IndexTwo] = arr[el2IndexOne, el2IndexTwo];
            arr[el2IndexOne, el2IndexTwo] = temp;

            return arr;
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
