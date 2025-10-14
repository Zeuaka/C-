namespace ClassWork
{
    internal class Name
    {
        string surname;
        string mainName;
        string patronymic;

        public string MainName
        {
            get { return mainName; }
            set { mainName = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }

        public Name()
        {
            surname = "Щербина";
            mainName = "Сергей";
            patronymic = "Александрович";
        }

        public Name(string mainName)
        {
            this.MainName = mainName;
            this.Surname = "";
            this.Patronymic = "";
        }

        public Name(string surname, string mainName)
        {
            this.Surname = surname;
            this.MainName = mainName;
            this.Patronymic = "";
        }

        public Name(string surname, string mainName, string patronymic)
        {
            this.Surname = surname;
            this.MainName = mainName;
            this.Patronymic = patronymic;
        }

        public static Name CreateFromInput()
        {
            string surname = GetValidInput("фамилию", false);
            if (surname == null)
            {
                return null; 
            }
            

            string name = GetValidInput("имя", true);
            if (name == null)  
            {
                return null; 
            }

            string patronymic = GetValidInput("отчество", false);
            if (patronymic == null)  
            {
                return null; 
            }

            if (surname == "" && patronymic == "")
            {
                return new Name(name);
            }
            else if (patronymic == "")
            {
                return new Name(surname, name);
            }
            else
            {
                return new Name(surname, name, patronymic);
            }
        }

        private static string GetValidInput(string fieldName, bool isRequired)
        {
            if (isRequired)
            {
                Console.WriteLine("Введите " + fieldName + " человека:");
            }
            else
            {
                Console.WriteLine("Введите " + fieldName + " человека (если нет - нажмите Enter):");
            }

            string input = Console.ReadLine();
            if (input == null)
            {
                input = "";
            }

            if (isRequired && input == "")
            {
                Console.WriteLine("Ошибка: " + fieldName + " не может быть пустым(ой)");
                return null;
            }

            if (input != "" && !char.IsUpper(input[0]))
            {
                Console.WriteLine("Ошибка: " + fieldName + " должна начинаться с заглавной буквы");
                return null;
            }

            return input;
        }

        public override string ToString()
        {
            if (surname == "" && patronymic == "")
            {
                return "Имя человека: " + mainName;
            }
            else if (patronymic == "")
            {
                return "ФИ человека: " + surname + " " + mainName;
            }
            else if (surname == "")
            {
                return "ИО человека: " + mainName + " " + patronymic;
            }
            else
            {
                return "ФИО человека: " + surname + " " + mainName + " " + patronymic;
            }
        }
    }
}