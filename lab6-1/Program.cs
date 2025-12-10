using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int infinite = 0;
            int x = 0;
            Description();
            while (infinite == 0)
            {
                Console.WriteLine("Выберите номер задания (Введите одну цифру 1 или 2):");

                try
                {
                    x = int.Parse(Console.ReadLine());
                    if (x == 1 || x == 2) break;
                    else Console.WriteLine("Введите целое число от 1 или 2");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                }
            }
            switch (x)
            {
                case 1:
                    Cat barsik = new Cat("Барсик");
                    Console.WriteLine(barsik);
                    barsik.Meow();
                    barsik.Meow(3);
                    
                    Console.WriteLine("\n=== Задание 2: Интерфейс и метод для всех мяукающих ===");
                    
                    Cat murzik = new Cat("Мурзик");
                    Cat vaska = new Cat("Васька");
                    MeowableCat barsikAdapter = new MeowableCat(barsik);
                    MeowableCat murzikAdapter = new MeowableCat(murzik);
                    MeowableCat vaskaAdapter = new MeowableCat(vaska);
                    MeowHelper.MakeAllMeow(barsikAdapter, murzikAdapter, vaskaAdapter);
                    Cat cat1 = new Cat("Барсик");
                    Cat cat2 = new Cat("Мурзик");
                    Cat cat3 = new Cat("Васька");
            
                    Console.WriteLine("Передаем котов в метод CountMeowsForCats...");
                    Dictionary<Cat, int> results = MeowHelper.CountMeowsForCats(cat1, cat2, cat3);
                    Console.WriteLine("\nРезультаты:");
                    foreach (KeyValuePair<Cat, int> pair in results)
                    {
                        Console.WriteLine($"{pair.Key.Name} мяукал {pair.Value} раз");
                    }
                    break;
                    
                case 2:
                    Console.WriteLine("=== ДЕМОНСТРАЦИЯ РАБОТЫ С ДРОБЯМИ ===\n");
                    try
                    {
                        Console.WriteLine("1. СОЗДАНИЕ ДРОБЕЙ:");
                        Fraction f1 = new Fraction(1, 3);
                        Fraction f2 = new Fraction(2, 3);
                        Fraction f3 = new Fraction(3, 4);
                        Fraction f4 = new Fraction(-2, 5);
                        Fraction f5 = new Fraction(4, -6);
                        
                        Console.WriteLine($"f1 = {f1}");
                        Console.WriteLine($"f2 = {f2}");
                        Console.WriteLine($"f3 = {f3}");
                        Console.WriteLine($"f4 = {f4}");
                        Console.WriteLine($"f5 = {f5} (автоматическая коррекция знака)\n");
                        
                        Console.WriteLine("2. ПРИМЕРЫ ОПЕРАЦИЙ:");
                        Console.WriteLine(Fraction.FormatOperation(f1, "+", f2));
                        Console.WriteLine(Fraction.FormatOperation(f2, "-", f3));
                        Console.WriteLine(Fraction.FormatOperation(f1, "*", f2));
                        Console.WriteLine(Fraction.FormatOperation(f2, "/", f1));
                        Console.WriteLine(Fraction.FormatOperation(f1, "+", 2));
                        Console.WriteLine(Fraction.FormatOperation(f3, "-", 1));
                        
                        Console.WriteLine("\n3. ЦЕПОЧКА ОПЕРАЦИЙ:");
                        Fraction chainResult = f1.Sum(f2).Div(f3).Minus(5);
                        Console.WriteLine($"f1.Sum(f2).Div(f3).Minus(5) = {chainResult}");
                        Console.WriteLine($"Подробно: ({f1} + {f2}) / {f3} - 5 = {chainResult}\n");
                        
                        Console.WriteLine("4. СРАВНЕНИЕ ДРОБЕЙ:");
                        Fraction f6 = new Fraction(2, 4);
                        Fraction f7 = new Fraction(1, 2);
                        Console.WriteLine($"f6 = {f6}, f7 = {f7}");
                        Console.WriteLine($"f6.Equals(f7): {f6.Equals(f7)}");
                        Console.WriteLine($"f6.GetHashCode(): {f6.GetHashCode()}");
                        Console.WriteLine($"f7.GetHashCode(): {f7.GetHashCode()}");
                        Console.WriteLine($"Хэш-коды равны? {f6.GetHashCode() == f7.GetHashCode()}\n");
                        
                        Console.WriteLine("5. КЛОНИРОВАНИЕ:");
                        Fraction original = new Fraction(3, 5);
                        Fraction clone = (Fraction)original.Clone();
                        Console.WriteLine($"Оригинал: {original}");
                        Console.WriteLine($"Клон: {clone}");
                        Console.WriteLine($"Ссылаются на один объект? {ReferenceEquals(original, clone)}");
                        Console.WriteLine($"Равны по значению? {original.Equals(clone)}");
                        
                        clone.SetNumerator(6);
                        Console.WriteLine($"После изменения клона:");
                        Console.WriteLine($"Оригинал: {original}");
                        Console.WriteLine($"Клон: {clone}\n");
                        Console.WriteLine("6. ОБРАБОТКА ОШИБОК:");
                        try
                        {
                            Fraction error = new Fraction(1, 0);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Создание с нулевым знаменателем: {ex.Message}");
                        }
                        
                        try
                        {
                            Fraction divByZero = f1 / new Fraction(0, 1);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Деление на ноль: {ex.Message}");
                        }
                        
                        Console.WriteLine("\n8. ХЭШ-КОДЫ ДРОБЕЙ:");
                        Fraction[] fractions = {
                            new Fraction(1, 2),
                            new Fraction(2, 4),
                            new Fraction(1, 3),
                            new Fraction(3, 4),
                            new Fraction(2, 3)
                        };
                        
                        foreach (var frac in fractions)
                        {
                            Console.WriteLine($"{frac}, Hash: {frac.GetHashCode()}");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;
            }
        }
        /// <summary>
        /// Выводит базовый интерфейс работы с программой
        /// </summary>
        static void Description()
        {
            Console.WriteLine("1. Работа с заданием 1: 'Интерактивный кот'");
            Console.WriteLine("2. Работа с заданием 2: 'Дроби'");
        }
    }
}