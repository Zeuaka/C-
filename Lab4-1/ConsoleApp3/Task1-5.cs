using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class TaskSolver
{
    // Задание 1:
    public static List<object> RemoveAllElements(List<object> list, object elementToRemove)
    {
        if (list == null)
        {
            Console.WriteLine("Ошибка: список не может быть null");
            return new List<object>();
        }
        
        List<object> result = new List<object>();
        
        for (int i = 0; i < list.Count; i++)
        {
            if (!Equals(list[i], elementToRemove))
            {
                result.Add(list[i]);
            }
        }
        
        return result;
    }

    // Задание 2:
    public static void PrintReverse(LinkedList<object> list)
    {
        if (list == null)
        {
            Console.WriteLine("Ошибка: список не может быть null");
            return;
        }
        
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        
        LinkedListNode<object> current = list.Last;

        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Previous;

        }
        Console.WriteLine();
    }

    // Задание 3: 
    public static void AnalyzePurchases(Dictionary<string, HashSet<string>> institutionsPurchases, HashSet<string> allFirms)
    {
        if (institutionsPurchases == null || allFirms == null)
        {
            Console.WriteLine("Ошибка: данные о закупках и список фирм не могут быть null");
            return;
        }

        if (institutionsPurchases.Count == 0)
        {
            Console.WriteLine("Нет данных о закупках");
            return;
        }

        HashSet<string> commonFirms = new HashSet<string>(allFirms);
        foreach (HashSet<string> firms in institutionsPurchases.Values)
        {
            commonFirms.IntersectWith(firms);
        }

        Console.WriteLine("1) Фирмы, где закупка производилась каждым из заведений:");
        if (commonFirms.Count == 0)
        {
            Console.WriteLine("   - Нет таких фирм");
        }
        else
        {
            foreach (string firm in commonFirms)
            {
                Console.WriteLine($"   - {firm}");
            }
        }

        HashSet<string> atLeastOneFirms = new HashSet<string>();
        foreach (HashSet<string> firms in institutionsPurchases.Values)
        {
            atLeastOneFirms.UnionWith(firms);
        }

        Console.WriteLine("\n2) Фирмы, где закупка производилась хотя бы одним из заведений:");
        if (atLeastOneFirms.Count == 0)
        {
            Console.WriteLine("   - Нет таких фирм");
        }
        else
        {
            foreach (string firm in atLeastOneFirms)
            {
                Console.WriteLine($"   - {firm}");
            }
        }
        HashSet<string> noPurchaseFirms = new HashSet<string>(allFirms);
        noPurchaseFirms.ExceptWith(atLeastOneFirms);

        Console.WriteLine("\n3) Фирмы, где ни одно из заведений не закупало компьютеры:");
        if (noPurchaseFirms.Count == 0)
        {
            Console.WriteLine("   - Нет таких фирм");
        }
        else
        {
            foreach (string firm in noPurchaseFirms)
            {
                Console.WriteLine($"   - {firm}");
            }
        }
    }
    // Задание 4: 
    public static void CreateTextFile(string filePath)
    {
        string sampleText = @"Щербина! Сергей,    Александрович...";
        File.WriteAllText(filePath, sampleText, Encoding.UTF8);
        Console.WriteLine($"Файл {filePath} успешно создан с примером текста.");
    }
    public static void PrintVoicedConsonants(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл {filePath} не найден");
            
        string text = File.ReadAllText(filePath, Encoding.UTF8);
        HashSet<char> voicedConsonants = GetVoicedConsonants();
        HashSet<char> foundConsonants = new HashSet<char>();
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            foreach (char c in word.ToLower())
            {
                if (voicedConsonants.Contains(c))
                {
                    foundConsonants.Add(c);
                }
            }
        }
        List<char> sortedConsonants = new List<char>(foundConsonants);
        sortedConsonants.Sort();      
        Console.WriteLine("Звонкие согласные буквы, которые входят хотя бы в одно слово:");
        foreach (char consonant in sortedConsonants)
        {
            Console.WriteLine(consonant);
        }
    }
    private static HashSet<char> GetVoicedConsonants()
    {
        return new HashSet<char>
        {
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р'
        };
    }
    // Задание 5: 
   public static void CreateStudentsFile(string filePath)
    {
        string[] students = {
            "Иванова Мария",
            "Петров Сергей",
            "Бойцова Екатерина",
            "Петров Иван",
            "Иванова Наташа"
        };
        
        File.WriteAllLines(filePath, students);
        Console.WriteLine($"Файл {filePath} успешно создан с {students.Length} записями.");
    }

    public static string[] ReadStudentsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден!");
            return new string[0];
        }
        
        return File.ReadAllLines(filePath);
    }

    public static Dictionary<string, string> GenerateLogins(string[] students)
    {
        Dictionary<string, string> logins = new Dictionary<string, string>();
        if (students == null)
            return logins;
                    
        Dictionary<string, int> surnameCount = new Dictionary<string, int>();
                
        foreach (string student in students)
        {
            string[] parts = student.Split(' ');
            if (parts.Length < 2)
                continue;
                        
            string surname = parts[0].Trim();
            if (!surnameCount.ContainsKey(surname))
            {
                surnameCount[surname] = 1;
            }
            else
            {
                surnameCount[surname]++;
            }
                    
            string login;
            if (surnameCount[surname] == 1)
            {
                login = surname;
            }
            else
            {
                login = $"{surname}{surnameCount[surname]}";
            }
            logins[student] = login;
        }
                
        return logins;
    }

    public static void DemonstrateLoginGeneration()
    {
        string filePath = "students.txt";
        CreateStudentsFile(filePath);
        string[] students = ReadStudentsFromFile(filePath);
        
        if (students.Length == 0)
        {
            Console.WriteLine("Нет данных для обработки.");
            return;
        }
        var logins = GenerateLogins(students);

        Console.WriteLine("Сгенерированные логины:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student} -> {logins[student]}");
        }
        SaveLoginsToFile(logins, "logins.txt");
    }

    public static void SaveLoginsToFile(Dictionary<string, string> logins, string outputFilePath)
    {
        var lines = logins.Select(kvp => $"{kvp.Key} -> {kvp.Value}");
        File.WriteAllLines(outputFilePath, lines);
        Console.WriteLine($"Результаты сохранены в файл: {outputFilePath}");
    }
    
}