'''
name = input("Введите ваше имя: ")
age = input("Введите ваш возраст: ")

for i in range(10):
    print(f"Меня зовут {name} и мне {age} лет")
'''
'''
num = int(input("Введите число от 1 до 9: "))

print(f"Таблица умножения для числа {num}:")
for i in range(1, 11):
    result = num * i
    print(f"{num} * {i} = {result}")
'''
'''
print("Каждое третье число от 0 до 100:")
for i in range(0, 101, 3):
    print(i, end=" ")
print()  # перенос строки
'''
'''
num = int(input("Введите число для вычисления факториала: "))
factorial = 1

for i in range(1, num + 1):
    factorial *= i

print(f"Факториал числа {num} равен {factorial}")
'''
'''
i = 20
print("Числа от 20 до 0:")
while i >= 0:
    print(i, end=" ")
    i -= 1
print()  # перенос строки
'''
'''
limit = int(input("Введите предел для чисел Фибоначчи: "))

a, b = 0, 1
print(f"Числа Фибоначчи до {limit}:")
while a <= limit:
    print(a, end=" ")
    a, b = b, a + b
print()  # перенос строки
'''
'''
text = input("Введите строку: ")
result = ""

for i, char in enumerate(text, 1):
    result += char + str(i)

print(f"Результат: {result}")
'''
'''
print("Программа для сложения двух чисел (для выхода нажмите Ctrl+C)")

while True:
    numbers = input("Введите два числа через пробел: ").split()
    
    if len(numbers) == 2:
        try:
            num1 = float(numbers[0])
            num2 = float(numbers[1])
            sum_result = num1 + num2
            print(f"Сумма равна: {sum_result}")
            print()  # пустая строка для разделения
        except ValueError:
            print("Ошибка! Введите числа корректно.")
    else:
        print("Ошибка! Введите ровно два числа.")
'''
