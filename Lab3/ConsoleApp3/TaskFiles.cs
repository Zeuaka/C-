using System;
using System.IO;
using System.Xml.Serialization;

namespace Lab3
{
    [Serializable]
    public class LuggageItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        
        public LuggageItem() { }
        
        public LuggageItem(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }

    [Serializable]
    public class PassengerLuggage
    {
        public string PassengerName { get; set; }
        public LuggageItem[] Items { get; set; }
        
        public PassengerLuggage()
        {
            Items = new LuggageItem[0];
        }
        
        public PassengerLuggage(string name)
        {
            Items = new LuggageItem[0];
            PassengerName = name;
        }
        
        public double GetAverageWeight()
        {
            if (Items.Length == 0) return 0;
            
            double totalWeight = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                totalWeight += Items[i].Weight;
            }
            return totalWeight / Items.Length;
        }
    }

    [Serializable]
    public class LuggageData
    {
        public PassengerLuggage[] Passengers { get; set; }
        
        public LuggageData()
        {
            Passengers = new PassengerLuggage[0];
        }
    }

    public class Filer
    {
        BinaryWriter _binaryWriter1;
        BinaryWriter _binaryWriter2;
        
        public Filer()
        {
            try
            {
                _binaryWriter1 = new BinaryWriter(File.Open("task4.bin", FileMode.Create));
                _binaryWriter2 = new BinaryWriter(File.Open("task4End.bin", FileMode.Create));
            }
            catch
            {
                Console.WriteLine("Ошибка открытия файла");
                return;
            }
        }
        
        public void FillStart(int[] numbers)
        {
            try
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    _binaryWriter1.Write(numbers[i]);
                }
                _binaryWriter1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка записи");
            }
        }

        public void FillEnd()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open("task4.bin", FileMode.Open)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32();

                        if (number % 2 == 0)
                        {
                            _binaryWriter2.Write(number);
                        }
                    }
                }

                _binaryWriter2.Close();
                Console.WriteLine("Четные числа записаны в файл task4End.bin");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка файла");
            }
        }
        public void DisplayBin(string filename)
        {
            try
            {
                Console.WriteLine($"\nСодержимое бинарного файла {filename}:");

                using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    int position = 0;
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32();
                        Console.WriteLine($"[{position}] {number}");
                        position++;
                    }
                    Console.WriteLine($"Всего элементов: {position}");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка чтения бинарного файла");
            }
        }
        public void CreateData()
        {
            LuggageData luggageData = new LuggageData();

            luggageData.Passengers = new PassengerLuggage[3];

            luggageData.Passengers[0] = new PassengerLuggage("Иванов");
            luggageData.Passengers[0].Items = new LuggageItem[3];
            luggageData.Passengers[0].Items[0] = new LuggageItem("Чемодан", 15.5);
            luggageData.Passengers[0].Items[1] = new LuggageItem("Рюкзак", 3.2);
            luggageData.Passengers[0].Items[2] = new LuggageItem("Сумка", 4.1);

            luggageData.Passengers[1] = new PassengerLuggage("Петров");
            luggageData.Passengers[1].Items = new LuggageItem[2];
            luggageData.Passengers[1].Items[0] = new LuggageItem("Чемодан", 12.8);
            luggageData.Passengers[1].Items[1] = new LuggageItem("Коробка", 6.7);

            luggageData.Passengers[2] = new PassengerLuggage("Сидоров");
            luggageData.Passengers[2].Items = new LuggageItem[3];
            luggageData.Passengers[2].Items[0] = new LuggageItem("Рюкзак", 5.3);
            luggageData.Passengers[2].Items[1] = new LuggageItem("Сумка", 2.9);
            luggageData.Passengers[2].Items[2] = new LuggageItem("Пакет", 1.2);
            SaveXml(luggageData, "luggage_data.xml");
        }
        public void SaveXml(LuggageData luggageData, string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LuggageData));
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, luggageData);
                }
                Console.WriteLine($"Данные сохранены в {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения XML: {ex.Message}");
            }
        }
        public LuggageData LoadXml(string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LuggageData));
                using (StreamReader reader = new StreamReader(filename))
                {
                    return (LuggageData)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки XML: {ex.Message}");
                return new LuggageData();
            }
        }
        public void FindChampion(double maxDifference)
        {
            try
            {
                LuggageData luggageData = LoadXml("luggage_data.xml");
                
                if (luggageData.Passengers.Length == 0)
                {
                    Console.WriteLine("Нет данных о багаже");
                    return;
                }
                double totalWeight = 0;
                int totalItems = 0;
                
                for (int i = 0; i < luggageData.Passengers.Length; i++)
                {
                    for (int j = 0; j < luggageData.Passengers[i].Items.Length; j++)
                    {
                        totalWeight += luggageData.Passengers[i].Items[j].Weight;
                        totalItems++;
                    }
                }
                
                if (totalItems == 0)
                {
                    Console.WriteLine("Нет данных о весе багажа");
                    return;
                }
                
                double overallAverage = totalWeight / totalItems;
                Console.WriteLine($"Общая средняя масса единицы багажа: {overallAverage} кг");
                Console.WriteLine($"\nБагаж со средней массой в пределах ±{maxDifference} кг от общей средней:");
                bool found = false;
                
                for (int i = 0; i < luggageData.Passengers.Length; i++)
                {
                    double passengerAverage = luggageData.Passengers[i].GetAverageWeight();
                    double difference = Math.Abs(passengerAverage - overallAverage);
                    
                    if (difference <= maxDifference)
                    {
                        Console.WriteLine($"Пассажир: {luggageData.Passengers[i].PassengerName}");
                        Console.WriteLine($"Средняя масса: {passengerAverage:F2} кг");
                        Console.WriteLine($"Отличие от общей: {difference:F2} кг");
                        Console.WriteLine("Единицы багажа:");
                        
                        for (int j = 0; j < luggageData.Passengers[i].Items.Length; j++)
                        {
                            Console.WriteLine($"  - {luggageData.Passengers[i].Items[j].Name}: {luggageData.Passengers[i].Items[j].Weight} кг");
                        }
                        Console.WriteLine();
                        found = true;
                    }
                }
                
                if (!found)
                {
                    Console.WriteLine("Не найден багаж, удовлетворяющий условию");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки багажа: {ex.Message}");
            }
        }

        public void CreateKeyboard()
        {
            Console.Write("Введите количество пассажиров: ");
            int passengerCount = int.Parse(Console.ReadLine());

            LuggageData luggageData = new LuggageData();
            luggageData.Passengers = new PassengerLuggage[passengerCount];

            for (int i = 0; i < passengerCount; i++)
            {
                Console.Write($"Введите имя пассажира {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Введите количество единиц багажа для {name}: ");
                int itemCount = int.Parse(Console.ReadLine());

                luggageData.Passengers[i] = new PassengerLuggage(name);
                luggageData.Passengers[i].Items = new LuggageItem[itemCount];

                for (int j = 0; j < itemCount; j++)
                {
                    Console.Write($"  Название единицы багажа {j + 1}: ");
                    string itemName = Console.ReadLine();

                    Console.Write($"  Масса {itemName}: ");
                    double weight = double.Parse(Console.ReadLine());

                    luggageData.Passengers[i].Items[j] = new LuggageItem(itemName, weight);
                }
            }

            SaveXml(luggageData, "custom_luggage.xml");
        }
        
        public void FillTextRandom(string filePath, int count)
        {
            if (count % 2 != 0)
            {
                throw new ArgumentException("Количество элементов должно быть чётным");
            }
            
            try
            {
                Random random = new Random();
                string[] numbers = new string[count];
                
                for (int i = 0; i < count; i++)
                {
                    numbers[i] = random.Next(-100, 101).ToString();
                }
                
                File.WriteAllLines(filePath, numbers);
                Console.WriteLine($"Файл {filePath} заполнен {count} случайными числами");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при заполнении файла: {ex.Message}");
            }
        }
        
        public int HalfDiff(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length % 2 != 0)
                {
                    throw new InvalidOperationException("Количество элементов в файле должно быть чётным");
                }               
                int half = lines.Length / 2;                
                int firstHalfSum = 0;
                for (int i = 0; i < half; i++)
                {
                    if (int.TryParse(lines[i], out int number))
                    {
                        firstHalfSum += number;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка преобразования строки '{lines[i]}' в число");
                    }
                }                
                int secondHalfSum = 0;
                for (int i = half; i < lines.Length; i++)
                {
                    if (int.TryParse(lines[i], out int number))
                    {
                        secondHalfSum += number;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка преобразования строки '{lines[i]}' в число");
                    }
                }
                
                Console.WriteLine($"Сумма первой половины: {firstHalfSum}");
                Console.WriteLine($"Сумма второй половины: {secondHalfSum}");
                
                return firstHalfSum - secondHalfSum;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении разности: {ex.Message}");
                return 0;
            }
        }
        
        public int CalculateSum(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int totalSum = 0;
                
                for (int i = 0; i < lines.Length; i++)
                {
                    if (int.TryParse(lines[i], out int number))
                    {
                        totalSum += number;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка преобразования строки '{lines[i]}' в число");
                    }
                }
                
                Console.WriteLine($"Сумма всех элементов файла: {totalSum}");
                return totalSum;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении суммы: {ex.Message}");
                return 0;
            }
        }
        
        public void DisplayText(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл {filePath} не существует");
                    return;
                }
                
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($"\nСодержимое файла {filePath} ({lines.Length} элементов):");
                
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"[{i}] {lines[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }
        public void WriteShortAndLong(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    Console.WriteLine($"Исходный файл {sourceFilePath} не существует");
                    return;
                }

                string[] lines = File.ReadAllLines(sourceFilePath);
                
                if (lines.Length == 0)
                {
                    Console.WriteLine("Исходный файл пуст");
                    return;
                }
                string shortestLine = lines[0];
                string longestLine = lines[0];

                for (int i = 1; i < lines.Length; i++)
                {
                    if (lines[i].Length < shortestLine.Length)
                    {
                        shortestLine = lines[i];
                    }
                    
                    if (lines[i].Length > longestLine.Length)
                    {
                        longestLine = lines[i];
                    }
                }
                string[] resultLines = {
                    $"Самая короткая строка (длина {shortestLine.Length}): {shortestLine}",
                    $"Самая длинная строка (длина {longestLine.Length}): {longestLine}"
                };

                File.WriteAllLines(destinationFilePath, resultLines);
                
                Console.WriteLine($"Результаты записаны в файл {destinationFilePath}");
                Console.WriteLine($"Самая короткая строка: '{shortestLine}' (длина: {shortestLine.Length})");
                Console.WriteLine($"Самая длинная строка: '{longestLine}' (длина: {longestLine.Length})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
            }
        }
        public void CreateTest(string filePath, int lineCount)
        {
            try
            {
                string[] testStrings = {
                    "ААААААААА",
                    "ББББББББББББББББББББББББББББ",
                    "ВВВВВВВВВВВВВ",
                    "ГГГГГГГГГГГГГГГ",
                    "ДДДДДДД",
                    "ЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕ",
                    "ЁЁЁЁЁ",
                    "ЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖЖ",
                    "ЗЗЗ",
                    "ИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИ"
                };

                Random random = new Random();
                string[] lines = new string[lineCount];

                for (int i = 0; i < lineCount; i++)
                {
                    lines[i] = testStrings[random.Next(testStrings.Length)];
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Тестовый файл {filePath} создан с {lineCount} строками");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании тестового файла: {ex.Message}");
            }
        }
    }
}