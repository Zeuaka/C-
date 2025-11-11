using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== ТЕСТИРОВАНИЕ КЛАССА TIME ===\n");
        int infinite = 0;
            int x = 0;

        while (infinite == 0)
        {
            Console.WriteLine("Выберите номер задания (Введите одну цифру от 1  до 5):");
            Console.WriteLine("1) Проверка конструкторов:");
            Console.WriteLine("2) Проверка унарных операторов:");
            Console.WriteLine("3) Проверка бинарных операций:");
            Console.WriteLine("4) Проверка операторов приведения:");
            try
            {
                x = int.Parse(Console.ReadLine());
                if (x == 1 || x == 2 || x == 3 || x == 4) break;
                else Console.WriteLine("Введите целое число от 1 до 8");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incorrect Input");
            }
        }
        switch (x)
        {
            case 1:
                Console.WriteLine("1. ТЕСТИРОВАНИЕ КОНСТРУКТОРОВ:");
                Time time1 = new Time();
                Console.WriteLine($"Конструктор по умолчанию: {time1}");
                Time time2 = new Time(14, 30);
                Console.WriteLine($"Конструктор с параметрами (14, 30): {time2}");
                try
                {
                    Time time3 = new Time(25, 0);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка при создании времени (25, 0): {ex.Message}");
                }
                try
                {
                    Time time4 = new Time(12, 70);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка при создании времени (12, 70): {ex.Message}");
                }
                
                Console.WriteLine();
                break;
            case 2:
                Console.WriteLine("2. ТЕСТИРОВАНИЕ УНАРНЫХ ОПЕРАТОРОВ:");
                Time time5 = new Time(10, 30);
                Console.WriteLine($"Исходное время: {time5}");
                time5++;
                Console.WriteLine($"После ++: {time5}");
                Time time6 = new Time(10, 0);
                Console.WriteLine($"Исходное время: {time6}");
                time6--;
                Console.WriteLine($"После --: {time6}");
                Console.WriteLine();
                break;
            case 3:
                Console.WriteLine("3. ТЕСТИРОВАНИЕ БИНАРНЫХ ОПЕРАТОРОВ:");
                Time time = new Time(10, 30);
                Console.WriteLine($"Исходное время: {time}");
                Time result1 = time + 45;
                Console.WriteLine($"time + 45 = {result1}");
                Time result2 = 120 + time;
                Console.WriteLine($"120 + time = {result2}");
                Time result3 = time - 30;
                Console.WriteLine($"time - 30 = {result3}");
                Time result4 = 600 - time;
                Console.WriteLine($"600 - time = {result4}");
                Console.WriteLine();
                break;
            case 4:
                Console.WriteLine("4. ТЕСТИРОВАНИЕ ОПЕРАТОРОВ ПРИВЕДЕНИЯ:");
                Time time7 = new Time(14, 45);
                byte hours = (byte)time7;
                Console.WriteLine($"Время: {time7}, byte (часы): {hours}");
                Time time8 = new Time(0, 0);
                Time time9 = new Time(0, 1);
                Time time10 = new Time(1, 0);
                Console.WriteLine($"Время {time8} -> bool: {(bool)time8}");
                Console.WriteLine($"Время {time9} -> bool: {(bool)time9}");
                Console.WriteLine($"Время {time10} -> bool: {(bool)time10}");
                Console.WriteLine("\nИспользование в условиях:");
                if (time8)
                    Console.WriteLine($"{time8} - считается истиной");
                else
                    Console.WriteLine($"{time8} - считается ложью");
                    
                if (time9)
                    Console.WriteLine($"{time9} - считается истиной");
                else
                    Console.WriteLine($"{time9} - считается ложью");
                Console.WriteLine();
                break;
        }
    }  
}
