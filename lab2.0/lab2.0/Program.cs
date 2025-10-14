using ClassWork;

namespace Lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        int infinite = 0;
        int x = 0, y = 0;

        while (infinite == 0)
        {
            Console.WriteLine("Выберите номер задания (Введите одну цифру от 1  до 5):");

            try
            {
                x = int.Parse(Console.ReadLine());
                if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5) break;
                else Console.WriteLine("Введите целое число от 1 до 5");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incorrect Input");
            }
        }
        if (x == 1)
        {
            while (infinite == 0)
            {
                Console.WriteLine("Выбранный номер задания: 1");
                Console.WriteLine("Выберите номер задачи в первом задании.");
                Console.WriteLine("Введите 1 или 3");
                try
                {
                    y = int.Parse(Console.ReadLine());
                    if (y == 1 || y == 3) break;
                    else Console.WriteLine("Введите допустимый номер задания");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                }
            }
        }
        switch (x)
        {
            case 1:
                switch (y)
                {
                    case 1:
                        Console.WriteLine("Задача про создание точки с координатами x и y");
                        Console.WriteLine("По условию задачи нам необходимо создать 3 точки разными способами");
                        Console.WriteLine("1-й способ задать точку - задать ее без параметров, в таком случае точке будут присвоены");
                        Console.WriteLine("случайно сгенерированные значения координат");
                        MyPoint point1 = new MyPoint();
                        Console.WriteLine("Координаты первой точки:");
                        Console.WriteLine(point1);
                        Console.WriteLine("Теперь зададим 2-ю точку. Введите поочередно координаты точки по оси Ох и Оу");
                        try
                        {
                            Console.WriteLine("Координата точки по оси Ох:");
                            float xAx = float.Parse(Console.ReadLine());
                            Console.WriteLine("Координата точки по оси Оу:");
                            float yAx = float.Parse(Console.ReadLine());
                            MyPoint point2 = new MyPoint(xAx, yAx);
                            Console.WriteLine("Координаты второй точки:");
                            Console.WriteLine(point2);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Incorrect Input");
                            break;
                        }
                        Console.WriteLine("Теперь зададим 3-ю точку с произвольными координатами.");
                        Console.WriteLine("Пусть координата Ох будет равна 3, а координата Оу задаим числом 4");
                        MyPoint point3 = new MyPoint(3, 4);
                        Console.WriteLine(point3);
                        break;
                    case 3:
                        Console.WriteLine("Задача про создание сущности Имя с тремя параметрами");
                        Console.WriteLine("По условию задачи нам необходимо создать 3 ФИО с различной степенью заполненности:");
                        Console.WriteLine("Примеры: Клеопатра (только имя), Маяковский Владимир (фамилия и имя), Пушкин Александр Сергеевич (полное ФИО)");

                        Name name1 = null;
                        Name name2 = null;
                        Name name3 = null;

                        Console.WriteLine("Ввод 1-ого ФИО:");
                        name1 = Name.CreateFromInput();
                        if (name1 != null)
                        {
                            Console.WriteLine("ФИО успешно зарегистрировано");
                            Console.WriteLine(name1.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Не удалось создать ФИО из-за ошибок ввода");
                        }

                        Console.WriteLine("Ввод 2-ого ФИО:");
                        name2 = Name.CreateFromInput();
                        if (name2 != null)
                        {
                            Console.WriteLine("ФИО успешно зарегистрировано");
                            Console.WriteLine(name2.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Не удалось создать ФИО из-за ошибок ввода");
                        }

                        Console.WriteLine("Ввод 3-ого ФИО:");
                        name3 = Name.CreateFromInput();
                        if (name3 != null)
                        {
                            Console.WriteLine("ФИО успешно зарегистрировано");
                            Console.WriteLine(name3.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Не удалось создать ФИО из-за ошибок ввода");
                        }
                        Console.WriteLine("\n Совокупность всех введенных ФИО");
                        Console.WriteLine(name1);
                        Console.WriteLine(name2);
                        Console.WriteLine(name3);
                        break;

                }
                break;
            case 2:
                Console.WriteLine("Задача про создание сущности Линия, которая описывается:");
                Console.WriteLine("Координата начала: Точка");
                Console.WriteLine("Координата конца: Точка");
                Console.WriteLine("Может возвращать текстовое представление вида “Линия от {X1;Y1} до {X2;Y2}”");
                Console.WriteLine("Для указания координат нужно использовать сущность Точка, разработанную в задании 1.1.");
                Console.WriteLine("Необходимо создать линии с текущими значениями:");
                Console.WriteLine("Линия 1 с началом в т. {1;3} и концом в т.{23;8}.");
                Console.WriteLine("Линия 2, горизонтальная, на высоте 10, от точки 5 до точки 25.");
                Console.WriteLine("Линия 3, которая начинается всегда там же, где начинается линия 1, и заканчивается всегда там");
                Console.WriteLine("же, где заканчивается линия 2. Таким образом, если положение первой или второй линии");
                Console.WriteLine("меняется, то меняется и третья линия.");
                Console.WriteLine("");
                Console.WriteLine("Первая линия:");
                try
                {
                    Console.WriteLine("Координата точки начала по оси Ох:");
                    float xAx1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Координата точки начала по оси Оу:");
                    float yAx1 = float.Parse(Console.ReadLine());
                    MyPoint start1 = new MyPoint(xAx1, yAx1);
                    Console.WriteLine("Координата точки конца по оси Ох:");
                    float xAx2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Координата точки конца по оси Оу:");
                    float yAx2 = float.Parse(Console.ReadLine());
                    MyPoint end1 = new MyPoint(xAx2, yAx2);
                    MyLine line1 = new MyLine(start1, end1);
                    Console.WriteLine(line1);

                    Console.WriteLine("Вторая линия (горизонтальная на высоте 10):");
                    Console.WriteLine("Начало по оси Ох:");
                    float startX2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Конец по оси Ох:");
                    float endX2 = float.Parse(Console.ReadLine());
                    MyPoint start2 = new MyPoint(startX2, 10);
                    MyPoint end2 = new MyPoint(endX2, 10);
                    MyLine line2 = new MyLine(start2, end2);
                    Console.WriteLine(line2);
                    Console.WriteLine("Третья линия (зависит от начала первой и конца второй):");
                    MyLine line3 = new MyLine(start1, end2);
                    Console.WriteLine(line3);
                    
                    
                    string inf = "0";
                    while (inf == "0")
                    {
                        try
                        {
                            Console.WriteLine("Замена координаты начала первой линии:");
                            Console.WriteLine("Координата точки начала по оси Ох:");
                            float n = float.Parse(Console.ReadLine());
                            Console.WriteLine("Координата точки начала по оси Оу:");
                            float m = float.Parse(Console.ReadLine());
                            start1.XAxis = n;
                            start1.YAxis = m;
                            Console.WriteLine("Замена координаты конца второй линии:");
                            Console.WriteLine("Координата точки конца по оси Ох:");
                            float n1 = float.Parse(Console.ReadLine());
                            Console.WriteLine("Координата точки конца по оси Оу:");
                            float m1 = float.Parse(Console.ReadLine());
                            end2.XAxis = n1;
                            end2.YAxis = m1;
                            Console.WriteLine("Отображение изменений координат третьей линии ");
                            Console.WriteLine(line3);
                            Console.WriteLine("Хотите продолжить менять координаты линий 1 и 2? Введите 0...");
                            inf = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Incorrect Input");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Input");
                    break;
                }
                
                break;
            case 3:
                Console.WriteLine("Задача про создание сущности Город, которая будет представлять собой точку на карте:");
                Console.WriteLine("Создана готовая схема из 6 городов с дорогами между ними.");
    
                City cityA = new City("A");
                City cityB = new City("B");
                City cityC = new City("C");
                City cityD = new City("D");
                City cityE = new City("E");
                City cityF = new City("F");
    
                cityA.AddRoad(cityB, 5);
                cityA.AddRoad(cityF, 1);
                cityA.AddRoad(cityD, 6);

                cityB.AddRoad(cityA, 5);
                cityB.AddRoad(cityC, 3);

                cityC.AddRoad(cityB, 3);
                cityC.AddRoad(cityD, 4);

                cityD.AddRoad(cityC, 4);
                cityD.AddRoad(cityE, 2);
                cityD.AddRoad(cityA, 6);

                cityE.AddRoad(cityF, 2);

                cityF.AddRoad(cityE, 2);
                cityF.AddRoad(cityB, 1);
    
                Console.WriteLine("Готовая схема городов создана!");
                
                bool exit1 = false;
                Console.WriteLine("Вы можете проверить связи городов:");
                Console.WriteLine("1) Проверить связи города A");
                Console.WriteLine("2) Проверить связи города B");
                Console.WriteLine("3) Проверить связи города C");
                Console.WriteLine("4) Проверить связи города D");
                Console.WriteLine("5) Проверить связи города E");
                Console.WriteLine("6) Проверить связи города F");
                
                while (!exit1)
                {
                    Console.WriteLine("Введите число от 1 до 6:");
                    try
                    {
                        int par = int.Parse(Console.ReadLine());
                        
                        if (par >= 1 && par <= 6)
                        {
                            switch (par)
                            {
                                case 1:
                                    Console.WriteLine(cityA);
                                    exit1 = true;
                                    break;
                                case 2:
                                    Console.WriteLine(cityB);
                                    exit1 = true;
                                    break;
                                case 3:
                                    Console.WriteLine(cityC);
                                    exit1 = true;
                                    break;
                                case 4:
                                    Console.WriteLine(cityD);
                                    exit1 = true;
                                    break;
                                case 5:
                                    Console.WriteLine(cityE);
                                    exit1 = true;
                                    break;
                                case 6:
                                    Console.WriteLine(cityF);
                                    exit1 = true;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введено неверное число!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Incorrect Input");
                    }
                }
                break;
            case 4:
                Console.WriteLine("Задача 'Создаем города'.");
                Console.WriteLine("Ключевой смысл задачи состоит в расширении функционала сущности.");
                Console.WriteLine("Теперь город можно задать с помощью:");
                Console.WriteLine("Названия города");
                Console.WriteLine("Набора связанных с ним городов и стоимостей путей к ним");
                Console.WriteLine("Проверим работу обновленного метода...");
                Console.WriteLine("Создадим три города А1 В1 и С1 по именам");
                City cityA1 = new City("A1");
                City cityB1 = new City("B1");
                City cityC1 = new City("C1");
                City[] neighbourCities = { cityA1, cityB1, cityC1 };
                int[] costs = { 20, 40, 10 };
                Console.WriteLine("А так же город D1, предварительно включив в параметры для конструктора массив с городами А1 В1 С1 и массив с стоимостью путей до них");
                City cityD1 = new City("D1", neighbourCities, costs);
                Console.WriteLine("Выведем связи города D1 на экран");
                Console.WriteLine(cityD1);
                break;
            case 5:
                Console.WriteLine("Задача 'Дроби'.");
                Console.WriteLine("Работа с дробями.");
                
                Fraction[] fractions = new Fraction[30];
                int fractionsCount = 0;
                bool fractionsExit = false;
                
                while (!fractionsExit)
                {
                    Console.WriteLine("\n Выберите действие:");
                    Console.WriteLine("1) Создать новую дробь");
                    Console.WriteLine("2) Показать все созданные дроби");
                    Console.WriteLine("3) Выполнить операцию с дробями");
                    Console.WriteLine("4) Показать пример: 1/3 * 2/3 = 2/9");
                    Console.WriteLine("5) Посчитать f1.sum(f2).div(f3).minus(5)");
                    Console.WriteLine("6) Выход");
                    
                    try
                    {
                        int choice = int.Parse(Console.ReadLine());
                        
                        switch (choice)
                        {
                            case 1:
                                if (fractionsCount >= 30)
                                {
                                    Console.WriteLine("Достигнут максимум дробей (10).");
                                    break;
                                }
                                
                                Console.WriteLine("Введите числитель:");
                                int num = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите знаменатель:");
                                int den = int.Parse(Console.ReadLine());
                                
                                Fraction newFraction = new Fraction(num, den);
                                fractions[fractionsCount] = newFraction;
                                fractionsCount++;
                                Console.WriteLine($"Дробь {newFraction} успешно создана и добавлена!");
                                break;
                                
                            case 2:
                                if (fractionsCount == 0)
                                {
                                    Console.WriteLine("Список дробей пуст.");
                                }
                                else
                                {
                                    Console.WriteLine("Созданные дроби:");
                                    for (int i = 0; i < fractionsCount; i++)
                                    {
                                        Console.WriteLine($"{i + 1}) {fractions[i]}");
                                    }
                                }
                                break;
                                
                            case 3:
                                if (fractionsCount < 2)
                                {
                                    Console.WriteLine("Для выполнения операций нужно создать хотя бы 2 дроби.");
                                    break;
                                }
                                
                                Console.WriteLine("Выберите операцию:");
                                Console.WriteLine("1) Сложение (+)");
                                Console.WriteLine("2) Вычитание (-)");
                                Console.WriteLine("3) Умножение (*)");
                                Console.WriteLine("4) Деление (/)");
                                try
                                {
                                    int opChoice = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Выберите первую дробь (введите номер):");
                                    for (int i = 0; i < fractionsCount; i++)
                                    {
                                        Console.WriteLine($"{i + 1}) {fractions[i]}");
                                    }
                                    int frac1Index = int.Parse(Console.ReadLine()) - 1;

                                    Console.WriteLine("Выберите вторую дробь (введите номер):");
                                    for (int i = 0; i < fractionsCount; i++)
                                    {
                                        Console.WriteLine($"{i + 1}) {fractions[i]}");
                                    }
                                    int frac2Index = int.Parse(Console.ReadLine()) - 1;

                                    if (frac1Index < 0 || frac1Index >= fractionsCount ||
                                        frac2Index < 0 || frac2Index >= fractionsCount)
                                    {
                                        Console.WriteLine("Неверный номер дроби.");
                                        break;
                                    }

                                    Fraction result = null;
                                    string operation = "";

                                    switch (opChoice)
                                    {
                                        case 1:
                                            result = fractions[frac1Index] + fractions[frac2Index];
                                            operation = "+";
                                            break;
                                        case 2:
                                            result = fractions[frac1Index] - fractions[frac2Index];
                                            operation = "-";
                                            break;
                                        case 3:
                                            result = fractions[frac1Index] * fractions[frac2Index];
                                            operation = "*";
                                            break;
                                        case 4:
                                            result = fractions[frac1Index] / fractions[frac2Index];
                                            operation = "/";
                                            break;
                                        default:
                                            Console.WriteLine("Неверный выбор операции.");
                                            break;
                                    }

                                    if (result != null)
                                    {
                                        Console.WriteLine($"{fractions[frac1Index]} {operation} {fractions[frac2Index]} = {result}");

                                        if (fractionsCount < 30)
                                        {
                                            fractions[fractionsCount] = result;
                                            fractionsCount++;
                                            Console.WriteLine("Результат добавлен в массив дробей.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Результат не добавлен - массив полон.");
                                        }
                                    }
                                    
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                break;
                            case 4:
                                Fraction demo1 = new Fraction(1, 3);
                                Fraction demo2 = new Fraction(2, 3);
                                Fraction demoResult = demo1 * demo2;
                                Console.WriteLine($"{demo1} * {demo2} = {demoResult}");
                                break;
                            case 5:
                                try
                                {
                                    Console.WriteLine("Введите числитель первой дроби (f1):");
                                    int numer1 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите знаменатель первой дроби (f1):");
                                    int denom1 = int.Parse(Console.ReadLine());
                                    Fraction f1 = new Fraction(numer1, denom1);

                                    Console.WriteLine("К дроби f1, по условию задачи, необходимо добавить дробь f2.");

                                    Console.WriteLine("Введите числитель второй дроби (f2):");
                                    int numer2 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите знаменатель второй дроби (f2):");
                                    int denom2 = int.Parse(Console.ReadLine());
                                    Fraction f2 = new Fraction(numer2, denom2);

                                    Console.WriteLine("Результат сложения дробей:");
                                    Fraction f12 = f1.Sum(f2);
                                    Console.WriteLine($"{f1} + {f2} = {f12}");
                                    Console.WriteLine("Получившуюся дробь необходимо делить на третью дробь");

                                    Console.WriteLine("Введите числитель третьей дроби (f3):");
                                    int numer3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите знаменатель третьей дроби (f3):");
                                    int denom3 = int.Parse(Console.ReadLine());
                                    Fraction f3 = new Fraction(numer3, denom3);

                                    Console.WriteLine("Результат деления дробей:");
                                    Fraction f123 = f12.Div(f3);
                                    Console.WriteLine($"{f12} / {f3} = {f123}");
                                    Console.WriteLine("Из получившейся дроби необходимо вычесть целое число 5");

                                    Console.WriteLine("Результат разности дробей:");
                                    Fraction f1234 = f123.Minus(5);
                                    Console.WriteLine($"{f123} - 5 = {f1234}");
                                    Console.WriteLine($"Итоговый результат: {f1234}");
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                break;
                            case 6:
                                fractionsExit = true;
                                Console.WriteLine("Выход из работы с дробями.");
                                break;

                            default:
                                Console.WriteLine("Неверный выбор. Введите число от 1 до 6.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                break;
            }                
    }
}
