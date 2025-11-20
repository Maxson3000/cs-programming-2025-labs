using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //задание 1
        int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] == 3)
            {
                num[i] = 30;

            }
        }
        Console.WriteLine(string.Join(", ", num));

        //задание 2
        int[] num2 = { 1, 6, 3, 4, 5 };
        for (int i = 0;i < num2.Length; i++)
        {
            num2[i] = num2[i]*num2[i];
        }
        Console.WriteLine(string.Join(", ", num2));

        //задание 3
        int[] num3 = { 1, 93, 6, 8, 4, 99 };
        double result = num3.Max()/(double)num3.Length;
        Console.WriteLine(result);

        //задание 4
        var tuple = (5, 2, 8, 1, 3);

        try
        {
            var items = new[] { tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5 };
            Array.Sort(items);
            tuple = (items[0], items[1], items[2], items[3], items[4]);
        }
        catch
        {
            
        }
        Console.WriteLine(tuple);
        // задание 5
        var product = new Dictionary<string, int>
        {
            {"apples", 100},
            {"bananas",150 },
            {"orange",130 },
            {"pear" , 180},
        };
        var minProduct=product.OrderBy(i=>i.Value).First();
        var maxProduct=product.OrderByDescending(i=>i.Value).First();
        Console.WriteLine(minProduct.Key, maxProduct.Key);

        //задание 6
        var slov = new List<object> { "car", 404, false }.ToDictionary(x => x, x => x);
        foreach (var item  in slov)
        {
            Console.WriteLine($"{ item.Key}->{item.Value}");
        }

        //задание 7
        var translate = new Dictionary<string, string>
        {
            {"apples","яблоки" },
            {"car" ,"машина"},
            {"chicken","курица" },
            {"orange","апельсин" },
        };
        string rusword=Console.ReadLine();
        string engword=translate.FirstOrDefault(x=>x.Value==rusword).Key;
        Console.WriteLine(engword);

        //задание 8
        string[] choices = { "камень", "ножницы", "бумага", "ящерица", "спок" };
        string userChoice = Console.ReadLine().ToLower();
        Random random = new Random();
        string computerChoice = choices[random.Next(choices.Length)];
        Console.WriteLine($"Компьютер выбрал: {computerChoice}");
        if (userChoice == computerChoice)
        {
            Console.WriteLine("Ничья!");
        }
        else if (
            (userChoice == "ножницы" && (computerChoice == "бумага" || computerChoice == "ящерица")) ||
            (userChoice == "бумага" && (computerChoice == "камень" || computerChoice == "спок")) ||
            (userChoice == "камень" && (computerChoice == "ножницы" || computerChoice == "ящерица")) ||
            (userChoice == "ящерица" && (computerChoice == "спок" || computerChoice == "бумага")) ||
            (userChoice == "спок" && (computerChoice == "ножницы" || computerChoice == "камень"))
        )
        {
            Console.WriteLine("Вы победили!");
        }
        else
        {
            Console.WriteLine("Компьютер победил!");
        }
        //задание 9
        string[] words = { "дом", "машина", "рыба", "таможня" };
        var dict = new Dictionary<char, string>();
        foreach ( string word in words )
        {
            char first = word[0];
            if (!dict.ContainsKey(first))
            {
                dict.Add(first, word);
            }
        }
        foreach ( var item in dict )
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
        // задание 10
        var students = new List<(string name, int[] estimation)>
        {
            ("Анна", [5, 4, 5]),
            ("Иван", [3, 4, 4]),
            ("Мария", [5, 5, 5]),
        };
        var midle = new Dictionary<string, double>();
        foreach (var student in students)
        {
            midle[student.name] = student.estimation.Average();
        }
        var maxEstimation = midle.OrderByDescending(i => i.Value).First();
        Console.WriteLine($"{maxEstimation.Key}:{maxEstimation.Value}");


    }
}
