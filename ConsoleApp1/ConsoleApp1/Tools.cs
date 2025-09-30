namespace ConsoleApp1
{
    class Tools
    {
        public double fraction(double x)
        {
            return x % 1;
        }

        public int charToNum(char x)
        {
            return x - 48;
        }

        public bool is2Digits(int x) => (x > 10 && x < 100);

        public bool isInRange(int a, int b, int num)
        {
            if ((num >= a) && (num <= b))
            {
                return true;
            }
            else if ((num <= a) && (num >= b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isEqual(int a, int b, int c) => (a == b && a == c);

        public int abs(int x)
        {
            if (x > 0)
            {
                return x;
            }
            else
            {
                return x * (-1);
            }
        }

        public bool is35(int x)
        {
            if ((x % 3 + x % 5 != 0) & ((x % 3 == 0) || (x % 5 == 0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int max3(int x, int y, int z)
        {
            if ((x > y) & (x > z))
            {
                return x;
            }

            if (y > z)
            {
                return y;
            }

            return z;
        }

        public int sum2(int x, int y)
        {
            if ((x + y >= 10) && (x + y < 20))
            {
                return 20;
            }
            else
            {
                return x + y;
            }
        }

        public String day(int x)
        {
            string y = "";
            switch (x)
            {
                case 1:
                    y = "Понедельник";
                    break;
                case 2:
                    y = "Вторник";
                    break;
                case 3:
                    y = "Среда";
                    break;
                case 4:
                    y = "Четверг";
                    break;
                case 5:
                    y = "Пятница";
                    break;
                case 6:
                    y = "Суббота!";
                    break;
                case 7:
                    y = "Воскресенье!";
                    break;
                default:
                    y = "Вашему числу/символу не соответствует ни один день недели.";
                    break;
            }

            return y;
        }

        public String listNums(int x)
        {
            string y = "";
            if (x >= 0)
            {
                for (int i = 0; i < x + 1; i++)
                {
                    y += i.ToString() + " ";
                }
            }
            else
            {
                for (int i = 0; i > x - 1; i--)
                {
                    y += i.ToString() + " ";
                }
            }

            return y;
        }

        public String chet(int x)
        {
            string y = "";
            if (x >= 0)
            {
                for (int i = 0; i < x + 1; i += 2)
                {
                    y += i.ToString() + " ";
                }
            }
            else
            {
                for (int i = 0; i > x - 1; i -= 2)
                {
                    y += i.ToString() + " ";
                }
            }

            return y;
        }

        public int numLen(long x)
        {
            int counter = 0;
            if (x < 0)
            {
                x = x * (-1);
            }
            else if (x == 0)
            {
                return 1;
            }

            while (x > 0)
            {
                x /= 10;
                counter += 1;
            }

            return counter;
        }

        public void square(int x)
        {
            if (x < 0)
            {
                Console.WriteLine("Введенное число было отрицательным, квадрат вы не увидите.");
            }

            int i, j;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < x; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        public void rightTriangle(int x)
        {
            if (x < 0)
            {
                Console.WriteLine("Введенное число было отрицательным, треугольник вы не увидите.");
            }

            int s = x;
            int i, j;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < x; j++)
                {
                    if (j >= s - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                s--;
                Console.WriteLine();
            }
        }

        public int[] makeArr(int n, int a, int b)
        {
            int[] arr = new int[n];
            Random random = new Random();
            Console.WriteLine("Полученный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b + 1);
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            return arr;
        }

        public int findFirst(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }

            return -1;
        }

        public int maxAbs(int[] arr)
        {
            int maxarr = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (abs(arr[i]) > abs(maxarr))
                {
                    maxarr = arr[i];
                }
            }

            return maxarr;
        }

        public int[] goodArr(int n, int start)
        {
            int[] arr = new int[n];
            Console.WriteLine("Полученный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = start;
                Console.Write(arr[i] + " ");
                start += 1;
            }

            Console.WriteLine();
            return arr;
        }

        public void printArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        public int[] add(int[] arr, int[] ins, int pos)
        {
            int counter = 0;
            int[] mix = new int[arr.Length + ins.Length];
            for (int i = 0; i < pos; i++)
            {
                mix[counter] = arr[i];
                counter += 1;
            }

            for (int j = 0; j < ins.Length; j++)
            {
                mix[counter] = ins[j];
                counter += 1;
            }

            for (int i = pos; i < arr.Length; i++)
            {
                mix[counter] = arr[i];
                counter += 1;
            }

            return mix;
        }

        public int[] reverseBack(int[] arr)
        {
            int[] arr1 = new int[arr.Length];
            int j = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr1[j] = arr[i];
                j += 1;
            }

            return arr1;
        }

        public int[] keyboardArr(int n)
        {
            int[] arr = new int[n];
            int fails = 0;
            while (fails == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        Console.WriteLine("Введите элемент для заполнения массива:");
                        arr[i] = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка ввода. Необходимо вводить элементы массива построчно, каждый элемент должен быть числом");
                        Console.WriteLine("Попробуйте еще раз...");
                        fails = 1;
                        break;
                    }
                }

                break;
            }

            printArr(arr);
            return arr;
        }

        public int[] findAll(int[] arr, int x)
        {
            int counter = 0;
            int lenght = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    counter += 1;
                }
            }

            int[] newarr = new int[counter];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    newarr[lenght] = i;
                    lenght += 1;
                }
            }

            return newarr;
        }

        public int[] choseArr()
        {
            Console.WriteLine("Выберите способ формирования массива:");
            Console.WriteLine("1: Ввод массива с клавиатуры");
            Console.WriteLine("2: Генерация массива из случайных чисел");
            Console.WriteLine("3: Генерация массива из чисел от 1 до n");
            Console.WriteLine("Введите число (1, 2 или 3)");
            int infi = 0;
            int i = 0;
            int[] stop = new int[1];
            while (infi == 0)
            {
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if (i == 1 || i == 2 || i == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите число 1, 2 или 3");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                }
            }

            switch (i)
            {
                case 1:
                    Console.WriteLine("Ввод массива с клавиатуры...");
                    Console.WriteLine("Введите размерность массива:");
                    try
                    {
                        int n = int.Parse(Console.ReadLine());
                        return keyboardArr(n);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Incorrect Input");
                    }

                    break;
                case 2:
                    Console.WriteLine("Генерация массива из случайных чисел...");
                    Console.WriteLine("Введите размерность массива:");
                    try
                    {
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите меньшую границу диапазона случайных чисел");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите большую границу диапазона случайных чисел");
                        int b = int.Parse(Console.ReadLine());
                        int[] arrMake = makeArr(n, a, b);
                        Console.WriteLine("Массив успешно сгенерирован!");
                        return arrMake;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Incorrect Input");
                    }

                    break;
                case 3:
                    Console.WriteLine("Генерация массива из чисел от 1 до n...");
                    Console.WriteLine("Введите размерность массива:");
                    try
                    {
                        int n = int.Parse(Console.ReadLine());
                        return goodArr(n, 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Incorrect Input");
                    }

                    break;
            }

            return stop;
        }

        public string GetThemeName(int themeNumber)
        {
            return themeNumber switch
            {
                1 => "Методы",
                2 => "Условия",
                3 => "Циклы",
                4 => "Массивы",
                _ => "Неизвестная тема"
            };
        }
    }
}