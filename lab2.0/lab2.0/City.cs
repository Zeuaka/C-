namespace ClassWork
{
    internal class City
    {
        string name;
        City[] neighbourCities;
        int[] roadCosts;
        int roadsCount;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public City(string cityName)
        {
            this.name = cityName;
            this.neighbourCities = new City[11];
            this.roadCosts = new int[11];
            this.roadsCount = 0;
        }
        
        public void AddRoad(City targetCity, int cost)
        {
            if (targetCity == null)
            {
                Console.WriteLine("Ошибка: Имя города для связи не задано");
                return;
            }

            if (targetCity == this)
            {
                Console.WriteLine("Ошибка: Нельзя добавить путь к самому себе");
                return;
            }

            if (roadsCount >= 10)
            {
                Console.WriteLine("Ошибка: Достигнут максимум связей для города");
                return;
            }

            for (int i = 0; i < roadsCount; i++)
            {
                if (neighbourCities[i] == targetCity)
                {
                    Console.WriteLine($"Ошибка: Город {targetCity.Name} уже связан");
                    return;
                }
            }

            neighbourCities[roadsCount] = targetCity;
            roadCosts[roadsCount] = cost;
            roadsCount++;
            Console.WriteLine($"Добавлена дорога из {this.Name} в {targetCity.Name} стоимостью {cost}");
        }
        
        public City(string cityName, City[] neighbourCities, int[] roadCosts)
        {
            this.name = cityName;
            
            if (neighbourCities == null || roadCosts == null)
            {
                Console.WriteLine("Ошибка: Данные о городе не получены.");
                this.neighbourCities = new City[11];
                this.roadCosts = new int[11];
                this.roadsCount = 0;
                return;
            }
            
            if (neighbourCities.Length != roadCosts.Length)
            {
                Console.WriteLine("Ошибка: Количество городов и стоимостей должно совпадать");
                this.neighbourCities = new City[11];
                this.roadCosts = new int[11];
                this.roadsCount = 0;
                return;
            }
            
            if (neighbourCities.Length > 10)
            {
                Console.WriteLine("Ошибка: Слишком много связей. Максимум - 10");
                this.neighbourCities = new City[11];
                this.roadCosts = new int[11];
                this.roadsCount = 0;
                return;
            }
            
            this.neighbourCities = new City[11];
            this.roadCosts = new int[11];
            this.roadsCount = neighbourCities.Length;
            
            for (int i = 0; i < neighbourCities.Length; i++)
            {
                if (neighbourCities[i] == null)
                {
                    Console.WriteLine("Ошибка: Город в массиве не может быть null");
                    this.roadsCount = i;
                    return;
                }
                
                if (neighbourCities[i] == this)
                {
                    Console.WriteLine("Ошибка: Нельзя добавить путь к самому себе");
                    this.roadsCount = i;
                    return;
                }
                
                this.neighbourCities[i] = neighbourCities[i];
                this.roadCosts[i] = roadCosts[i];
            }
            
            Console.WriteLine($"Создан город {cityName} с {neighbourCities.Length} связями");
        }
        
        public override string ToString()
        {
            string result = "Город: " + name + "\n";
            result += "Связанные города:\n";
            
            if (roadsCount == 0)
            {
                result += "  Нет связанных городов";
            }
            else
            {
                for (int i = 0; i < roadsCount; i++)
                {
                    result += "  " + neighbourCities[i].Name + ":" + roadCosts[i] + "\n";
                }
            }
            
            return result;
        }
    }
}