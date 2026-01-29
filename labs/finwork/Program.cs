using System;
using System.Collections.Generic;
using System.Linq;

namespace TextRPG
{
    // Класс для хранения данных игрока
    class Player
    {
        public string Race;
        public int HP;
        public int MaxHP;
        public int BaseAtk;
        public int BaseDef;
        public int Level = 1;
        public int Exp = 0;
        public int Points = 0; // Очки для прокачки
        // экипировка
        public string Weapon = null;
        public string Armor = null;
        // статы с учетом экипировки
        public int Atk { get { return BaseAtk + (Weapon != null ? 2 : 0); } }
        public int Def { get { return BaseDef + (Armor != null ? 2 : 0); } }
        // инвентарь
        public Dictionary<string, int> Inventory = new Dictionary<string, int>();
    }

    class Program
    {
        // Создаем статические переменные, чтобы они были видны во всех функциях
        static Player hero = new Player();
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            try
            {
                //создание персонажа
                CreateCharacter();
                int roomsCleared = 0;
                //главный цикл игры 
                while (hero.HP > 0)
                {
                    roomsCleared++;
                    //генерируем 2 варианта пути
                    string[] roomTypes = { "Боевая", "Отдых", "Сундук", "Инвентарь" };
                    string leftRoom = roomTypes[rnd.Next(0, roomTypes.Length)];
                    string rightRoom = roomTypes[rnd.Next(0, roomTypes.Length)];
                    //механика видимости (50% шанс увидеть чтото в комнате)
                    string showLeft = (rnd.NextDouble() > 0.5) ? leftRoom : "???";
                    string showRight = (rnd.NextDouble() > 0.5) ? rightRoom : "???";

                    Console.WriteLine("\n=========================================");
                    Console.WriteLine($"Комната #{roomsCleared} | Уровень: {hero.Level} | HP: {hero.HP}/{hero.MaxHP}");
                    Console.WriteLine($"ATK: {hero.Atk} (база: {hero.BaseAtk}) | DEF: {hero.Def} (база: {hero.BaseDef})");
                    Console.WriteLine($"Экипировка: Оружие: {(hero.Weapon ?? "нет")}, Броня: {(hero.Armor ?? "нет")}");
                    Console.WriteLine("=========================================");

                    Console.WriteLine("\nПеред вами развилка!");
                    Console.WriteLine($"1 - Налево ({showLeft})");
                    Console.WriteLine($"2 - Направо ({showRight})");
                    Console.WriteLine($"3 - Открыть инвентарь");
                    Console.Write("Ваш выбор: ");
                    string choice = "";
                    bool validChoice = false;
                    while (!validChoice)
                    {
                        try
                        {
                            choice = Console.ReadLine();
                            if (choice != "1" && choice != "2" && choice != "3")
                            {
                                throw new Exception("Пожалуйста, введите 1, 2 или 3");
                            }
                            validChoice = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.Write("Попробуйте снова: ");
                        }
                    }

                    if (choice == "3")
                    {
                        ShowInventory();
                        continue;
                    }

                    string chosenRoom = (choice == "1") ? leftRoom : rightRoom;
                    Console.WriteLine($"\nВы выбрали комнату: {chosenRoom}");

                    //заходим в выбранную комнату
                    if (chosenRoom == "Боевая")
                    {
                        bool survived = Battle();
                        if (!survived) break; // если умерли, выходим из цикла
                    }
                    else if (chosenRoom == "Отдых")
                    {
                        RestRoom();
                    }
                    else if (chosenRoom == "Сундук")
                    {
                        ChestRoom();
                    }
                    else if (chosenRoom == "Инвентарь")
                    {
                        ShowInventory();
                    }
                }

                Console.WriteLine("\n=== ГЕЙМ ОВЕР ===");
                Console.WriteLine($"Вы погибли. Ваш результат: {roomsCleared} комнат.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла критическая ошибка: {ex.Message}");
                Console.WriteLine("Игра будет завершена.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey(); // чтобы консоль не закрылась сразу
        }

        // --- ФУНКЦИИ ИГРЫ ---
        static void CreateCharacter()
        {
            Console.WriteLine("=== МЕНЮ СОЗДАНИЯ ПЕРСОНАЖА ===");
            Console.WriteLine("ВЫБЕРИТЕ РАСУ");
            Console.WriteLine("1 - Человек (средний во всем)");
            Console.WriteLine("2 - Эльф (много урона, мало HP)");
            Console.WriteLine("3 - Дварф (накачанный, много HP)");
            Console.Write("Ваш выбор: ");

            string choice = "";
            bool validChoice = false;

            while (!validChoice)
            {
                try
                {
                    choice = Console.ReadLine();
                    if (choice != "1" && choice != "2" && choice != "3")
                    {
                        throw new Exception("Пожалуйста, введите число от 1 до 3");
                    }
                    validChoice = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.Write("Попробуйте снова: ");
                }
            }

            // задаем статы в зависимости от выбора
            if (choice == "2")
            {
                hero.Race = "Эльф";
                hero.MaxHP = rnd.Next(60, 81);
                hero.BaseAtk = rnd.Next(14, 23);
                hero.BaseDef = rnd.Next(3, 8);
            }
            else if (choice == "3")
            {
                hero.Race = "Дварф";
                hero.MaxHP = rnd.Next(100, 131);
                hero.BaseAtk = rnd.Next(8, 13);
                hero.BaseDef = rnd.Next(8, 16);
            }
            else
            {
                hero.Race = "Человек";
                hero.MaxHP = rnd.Next(80, 101);
                hero.BaseAtk = rnd.Next(10, 16);
                hero.BaseDef = rnd.Next(5, 11);
            }
            hero.HP = hero.MaxHP; // полное здоровье на старте

            // Стартовые предметы
            hero.Inventory["Монета"] = 5;
            hero.Inventory["Малое зелье здоровья"] = 2;

            Console.WriteLine($"\nГерой создан! Раса: {hero.Race}");
            Console.WriteLine($"HP: {hero.HP}/{hero.MaxHP}, ATK: {hero.Atk}, DEF: {hero.Def}");
            Console.WriteLine("Стартовый инвентарь: 5 монет, 2 малых зелья здоровья");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static bool Battle()
        {
            // сила врага растет с уровнем героя
            int enemyHP = rnd.Next(20, 51) + (hero.Level * 5);
            int enemyAtk = rnd.Next(5, 11) + hero.Level;

            Console.WriteLine($"\n--- БОЙ! Враг: Скелет (HP: {enemyHP}, ATK: {enemyAtk}) ---");

            while (enemyHP > 0 && hero.HP > 0)
            {
                Console.WriteLine($"\nВаше HP: {hero.HP}/{hero.MaxHP} | HP Врага: {enemyHP}");
                Console.WriteLine("1 - Атаковать, 2 - Использовать предмет, 3 - Бежать");
                Console.Write("Ваш выбор: ");

                string action = "";
                bool validAction = false;

                while (!validAction)
                {
                    try
                    {
                        action = Console.ReadLine();
                        if (action != "1" && action != "2" && action != "3")
                        {
                            throw new Exception("Пожалуйста, введите 1, 2 или 3");
                        }
                        validAction = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.Write("Попробуйте снова: ");
                    }
                }

                if (action == "1")
                {
                    // расчет урона героя
                    int dmg = Math.Max(1, hero.Atk - rnd.Next(0, 4));
                    enemyHP -= dmg;
                    Console.WriteLine($"Вы нанесли {dmg} урона!");

                    if (enemyHP > 0)
                    {
                        // ответный удар врага
                        int dmgEnemy = Math.Max(1, enemyAtk - (hero.Def / 2));
                        hero.HP -= dmgEnemy;
                        Console.WriteLine($"Враг нанес вам {dmgEnemy} урона!");
                    }
                }
                else if (action == "2")
                {
                    UseItemInBattle();
                }
                else
                {
                    Console.WriteLine("Вы попытались сбежать, но споткнулись и получили урон!");
                    hero.HP -= 5;
                    break; // выход из боя
                }
            }

            if (hero.HP <= 0) return false; // умерли
            if (enemyHP <= 0)
            {
                int expGain = 15;
                int coinGain = rnd.Next(1, 4);
                Console.WriteLine($"\nПобеда! Вы получили {expGain} опыта и {coinGain} монет.");
                hero.Exp += expGain;
                AddToInventory("Монета", coinGain);
                CheckLevelUp();
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            return true; // выжили
        }

        static void ShowInventory()
        {
            Console.WriteLine("\n=== ИНВЕНТАРЬ ===");
            Console.WriteLine($"Монеты: {GetItemCount("Монета")}");
            Console.WriteLine("\nПредметы:");

            if (hero.Inventory.Count == 0 || (hero.Inventory.Count == 1 && hero.Inventory.ContainsKey("Монета")))
            {
                Console.WriteLine("(пусто)");
            }
            else
            {
                foreach (var item in hero.Inventory)
                {
                    if (item.Key != "Монета")
                    {
                        Console.WriteLine($"- {item.Key}: {item.Value}");
                    }
                }
            }

            Console.WriteLine("\nДействия:");
            Console.WriteLine("1 - Использовать предмет");
            Console.WriteLine("2 - Экипировать предмет");
            Console.WriteLine("3 - Выбросить предмет");
            Console.WriteLine("4 - Вернуться в игру");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UseItem();
                    break;
                case "2":
                    EquipItem();
                    break;
                case "3":
                    DiscardItem();
                    break;
                default:
                    Console.WriteLine("Возвращаемся в игру...");
                    break;
            }
        }

        static void UseItem()
        {
            Console.WriteLine("\n=== ИСПОЛЬЗОВАНИЕ ПРЕДМЕТА ===");

            var usableItems = hero.Inventory
                .Where(x => x.Key.StartsWith("Зелье") || x.Key.StartsWith("Эликсир"))
                .ToList();

            if (usableItems.Count == 0)
            {
                Console.WriteLine("Нет предметов для использования.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < usableItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {usableItems[i].Key} (x{usableItems[i].Value})");
            }
            Console.WriteLine("0 - Отмена");
            Console.Write("Ваш выбор: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= usableItems.Count)
            {
                string itemName = usableItems[choice - 1].Key;
                UseItemEffect(itemName);
                RemoveFromInventory(itemName, 1);
            }
        }

        static void UseItemInBattle()
        {
            Console.WriteLine("\n=== ИСПОЛЬЗОВАНИЕ ПРЕДМЕТА В БОЮ ===");

            var usableItems = hero.Inventory
                .Where(x => x.Key.StartsWith("Зелье"))
                .ToList();

            if (usableItems.Count == 0)
            {
                Console.WriteLine("Нет зелий для использования!");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < usableItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {usableItems[i].Key} (x{usableItems[i].Value})");
            }
            Console.WriteLine("0 - Отмена");
            Console.Write("Ваш выбор: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= usableItems.Count)
            {
                string itemName = usableItems[choice - 1].Key;
                UseItemEffect(itemName);
                RemoveFromInventory(itemName, 1);
            }
        }

        static void UseItemEffect(string itemName)
        {
            if (itemName.Contains("малое зелье здоровья"))
            {
                int heal = 20;
                hero.HP = Math.Min(hero.MaxHP, hero.HP + heal);
                Console.WriteLine($"Вы использовали {itemName} и восстановили {heal} HP!");
            }
            else if (itemName.Contains("большое зелье здоровья"))
            {
                int heal = 50;
                hero.HP = Math.Min(hero.MaxHP, hero.HP + heal);
                Console.WriteLine($"Вы использовали {itemName} и восстановили {heal} HP!");
            }
            else if (itemName.Contains("эликсир силы"))
            {
                hero.BaseAtk += 2;
                Console.WriteLine($"Вы использовали {itemName} и увеличили базовую атаку на 2!");
            }
        }

        static void EquipItem()
        {
            Console.WriteLine("\n=== ЭКИПИРОВКА ===");

            var equippableItems = hero.Inventory
                .Where(x => x.Key.Contains("Меч") || x.Key.Contains("Меч") ||
                           x.Key.Contains("Броня") || x.Key.Contains("Кольчуга") ||
                           x.Key.Contains("Щит"))
                .ToList();

            if (equippableItems.Count == 0)
            {
                Console.WriteLine("Нет предметов для экипировки.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Доступные предметы:");
            for (int i = 0; i < equippableItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {equippableItems[i].Key} (x{equippableItems[i].Value})");
            }
            Console.WriteLine("0 - Отмена");
            Console.Write("Ваш выбор: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= equippableItems.Count)
            {
                string itemName = equippableItems[choice - 1].Key;

                if (itemName.Contains("Меч") || itemName.Contains("Меч"))
                {
                    if (hero.Weapon != null)
                    {
                        AddToInventory(hero.Weapon, 1);
                        Console.WriteLine($"Снял: {hero.Weapon}");
                    }
                    hero.Weapon = itemName;
                    RemoveFromInventory(itemName, 1);
                    Console.WriteLine($"Экипировано оружие: {itemName}");
                }
                else if (itemName.Contains("Броня") || itemName.Contains("Кольчуга") || itemName.Contains("Щит"))
                {
                    if (hero.Armor != null)
                    {
                        AddToInventory(hero.Armor, 1);
                        Console.WriteLine($"Снял: {hero.Armor}");
                    }
                    hero.Armor = itemName;
                    RemoveFromInventory(itemName, 1);
                    Console.WriteLine($"Экипирована броня: {itemName}");
                }
            }
        }

        static void DiscardItem()
        {
            Console.WriteLine("\n=== ВЫБРОСИТЬ ПРЕДМЕТ ===");

            if (hero.Inventory.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст!");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            var itemsList = hero.Inventory.ToList();
            for (int i = 0; i < itemsList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {itemsList[i].Key} (x{itemsList[i].Value})");
            }
            Console.WriteLine("0 - Отмена");
            Console.Write("Ваш выбор: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= itemsList.Count)
            {
                string itemName = itemsList[choice - 1].Key;
                Console.Write($"Сколько выбросить? (1-{itemsList[choice - 1].Value}): ");

                if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0 && amount <= itemsList[choice - 1].Value)
                {
                    RemoveFromInventory(itemName, amount);
                    Console.WriteLine($"Выброшено {amount} x {itemName}");
                }
            }
        }

        static void CheckLevelUp()
        {
            int neededExp = hero.Level * 20;
            if (hero.Exp >= neededExp)
            {
                hero.Level++;
                hero.Exp -= neededExp;
                hero.Points += 3;
                Console.WriteLine($"\n!!! НОВЫЙ УРОВЕНЬ: {hero.Level} !!!");
                Console.WriteLine("Вы получили очки характеристик (распределите в комнате отдыха).");
            }
        }

        static void RestRoom()
        {
            Console.WriteLine("\n--- КОМНАТА ОТДЫХА ---");
            Console.WriteLine("Вы отдохнули у костра. HP восстановлено.");
            hero.HP += 20;
            if (hero.HP > hero.MaxHP) hero.HP = hero.MaxHP;

            // если есть очки прокачки, предлагаем потратить
            if (hero.Points > 0)
            {
                Console.WriteLine($"\nУ вас есть {hero.Points} очков прокачки.");
                Console.WriteLine("1 - +1 к Атаке");
                Console.WriteLine("2 - +1 к Защите");
                Console.WriteLine("3 - +10 к Здоровью");
                Console.Write("Ваш выбор (или нажмите Enter чтобы пропустить): ");

                string choice = Console.ReadLine();

                if (!string.IsNullOrEmpty(choice))
                {
                    bool validChoice = false;
                    while (!validChoice)
                    {
                        try
                        {
                            if (choice != "1" && choice != "2" && choice != "3")
                            {
                                throw new Exception("Пожалуйста, введите число от 1 до 3");
                            }
                            validChoice = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.Write("Попробуйте снова (или нажмите Enter чтобы пропустить): ");
                            choice = Console.ReadLine();
                            if (string.IsNullOrEmpty(choice))
                            {
                                break;
                            }
                        }
                    }

                    if (validChoice)
                    {
                        if (choice == "1")
                        {
                            hero.BaseAtk++;
                            Console.WriteLine("Базовая атака увеличена на 1!");
                        }
                        else if (choice == "2")
                        {
                            hero.BaseDef++;
                            Console.WriteLine("Базовая защита увеличена на 1!");
                        }
                        else if (choice == "3")
                        {
                            hero.MaxHP += 10;
                            hero.HP += 10;
                            Console.WriteLine("Максимальное здоровье увеличено на 10!");
                        }

                        hero.Points--;
                        Console.WriteLine($"Осталось очков прокачки: {hero.Points}");
                    }
                }
            }

            Console.WriteLine($"\nТекущие характеристики:");
            Console.WriteLine($"HP: {hero.HP}/{hero.MaxHP}, ATK: {hero.Atk} (база: {hero.BaseAtk}), DEF: {hero.Def} (база: {hero.BaseDef})");
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ChestRoom()
        {
            Console.WriteLine("\n--- СУНДУК ---");
            string[][] items =
            {
                new string[] { "Монета", "3" },
                new string[] { "Малое зелье здоровья", "1" },
                new string[] { "Большое зелье здоровья", "1" },
                new string[] { "Старый меч", "1" },
                new string[] { "Кольчуга", "1" },
                new string[] { "Эликсир силы", "1" }
            };

            string[] foundItem = items[rnd.Next(0, items.Length)];
            int amount = int.Parse(foundItem[1]);

            Console.WriteLine($"Вы открыли сундук и нашли: {foundItem[0]} (x{amount})");
            AddToInventory(foundItem[0], amount);

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        // --- ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ ДЛЯ ИНВЕНТАРЯ ---
        static void AddToInventory(string itemName, int amount)
        {
            if (hero.Inventory.ContainsKey(itemName))
            {
                hero.Inventory[itemName] += amount;
            }
            else
            {
                hero.Inventory[itemName] = amount;
            }
        }

        static void RemoveFromInventory(string itemName, int amount)
        {
            if (hero.Inventory.ContainsKey(itemName))
            {
                hero.Inventory[itemName] -= amount;
                if (hero.Inventory[itemName] <= 0)
                {
                    hero.Inventory.Remove(itemName);
                }
            }
        }

        static int GetItemCount(string itemName)
        {
            return hero.Inventory.ContainsKey(itemName) ? hero.Inventory[itemName] : 0;
        }
    }
}



