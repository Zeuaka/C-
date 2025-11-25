using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OfficeOpenXml;

public class DatabaseManager
{
    private List<ProductMovement> _movements;
    private List<Product> _products;
    private List<Store> _stores;
    private List<Category> _categories;
    private string _filePath;
    private int _nextMovementId = 1;
    private int _nextProductArticle = 1001;
    private int _nextStoreId = 1;
    private int _nextCategoryId = 1;

    public DatabaseManager(string path)
    {
        _filePath = path;
        _movements = new List<ProductMovement>();
        _products = new List<Product>();
        _stores = new List<Store>();
        _categories = new List<Category>();
        
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        CreateTestData();
    }
    private int GetNextMovementId()
    {
        int maxId = _nextMovementId;
        foreach (var movement in _movements)
        {
            if (movement.OperationId >= maxId)
            {
                maxId = movement.OperationId + 1;
            }
        }
        _nextMovementId = maxId;
        return _nextMovementId;
    }

    private int GetNextProductArticle()
    {
        int maxArticle = _nextProductArticle;
        foreach (var product in _products)
        {
            if (product.Article >= maxArticle)
            {
                maxArticle = product.Article + 1;
            }
        }
        _nextProductArticle = maxArticle;
        return _nextProductArticle;
    }

    private int GetNextStoreId()
    {
        int maxId = _nextStoreId;
        foreach (var store in _stores)
        {
            if (store.Id >= maxId)
            {
                maxId = store.Id + 1;
            }
        }
        _nextStoreId = maxId;
        return _nextStoreId;
    }

    private int GetNextCategoryId()
    {
        int maxId = _nextCategoryId;
        foreach (var category in _categories)
        {
            if (category.Id >= maxId)
            {
                maxId = category.Id + 1;
            }
        }
        _nextCategoryId = maxId;
        return _nextCategoryId;
    }

    public void ReadFromExcel()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Файл не найден. Используются тестовые данные.");
                return;
            }

            _movements.Clear();
            _products.Clear();
            _stores.Clear();
            _categories.Clear();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var categoriesSheet = package.Workbook.Worksheets["Категория"];
                if (categoriesSheet != null && categoriesSheet.Dimension != null)
                {
                    for (int row = 2; row <= categoriesSheet.Dimension.End.Row; row++)
                    {
                        if (categoriesSheet.Cells[row, 1].Value != null)
                        {
                            _categories.Add(new Category(
                                Convert.ToInt32(categoriesSheet.Cells[row, 1].Value),
                                categoriesSheet.Cells[row, 2].Value?.ToString() ?? "",
                                categoriesSheet.Cells[row, 3].Value?.ToString() ?? ""
                            ));
                        }
                    }
                    Console.WriteLine($"Загружено категорий: {_categories.Count}");
                }
                var storesSheet = package.Workbook.Worksheets["Магазин"];
                if (storesSheet != null && storesSheet.Dimension != null)
                {
                    for (int row = 2; row <= storesSheet.Dimension.End.Row; row++)
                    {
                        if (storesSheet.Cells[row, 1].Value != null)
                        {
                            _stores.Add(new Store(
                                Convert.ToInt32(storesSheet.Cells[row, 1].Value),
                                storesSheet.Cells[row, 2].Value?.ToString() ?? "",
                                storesSheet.Cells[row, 3].Value?.ToString() ?? ""
                            ));
                        }
                    }
                    Console.WriteLine($"Загружено магазинов: {_stores.Count}");
                }
                var productsSheet = package.Workbook.Worksheets["Товар"];
                if (productsSheet != null && productsSheet.Dimension != null)
                {
                    for (int row = 2; row <= productsSheet.Dimension.End.Row; row++)
                    {
                        if (productsSheet.Cells[row, 1].Value != null)
                        {
                            _products.Add(new Product(
                                Convert.ToInt32(productsSheet.Cells[row, 1].Value),
                                Convert.ToInt32(productsSheet.Cells[row, 2].Value),
                                productsSheet.Cells[row, 3].Value?.ToString() ?? "",
                                productsSheet.Cells[row, 4].Value?.ToString() ?? "",
                                Convert.ToInt32(productsSheet.Cells[row, 5].Value),
                                Convert.ToDecimal(productsSheet.Cells[row, 6].Value)
                            ));
                        }
                    }
                    Console.WriteLine($"Загружено товаров: {_products.Count}");
                }
                var movementsSheet = package.Workbook.Worksheets["Движение товаров"];
                if (movementsSheet != null && movementsSheet.Dimension != null)
                {
                    for (int row = 2; row <= movementsSheet.Dimension.End.Row; row++)
                    {
                        if (movementsSheet.Cells[row, 1].Value != null)
                        {
                            _movements.Add(new ProductMovement(
                                Convert.ToInt32(movementsSheet.Cells[row, 1].Value),
                                DateTime.FromOADate(Convert.ToDouble(movementsSheet.Cells[row, 2].Value)),
                                Convert.ToInt32(movementsSheet.Cells[row, 3].Value),
                                Convert.ToInt32(movementsSheet.Cells[row, 4].Value),
                                movementsSheet.Cells[row, 5].Value?.ToString() ?? "",
                                Convert.ToInt32(movementsSheet.Cells[row, 6].Value),
                                movementsSheet.Cells[row, 7].Value?.ToString() ?? ""
                            ));
                        }
                    }
                    Console.WriteLine($"Загружено движений товаров: {_movements.Count}");
                }
            }
            Console.WriteLine("Данные успешно загружены из Excel файла");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            Console.WriteLine("Используются тестовые данные.");
        }
    }

    private void CreateTestData()
    {
        _products.Clear();
        _stores.Clear();
        _categories.Clear();
        _movements.Clear();

        _categories.Add(new Category(1, "Игрушки на радиоуправлении", "17+"));
        _categories.Add(new Category(2, "Набор юного слесаря", "0+"));
        _categories.Add(new Category(3, "Лабубы", "10+"));
        _categories.Add(new Category(4, "Аниме мерч", "2+"));

        _stores.Add(new Store(1, "Дзержинский", "ул. Пушкина, д. Колотушкина"));
        _stores.Add(new Store(2, "Ленинский", "ул. Макаренко, 19"));
        _stores.Add(new Store(3, "Садовый", "ул. Пельменей, 21"));
        _stores.Add(new Store(4, "Грязный", "ул. Посредственностей, 15"));

        _products.Add(new Product(1001, 1, "РобоСобака", "шт", 1, 50000m));
        _products.Add(new Product(1002, 2, "Слесарь Сергей, пак № 1", "шт", 1, 30000m));
        _products.Add(new Product(1003, 3, "Лабуба Серая", "шт", 1, 15000m));
        _products.Add(new Product(1004, 4, "Фигурка Вокалоид в оригиналную высоту", "шт", 1, 20000m));
        _products.Add(new Product(1005, 1, "РобоКоп", "шт", 1, 25000m));

        _movements.Add(new ProductMovement(1, new DateTime(2024, 8, 1), 1, 1001, "Поступление", 10, "Нет"));
        _movements.Add(new ProductMovement(2, new DateTime(2024, 8, 2), 1, 1001, "Продажа", 3, "Да"));
        _movements.Add(new ProductMovement(3, new DateTime(2024, 8, 3), 2, 1002, "Продажа", 2, "Нет"));
        _movements.Add(new ProductMovement(4, new DateTime(2024, 8, 4), 3, 1003, "Продажа", 1, "Да"));
        _movements.Add(new ProductMovement(5, new DateTime(2024, 8, 5), 1, 1004, "Поступление", 5, "Нет"));
        _movements.Add(new ProductMovement(6, new DateTime(2024, 8, 5), 1, 1004, "Продажа", 2, "Нет"));
        
        Console.WriteLine("Созданы тестовые данные:");
        Console.WriteLine($"- Категорий: {_categories.Count}");
        Console.WriteLine($"- Магазинов: {_stores.Count}");
        Console.WriteLine($"- Товаров: {_products.Count}");
        Console.WriteLine($"- Движений товаров: {_movements.Count}");
    }
    public void ViewData(string tableName)
    {
        switch (tableName.ToLower())
        {
            case "movements":
                Console.WriteLine("=== Движение товаров ===");
                if (_movements.Count == 0)
                {
                    Console.WriteLine("Нет данных");
                    return;
                }
                foreach (var movement in _movements)
                {
                    var product = (from p in _products where p.Article == movement.Article select p).FirstOrDefault();
                    var store = (from s in _stores where s.Id == movement.StoreId select s).FirstOrDefault();
                    Console.WriteLine($"{movement} | Товар: {product?.Name} | Магазин: {store?.District}");
                }
                break;
            case "products":
                Console.WriteLine("=== Товары ===");
                if (_products.Count == 0)
                {
                    Console.WriteLine("Нет данных");
                    return;
                }
                foreach (var product in _products)
                {
                    var category = (from c in _categories where c.Id == product.CategoryId select c).FirstOrDefault();
                    Console.WriteLine($"{product} | Категория: {category?.Name}");
                }
                break;
            case "stores":
                Console.WriteLine("=== Магазины ===");
                if (_stores.Count == 0)
                {
                    Console.WriteLine("Нет данных");
                    return;
                }
                foreach (var store in _stores)
                {
                    Console.WriteLine(store);
                }
                break;
            case "categories":
                Console.WriteLine("=== Категории ===");
                if (_categories.Count == 0)
                {
                    Console.WriteLine("Нет данных");
                    return;
                }
                foreach (var category in _categories)
                {
                    Console.WriteLine(category);
                }
                break;
            default:
                Console.WriteLine("Неизвестная таблица");
                break;
        }
    }
    public void DeleteItem(string tableName, int id)
    {
        try
        {
            switch (tableName.ToLower())
            {
                case "movements":
                    var movementToDelete = (from m in _movements where m.OperationId == id select m).FirstOrDefault();
                    if (movementToDelete != null)
                    {
                        _movements.Remove(movementToDelete);
                        Console.WriteLine("Запись движения товаров удалена");
                    }
                    else Console.WriteLine("Запись не найдена");
                    break;

                case "products":
                    var productToDelete = (from p in _products where p.Article == id select p).FirstOrDefault();
                    if (productToDelete != null)
                    {
                        var relatedMovements = (from m in _movements where m.Article == id select m).ToList();
                        foreach (var relatedMovement in relatedMovements)
                        {
                            _movements.Remove(relatedMovement);
                        }
                        _products.Remove(productToDelete);
                        Console.WriteLine($"Товар удален. Удалено связанных движений: {relatedMovements.Count}");
                    }
                    else Console.WriteLine("Товар не найден");
                    break;

                case "stores":
                    var storeToDelete = (from s in _stores where s.Id == id select s).FirstOrDefault();
                    if (storeToDelete != null)
                    {
                        var relatedMovements = (from m in _movements where m.StoreId == id select m).ToList();
                        foreach (var relatedMovement in relatedMovements)
                        {
                            _movements.Remove(relatedMovement);
                        }
                        _stores.Remove(storeToDelete);
                        Console.WriteLine($"Магазин удален. Удалено связанных движений: {relatedMovements.Count}");
                    }
                    else Console.WriteLine("Магазин не найден");
                    break;

                case "categories":
                    var categoryToDelete = (from c in _categories where c.Id == id select c).FirstOrDefault();
                    if (categoryToDelete != null)
                    {
                        var relatedProducts = (from p in _products where p.CategoryId == id select p).ToList();
                        foreach (var product in relatedProducts)
                        {
                            var productMovements = (from m in _movements where m.Article == product.Article select m).ToList();
                            foreach (var movement in productMovements)
                            {
                                _movements.Remove(movement);
                            }
                            _products.Remove(product);
                        }
                        
                        _categories.Remove(categoryToDelete);
                        Console.WriteLine($"Категория удалена. Удалено товаров: {relatedProducts.Count}");
                    }
                    else Console.WriteLine("Категория не найден");
                    break;

                default:
                    Console.WriteLine("Неизвестная таблица");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении: {ex.Message}");
        }
    }
    private bool StoreExists(int storeId)
    {
        var store = (from s in _stores where s.Id == storeId select s).FirstOrDefault();
        return store != null;
    }

    private bool ProductExists(int article)
    {
        var product = (from p in _products where p.Article == article select p).FirstOrDefault();
        return product != null;
    }

    private bool CategoryExists(int categoryId)
    {
        var category = (from c in _categories where c.Id == categoryId select c).FirstOrDefault();
        return category != null;
    }
    public void AddProductMovement(DateTime date, int storeId, int article, 
                                  string operationType, int quantity, string hasCard)
    {
        try
        {
            if (!StoreExists(storeId))
            {
                Console.WriteLine("Ошибка: Магазин с указанным ID не существует");
                return;
            }

            if (!ProductExists(article))
            {
                Console.WriteLine("Ошибка: Товар с указанным артикулом не существует");
                return;
            }

            int newId = GetNextMovementId();
            _movements.Add(new ProductMovement(newId, date, storeId, article, operationType, quantity, hasCard));
            Console.WriteLine($"Запись добавлена с ID: {newId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
        }
    }

    public void AddProduct(string name, int categoryId, string unit, int quantityPerPackage, decimal pricePerPackage)
    {
        try
        {
            if (!CategoryExists(categoryId))
            {
                Console.WriteLine("Ошибка: Категория с указанным ID не существует");
                return;
            }

            int newArticle = GetNextProductArticle();
            _products.Add(new Product(newArticle, categoryId, name, unit, quantityPerPackage, pricePerPackage));
            Console.WriteLine($"Товар добавлен с артикулом: {newArticle}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении товара: {ex.Message}");
        }
    }

    public void AddStore(string district, string address)
    {
        try
        {
            int newId = GetNextStoreId();
            _stores.Add(new Store(newId, district, address));
            Console.WriteLine($"Магазин добавлен с ID: {newId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении магазина: {ex.Message}");
        }
    }

    public void AddCategory(string name, string ageRestriction)
    {
        try
        {
            int newId = GetNextCategoryId();
            _categories.Add(new Category(newId, name, ageRestriction));
            Console.WriteLine($"Категория добавлена с ID: {newId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении категории: {ex.Message}");
        }
    }
    public void GetSalesWithCustomerCards()
    {
        var result = from m in _movements
                    where m.OperationType == "Продажа" && m.HasCustomerCard == "Да"
                    select m;

        Console.WriteLine("=== Продажи с картой клиента ===");
        if (!result.Any())
        {
            Console.WriteLine("Нет данных");
            return;
        }
        
        foreach (var item in result)
        {
            var product = (from p in _products where p.Article == item.Article select p).FirstOrDefault();
            Console.WriteLine($"{item} | Товар: {product?.Name}");
        }
    }

    public void GetTotalSalesInWalkerDistrict()
    {
        var salesData = from m in _movements
                       join s in _stores on m.StoreId equals s.Id
                       join p in _products on m.Article equals p.Article
                       where m.OperationType == "Продажа" && s.District == "Ходунковый"
                       select new { Quantity = m.PackageQuantity, Price = p.PricePerPackage };

        decimal totalSales = 0;
        foreach (var item in salesData)
        {
            totalSales += item.Quantity * item.Price;
        }

        Console.WriteLine($"Общая стоимость продаж в Ходунковом районе: {totalSales:N0} руб.");
    }

    public void GetSalesByCategory()
    {
        var result = from m in _movements
                    join p in _products on m.Article equals p.Article
                    join c in _categories on p.CategoryId equals c.Id
                    where m.OperationType == "Продажа"
                    group new { Movement = m, Product = p, Category = c } by new { CategoryName = c.Name, Age = c.AgeRestriction } into g
                    select new
                    {
                        Category = g.Key.CategoryName,
                        AgeRestriction = g.Key.Age,
                        TotalRevenue = (from item in g select item.Movement.PackageQuantity * item.Product.PricePerPackage).Sum(),
                        TotalQuantity = (from item in g select item.Movement.PackageQuantity).Sum()
                    };

        Console.WriteLine("=== Продажи по категориям ===");
        if (!result.Any())
        {
            Console.WriteLine("Нет данных");
            return;
        }
        
        foreach (var item in result)
        {
            Console.WriteLine($"Категория: {item.Category} ({item.AgeRestriction}), " +
                            $"Выручка: {item.TotalRevenue:N0} руб., Количество: {item.TotalQuantity}");
        }
    }

    public void GetAveragePriceByAgeGroup()
    {
        var ageGroups = from p in _products
                       join c in _categories on p.CategoryId equals c.Id
                       join m in _movements on p.Article equals m.Article
                       where m.OperationType == "Поступление"
                       group p by c.AgeRestriction into g
                       select new
                       {
                           AgeGroup = g.Key,
                           AveragePrice = (from product in g select product.PricePerPackage).Average()
                       };

        Console.WriteLine("=== Средняя цена по возрастным группам ===");
        if (!ageGroups.Any())
        {
            Console.WriteLine("Нет данных");
            return;
        }
        
        foreach (var item in ageGroups)
        {
            Console.WriteLine($"Возрастная группа: {item.AgeGroup}, Средняя цена: {item.AveragePrice:N0} руб.");
        }
    }
    public void SaveToExcel()
    {
        try
        {
            using (var package = new ExcelPackage())
            {
                var categoriesSheet = package.Workbook.Worksheets.Add("Категория");
                categoriesSheet.Cells[1, 1].Value = "ID";
                categoriesSheet.Cells[1, 2].Value = "Наименование";
                categoriesSheet.Cells[1, 3].Value = "Возрастное ограничение";
                for (int i = 0; i < _categories.Count; i++)
                {
                    categoriesSheet.Cells[i + 2, 1].Value = _categories[i].Id;
                    categoriesSheet.Cells[i + 2, 2].Value = _categories[i].Name;
                    categoriesSheet.Cells[i + 2, 3].Value = _categories[i].AgeRestriction;
                }

                var storesSheet = package.Workbook.Worksheets.Add("Магазин");
                storesSheet.Cells[1, 1].Value = "ID";
                storesSheet.Cells[1, 2].Value = "Район";
                storesSheet.Cells[1, 3].Value = "Адрес";
                for (int i = 0; i < _stores.Count; i++)
                {
                    storesSheet.Cells[i + 2, 1].Value = _stores[i].Id;
                    storesSheet.Cells[i + 2, 2].Value = _stores[i].District;
                    storesSheet.Cells[i + 2, 3].Value = _stores[i].Address;
                }

                var productsSheet = package.Workbook.Worksheets.Add("Товар");
                productsSheet.Cells[1, 1].Value = "Артикул";
                productsSheet.Cells[1, 2].Value = "ID категории";
                productsSheet.Cells[1, 3].Value = "Наименование";
                productsSheet.Cells[1, 4].Value = "Единица измерения";
                productsSheet.Cells[1, 5].Value = "Количество в упаковке";
                productsSheet.Cells[1, 6].Value = "Цена за упаковку";
                for (int i = 0; i < _products.Count; i++)
                {
                    productsSheet.Cells[i + 2, 1].Value = _products[i].Article;
                    productsSheet.Cells[i + 2, 2].Value = _products[i].CategoryId;
                    productsSheet.Cells[i + 2, 3].Value = _products[i].Name;
                    productsSheet.Cells[i + 2, 4].Value = _products[i].Unit;
                    productsSheet.Cells[i + 2, 5].Value = _products[i].QuantityPerPackage;
                    productsSheet.Cells[i + 2, 6].Value = _products[i].PricePerPackage;
                }
                var movementsSheet = package.Workbook.Worksheets.Add("Движение товаров");
                movementsSheet.Cells[1, 1].Value = "ID операции";
                movementsSheet.Cells[1, 2].Value = "Дата";
                movementsSheet.Cells[1, 3].Value = "ID магазина";
                movementsSheet.Cells[1, 4].Value = "Артикул";
                movementsSheet.Cells[1, 5].Value = "Тип операции";
                movementsSheet.Cells[1, 6].Value = "Количество упаковок";
                movementsSheet.Cells[1, 7].Value = "Наличие карты клиента";
                for (int i = 0; i < _movements.Count; i++)
                {
                    movementsSheet.Cells[i + 2, 1].Value = _movements[i].OperationId;
                    movementsSheet.Cells[i + 2, 2].Value = _movements[i].Date.ToOADate();
                    movementsSheet.Cells[i + 2, 3].Value = _movements[i].StoreId;
                    movementsSheet.Cells[i + 2, 4].Value = _movements[i].Article;
                    movementsSheet.Cells[i + 2, 5].Value = _movements[i].OperationType;
                    movementsSheet.Cells[i + 2, 6].Value = _movements[i].PackageQuantity;
                    movementsSheet.Cells[i + 2, 7].Value = _movements[i].HasCustomerCard;
                }

                package.SaveAs(new FileInfo(_filePath));
            }
            Console.WriteLine("Данные успешно сохранены в Excel файл");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
        }
    }
}