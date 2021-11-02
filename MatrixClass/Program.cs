using System;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter height for array: ");
            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter width for array: ");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter MAX value for random number: ");
            int rndMax = int.Parse(Console.ReadLine());

            ArrayManager am = new ArrayManager();
            PrintManager pm = new PrintManager();
            int[,] matrix = am.CreateArray(height, width, rndMax);
            pm.Print(matrix);
            Console.WriteLine(string.Empty);
            int[] diagonal = am.GetDiagonal(matrix);
            if (diagonal != null)
            {
                pm.Print(diagonal);
            }
            Console.WriteLine(string.Empty);

            pm.Print("Maximum of two dimension array is ", am.GetMax(matrix));
            pm.Print("Minimum of two dimension array is ", am.GetMin(matrix));

            if (diagonal != null)
            {
                pm.Print("Maximum of one dimension array (diagonal) is ", am.GetMax(diagonal));
            }
            pm.Print("Maximim element indexes is ", am.GetIndexOfMaxElement(matrix));
            pm.Print("Minimum element indexes is ", am.GetIndexOfMinElement(matrix));
            //Console.WriteLine($"Maximum is {GetMax(matrix)}");

            am.SwapMaxWithMin(am.GetIndexOfMaxElement(matrix), am.GetIndexOfMinElement(matrix), matrix);
            pm.Print(matrix);
            Console.ReadKey();

        }
        public class ArrayManager
        {
            /// <summary>
            /// Creates a two-dimensional array with user-specified dimensions and MAX value for random elements.  
            /// </summary>
            /// <param name="width">First dimension of array</param>
            /// <param name="height">Second dimension of array</param>
            /// <param name="rndMax">MAX value for random elements</param>
            /// <returns></returns>
            public int[,] CreateArray(int height, int width, int rndMax)
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
            /// <param name="array">given two-dimensional square array</param>
            /// <returns>returns a diagonal as a one-dimensional array</returns>
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
            /// Gets a maximum element of the given array
            /// </summary>
            /// <param name="array">given two-dimensional square array</param>
            /// <returns>returns element with maximum value</returns>
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
            /// Gets a maximum element of the given array
            /// </summary>
            /// <param name="array">given one-dimensional array</param>
            /// <returns>returns element with maximum value</returns>
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
            /// Gets a minimum element of the given array
            /// </summary>
            /// <param name="array">given two-dimensional square array</param>
            /// <returns>returns element with minimum value</returns>
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
            /// Gets a minimum element of the given array
            /// </summary>
            /// <param name="array">given one-dimensional array</param>
            /// <returns>returns element with minimum value</returns>
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
            /// Gets an indexes of a maximum element of the given array
            /// </summary>
            /// <param name="array">given two-dimensional square array</param>
            /// <returns>returns indexes of a maximum element as a one-dimensional array</returns>
            public int[] GetIndexOfMaxElement(int[,] array)  //միգուցե ստանա էլեմենտ, ոչ թե զանգված, բայց էլեմենտն int-ա, ինդեքս չեմ կարող ստանալ
            {
                int index1 = 0;
                int index2 = 0;
                int max = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] > max)
                        {
                            max = array[i, j];
                            index1 = i;
                            index2 = j;
                        }
                    }
                }
                int[] index = new int[] { index1, index2 };
                return index;
            }
            /// <summary>
            /// Gets an indexes of a minimum element of the given array
            /// </summary>
            /// <param name="array">given two-dimensional square array</param>
            /// <returns>returns indexes of a minimum element as a one-dimensional array</returns>
            public int[] GetIndexOfMinElement(int[,] array)  //միգուցե ստանա էլեմենտ...
            {
                int index1 = 0;
                int index2 = 0;
                int min = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] < min)
                        {
                            min = array[i, j];
                            index1 = i;
                            index2 = j;
                        }
                    }
                }
                int[] index = new int[] { index1, index2 };
                return index;
            }
            /// <summary>
            /// Swaps maximum and minimum element of the given array
            /// </summary>
            /// <param name="max">given maximum element of the given array</param>
            /// <param name="min">given minimum element of the given array</param>
            /// <param name="array">given two-dimensional array</param>
            /// <returns>returns a new two-dimensional array with swapped elements</returns>
            public int[,] SwapMaxWithMin(int[] max, int[] min, int[,] array)
            {
                int max0 = max[0];
                int max1 = max[1];
                int min0 = min[0];
                int min1 = min[1];

                int temp = array[max0, max1];
                array[max0, max1] = array[min0, min1];
                array[min0, min1] = temp;

                return array;
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
            /// <param name="value">given any Int32 array</param>
            public void Print(string str, int[] value)  
            {
                Console.WriteLine($"{str}{value[0]} {value[1]}");
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


}
