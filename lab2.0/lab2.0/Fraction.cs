namespace ClassWork
{
    internal class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator 
        { 
            get { return numerator; }
            private set { numerator = value; }
        }

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
        public Fraction()
        {
            this.numerator = 1;
            this.denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                Console.WriteLine("Ошибка: Знаменатель не может быть равен нулю");
                this.Numerator = 0;
                this.Denominator = 1;
                return;
            }

            this.Numerator = numerator;
            this.Denominator = denominator;
            ToSimple();
        }

        public Fraction Sum(Fraction other)
        {
            int commonDenominator = this.denominator * other.denominator;
            int newNumerator = this.numerator * other.denominator + other.numerator * this.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        public Fraction Sum(int number)
        {
            return Sum(new Fraction(number, 1));
        }

        public Fraction Minus(Fraction other)
        {
            int commonDenominator = this.denominator * other.denominator;
            int newNumerator = this.numerator * other.denominator - other.numerator * this.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        public Fraction Minus(int number)
        {
            return Minus(new Fraction(number, 1));
        }

        public Fraction Multiply(Fraction other)
        {
            return new Fraction(
                this.numerator * other.numerator,
                this.denominator * other.denominator
            );
        }

        public Fraction Multiply(int number)
        {
            return Multiply(new Fraction(number, 1));
        }

        public Fraction Div(Fraction other)
        {
            if (other.numerator == 0)
            {
                Console.WriteLine("Ошибка: Деление на ноль");
                return new Fraction(0, 1);
            }

            return new Fraction(
                this.numerator * other.denominator,
                this.denominator * other.numerator
            );
        }

        public Fraction Div(int number)
        {
            if (number == 0)
            {
                Console.WriteLine("Ошибка: Деление на ноль");
                return new Fraction(0, 1);
            }

            return Div(new Fraction(number, 1));
        }

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

        public static Fraction operator +(Fraction left, Fraction right)
        {
            return left.Sum(right);
        }

        public static Fraction operator +(Fraction left, int right)
        {
            return left.Sum(right);
        }

        public static Fraction operator +(int left, Fraction right)
        {
            return right.Sum(left);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            return left.Minus(right);
        }

        public static Fraction operator -(Fraction left, int right)
        {
            return left.Minus(right);
        }

        public static Fraction operator -(int left, Fraction right)
        {
            return new Fraction(left, 1).Minus(right);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            return left.Multiply(right);
        }

        public static Fraction operator *(Fraction left, int right)
        {
            return left.Multiply(right);
        }

        public static Fraction operator *(int left, Fraction right)
        {
            return right.Multiply(left);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left.Div(right);
        }

        public static Fraction operator /(Fraction left, int right)
        {
            return left.Div(right);
        }

        public static Fraction operator /(int left, Fraction right)
        {
            return new Fraction(left, 1).Div(right);
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
}