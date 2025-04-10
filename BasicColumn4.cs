namespace Basic.BasicColumn4
{
    class BasicCSMethod 
    {

        // написание метода - модификатор + тип, который вернёт + название + (параметры)
        // void не возвращает значение - он выполняет действие
        public void cosolWrite () 
        {    
            Console.Write("Структура метода");
        }
        public void consoleWriteDeclarative() => Console.WriteLine("Компактное написание");
        // параметры, которые содержаться в методе => формальные параметры
        // значение, которое передаётся в параметр при вызове функции из переменной => 
        // фактический параметр (аргумент)
        // string href = "Аргумент для метода";
        // параметры имеющие значения по умолчанию - пишуться в конце => необязательные параметры
        // но при этом выдаётся ошибка warning
        public static void DescriptionParams(string params1, ref string paramsH) //, string params2 = "p2")
        {;
            Console.WriteLine(params1);
            Console.WriteLine(paramsH + "\n");
        }
        // использование модификатора out - выходные данные, которые нужно помещать в переменные
        public static void OutModifi(int value1, int value2, out int value11, out int value22)
        {
            // инициализаци out переменных для преобразование выходных данных
            value11 = value1 * 2;  // Пример преобразования
            value22 = value2 + 10; // Пример преобразования

            Console.WriteLine($"Входные значения: {value1}, {value2}");
            Console.WriteLine($"Выходные значения: {value11}, {value22}");
        }
        // оператор return в методах
        public static int TransformationNum(int num1, int num2, out int result)
        {
            // возращает сумму двух переменных
            return result = num1 + num2;
        }
        // возращает сумму двух переменных, через лямбду выражение
        public static int TransformationNumLambda(int num1, int num2) => num1 + num2;
        // использование return в void методах
        public static void CheckAgeUsers(string name, int age)
        {
            if (age < 18 || age > 45)
            {
                Console.WriteLine("Возвраст не подходит!");
                return; // выход из функции
            } 
            else
            {
                Console.WriteLine($"Name: {name}, Age: {age}");
            }
        }

        // рекурсии
        // факториал числа - 
        public static int Factorial(int n)
        {
            // начало последовательности у факториалов начинается с еденицы
            // пока не будет единицы, функция будет вызываться
            if (n == 1) return 1;
            // суммирует и возвращает все значения, пока не будет выполнено условие
            return n * Factorial(n - 1);
            // например вводим 5-ку отладка будет такая:
            // 5*4 =! 1, 5*3 != 1, 5*2 =! 1, 5*1 != 1, 5*0 = 1, возвращает сумму всех значений
        }

        public static int Fibonachi(int n)
        {
            // начало последовательности в числах Ф. начинается с нуля и еденицы
            // пока не будет нуля или единицы, функция будет вызываться
            if (n == 0 || n == 1) return n;

            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }

        // локальные функции

        public static void CompareArray(int[] numbers1, int[] numbers2)
        {
            int numbers1Sum = Sum(numbers1);    // первый результат лок.функции
            int numbers2Sum = Sum(numbers2);    // второй результат лок.функции

            if (numbers1Sum > numbers2Sum)
                Console.WriteLine("сумма чисел из массива numbers1 больше");
            else if (numbers1Sum < numbers2Sum)
                Console.WriteLine("сумма чисел из массива numbers2 больше");
            else
                Console.WriteLine("суммы чисел обоих массивов равны");
            
            // дабы не дублировать цикл, мы его используем один для двух операций
            int Sum(int[] numbers)	
            {
                int result = 0;
                // за каждую иттерацию, result суммирует числа с массива
                foreach (int number in numbers)
                    result += number; 
                // после завершения работы цикла, вернёт результат суммы чисел
                return result;
            }
        }
    }
}