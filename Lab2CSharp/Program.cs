using System.Drawing;
using System.Reflection.Metadata;

namespace Lab2CSharp
{
    internal class Program
    {
        /*Зауваження.Завдання з масивами вирішити двома способами,
        використовуючи одновимірний масив, а потім двовимірний.Розмірність
        масиву вводиться з клавіатури.*/

        //1.14. Вивести на екран номери всіх елементів, які не діляться на 7
        static void Task1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 7 != 0)
                {
                    Console.WriteLine($"[{i}]");
                }
            }
        }
        static void Task1(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 7 != 0)
                    {
                        Console.WriteLine($"[{i},{j}]");

                    }
                }
            }
        }


        /*Зауваження.При вирішенні завдання використовувати одновимірний масив.
        Розмірність масиву вводиться з клавіатури.
        Завдання 2. Варіанти задач. Дана послідовність з n дійсних чисел.*/

        //2.14. Знайти мінімум з додатних елементів.
        static void Task2(int[] arr)
        {
            double minPositive = -1;
            foreach (int i in arr)
            {
                if (minPositive < 0 && i >= 0)
                {
                    minPositive = i;
                }
                else if (i >= 0 && i < minPositive)
                {
                    minPositive = i;
                }
            }
            if (minPositive >= 0)
            {
                Console.WriteLine("Minimal positive element = {0}", minPositive);
            }
            else
            {
                Console.WriteLine("array does not have positive elements:(");
            }
        }


        /*Зауваження.При вирішенні завдання використовувати двовимірний масив.
        Завдання 3. Варіанти задач. Дано масив розміром n×n, елементи якого цілі
        числа.*/

        //3.14. З'ясувати, чи є матриця симетричною відносно головної діагоналі
        static void Task3(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            bool isSymmetric = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        isSymmetric = false;
                        break;
                    }
                }
                if (!isSymmetric)
                {
                    break;
                }
            }

            if (isSymmetric)
            {
                Console.WriteLine("The matrix is symmetric with respect to the main diagonal.");
            }
            else
            {
                Console.WriteLine("The matrix is not symmetric with respect to the main diagonal.");
            }

        }

        /*Завдання 4. Дано східчастий масив з n рядків, у рядках по
        mj (j= 1..n) елементів.*/

        //4.14. Парні стовпці таблиці замінити на вектор. ???
        static void Task4(int[][] array, int[] vector)
        {
            //Print array
            Console.WriteLine("start array:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (vector.Length != array.Length)
            {
                throw new ArgumentException("The length of the replacement vector must be equal to the number of rows in the token array.");
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        array[i][j] = vector[i];
                    }
                }
            }

            //Print array
            Console.WriteLine("Result array:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            string[] menuStrings =
            {
                "1. Task 1!",
                "2. Task 2!",
                "3. Task 3!",
                "4. Task 4!"
            };
            int currentOprtion = 0;
            ConsoleKeyInfo keyInfo;
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Lab 2 CSharp");
                PrintMenu(menuStrings, currentOprtion);


                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentOprtion = currentOprtion + 1 <= menuStrings.Length - 1 ? currentOprtion + 1 : 0;
                }
                else if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentOprtion = currentOprtion - 1 >= 0 ? currentOprtion - 1 : menuStrings.Length - 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    choice = currentOprtion;
                    break;
                }
            }
            switch (choice)
            {
                case 0:
                    Console.WriteLine("enter size of array:");
                    var inputSize = Console.ReadLine();
                    var inputSplited = inputSize.Split(' ');
                    if (inputSplited.Length == 1)
                    {
                        int size1;
                        if (int.TryParse(inputSplited[0], out size1))
                        {
                            int[] arr = new int[size1];
                            Console.WriteLine("enter array:");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write($"[{i}] = ");
                                if (!int.TryParse(Console.ReadLine(), out arr[i]))
                                {
                                    Console.WriteLine("invalid input (must be intager)");
                                    i--;
                                }
                            }
                            Task1(arr);
                        }
                        else
                        {
                            Console.WriteLine("invalid input (must be intager)");
                        }
                    }
                    else if (inputSplited.Length == 2)
                    {
                        int nSize, mSize;
                        if (int.TryParse(inputSplited[0], out nSize) &&
                            int.TryParse(inputSplited[1], out mSize))
                        {
                            int[,] arr = new int[nSize, mSize];
                            Console.WriteLine("enter array:");
                            for (int i = 0; i < nSize; i++)
                            {
                                for (int j = 0; j < mSize; j++)
                                {
                                    Console.Write($"[{i},{j}] = ");
                                    if (!int.TryParse(Console.ReadLine(), out arr[i, j]))
                                    {
                                        Console.WriteLine("invalid input (must be intager)");
                                        if (j < mSize)
                                        {
                                            j--;
                                        }
                                        else
                                        {
                                            i--;
                                            j = mSize - 1;
                                        }
                                    }
                                }
                                Console.WriteLine();
                            }
                            Task1(arr);
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("enter Size");
                    int size2;
                    if (int.TryParse(Console.ReadLine(), out size2))
                    {
                        int[] arr = new int[size2];
                        Console.WriteLine("enter array:");
                        for (int i = 0; i < size2; i++)
                        {
                            Console.Write($"[{i}] = ");
                            if (!int.TryParse(Console.ReadLine(), out arr[i]))
                            {
                                Console.WriteLine("invalid input (must be intager)");
                                i--;
                            }
                        }
                        Task2(arr);
                    }
                    else
                    {
                        Console.WriteLine("invalid input (must be intager)");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    int n;
                    Console.Write("Enter the size of the matrix n: ");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.Write("Incorrect value. Please enter again: ");
                    }

                    int[,] matrix = new int[n, n];
                    Console.WriteLine("Enter the elements of the matrix:");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write($"Element [{i}, {j}]: ");
                            while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                            {
                                Console.Write("Incorrect value. Please enter again: ");
                            }
                        }
                    }
                    Task3(matrix);
                    break;
                case 3:
                    Console.WriteLine("enter n:");
                    int N;
                    while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
                    {
                        Console.Write("Incorrect value. Please enter again: ");
                    }
                    Console.WriteLine("enter M:");
                    int M;
                    while (!int.TryParse(Console.ReadLine(), out M) || M <= 0)
                    {
                        Console.Write("Incorrect value. Please enter again: ");
                    }

                    int[][] array = new int[N][];
                    Console.WriteLine("enter array:");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = new int[M * (i + 1)];
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            Console.Write($"Element [{i}][{j}]: ");
                            while (!int.TryParse(Console.ReadLine(), out array[i][j]))
                            {
                                Console.Write("Incorrect value. Please enter again: ");
                            }
                        }
                    }


                    int[] vector = new int[N];
                    Console.WriteLine("enter vector:");
                    for (int i = 0; i < vector.Length; i++)
                    {
                        Console.Write($"Element [{i}]: ");
                        while (!int.TryParse(Console.ReadLine(), out vector[i]))
                        {
                            Console.Write("Incorrect value. Please enter again: ");
                        }
                    }
                    Task4(array, vector);
                    break;
                default:
                    break;
            }
        }
        static void PrintMenu(string[] menuString, int choosenString)
        {
            for (int i = 0; i < menuString.Length; i++)
            {
                if (i == choosenString)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(menuString[i]);
                if (i == choosenString)
                {
                    Console.ResetColor();
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    ShowMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
    }
}
