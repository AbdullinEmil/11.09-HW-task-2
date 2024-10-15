using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[,] array = GenerateRandomArray(5, 5, -100, 100);
        PrintArray(array);

        int minIndexRow = 0;
        int minIndexCol = 0;
        int maxIndexRow = 0;
        int maxIndexCol = 0;
        FindMinMax(array, ref minIndexRow, ref minIndexCol, ref maxIndexRow, ref maxIndexCol);

        int sumBetweenMinMax = CalculateSumBetweenMinMax(array, minIndexRow, minIndexCol, maxIndexRow, maxIndexCol);

        Console.WriteLine($"Сумма элементов между минимальным и максимальным: {sumBetweenMinMax}");
    }

    static int[,] GenerateRandomArray(int rows, int cols, int min, int max)
    {
        Random random = new Random();
        int[,] array = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = random.Next(min, max + 1);
            }
        }
        return array;
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j],3} ");
            }
            Console.WriteLine();
        }
    }

    static void FindMinMax(int[,] array, ref int minIndexRow, ref int minIndexCol, ref int maxIndexRow, ref int maxIndexCol)
    {
        int min = array[0, 0];
        int max = array[0, 0];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < min)
                {
                    min = array[i, j];
                    minIndexRow = i;
                    minIndexCol = j;
                }
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    maxIndexRow = i;
                    maxIndexCol = j;
                }
            }
        }
    }

    static int CalculateSumBetweenMinMax(int[,] array, int minIndexRow, int minIndexCol, int maxIndexRow, int maxIndexCol)
    {
        int sum = 0;

        int startRow = Math.Min(minIndexRow, maxIndexRow);
        int endRow = Math.Max(minIndexRow, maxIndexRow);

        int startCol = Math.Min(minIndexCol, maxIndexCol);
        int endCol = Math.Max(minIndexCol, maxIndexCol);

        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (!(i == minIndexRow && j == minIndexCol) && !(i == maxIndexRow && j == maxIndexCol))
                {
                    sum += array[i, j];
                }
            }
        }
        return sum;
    }
}