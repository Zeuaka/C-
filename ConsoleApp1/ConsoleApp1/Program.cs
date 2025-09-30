namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Tools Tool1 = new();
            int infinite = 0;
            int x = 0, y = 0;

            while (infinite == 0)
            {
                Console.WriteLine("Выберите тему задач (Введите одну цифру):");
                Console.WriteLine("1) Методы");
                Console.WriteLine("2) Условия");
                Console.WriteLine("3) Циклы");
                Console.WriteLine("4) Массивы");
                try
                {
                    x = int.Parse(Console.ReadLine());
                    if (x >= 1 && x <= 4) break;
                    else Console.WriteLine("Введите число от 1 до 4");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                }
            }

            while (infinite == 0)
            {
                Console.WriteLine($"Выбранная тема: '{Tool1.GetThemeName(x)}'");
                Console.WriteLine("Выберите номер задания (1, 3, 5, 7 или 9)");
                try
                {
                    y = int.Parse(Console.ReadLine());
                    if (y == 1 || y == 3 || y == 5 || y == 7 || y == 9) break;
                    else Console.WriteLine("Введите допустимый номер задания");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                }
            }

            switch (x)
            {
                case 1:
                    switch (y)
                    {
                        case 1:
                            Console.WriteLine("Метод для возвращения дробной части введенного числа.");
                            Console.WriteLine("Введите число для обработки методом (дробную часть вводите через запятую):");
                            try
                            {
                                double num1 = double.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.fraction(num1).ToString("F3"));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Метод для преобразования символа в соответствующее число.");
                            Console.WriteLine("Введите целое число для обработки методом:");
                            try
                            {
                                char chr1 = char.Parse(Console.ReadLine());
                                int x1 = Tool1.charToNum(chr1);
                                if ((x1 < 10) & (x1 >= 0))
                                {
                                    Console.WriteLine("Результат работы метода:");
                                    Console.WriteLine(x1);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Метод для проверки: двузначное число, или нет.");
                            Console.WriteLine("Введите целое число для обработки методом:");
                            try
                            {
                                int num2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.is2Digits(num2));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Метод для проверки: входит ли введенное пользователем число в желаемый им диапазон.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num3 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите целое число (первую границу диапазона):");
                                int a = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите целое число (вторую границу диапазона):");
                                int b = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.isInRange(a, b, num3));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 9:
                            Console.WriteLine("Метод для проверки: равны ли три числа, введенные пользователем.");
                            try
                            {
                                Console.WriteLine("Введите первое целое число для обработки методом:");
                                int num4 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите второе целое число для обработки методом:");
                                int num5 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите третье целое число для обработки методом:");
                                int num6 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.isEqual(num4, num5, num6));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                    }
                    break;

                case 2:
                    switch (y)
                    {
                        case 1:
                            Console.WriteLine("Метод для получения модуля введенного числа.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num7 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.abs(num7));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Метод для проверки делимости числа на 3 и на 5, но не одновременной делимости.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num8 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.is35(num8));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Метод для поиска максимума среди трех чисел.");
                            try
                            {
                                Console.WriteLine("Введите первое целое число для обработки методом:");
                                int num9 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите второе целое число для обработки методом:");
                                int num10 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите третье целое число для обработки методом:");
                                int num11 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.max3(num9, num10, num11));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Метод для суммирования двух чисел с условием:");
                            Console.WriteLine("Если сумма двух чисел попадает в диапазон от 10 до 19, метод возвращает число 20.");
                            try
                            {
                                Console.WriteLine("Введите первое целое число для обработки методом:");
                                int num12 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите второе целое число для обработки методом:");
                                int num13 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.sum2(num12, num13));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 9:
                            Console.WriteLine("Метод, который по номеру дня недели возвращает его название в текстовом виде.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num14 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.day(num14));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (y)
                    {
                        case 1:
                            Console.WriteLine("Метод, который по введенному числу Х, выводит строку от 0 до Х, включительно.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num15 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.listNums(num15));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Метод, который по введенному числу Х, выводит строку из четных чисел от 0 до Х, включительно.");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num16 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.chet(num16));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Метод, который по выводит количество знаков в записи числа, введенного пользователем");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                long long1 = long.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.numLen(long1));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Метод, который выводит квадрат из смиволов '*'");
                            Console.WriteLine("Длинна сторон этого квадрата задается числом, введенным пользователем с клавиатуры");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num17 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Tool1.square(num17);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 9:
                            Console.WriteLine("Метод, который выводит треугольник из смиволов '*'");
                            Console.WriteLine("у которого X символов в высоту, а количество символов в ряду совпадает с номером строки");
                            Console.WriteLine("при этом треугольник выровнен по правому краю.");
                            Console.WriteLine("Число Х пользователь должен ввести с клавиатуры");
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num18 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Tool1.rightTriangle(num18);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (y)
                    {
                        case 1:
                            Console.WriteLine("Метод, возвращающий индекс числа Х в массиве arr[]");
                            Console.WriteLine("Число Х пользователь должен ввести с клавиатуры");
                            Console.WriteLine("");
                            int[] arr1 = Tool1.choseArr();
                            try
                            {
                                Console.WriteLine("Введите целое число для обработки методом:");
                                int num19 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine(Tool1.findFirst(arr1, num19));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Метод, возвращающий наибольший по модулю элемент массива");
                            Console.WriteLine("");
                            int[] arr2 = Tool1.choseArr();
                            Console.WriteLine(Tool1.maxAbs(arr2));
                            break;
                        case 5:
                            Console.WriteLine("Метод, для добавления массива в другой массив с определенной позиции, указанной пользователем");
                            Console.WriteLine("Массив 1:");
                            int[] arr3 = Tool1.choseArr();
                            Console.WriteLine("");
                            Console.WriteLine("Массив 2:");
                            int[] arr4 = Tool1.choseArr();
                            Console.WriteLine("");
                            try
                            {
                                Console.WriteLine("Введите позицию для вставки массива 2 в массив 1 для обработки методом:");
                                int num20 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Результат работы метода:");
                                Console.WriteLine("Массив, полученный в результате слияния");
                                Tool1.printArr(Tool1.add(arr3, arr4, num20));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Метод, который возвращает массив, реверсивный данному");
                            int[] arr5 = Tool1.choseArr();
                            int[] arr6 = Tool1.reverseBack(arr5);
                            Console.WriteLine("Массив, полученный в результате обратного считывания");
                            Tool1.printArr(arr6);
                            break;
                        case 9:
                            Console.WriteLine("Метод, для нахождения всех вхождений элемента Х в массив");
                            Console.WriteLine("Число Х пользователь должен ввести с клавиатуры");
                            int[] arr7 = Tool1.choseArr();
                            try
                            {
                                Console.WriteLine("Введите элемент Х, для поиска в массиве");
                                int num20 = int.Parse(Console.ReadLine());
                                int[] arr8 = Tool1.findAll(arr7, 3);
                                Tool1.printArr(arr8);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                            break;
                    }
                    break;
            }
        }
    }
}