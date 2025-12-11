using System.Globalization;
using System.IO.Pipelines;
using System.Numerics;

class Program
{
     //задание 1
     static int Hours_Minuts(int  a)
     {
         return a * 60;
     }
     static int Minuts_Hours(int a)
     {
         return a / 60;
     }
     static int Hours_Seconds(int a)
     {
         return a * 60 * 60;
     }
     static int Seconds__Hours(int a)
     {
         return a / 60 / 60;
     }
     static int Minuts_Seconds(int a)
     {
         return a * 60;
     }
     static int Seconds_Minuts(int a)
     {
         return a / 60;
     }

     static void Main(string[] args)
     {
         int a, hours_minuts, minuts_hours, minuts_seconds, second_minuts, hours_seconds, second_hours;
         string letter1, letter2;
         a = int.Parse(Console.ReadLine());
         letter1 = Console.ReadLine();
         letter2 = Console.ReadLine();
         hours_minuts = Hours_Minuts(a);
         minuts_hours = Minuts_Hours(a);
         hours_seconds = Hours_Seconds(a);
         second_hours = Seconds__Hours(a);
         minuts_seconds = Minuts_Seconds(a);
         second_minuts = Seconds_Minuts(a);
         if (letter1 == "h" & letter2 == "m")
         {
             Console.WriteLine(hours_minuts + "m");
         }
         if (letter1 == "m" & letter2 == "h")
         {
             Console.WriteLine(minuts_hours + "h");
         }
         if (letter1 == "h" & letter2 == "s")
         {
             Console.WriteLine(hours_seconds + "s");
         }
         if (letter1 == "s" & letter2 == "h")
         {
             Console.WriteLine(second_hours + "h");
         }
         if (letter1 == "m" & letter2 == "s")
         {
             Console.WriteLine(minuts_seconds + "s");
         }
         if (letter1 == "s" & letter2 == "m")
         {
             Console.WriteLine(second_minuts + "m");
         }
     }
    //задание 2
    static void Main()
    {
        double amount= Convert.ToDouble(Console.ReadLine());
        int years =Convert.ToInt32(Console.ReadLine());
        double profit = CalculateIncrement(amount,years);
        Console.WriteLine(profit);

    }
    static double CalculateIncrement(double amount,int years)
    {
        double rate = years <= 3 ? 0.03 : years <= 6 ? 0.05 : 0.02;
        double amount_increment = Math.Min(Math.Floor(amount/10000) * 0.003,0.05);
        double total_rate= rate + amount_increment;
        double total_amount = amount * Math.Pow(1 + total_rate, years);
        double profit = total_amount - amount;
        return profit;
    }*/


    //задание 3
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split();
        int start = int.Parse(numbers[0]);
        int end = int.Parse(numbers[1]);
        if (start > end)
        {
            Console.WriteLine("ERROR");
            return;
        }
        string stroka = "";
        for (int number = start; number <= end; number++)
        {
            bool simple = true;

            if (number < 2)
            {
                simple = false;
            }
            else
            {
                for (int divider = 2; divider < number; divider++)
                {
                    if (number % divider == 0)
                    {
                        simple = false;
                    }
                }
            }
            if (simple)
            {
                stroka += number + "";
            }
            Console.WriteLine(stroka);
        }
    }*/
    //задание 4
    

class Program
{
    static void Main()
    {
        try
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 2)
            {
                Console.WriteLine("Error!");
                return;
            }
            int[,] matrix1 = ReadMatrix(n);
            int[,] matrix2 = ReadMatrix(n);
            if (matrix1 == null || matrix2 == null)
            {
                Console.WriteLine("Error!");
                return;
            }
            int[,] result = AddMatrices(matrix1, matrix2, n);
            PrintMatrix(result, n);
        }
        catch
        {
            Console.WriteLine("Error!");
        }
    }
    static int[,] ReadMatrix(int n)
    {
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            if (row.Length != n) return null;
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = Convert.ToInt32(row[j]);
            }
        }

        return matrix;
    }

    static int[,] AddMatrices(int[,] m1, int[,] m2, int n)
    {
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return result;
    }

    static void PrintMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
//задание 5

static void Main()
    {
        string line1 = Console.ReadLine();
        if(Palindrome(line1))
        {
            Console.WriteLine("да");
        }
        else
        {
            Console.WriteLine("нет");
        }
        
    }
    static bool Palindrome(string str)
    {
        string leght = str.Replace(" ", "").ToLower();
        for (int i = 0; i < leght.Length / 2; i++)
        { 
            if (leght[i] != leght[leght.Length - 1 - i])
            {
                return  false;
            }
        }
        return true;
    }
}

