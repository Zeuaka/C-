using System;

namespace Lab6
{
    /// <summary>
    /// Интерфейс для операций с дробями
    /// </summary>
    public interface IFractionOperations
    {
        /// <summary>
        /// Получает вещественное значение дроби
        /// </summary>
        /// <returns>Вещественное значение дроби</returns>
        double GetHashCode();
        
        /// <summary>
        /// Устанавливает числитель дроби
        /// </summary>
        /// <param name="numerator">Новое значение числителя</param>
        void SetNumerator(int numerator);
        
        /// <summary>
        /// Устанавливает знаменатель дроби
        /// </summary>
        /// <param name="denominator">Новое значение знаменателя</param>
        void SetDenominator(int denominator);
    }
    
    /// <summary>
    /// Класс, представляющий математическую дробь
    /// </summary>
    /// <remarks>
    /// Дробь состоит из числителя и знаменателя.
    /// Знаменатель не может быть равен нулю.
    /// При создании дробь автоматически сокращается.
    /// Знак всегда хранится в числителе, знаменатель всегда положительный.
    /// </remarks>
    public class Fraction : IFractionOperations
    {
        private int numerator;
        private int denominator;
        private double? cachedValue = null;

        /// <summary>
        /// Числитель дроби
        /// </summary>
        /// <value>Целое число</value>
        public int Numerator 
        { 
            get { return numerator; }
            private set { numerator = value; }
        }

        /// <summary>
        /// Знаменатель дроби
        /// </summary>
        /// <value>Целое число, не равное нулю</value>
        public int Denominator 
        { 
            get { return denominator; } 
            private set 
            {
                if (value != 0)
                {
                    denominator = value;
                } 
            }
        }
        
        /// <summary>
        /// Инициализирует новый экземпляр дроби со значением 1/1
        /// </summary>
        public Fraction()
        {
            this.numerator = 1;
            this.denominator = 1;
        }
        
        /// <summary>
        /// Инициализирует новый экземпляр дроби с указанными числителем и знаменателем
        /// </summary>
        /// <param name="numerator">Числитель дроби</param>
        /// <param name="denominator">Знаменатель дроби</param>
        /// <exception cref="ArgumentException">Выбрасывается, если знаменатель равен нулю</exception>
        /// <example>
        /// <code>
        /// // Создание дробей
        /// Fraction f1 = new Fraction(1, 2);    // 1/2
        /// Fraction f2 = new Fraction(3, 4);    // 3/4
        /// Fraction f3 = new Fraction(-2, 3);   // -2/3
        /// Fraction f4 = new Fraction(4, -6);   // -2/3 (автоматическое приведение)
        /// </code>
        /// </example>
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Ошибка: Знаменатель не может быть равен нулю");
            }

            this.Numerator = numerator;
            this.Denominator = denominator;
            if (this.denominator < 0)
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
            
            ToSimple();
        }
        
        /// <summary>
        /// Возвращает вещественное значение дроби
        /// </summary>
        /// <returns>Десятичное представление дроби</returns>
        /// <remarks>
        /// Значение кэшируется для повышения производительности
        /// </remarks>
        /// <example>
        /// <code>
        /// Fraction f = new Fraction(1, 4);
        /// double value = f.GetHashCode(); // 0.25
        /// </code>
        /// </example>
        public double GetHashCode()
        {
            if (cachedValue == null)
            {
                cachedValue = (double)numerator / denominator;
            }
            return cachedValue.Value;
        }
        
        /// <summary>
        /// Устанавливает новый числитель дроби
        /// </summary>
        /// <param name="numerator">Новое значение числителя</param>
        /// <remarks>
        /// После установки дробь автоматически сокращается
        /// </remarks>
        public void SetNumerator(int numerator)
        {
            this.numerator = numerator;
            cachedValue = null;
            ToSimple();
        }
        
        /// <summary>
        /// Устанавливает новый знаменатель дроби
        /// </summary>
        /// <param name="denominator">Новое значение знаменателя</param>
        /// <exception cref="ArgumentException">Выбрасывается, если знаменатель равен нулю</exception>
        /// <remarks>
        /// После установки дробь автоматически сокращается
        /// Знаменатель всегда приводится к положительному значению
        /// </remarks>
        public void SetDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }
            
            this.denominator = denominator;
            if (this.denominator < 0)
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
            cachedValue = null;
            ToSimple();
        }
        
        /// <summary>
        /// Определяет, равен ли указанный объект текущему объекту
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом</param>
        /// <returns>true, если указанный объект равен текущему объекту; в противном случае — false</returns>
        /// <remarks>
        /// Две дроби считаются равными, если их сокращенные формы идентичны
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                Fraction thisSimple = new Fraction(this.numerator, this.denominator);
                Fraction otherSimple = new Fraction(other.numerator, other.denominator);
                
                return thisSimple.numerator == otherSimple.numerator && 
                       thisSimple.denominator == otherSimple.denominator;
            }
            return false;
        }
        
        /// <summary>
        /// Оператор равенства для двух дробей
        /// </summary>
        /// <param name="left">Левая дробь</param>
        /// <param name="right">Правая дробь</param>
        /// <returns>true, если дроби равны; иначе false</returns>
        public static bool operator ==(Fraction left, Fraction right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        
        /// <summary>
        /// Оператор неравенства для двух дробей
        /// </summary>
        /// <param name="left">Левая дробь</param>
        /// <param name="right">Правая дробь</param>
        /// <returns>true, если дроби не равны; иначе false</returns>
        public static bool operator !=(Fraction left, Fraction right) => !(left == right);
        
        /// <summary>
        /// Создает новый объект, который является копией текущего экземпляра
        /// </summary>
        /// <returns>Новый объект, являющийся копией этого экземпляра</returns>
        /// <remarks>
        /// Реализация интерфейса ICloneable
        /// </remarks>
        public object Clone()
        {
            return new Fraction(this.numerator, this.denominator);
        }
        
        /// <summary>
        /// Складывает текущую дробь с другой дробью
        /// </summary>
        /// <param name="other">Дробь для сложения</param>
        /// <returns>Новая дробь - результат сложения</returns>
        public Fraction Sum(Fraction other)
        {
            int commonDenominator = this.denominator * other.denominator;
            int newNumerator = this.numerator * other.denominator + other.numerator * this.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        /// <summary>
        /// Складывает текущую дробь с целым числом
        /// </summary>
        /// <param name="number">Целое число для сложения</param>
        /// <returns>Новая дробь - результат сложения</returns>
        public Fraction Sum(int number)
        {
            return Sum(new Fraction(number, 1));
        }

        /// <summary>
        /// Вычитает другую дробь из текущей дроби
        /// </summary>
        /// <param name="other">Дробь для вычитания</param>
        /// <returns>Новая дробь - результат вычитания</returns>
        public Fraction Minus(Fraction other)
        {
            int commonDenominator = this.denominator * other.denominator;
            int newNumerator = this.numerator * other.denominator - other.numerator * this.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        /// <summary>
        /// Вычитает целое число из текущей дроби
        /// </summary>
        /// <param name="number">Целое число для вычитания</param>
        /// <returns>Новая дробь - результат вычитания</returns>
        public Fraction Minus(int number)
        {
            return Minus(new Fraction(number, 1));
        }

        /// <summary>
        /// Умножает текущую дробь на другую дробь
        /// </summary>
        /// <param name="other">Дробь для умножения</param>
        /// <returns>Новая дробь - результат умножения</returns>
        public Fraction Multiply(Fraction other)
        {
            return new Fraction(
                this.numerator * other.numerator,
                this.denominator * other.denominator
            );
        }

        /// <summary>
        /// Умножает текущую дробь на целое число
        /// </summary>
        /// <param name="number">Целое число для умножения</param>
        /// <returns>Новая дробь - результат умножения</returns>
        public Fraction Multiply(int number)
        {
            return Multiply(new Fraction(number, 1));
        }

        /// <summary>
        /// Делит текущую дробь на другую дробь
        /// </summary>
        /// <param name="other">Делитель (дробь)</param>
        /// <returns>Новая дробь - результат деления</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается, если числитель делителя равен нулю</exception>
        public Fraction Div(Fraction other)
        {
            if (other.numerator == 0)
            {
                throw new DivideByZeroException("Ошибка: Деление на ноль");
            }

            return new Fraction(
                this.numerator * other.denominator,
                this.denominator * other.numerator
            );
        }

        /// <summary>
        /// Делит текущую дробь на целое число
        /// </summary>
        /// <param name="number">Делитель (целое число)</param>
        /// <returns>Новая дробь - результат деления</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается, если число равно нулю</exception>
        public Fraction Div(int number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException("Ошибка: Деление на ноль");
            }

            return Div(new Fraction(number, 1));
        }

        /// <summary>
        /// Сокращает дробь до простейшего вида
        /// </summary>
        /// <remarks>
        /// Внутренний метод, вызывается автоматически
        /// Использует алгоритм Евклида для нахождения НОД
        /// </remarks>
        private void ToSimple()
        {
            if (numerator == 0)
            {
                denominator = 1;
                return;
            }

            int average = Euclid(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= average;
            denominator /= average;
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        /// <summary>
        /// Вычисляет наибольший общий делитель двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольший общий делитель</returns>
        /// <remarks>
        /// Используется алгоритм Евклида
        /// </remarks>
        private int Euclid(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        
        /// <summary>
        /// Оператор сложения двух дробей
        /// </summary>
        /// <param name="left">Левая дробь</param>
        /// <param name="right">Правая дробь</param>
        /// <returns>Результат сложения</returns>
        public static Fraction operator +(Fraction left, Fraction right)
        {
            return left.Sum(right);
        }

        /// <summary>
        /// Оператор сложения дроби и целого числа
        /// </summary>
        /// <param name="left">Дробь</param>
        /// <param name="right">Целое число</param>
        /// <returns>Результат сложения</returns>
        public static Fraction operator +(Fraction left, int right)
        {
            return left.Sum(right);
        }

        /// <summary>
        /// Оператор сложения целого числа и дроби
        /// </summary>
        /// <param name="left">Целое число</param>
        /// <param name="right">Дробь</param>
        /// <returns>Результат сложения</returns>
        public static Fraction operator +(int left, Fraction right)
        {
            return right.Sum(left);
        }

        /// <summary>
        /// Оператор вычитания двух дробей
        /// </summary>
        /// <param name="left">Уменьшаемое (дробь)</param>
        /// <param name="right">Вычитаемое (дробь)</param>
        /// <returns>Результат вычитания</returns>
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return left.Minus(right);
        }

        /// <summary>
        /// Оператор вычитания целого числа из дроби
        /// </summary>
        /// <param name="left">Уменьшаемое (дробь)</param>
        /// <param name="right">Вычитаемое (целое число)</param>
        /// <returns>Результат вычитания</returns>
        public static Fraction operator -(Fraction left, int right)
        {
            return left.Minus(right);
        }

        /// <summary>
        /// Оператор вычитания дроби из целого числа
        /// </summary>
        /// <param name="left">Уменьшаемое (целое число)</param>
        /// <param name="right">Вычитаемое (дробь)</param>
        /// <returns>Результат вычитания</returns>
        public static Fraction operator -(int left, Fraction right)
        {
            return new Fraction(left, 1).Minus(right);
        }

        /// <summary>
        /// Оператор умножения двух дробей
        /// </summary>
        /// <param name="left">Первый множитель (дробь)</param>
        /// <param name="right">Второй множитель (дробь)</param>
        /// <returns>Результат умножения</returns>
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return left.Multiply(right);
        }

        /// <summary>
        /// Оператор умножения дроби на целое число
        /// </summary>
        /// <param name="left">Дробь</param>
        /// <param name="right">Целое число</param>
        /// <returns>Результат умножения</returns>
        public static Fraction operator *(Fraction left, int right)
        {
            return left.Multiply(right);
        }

        /// <summary>
        /// Оператор умножения целого числа на дробь
        /// </summary>
        /// <param name="left">Целое число</param>
        /// <param name="right">Дробь</param>
        /// <returns>Результат умножения</returns>
        public static Fraction operator *(int left, Fraction right)
        {
            return right.Multiply(left);
        }

        /// <summary>
        /// Оператор деления одной дроби на другую
        /// </summary>
        /// <param name="left">Делимое (дробь)</param>
        /// <param name="right">Делитель (дробь)</param>
        /// <returns>Результат деления</returns>
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left.Div(right);
        }

        /// <summary>
        /// Оператор деления дроби на целое число
        /// </summary>
        /// <param name="left">Делимое (дробь)</param>
        /// <param name="right">Делитель (целое число)</param>
        /// <returns>Результат деления</returns>
        public static Fraction operator /(Fraction left, int right)
        {
            return left.Div(right);
        }

        /// <summary>
        /// Оператор деления целого числа на дробь
        /// </summary>
        /// <param name="left">Делимое (целое число)</param>
        /// <param name="right">Делитель (дробь)</param>
        /// <returns>Результат деления</returns>
        public static Fraction operator /(int left, Fraction right)
        {
            return new Fraction(left, 1).Div(right);
        }
        
        /// <summary>
        /// Возвращает строковое представление дроби
        /// </summary>
        /// <returns>Строка в формате "числитель/знаменатель"</returns>
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
        
        /// <summary>
        /// Форматирует операцию между двумя дробями
        /// </summary>
        /// <param name="a">Первая дробь</param>
        /// <param name="operation">Операция (+, -, *, /)</param>
        /// <param name="b">Вторая дробь</param>
        /// <returns>Строка с отформатированной операцией и результатом</returns>
        /// <exception cref="ArgumentException">Выбрасывается при неизвестной операции</exception>
        /// <example>
        /// <code>
        /// Fraction f1 = new Fraction(1, 2);
        /// Fraction f2 = new Fraction(1, 3);
        /// string result = Fraction.FormatOperation(f1, "+", f2);
        /// // result: "1/2 + 1/3 = 5/6"
        /// </code>
        /// </example>
        public static string FormatOperation(Fraction a, string operation, Fraction b)
        {
            Fraction result;
            switch (operation)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/": result = a / b; break;
                default: throw new ArgumentException("Неизвестная операция");
            }
            return $"{a} {operation} {b} = {result}";
        }
        
        /// <summary>
        /// Форматирует операцию между дробью и целым числом
        /// </summary>
        /// <param name="a">Дробь</param>
        /// <param name="operation">Операция (+, -, *, /)</param>
        /// <param name="b">Целое число</param>
        /// <returns>Строка с отформатированной операцией и результатом</returns>
        /// <exception cref="ArgumentException">Выбрасывается при неизвестной операции</exception>
        public static string FormatOperation(Fraction a, string operation, int b)
        {
            Fraction result;
            switch (operation)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/": result = a / b; break;
                default: throw new ArgumentException("Неизвестная операция");
            }
            return $"{a} {operation} {b} = {result}";
        }
    }
}