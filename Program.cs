global using System;
using Basic.BasicColumn1_2;
using Basic.BasicColumn3;
using Basic.BasicColumn4;
using Basic.ClassStructNameSpace;
using Basic.OOPMethods;
using Basic.Practic;

namespace Basic 
{
    class Program
    {
        public static void Main(string[] args)
        {
//--------------------------------------------------------------------------------------------------------------------------------------//
//-------------------------------Практика C#--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//

            // Калькулятор (beginner)
            // var operation = new CalculatorBegin();

            // Условные конструкции
            // var operation = new ComparingTwoNumbs();
            // var operation = new RangeNumbs();
            // var operation = new Deposit();
            //var operation = new EqualityTreeNumbers();

//--------------------------------------------------------------------------------------------------------------------------------------//
//-------------------------------Основы C#----------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//

/*          BasicCS.Column1();       // Вызов основы C# - первой колоны
            BasicCS.Column2();       // Вызов основы C# - второй колоны
            BasicCS3.Column3();      // Вызов основы C# - третьей колоны
                                        // Вызов основы C# - четвёртая колона
            // Назначение аргумента для метода (значение меняется только в методе)
            string params45 = "factArgument";                      
            // Аргумент через ссылку (значение меняется там и там)
            string href = "Аргумент для метода";
            Console.WriteLine($"\nParams45: {params45}");
            Console.WriteLine($"Href: {href}\n");
            // Первый способ назначения - переменной
            BasicCSMethod.DescriptionParams(params45 = "patt", ref href);
            // Второй способ назначения - значением
            BasicCSMethod.DescriptionParams("factArgument", ref params45);
            // Лаконичный способ - плюс к читаемости - рефу присваивается только значение
            BasicCSMethod.DescriptionParams(params1: "!params45", paramsH: ref href);
            // Лаконичный способ - плюс к читаемости
            BasicCSMethod.DescriptionParams(params1: href, paramsH: ref params45);
            // Проверка, как поменялись переменные
            Console.WriteLine($"\nParams45: {params45}");
            Console.WriteLine($"Href: {href}\n");

            // Модификатор OUT
            BasicCSMethod.OutModifi(324, 543, out int value11, out int value22);

            // Оператор return
            Console.WriteLine(BasicCSMethod.TransformationNum(43, 45, out int result));
            Console.WriteLine(BasicCSMethod.TransformationNumLambda(43, 67));
            // return в void функциях 
            BasicCSMethod.CheckAgeUsers("Alex", 17); 


            // Рекурсии
            Console.WriteLine(BasicCSMethod.Factorial(5));
            Console.WriteLine(BasicCSMethod.Fibonachi(6));

            // Локальные функции
            int[] array1 = { 1, 5, 44, 123, 43 };
            int[] array2 = { 423, 54, 3, 5, 61 };
            BasicCSMethod.CompareArray(array1, array2);                                 */

//--------------------------------------------------------------------------------------------------------------------------------------//
//------------------------------------Классы, объекты, структуры, пространства имён-----------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//

/*          // Создание объекта и выделение памяти для него new Persone
            // Persone - класс
            // Alex - переменная для работы с функционалом и полями класса
            // new - создание экземпляра класса, выделение памяти и вызов конструктора
            // Persone() - вызов конструктора - если нет значения, то два варианта
            // 1) Либо есть кастомный конструктор, который инициализирует поля
            // 2) Либо он создаёт пустой конструктор
            // Подкапотка: Persone Alex(стек, stack), new Persone(управляемая куча, heap)
            Persone alex = new Persone();
            // Инициализируем значения из поля класса
            alex.name = "Alex";
            alex.age = 21;
            // Вызываем метод класса
            alex.printExemple();


            // Конструкторы
            PersoneConstructor basicValue = new PersoneConstructor();
            PersoneConstructor dmitry = new PersoneConstructor("Dmitry");
            PersoneConstructor dmitryAge = new PersoneConstructor("Dmitry", 20);
            // Ключевое слово this - ссылка на экземпляр класса
            // Начиная с C#9+ можно не писать название конструктора
            PersoneConstructor thisValue = new ("This and This", "45");
            // Цепочка вызова конструкторов и конструктор со значениями по умолчанию
            PersoneConstructorDefoultValue dbUser = new(age: 26);

            // Инициализация объектов
            PersoneInicial tom = new PersoneInicial{ name = "Tom", company = { title = "Microsoft"} };
            tom.PersonePrint();

            // Деконструктор
            PersonDeconst userDecons = new PersonDeconst("Ivan", 17);
            //Разобрали результат значения, через деструктор
            userDecons.Deconstruct(out string nameDecons, out int ageDecons);
            Console.WriteLine($"Имя: {nameDecons}, возраст: {ageDecons}");

            // Структуры
            PersonStuct toms = new PersonStuct { name = "Tom", age = 22 };
            PersonStuct bob = toms with { name = "Bobs" };
            bob.PrintStruct();    // Имя: Bobs  Возраст: 22
            toms.PrintStruct();   // Имя: Tom  Возраст: 22

            // Типы значений и ссылочные типы
            // Структура (value types)
            PersonStuct stack = new ();
            PersonStuct stack1 = new ();
            stack.age = 5;
            stack1.age = 8;
            stack = stack1;
            stack.age = 9;          // Переопределяет только stack, т.к. stack1 - независимая копия
            stack.PrintStruct();    // 9
            stack1.PrintStruct();   // 8
            // Класс (referens types)
            PersonRefTypeClass heap = new ();
            PersonRefTypeClass heap1 = new();
            heap.age = 3;
            heap1.age = 6;
            heap = heap1;
            heap.age = 8;           // Переопределяет два значения, heap1 работает по ссылке - зависимая копия
            heap.PrintRefType();    // 8
            heap1.PrintRefType();   // 8 

            // Cв-ва (init)
            //muttable object
            var personMutObj = new PersonInitMutObj { Name = "Егор", Age = 48 };
            Console.WriteLine(personMutObj.Name);
            Console.WriteLine(personMutObj.Age);
            //construction
            var personConstruct = new PersonInitConstruction("Алексей", 17);
            Console.WriteLine(personConstruct.Name);
            Console.WriteLine(personConstruct.Age);
            //init
            var personInit = new PersonInitEmail { NameInit = "Lonsdale" };
            Console.WriteLine(personInit.Email);                  */

//--------------------------------------------------------------------------------------------------------------------------------------//
//------------------------------------Наследование, Виртуалки, Инкапсуляция-------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//
        
            InheritPersone peroneEmployee = new Employee();

//--------------------------------------------------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//
    
        }
    }
}    