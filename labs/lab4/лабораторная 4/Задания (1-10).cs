
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите температуру: ");
        double t = Convert.ToDouble(Console.ReadLine());

        if (t >= 20)
        {
            Console.WriteLine("Кондиционер выключен");
        }
        else
        {
            Console.WriteLine("Кондиционер включен");
        }
        Console.Write("Введите возраст собаки (в годах): ");
        string input = Console.ReadLine();

        if (!double.TryParse(input, out double dogAge))
        {
            Console.WriteLine("Ошибка: введено не число");
            return;
        }

        
        if (dogAge < 1)
        {
            Console.WriteLine("Ошибка: возраст должен быть не меньше 1");
            return;
        }

        
        if (dogAge > 22)
        {
            Console.WriteLine("Ошибка: возраст должен быть не больше 22");
            return;
        }

        double humanAge;

        if (dogAge <= 2)
        {
            humanAge = dogAge * 10.5;
        }
        else
        {
            humanAge = 2 * 10.5 + (dogAge - 2) * 4;
        }

        Console.WriteLine($"Возраст собаки в человеческих годах: {humanAge}");


        /* Console.Write("Введите число: ");
         string input = Console.ReadLine();


         if (!long.TryParse(input, out long number))
         {
             Console.WriteLine("Ошибка: введено не число");
             return;
         }


         int lastDigit = (int)Math.Abs(number % 10);


         long tempNumber = Math.Abs(number);
         int sumOfDigits = 0;

         while (tempNumber > 0)
         {
             sumOfDigits += (int)(tempNumber % 10);
             tempNumber /= 10;
         }


         bool isEven = lastDigit % 2 == 0;
         bool divisibleBy3 = sumOfDigits % 3 == 0;

         if (isEven && divisibleBy3)
         {
             Console.WriteLine($"Число {number} делится на 6");
         }
         else
         {
             Console.WriteLine($"Число {number} не делится на 6");


             if (!isEven)
             {
                 Console.WriteLine("Причина: последняя цифра нечетная");
             }
             if (!divisibleBy3)
             {
                 Console.WriteLine("Причина: сумма цифр не делится на 3");*/
        //задание 5
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        bool hasUpperCase = password.Any(char.IsUpper);
        bool hasLowerCase = password.Any(char.IsLower);
        bool hasDigits = password.Any(char.IsDigit);
        bool hasSpecialChars = password.Any(ch => !char.IsLetterOrDigit(ch));
        bool hasMinLength = password.Length >= 8;

        if (hasMinLength && hasUpperCase && hasLowerCase && hasDigits && hasSpecialChars)
        {
            Console.WriteLine("Пароль надежный");
        }
        else
        {
            Console.Write("Пароль ненадежный: ");

            var errors = new System.Collections.Generic.List<string>();

            if (!hasMinLength) errors.Add("длина менее 8 символов");
            if (!hasUpperCase) errors.Add("отсутствуют заглавные буквы");
            if (!hasLowerCase) errors.Add("отсутствуют строчные буквы");
            if (!hasDigits) errors.Add("отсутствуют числа");
            if (!hasSpecialChars) errors.Add("отсутствуют специальные символы");

            Console.WriteLine(string.Join(", ", errors));
        }
        //задание 6
        Console.Write("Введите год: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            bool isLeap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            Console.WriteLine($"{year} - {(isLeap ? "високосный" : "невисокосный")} год");
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число");
        }
        //задание 7
        Console.Write("Введите три числа: ");
        string[] inputs = Console.ReadLine().Split(' ');

        if (inputs.Length == 3 &&
            double.TryParse(inputs[0], out double a) &&
            double.TryParse(inputs[1], out double b) &&
            double.TryParse(inputs[2], out double c))
        {
            double min = a;

            if (b < min) min = b;
            if (c < min) min = c;

            Console.WriteLine($"Наименьшее число: {min}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите три числа через пробел");
        }
        //задание 8
        Console.Write("Введите сумму покупки: ");
        if (double.TryParse(Console.ReadLine(), out double purchaseAmount) && purchaseAmount >= 0)
        {
            double discount = 0;

            if (purchaseAmount >= 1000 && purchaseAmount < 5000)
                discount = 5;
            else if (purchaseAmount >= 5000 && purchaseAmount < 10000)
                discount = 10;
            else if (purchaseAmount >= 10000)
                discount = 15;

            double discountAmount = purchaseAmount * discount / 100;
            double finalAmount = purchaseAmount - discountAmount;

            Console.WriteLine($"Ваша скидка: {discount}%");
            Console.WriteLine($"К оплате: {finalAmount:F1}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректную сумму");
        }
        //задание 9
        Console.Write("Введите час: ");
        if (int.TryParse(Console.ReadLine(), out int hour) && hour >= 0 && hour <= 23)
        {
            string timeOfDay;

            if (hour >= 0 && hour <= 5)
                timeOfDay = "Ночь";
            else if (hour >= 6 && hour <= 11)
                timeOfDay = "Утро";
            else if (hour >= 12 && hour <= 17)
                timeOfDay = "День";
            else
                timeOfDay = "Вечер";

            Console.WriteLine($"Сейчас {timeOfDay}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите число от 0 до 23");
        }
        //задание 10
        Console.Write("Введите число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number <= 1)
            {
                Console.WriteLine($"{number} - не является простым числом");
                return;
            }

            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{number} - {(isPrime ? "простое" : "составное")} число");
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число");
        }
    }
}
    
    
    


    
       
    


        
