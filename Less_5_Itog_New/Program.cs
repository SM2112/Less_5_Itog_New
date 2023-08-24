namespace Less_5_Itog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // главный  метод откуда все вызываем
            var anketaUser = UpdateAnketaUser();
            PrintAnketaUser(anketaUser.name, anketaUser.lastName, anketaUser.age, anketaUser.isZoo, anketaUser.valZoo, anketaUser.nameZoo, anketaUser.valColors, anketaUser.nameColor);
        }

        // метод по выводу даннных анкеты
        static void PrintAnketaUser(string nameUser, string lastNameUser, byte ageUser, bool isZoo, byte valZoo, string[] nameZoo, byte valColors, string[] nameColor)
        {
            Console.WriteLine("\n\nВывожу результаты заполнения Вами Вашей  Анкеты: ");
            Console.WriteLine("Ваше имя - {0}", nameUser);
            Console.WriteLine("Ваша фамилия - {0}", lastNameUser);
            Console.WriteLine("Ваш возраст - {0}", ageUser);
            if (isZoo == true)
            {
                Console.WriteLine("У Вас есть домашние животные");
                Console.WriteLine("У Вас {0} домашних питомцев", valZoo);
                Console.WriteLine("Вот их имена: ");
                for (byte i = 0; i < nameZoo.Length; i++)
                {
                    Console.WriteLine(nameZoo[i]);
                }
            }
            else
            {
                Console.WriteLine("У Вас нет домашних животных");
            }
            Console.WriteLine("У Вас {0} любимых цветов", valColors);
            Console.WriteLine("Вот их названия: ");
            for (byte i = 0; i < nameColor.Length; i++)
            {
                Console.WriteLine(nameColor[i]);
            }
            Console.WriteLine("{0}! Спасибо за сотрудничество!", nameUser);
        }


        // метод по заполнению анкеты
        static (string name, string lastName, byte age, bool isZoo, byte valZoo, string[] nameZoo, byte valColors, string[] nameColor) UpdateAnketaUser()

        {
            // метод по заполнению анкеты
            (string name, string lastName, byte age, bool isZoo, byte valZoo, string[] nameZoo, byte valColors, string[] nameColor) AnketaUser;

            ///////////////////////////////////////////////////////////////////////////////////////////
            // заполняем имя пользователя 
            Console.WriteLine("Уважаемый пользователь! Пожалуйста ответьте на несколько вопросов!");
            Console.Write("Как Вас зовут: ");
            AnketaUser.name = Console.ReadLine();
            ///////////////////////////////////////////////////////////////////////////////////////////


            ///////////////////////////////////////////////////////////////////////////////////////////
            // заполняем фамилию 
            Console.Write("Введите Вашу фамилию: ");
            AnketaUser.lastName = Console.ReadLine();
            //////////////////////////////////////////////////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////////
            // по умолчанию примаем что возраст равен 0
            //AnketaUser.age = 0;
            string sAge;
            bool bAge = false;
            AnketaUser.age = 0;

            do
            {
                Console.Write("Введите  Ваш возраст: ");
                sAge = Console.ReadLine();
                bAge = processingNum(sAge);

                if (bAge == true)
                {
                    AnketaUser.age = Convert.ToByte(sAge);
                }

                if (AnketaUser.age == 0 || bAge == false)
                {
                    Console.WriteLine("Вы ввели  возраст равный 0 или значение невозможно привести к целому числу. Ввведите  число заново!");
                    bAge = false;
                }
            }
            while (bAge == false);
            //////////////////////////////////////////////////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////////
            Console.Write("Есть ли у Вас домашние животные? (Если есть, то напишите 'Да'): ");
            string sIsZoo = Console.ReadLine();

            if (sIsZoo == "Да")
            {
                AnketaUser.isZoo = true;
            }
            else
            {
                AnketaUser.isZoo = false;
            }

            //////////////////////////////////////////////////////////////////////////////////////////
            AnketaUser.valZoo = 0;

            if (AnketaUser.isZoo == true)
            {
                bool bValZoo = false;

                do
                {
                    Console.Write("Введите кол-во животных: ");
                    string sValZoo = Console.ReadLine();
                    bValZoo = processingNum(sValZoo);

                    if (bValZoo == true)
                    {
                        AnketaUser.valZoo = Convert.ToByte(sValZoo);
                    }

                    if (AnketaUser.valZoo == 0 || bValZoo == false)
                    {
                        Console.WriteLine("Вы ввели  кол-во животных равное 0 или значение невозможно привести к целому числу. Ввведите  число заново!");
                        bValZoo = false;
                    }

                }
                while (bValZoo == false);
            }

            //////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////
            if (AnketaUser.isZoo == true)
            {
                // вызываем  метод по заполннению массива с именами животных 
                AnketaUser.nameZoo = NameZoo(AnketaUser.valZoo);
            }
            else
            {
                AnketaUser.nameZoo = new string[1];
                AnketaUser.nameZoo[0] = "Нет";
            }
            //////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////
            bool bValColors = false;
            AnketaUser.valColors = 0;

            do
            {
                Console.Write("Введите кол-во любимых цветов (минимум 1): ");
                string sValColors = Console.ReadLine();
                bValColors = processingNum(sValColors);

                if (bValColors == true)
                {
                    AnketaUser.valColors = Convert.ToByte(sValColors);
                }
                if (AnketaUser.valColors == 0 || bValColors == false)
                {
                    Console.WriteLine("Вы ввели  кол-во цветов равное 0 или значение невозможно привести к целому числу. Ввведите  число заново!");
                    bValColors = false;
                }
            }
            while (bValColors == false);
            //////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////
            AnketaUser.nameColor = NameColors(AnketaUser.valColors);
            //////////////////////////////////////////////////////////////////////////////////////////

            return AnketaUser;
        }


        // метод по проверке введенного числа с клавиатуры
        static bool processingNum(string sNum)
        {
            bool result = int.TryParse(sNum, out var number);
            return result;

        }


        // метод для ввода с клавиатуры кличек животных
        static string[] NameZoo(int valZoo)
        {
            int val = valZoo;
            var ZooName = new string[val];

            for (int i = 0; i < ZooName.Length; i++)
            {
                Console.Write("Ввведите кличку {0}-ого питомца: ", i + 1);
                ZooName[i] = Console.ReadLine();
            }
            return ZooName;
        }


        // метод возвращает количество цветов, введеннных с  клавиатруры
        static string[] NameColors(int valColors)
        {
            int val = valColors;
            var ColorsVal = new string[val];

            for (int i = 0; i < ColorsVal.Length; i++)
            {
                Console.Write("Введите {0} любимый цвет: ", i + 1);
                ColorsVal[i] = Console.ReadLine();
            }
            return ColorsVal;
        }
    }
}