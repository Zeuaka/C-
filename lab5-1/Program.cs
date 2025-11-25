using System;

class Program
{
    static void Main()
    {
        DatabaseManager dbManager = new DatabaseManager("LR5-var1.xls");
        
        Console.WriteLine("=== Детские товары - Управление базой данных ===");
        
        bool exit = false;
        while (!exit)
        {
            ShowMenu();
            string choice = Console.ReadLine() ?? "";
            
            try
            {
                switch (choice)
                {
                    case "1":
                        dbManager.ReadFromExcel();
                        break;
                    case "2":
                        Console.Write("Введите название таблицы (movements/products/stores/categories): ");
                        string table = Console.ReadLine() ?? "";
                        dbManager.ViewData(table);
                        break;
                    case "3":
                        Console.Write("Введите название таблицы и ID через пробел: ");
                        var deleteInput = (Console.ReadLine() ?? "").Split(' ');
                        if (deleteInput.Length == 2)
                        {
                            dbManager.DeleteItem(deleteInput[0], int.Parse(deleteInput[1]));
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ввода");
                        }
                        break;
                    case "4":
                        ShowAddMenu(dbManager);
                        break;
                    case "5":
                        dbManager.GetSalesWithCustomerCards();
                        break;
                    case "6":
                        dbManager.GetTotalSalesInWalkerDistrict();
                        break;
                    case "7":
                        dbManager.GetTotalSales();
                        break;
                    case "8":
                        dbManager.GetAveragePriceByAgeGroup();
                        break;
                    case "9":
                        dbManager.SaveToExcel();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n1. Загрузить данные из Excel");
        Console.WriteLine("2. Просмотреть данные");
        Console.WriteLine("3. Удалить элемент");
        Console.WriteLine("4. Добавить элемент");
        Console.WriteLine("5. Запрос 1: Продажи с картой клиента");
        Console.WriteLine("6. Запрос 2: Общие продажи в Дзержинском районе");
        Console.WriteLine("7. Запрос 3: Общая стоимость всех продаж");
        Console.WriteLine("8. Запрос 4: Средняя цена по возрастным группам");
        Console.WriteLine("9. Сохранить данные в Excel");
        Console.WriteLine("0. Выход");
        Console.Write("Выберите действие: ");
    }

    static void ShowAddMenu(DatabaseManager dbManager)
    {
        Console.WriteLine("\nДобавление элемента:");
        Console.WriteLine("1. Добавить движение товара");
        Console.WriteLine("2. Добавить товар");
        Console.WriteLine("3. Добавить магазин");
        Console.WriteLine("4. Добавить категорию");
        Console.Write("Выберите тип элемента: ");
        
        string choice = Console.ReadLine() ?? "";
        
        try
        {
            switch (choice)
            {
                case "1":
                    AddNewMovement(dbManager);
                    break;
                case "2":
                    AddNewProduct(dbManager);
                    break;
                case "3":
                    AddNewStore(dbManager);
                    break;
                case "4":
                    AddNewCategory(dbManager);
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
        }
    }

    static void AddNewMovement(DatabaseManager dbManager)
    {
        Console.Write("Дата (дд.мм.гггг): ");
        DateTime date = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("dd.MM.yyyy"));
        Console.Write("ID магазина: ");
        int storeId = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Артикул товара: ");
        int article = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Тип операции (Поступление/Продажа/Возврат): ");
        string operation = Console.ReadLine() ?? "";
        Console.Write("Количество упаковок: ");
        int quantity = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Наличие карты (Да/Нет): ");
        string card = Console.ReadLine() ?? "";
        
        dbManager.AddProductMovement(date, storeId, article, operation, quantity, card);
    }

    static void AddNewProduct(DatabaseManager dbManager)
    {
        Console.Write("Наименование товара: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("ID категории: ");
        int categoryId = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Единица измерения: ");
        string unit = Console.ReadLine() ?? "";
        Console.Write("Количество в упаковке: ");
        int quantityPerPackage = int.Parse(Console.ReadLine() ?? "1");
        Console.Write("Цена за упаковку: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "0");
        
        dbManager.AddProduct(name, categoryId, unit, quantityPerPackage, price);
    }

    static void AddNewStore(DatabaseManager dbManager)
    {
        Console.Write("Район: ");
        string district = Console.ReadLine() ?? "";
        Console.Write("Адрес: ");
        string address = Console.ReadLine() ?? "";
        
        dbManager.AddStore(district, address);
    }

    static void AddNewCategory(DatabaseManager dbManager)
    {
        Console.Write("Наименование категории: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Возрастное ограничение: ");
        string ageRestriction = Console.ReadLine() ?? "";
        
        dbManager.AddCategory(name, ageRestriction);
    }
}