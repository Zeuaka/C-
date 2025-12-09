using System;

namespace Lab6
{
    /// <summary>Класс, представляющий кота с возможностью мяукать</summary>
    public class Cat
    {
        private string _name;
        
        /// <summary>Имя кота</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        /// <summary>Создает кота с указанным именем</summary>
        /// <param name="name">Имя кота</param>
        /// <exception cref="ArgumentException">Если имя пустое</exception>
        public Cat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя кота не может быть пустым");     
            Name = name;
        }
        
        /// <summary>Кот мяукает один раз</summary>
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }
        
        /// <summary>Кот мяукает n раз</summary>
        /// <param name="n">Количество мяуканий</param>
        public void Meow(int n)
        {
            if (n <= 0) return;
    
            Console.Write($"{Name}: ");
            
            for (int i = 0; i < n; i++)
            {
                Console.Write("мяу");
                if (i != n - 1)
                {
                    Console.Write("-");
                }
            } 
            Console.WriteLine("!");
        }
        
        /// <summary>Возвращает строковое представление кота</summary>
        /// <returns>Строка в формате "кот: Имя"</returns>
        public override string ToString()
        {
            return $"кот: {Name}";
        }
    }
}
