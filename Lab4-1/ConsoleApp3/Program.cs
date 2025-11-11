class Program
{
    static void Main(string[] args)
    {
        int infinite = 0;
            int x = 0;

            while (infinite == 0)
            {
                Console.WriteLine("Выберите номер задания (Введите одну цифру от 1  до 5):");

                try
                {
                    x = int.Parse(Console.ReadLine());
                    if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5) break;
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
                Console.WriteLine("=== Задание 1 ===");
                List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 2, 5 };
                Console.WriteLine("До удаления: " + string.Join(", ", numbers));
                List<object> objectList = new List<object>();
                foreach (int num in numbers)
                {
                    objectList.Add(num);
                }
                objectList = TaskSolver.RemoveAllElements(objectList, 2);
                Console.WriteLine("После удаления двоек: " + string.Join(" ", objectList));
                break;
            case 2:
                LinkedList<object> mixedList = new LinkedList<object>();
                mixedList.AddLast(1);
                mixedList.AddLast("Сергей");
                mixedList.AddLast(3.14);
                mixedList.AddLast(true);
                mixedList.AddLast(DateTime.Now);
                Console.WriteLine("Исходный список: " + string.Join(", ", mixedList));
                Console.WriteLine("Список в обратном порядке:");
                TaskSolver.PrintReverse(mixedList);
                break;
            case 3:
                Console.WriteLine("\n=== Задание 3 ===");
                var purchases = new Dictionary<string, HashSet<string>>
                {
                    { "Школа №1", new HashSet<string> { "Фирма А", "Фирма Б", "Фирма В" } },
                    { "Школа №2", new HashSet<string> { "Фирма Б", "Фирма Г" } },
                    { "Школа №3", new HashSet<string> { "Фирма А", "Фирма Б" } }
                };
                var allFirms = new HashSet<string> { "Фирма А", "Фирма Б", "Фирма В", "Фирма Г", "Фирма Д", "Фирма Е" };

                TaskSolver.AnalyzePurchases(purchases, allFirms);
                break;
            case 4:
                Console.WriteLine("\n=== Задание 4 ===");
                string testFilePath = "test_text.txt";
                TaskSolver.CreateTextFile(testFilePath);
                TaskSolver.PrintVoicedConsonants(testFilePath);
                break;
            case 5:
                Console.WriteLine("\n=== Задание 5 ===");
                TaskSolver.DemonstrateLoginGeneration();
                break;
        }
    }
}
