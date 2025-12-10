using System;
using System.Collections.Generic;

namespace Lab6
{
    /// <summary>
    /// Статический класс для работы с мяукающими объектами
    /// </summary>
    /// <remarks>
    /// Содержит методы для организации мяуканья нескольких объектов
    /// и подсчета количества мяуканий.
    /// </remarks>
    public static class MeowHelper
    {
        /// <summary>
        /// Заставляет все переданные объекты мяукать по три раза
        /// </summary>
        /// <param name="meowables">Массив объектов, реализующих интерфейс <see cref="IMeowable"/></param>
        /// <remarks>
        /// Каждый объект в массиве вызывает метод <see cref="IMeowable.Meow"/> три раза подряд.
        /// Метод выводит заголовочное сообщение перед началом мяуканья.
        /// </remarks>
        public static void MakeAllMeow(params IMeowable[] meowables)
        {
            Console.WriteLine("=== Начинаем мяукать ===");
            
            foreach (IMeowable meowable in meowables)
            {
                meowable.Meow();
                meowable.Meow();
                meowable.Meow();
            }
        }
        
        /// <summary>
        /// Принимает котов, заставляет их мяукать и возвращает словарь с количеством мяуканий
        /// </summary>
        /// <param name="cats">Массив котов</param>
        /// <returns>
        /// Словарь, где ключ - объект кота (<see cref="Cat"/>), 
        /// значение - количество его мяуканий (целое число)
        /// </returns>
        /// <remarks>
        /// Метод создает адаптеры для каждого кота, вызывает у них мяуканье
        /// и возвращает результаты в виде словаря.
        /// </remarks>
        public static Dictionary<Cat, int> CountMeowsForCats(params Cat[] cats)
        {
            Dictionary<Cat, int> results = new Dictionary<Cat, int>();
            
            if (cats == null || cats.Length == 0)
            {
                Console.WriteLine("Нет котов для мяуканья");
                return results;
            }
            
            Console.WriteLine($"Начинаем мяукать с {cats.Length} котами:");
            
            List<MeowableCat> adapters = new List<MeowableCat>();
            
            foreach (Cat cat in cats)
            {
                if (cat != null)
                {
                    MeowableCat adapter = new MeowableCat(cat);
                    adapters.Add(adapter);
                    results.Add(cat, 0);
                }
            }
            
            IMeowable[] meowables = adapters.ToArray();
            
            MakeAllMeow(meowables);
            
            foreach (MeowableCat adapter in adapters)
            {
                Cat originalCat = adapter.OriginalCat;
                int count = adapter.Counter;
                results[originalCat] = count;
            }
            
            return results;
        }
    }
}
