using System;

namespace Lab6
{
    /// <summary>
    /// Класс-адаптер для кота с подсчетом мяуканий
    /// </summary>
    /// <remarks>
    /// Реализует паттерн "Адаптер", оборачивая объект <see cref="Cat"/>
    /// и добавляя функциональность подсчета количества мяуканий.
    /// </remarks>
    public class MeowableCat : IMeowable
    {
        private Cat _cat;
        private int _counter;
        
        /// <summary>
        /// Количество выполненных мяуканий
        /// </summary>
        /// <value>Целое число, количество вызовов метода <see cref="Meow"/></value>
        /// <remarks>
        /// Счетчик увеличивается каждый раз при вызове метода <see cref="Meow"/>
        /// </remarks>
        public int Counter
        {
            get { return _counter; }
        }
        
        /// <summary>
        /// Оригинальный объект кота
        /// </summary>
        /// <value>Объект класса <see cref="Cat"/>, который обернут адаптером</value>
        public Cat OriginalCat
        {
            get { return _cat; }
        }
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MeowableCat"/>
        /// </summary>
        /// <param name="cat">Объект кота, который будет мяукать</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="cat"/> равен null</exception>
        /// <remarks>
        /// Конструктор создает адаптер для указанного кота и инициализирует счетчик нулем.
        /// </remarks>
        public MeowableCat(Cat cat)
        {
            if (cat == null)
                throw new ArgumentNullException("cat", "Кот не может быть null");
            _cat = cat;
            _counter = 0;
        }
        
        /// <summary>
        /// Заставляет кота мяукать и увеличивает счетчик
        /// </summary>
        /// <remarks>
        /// Метод вызывает <see cref="Cat.Meow"/> у оригинального кота
        /// и увеличивает внутренний счетчик на единицу.
        /// </remarks>
        public void Meow()
        {
            _cat.Meow();
            _counter++;
        }
    }
}