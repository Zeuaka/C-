namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int infinite = 0;
            int x = 0;

            while (infinite == 0)
            {
                Console.WriteLine("Выберите номер задания (Введите одну цифру от 1  до 8):");

                try
                {
                    x = int.Parse(Console.ReadLine());
                    if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6 || x == 7 || x == 8) break;
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
                    Console.WriteLine("Задание 1. Заполнение двумерных массивов");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("Первый массив размерностью (nxm)");
                    Console.WriteLine("(Заполнение массива осуществляется пользователем с клавиатуры):");
                    int n2 = 3, m2 = 4;
                    try
                    {
                        Console.WriteLine("Введите значение n (целое число):");
                        n2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите значение m (целое число):");
                        m2 = int.Parse(Console.ReadLine());
                        Matrix matrix1 = new Matrix(n2, m2);
                        Console.WriteLine(matrix1);
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("Массив создан не будет.");
                    }
                    Console.WriteLine("\nВторой массив размерностью (nxn):");
                    Console.WriteLine("\nЗаполнение осуществляется следующим образом: элементы, лежащие ниже главной диагонали,");
                    Console.WriteLine("являются случайными числами из интервала [-17;36], а лежащие на главной диагонали и выше,");
                    Console.WriteLine("являются случайными числами из интервала [100; 10000].");
                    try
                    {
                        Console.WriteLine("Введите значение n (целое число):");
                        n2 = int.Parse(Console.ReadLine());
                        Matrix matrix2 = new Matrix(n2);
                        Console.WriteLine(matrix2);
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("Массив создан не будет.");
                    }
                    Console.WriteLine("\nТретий массив размерностью (nxn) с особым условием заполнения:");
                    try
                    {
                        Console.WriteLine("Введите значение n (целое число):");
                        n2 = int.Parse(Console.ReadLine());
                        Matrix matrix3 = new Matrix(n2, true);
                        Console.WriteLine(matrix3);
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("Массив создан не будет.");
                    }
                    break;
                case 2:
                        Console.WriteLine("Задание 2. Нахождение уникального максимума в матрице");
                        Console.WriteLine(new string('=', 50));
                        int n3 = 4, m3 = 4, par2 = 0;
                        Console.WriteLine("Выберите способ заполнения матрицы:");
                        Console.WriteLine("1) Заполнение матрицы с клавиатуры");
                        Console.WriteLine("2) Заполнение матрицы по шаблону для матриц, зависящих от одного параметра (со случайными числами)");
                        Console.WriteLine("3) Заполнение матрицы по шаблону для матриц, зависящих от одного параметра (последний шаблон)");
                        while (4 == 4)
                        {

                            try
                            {
                                Console.WriteLine("Введите номер варианта заполнения 1, 2 или 3");
                                par2 = int.Parse(Console.ReadLine());
                                if (par2 == 1 || par2 == 2 || par2 == 3)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Введите 1, 2 или 3");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input");
                            }

                        }
                        switch (par2)
                        {
                        case 1:
                            try
                            {
                                Console.WriteLine("Введите значение n (целое число):");
                                n3 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите значение m (целое число):");
                                m3 = int.Parse(Console.ReadLine());
                                Matrix matrixMax = new Matrix(n3, m3);
                                Console.WriteLine(matrixMax);
                                Console.WriteLine("Максимальный + уникальный элемент матрицы:");
                                Console.WriteLine(matrixMax.FindMaxOne());
                            }
                            catch
                            {
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Массив создан не будет.");
                            }
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Введите значение n (целое число):");
                                n3 = int.Parse(Console.ReadLine());
                                Matrix matrixMax = new Matrix(n3);
                                Console.WriteLine(matrixMax);
                                Console.WriteLine("Максимальный + уникальный элемент матрицы:");
                                Console.WriteLine(matrixMax.FindMaxOne());
                            }
                            catch
                            {
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Массив создан не будет.");
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine("Введите значение n (целое число):");
                                n3 = int.Parse(Console.ReadLine());
                                Matrix matrixMax = new Matrix(n3, true);
                                Console.WriteLine(matrixMax);
                                Console.WriteLine("Максимальный + уникальный элемент матрицы:");
                                Console.WriteLine(matrixMax.FindMaxOne());
                            }
                            catch
                            {
                                Console.WriteLine("Incorrect Input");
                                Console.WriteLine("Массив создан не будет.");
                            }
                            break;
                        case 0:
                            break;
                        }                     
                        break;
                    case 3:
                        Console.WriteLine("Задание 3. Нахождение значения матричного выражения 2*А-З*В*С");
                        Console.WriteLine(new string('=', 50));
                        Console.WriteLine("Для наглядности работа будет осуществляться с матрицами 2 на 2, однако методы класса расчитаны на любой размер матрицы");
                        Console.WriteLine("Заполнение матриц осуществляется с клавиатуры");
                        Matrix A = new Matrix(2, 2);
                        Console.WriteLine(A);
                        Matrix B = new Matrix(2, 2);
                        Console.WriteLine(B);
                        Matrix C = new Matrix(2, 2);
                        Console.WriteLine(C);
                        Matrix result = 2 * A - 3 * B * C;
                        Console.WriteLine("Результат:");
                        Console.WriteLine(result);
                        break;
                    case 4:
                        Console.WriteLine("Задание 4. Бинарные файлы");
                        Console.WriteLine(new string('=', 50));
                        Console.WriteLine("Получить в новом файле те компоненты исходного файла, которые являются четными.");
                        Filer filer = new Filer();
                        Random random = new Random();
                        int[] numbers = new int[10];
                        for (int i = 0; i < 10; i++)
                            numbers[i] = random.Next(10, 100);
                        filer.FillStart(numbers);
                        filer.DisplayBin("task4.bin");
                        filer.FillEnd();
                        filer.DisplayBin("task4End.bin");
                        break;
                case 5:
                        Console.WriteLine("Задание 5. Бинарные файлы и структуры");
                        Console.WriteLine(new string('=', 50));
                        Console.WriteLine("Информация о багаже пассажира описывается массивом, где каждый элемент содержит название ");
                        Console.WriteLine("единицы багажа (чемодан, сумка, коробка и т.д.) и ее массу. Дан файл, содержащий сведения о");
                        Console.WriteLine("багаже нескольких пассажиров. Найти багаж, средняя масса одной единицы багажа, в котором ");
                        Console.WriteLine("отличается не более чем на m кг от общей средней массы одной единицы багажа.");
                        Filer filer1 = new Filer();
                        filer1.CreateData();
                        Console.WriteLine("\nОзнакомиться с содержимым можно в файле luggage_data.xml");
                        Console.WriteLine("Введите разницу веса багажа в сравнении со средним допустимым весом, которую можно считать предельной.");
                        try
                        {
                            double y = double.Parse(Console.ReadLine()); 
                            filer1.FindChampion(y);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input");
                        }
                        
                        break;
                    case 6:
                        Console.WriteLine("Задание 6. Текстовые файлы");
                        Console.WriteLine(new string('=', 50));
                        Console.WriteLine("Количество элементов файла чётно. Определить разность суммы элементов первой и второй половины файла.");
                        string filePath = "half.txt";
                        Filer filer2 = new Filer();
                        try
                        {
                            Console.WriteLine("\n1. Заполнение файла случайными числами:");
                            filer2.FillTextRandom(filePath, 8);
                            filer2.DisplayText(filePath);
                            Console.WriteLine("\n2. Вычисление разности сумм первой и второй половины:");
                            int difference = filer2.HalfDiff(filePath);
                            Console.WriteLine($"Разность суммы элементов первой и второй половины: {difference}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;
                    case 7:
                        Filer filer3 = new Filer();
                        Console.WriteLine("\n2. Вычисление суммы всех элементов:");
                        Console.WriteLine(new string('=', 50));
                        string filePath1 = "sum.txt";
                        try
                        {
                            filer3.FillTextRandom(filePath1, 8);
                            filer3.DisplayText(filePath1);
                            int totalSum = filer3.CalculateSum(filePath1);
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка...");
                        }

                        break;
                    case 8:
                        Filer filer4 = new Filer();
                        Console.WriteLine("ПОИСК САМОЙ КОРОТКОЙ И САМОЙ ДЛИННОЙ СТРОКИ");
                        Console.WriteLine(new string('=', 50));

                        string sourceFile = "strings.txt";
                        string resultFile = "result_strings.txt";

                        try
                        {
                            Console.WriteLine("\n1. Создание тестового файла со строками:");
                            filer4.CreateTest(sourceFile, 10);
                            Console.WriteLine("\n2. Содержимое исходного файла:");
                            filer4.DisplayText(sourceFile);
                            Console.WriteLine("\n3. Поиск самой короткой и длинной строки:");
                            filer4.WriteShortAndLong(sourceFile, resultFile);
                            filer4.DisplayText(resultFile);

                        }
                        catch
                        {
                            Console.WriteLine($"Ошибка...");
                        }
                        break;
                    }


                    }
    }
}
