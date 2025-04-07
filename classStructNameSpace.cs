namespace Basic.ClassStructNameSpace
{
    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Классы - это шаблон объекта
    // Объект - это экземпляр шаблона
    class Persone 
    {
        // Внутрянка класса - это поле класса
        // То где храняться данные - переменные
        // Для поведения класса над переменными - используются методы
        public string name = "unkown";  // Поле класса со значением по умолчанию
        public int age = 0;                 // Поле класса

        public void printExemple() => Console.WriteLine($"Name: {name}, age: {age}");
    }   

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Конструкторы
    class PersoneConstructor
    {
        // Входые данные
        public string name;
        public int age;
        public string thisU;

        // Назначаем три коструктора - нарушает принцип DRY, старый метод
        // Все конструкторы называются так же, как и название класса
        // Конструктор со значениями по умолчанию
        public PersoneConstructor() { name = "Unkown"; age = 0; thisU = "abc";  PrintConstructor(); }
        public PersoneConstructor(string n) { name = n; age = 0; thisU = "abc"; PrintConstructor(); }
        public PersoneConstructor(string n, int a) { name = n; age = a; thisU = "abc"; PrintConstructor(); }
        // this - ссылкой обращается к переменной в поле класса, а не к параметру
        public PersoneConstructor(string name, string thisU = "abc") { this.name = name; this.thisU = thisU; PrintConstructor();}
        // Разделяем ответственность (печатаем значения переменных)
        public void PrintConstructor() => Console.WriteLine($"Имя: {name}, возвраст: {age}");
    }
    
    class PersoneChainConstructionThis
    {
        // Пример выше не эффективный, дабы избежать дублирования функционала construction =>
        // Обращаемся к другим конструкторам, через this
        // Для каких задач подходи? - Для сложных объектов с валидацией или разными сценариями создания
        // Ограничения - может быть избыточным, для простого класса, длинные комбинации
        // Если изменять главный конструктор, то он может сломать другие
        public string? name;
        public int age = 0;
        // При сценарии с пустым методом, this помещает "Неизвестное значение"
        public PersoneChainConstructionThis() : this("Неизвестные значения") {}
        // При сценарии, где только name, this возвращает name с поля класса и зн. по умолчанию
        public PersoneChainConstructionThis(string name) : this(name, 16) {}
        // При данном сценарии, this возвращает значения из поля класса
        public PersoneChainConstructionThis(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class PersoneConstructorDefoultValue
    {
        // Входые данные
        public string name;
        public int age;

        // Конструктор с дефолтными параметрами
        // Для каких задач подходи? - Для DTO, моделей данных, простых сущностей от 2-5 полей
        // Ограничения - не подходит, если переменные имеют логику, а не значения. 
        // Не показывает комбинации в конструкторе (сценарии, которые могут быть)
        public PersoneConstructorDefoultValue(string name = "Uncown", int age = 0) 
        { 
            this.name = name; 
            this.age = age; 
            PrintConstructor(); 
        }  
        public void PrintConstructor() => Console.WriteLine($"Имя: {name}, возвраст: {age}");
    }
 
    // Первичный конструктор в классе начиная с C#12
    public class PersoneConstructorToClass(string name, int age)
    {
        // Этот конструктор обращается к первичному конструктору
        public PersoneConstructorToClass(string name) : this(name, 18) { }
        public void PersonePrint() => Console.WriteLine($"name: {name}, age: {age}");
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Альтернатива конструкторам - инициализаторы
    // Нужны для установления значения при создании объекта
    class PersoneInicial
    {
        public string name;
        // переменная объекта, класса company
        public Company company;
        public PersoneInicial(string name = "Undefined") 
        { 
            this.name = name;
            // Создание экземпляра класса Company 
            company = new Company();
        }
        public void PersonePrint() => Console.WriteLine($"Имя: {name}  Компания: {company.title}");
    }
 
    class Company
    {
        public string title = "Unknown";
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Деконструктор !Деструктор - разложение объекта на переменные
    class PersonDeconst
    {
        public string name;
        public int age;

        public PersonDeconst(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Деконструктор
        public void Deconstruct(out string nameParams, out int ageParams)
        {
            nameParams = this.name;
            ageParams = this.age;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//
    
    // Структуры - тип данных C# - синтаксически аналогичен классу. Различия:
    // struct — для легковесных, неизменяемых данных (координаты, время, деньги).
    // Значимый тип (Value Type) (хранится в стеке или внутри других объектов), классы в куче (ссылочный тип)
    // Копирования - структура созадёт новую независимую копию, класс обращается через ссылку к одним данным
    // Нет наследования, но есть интерфейсы
    // Все поля инициализируются, в классах присваивается null, если не инициализированно через new
    struct PersonStuct
    {
        public string name;
        public int age;
        public PersonStuct(string name = "Grom", int age = 1)
        {
            this.name = name;
            this.age = age;
        }
        public void PrintStruct() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Типы значений и ссылочные типы - для примера сравним два разных типа (структуру и класс)
    class PersonRefTypeClass
    {
        public string name;
        public int age;
        public PersonRefTypeClass(string name = "Grom", int age = 1)
        {
            this.name = name;
            this.age = age;
        }
        public void PrintRefType() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Область видимости(контекст) переменных
    // Контекст класса. Доступны в любом методе этого класса. Их еще называют глобальными переменными или полями
    // Контекст метода. Являются локальными и доступны только в рамках данного метода. В других методах они недоступны
    // Контекст блока кода. Доступны только в рамках данного блока. Вне своего блока кода они не доступны.
    // Мораль такая: все переменные, которые ниже по абстракции, доступны те, что выше
    // Переменным выше по абстракции доступны только те, которые на том же уровне или выше
    class Person                               // начало контекста класса
    {
        string type = "Person";                // переменная уровня класса
        public void PrintName()                // начало контекста метода PrintName
        {  
            string name = "Tom";               // переменная уровня метода
      
            {                                  // начало контекста блока кода
                string shortName = "Tomas";    // переменная уровня блока кода
                Console.WriteLine(type);       // в блоке доступна переменная класса
                Console.WriteLine(name);       // в блоке доступна переменная окружающего метода
                Console.WriteLine(shortName);  // в блоке доступна переменная этого же блока
            }                                  // конец контекста блока кода, переменная shortName уничтожается
      
            Console.WriteLine(type);           // в методе доступна переменная класса
            Console.WriteLine(name);           // в методе доступна переменная этого же метода
            //Console.WriteLine(shortName);    // так нельзя, переменная c определена в блоке кода
            //Console.WriteLine(surname);      // так нельзя, переменная surname определена в другом методе
      
        }                                      // конец контекста метода PrintName, переменная name уничтожается
    
        public void PrintSurname()             // начало контекста метода PrintSurname
        {
            string surname = "Smith";          // переменная уровня метода
    
            Console.WriteLine(type);           // в методе доступна переменная класса
            Console.WriteLine(surname);        // в методе доступна переменная этого же метода 
        }                                      // конец конекста метода PrintSurname, переменная surname уничтожается
    
    }                                          // конец контекста класса, переменная type уничтожается

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Пространство имён - namespace, using - виртуальная директория кода, которая сортирует логически связанный код
    // - по директории, namespace - определяет своего рода виртуальный файл с участком кода, можно так же писать вложенные
    // - участки кода, using - обращение к директории, что бы использовать иные классы и объекты за пределом физ.файла
    // Так же есть глобальные пространства имён, дабы не доблировать using Base (например) - пространство имён главного файла
    // - можно в главном файле определить: global using System; global using Base; - теперь во всех файлах проекта будут
    // - использоваться эти пространства имён

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Модификаторы доступа - области видимости для компонентов класса
    // FAQ: Сборка - собранный проект - (.exe, .dll), Проект - (все файлы в рамках одной папки), Производный класс - (насоедуемый класс)
    // private - закрытый, доступен только в рамках своего класса
    // private protect - доступен в рамках своего класса и производного класса, кот. оперд. в той же сборке
    // file - с C#11, класс или структура доступны только в рамках этого файла
    // protected - так же, как private protect, только можно производные классы ис. в др. сборках
    // internal - доступен в рамках своей сборке, недоступен в др. программе или сборке
    // protected internal - совмещает функционал двух - доступен в текущей сборке и из производных классов, которые могут располагаться в других сборках.
    // public - доступен в своей и др. сборке не имея ограничений
    // структуры принимают те же модиф. кроме private protected, protected и protected internal
    // если компоненты класса или структуры не имеют модиф. => private
    // если класс или структура не имеет модиф. => internal

    class State
    {
        // Разные модификаторы доступа для демонстрации
        private int privateVar = 1;
        private protected int protectedPrivateVar = 2;
        protected int protectedVar = 3;
        internal int internalVar = 4;
        protected internal int protectedInternalVar = 5;
        public int publicVar = 6;
        
        public State(int privateVar)
        {
            this.privateVar = privateVar;
        }
    }

    class StateConsumer
    {
        public void PrintAccessibleState()
        {
            //State state = new State();

            //Console.WriteLine("Доступные поля из StateConsumer:");
            //Console.WriteLine($"Internal: {state.internalVar}");
            //Console.WriteLine($"Protected Internal: {state.protectedInternalVar}");
            //Console.WriteLine($"Public: {state.publicVar}");

            // Недоступные поля (раскомментируйте для проверки ошибок)
            // Console.WriteLine($"Private: {state.privateVar}"); // Ошибка
            // Console.WriteLine($"Private Protected: {state.protectedPrivateVar}"); // Ошибка
            // Console.WriteLine($"Protected: {state.protectedVar}"); // Ошибка
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Св-ва - это посредник между переменной (поле класса) и функцией, которая работает с ней

    // Когда использовать автосвойства?
    // Если не нужна дополнительная логика (проверки, вычисления).
    // Для DTO (классов-моделей данных).
    // Если в будущем может потребоваться расширение.

    // Не использовать, если нужно:
    // Валидировать данные при записи.
    // Выполнять действия при изменении значения.
    // Структура св-в по умолчанию
    class Property
    {
        private string name = "Property";
        public string Name
        {
            // Действия, выполняемые при получении значения свойства (чтение)
            get
            {
                // Значение возвращается
                return name;
            }
            // Действия, выполняемые при записи значения свойства (запись)
            set
            {  
                // Устанавливается новое значение
                name = value;
            }
        }
    }

    // Пример использования
    // И да, не обязательно использовать сразу два свойства!
    class PersonPropertyAge
    {
        int age = 1;
        // Если условие подходит, то в переменной age устанавливается др. значение
        // Если не подходит, даёт вернёт то значение, которое подходит условию, если до этого было инициализированно правильно
        public int Age
        {
            set
            {
                if (value < 1 || value > 120)
                    Console.WriteLine("Возраст должен быть в диапазоне от 1 до 120");
                else    
                    // value != переменная, это параметр
                    age = value;
            }
            get { return age; }
        }

        // Так же св-ва можно использовать не только для переменной, но и для выражений
        private string firstName = "Property";
        private string lastName = "Property";
        public string Name
        {
            get { return  $"{firstName} {lastName}"; }
        }
    }

    // Компилятор C# автоматически определяет св-ва полей { get; set; } - инкапсулирует операции над переменной (чтение\запись)
    // Это компилируется автоматически
    // get { return _name; }  // вернуть значение
    // set { _name = value; } // установить значение

    // init - инициализация св-в без конструктора, но можно и с ним
    // - в дальнейшем значения нельзя изменить - аналог readonly
    // - нужен для неизменных объектов (иммутабельные объект)
    // - нельзя использовать в структурах (только классы или record)
    // - нельзя использовать с set
    public class PersonInitMutObj
    {
        public string? Name { get; init; } // Можно задать значение при инициализации
        public int Age { get; init; }
    }
    // var person = new PersonInit { Name = "Алексей", Age = 30 };   - иммутабельный объект
    // person.Name = "Новое имя";                                    - Ошибка! Нельзя изменить после инициализации

    public class PersonInitConstruction
    {
        public string Name { get; init; } // Можно задать значение при инициализации
        public int Age { get; init; }
        public PersonInitConstruction(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    // var person = new PersonInit ("Алексей", 42);                  - значение через конструктор
    // person.Name = "Новое имя";                                    - Ошибка! Нельзя изменить после инициализации

    public class PersonInitEmail
    {
        private string nameInit = "";
        public string NameInit
        {
            get { return nameInit; }
            init
            {
                nameInit = value;
                Email = $"{value}@gmail.com";
            }
        }
        public string Email { get; init; } = "";
    }
    // var person = new PersonInitEmail { NameInit = "Lonsdale" };        - через инит
    // Console.WriteLine(person.Email);                                   - Lonsdale@gmail.com 
    // person.Name = "Новое имя";                                         - Ошибка! Нельзя изменить после инициализации

    // Сокращение записи
    class PersonShotProp
    {
        string name = "";
        int age = 0;
        public string Name 
        { 
            get => name;         // return name
            set => name = value; // return name = value
        }
        // эквивалентно public int Age { get { return age; } }
        public int Age => age;
    }
    // Модификатор requier
    // var bob = new PersonRequiredProp("Bob"); // ошибка - свойства Name и Age все равно надо установить в инициализаторе
    public class PersonRequiredProp
    {
        public PersonRequiredProp(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
        public required int Age { get; set; } = 22; // даже с тем условие, что есть значение по умолчанию
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Перегрузка методов - создание методов с одим и тем же именем, но с разными параметрами
    // Создание одних и тех же методов возможно только с разной сигнатурой: Sum() - название, параметры, св-ва параметров
    // Т.е. для того, чтобы создать много методов с одним названием, нужно чтобы в сигнатуре были:
    // Разное кол-во параметров, разные типы параметров, разные модификаторы, разный порядок параметров
    // Пример:
    class CalculatorMethodOverload
    {
        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Result is {result}");
        }
        public void Add(int a, int b, int c)
        {
            int result = a + b + c;
            Console.WriteLine($"Result is {result}");
        }
        public int Add(int a, int b, int c, int d)
        {
            int result = a + b + c + d;
            Console.WriteLine($"Result is {result}");
            return result;
        }
        public void Add(double a, double b)
        {
            double result = a + b;
            Console.WriteLine($"Result is {result}");
        }

        // Пример с разными модификаторами: 
        public void Increment(ref int val)
        {
            val++;
            Console.WriteLine(val);
        }
        public void Increment(int val)
        {
            val++;
            Console.WriteLine(val);
        }
        // В остальных случаях работать перезагрузка метода не будет
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Статические члены и модификатор static

    // Статическое поле - поле, которое относиться ко всем объектам, а не к одному (по значению)
    // Пример с пенсионным возврастом
    // Console.WriteLine(PersonFieldStatic.retirementAge);      - обращение к статики только через имя класса
    // PersonFieldStatic.retirementAge = 67;
    class PersonFieldStatic
    {
        // возраст у всех разный - соответственно значение для всех объектов разное
        int age;
        // пенсионный для всех одинаковый - хранит одинаковое значение для всех объектов
        public static int retirementAge = 65;
        public PersonFieldStatic(int age)
        {
            this.age = age;
        }
        public void СheckAge()
        {
            if (age >= retirementAge)
                Console.WriteLine("Уже на пенсии");
            else
                Console.WriteLine($"Сколько лет осталось до пенсии: {retirementAge - age}");
        }
    }

    // Статическое св-во
    // PersonPropertyStatic bob = new(68);
    // bob.СheckAge();
    // Console.WriteLine(PersonPropertyStatic.RetirementAge); // 65
    class PersonPropertyStatic
    {
        int age;
        static int retirementAge = 65;
        public static int RetirementAge
        {
            get { return retirementAge; }
            // проверка условия, для изменения значения
            set { if (value > 1 && value < 100) retirementAge = value; }
        }
        public PersonPropertyStatic(int age)
        {
            this.age = age;
        }
        public void СheckAge()
        {
            if (age >= retirementAge)
                Console.WriteLine("Уже на пенсии");
            else
                Console.WriteLine($"Сколько лет осталось до пенсии: {retirementAge - age}") ;
        }
    }
    // Использование статик поля для счётчика объектов
    // var tom = new PersonCounterStatic();
    // var bob = new PersonCounterStatic();
    // var sam = new PersonCounterStatic();
    // Console.WriteLine(PersonCounterStatic.Counter);  // 3
    class PersonCounterStatic
    {
        static int counter = 0;
        public static int Counter => counter;
        public PersonCounterStatic()
        {
            counter++;
        }
    }

    // Статические метод, принимает только статик члены класса
    // PersonMethodStatic bob = new(68);
    // PersonMethodStatic.CheckRetirementStatus(bob);
    class PersonMethodStatic
    {
        public int Age { get; set; }
        static int retirementAge = 65;
        // Конструктор, кот. возвращает значение в св-во 
        public PersonMethodStatic(int age) => Age = age;
        // Метод, кот принимает объект и проверет его на пенсионный возраст
        public static void CheckRetirementStatus(PersonMethodStatic person)
        {
            if (person.Age >= retirementAge)
                Console.WriteLine("Уже на пенсии");
            else
                Console.WriteLine($"Сколько лет осталось до пенсии: {retirementAge - person.Age}") ;
        }
    }

    // Статический конструктор
    // Нет модификаторов, нет параметров
    // this не используется, т.к. конструктор для всех, обращение только к статике
    // В ручную не вызывается. Выполняются автоматически при первом создании объекта или при первом обращении к его статическим членам
    //Console.WriteLine(PersonСonstructStatic.RetirementAge);
    class PersonСonstructStatic
    {
        static int retirementAge;
        public static int RetirementAge => retirementAge;
        static PersonСonstructStatic()
        {
            if (DateTime.Now.Year == 2022)
                retirementAge = 65;
            else
                retirementAge = 67;
        }
    }

    // Статические классы - может иметь только статические поля, св-ва и методы
    // Console.WriteLine(OperationStatic.Add(5, 4));         // 9
    // Console.WriteLine(OperationStatic.Subtract(5, 4));    // 1
    // Console.WriteLine(OperationStatic.Multiply(5, 4));    // 20
    
    static class OperationStatic
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Константы класса, поля и срутктуры для чтения

    // Константы
    // Person tom = new Person();
    // tom.name = "Tom";
    // tom.Print();    // Person: Tom

    // Console.WriteLine(Person.type); // Person
    // Person.type = "User";    // !Ошибка: изменить константу нельзя - 
                                // но если мы захотим к ней обратиться нужно указывать название класса
    
    class PersonConst
    {
        // Константа, значение которой неизменно
        public const string type = "Person";
        // Поле выступает в виде конструктора - её значение можно поменять
        public string name = "Undefined";
        public void Print() => Console.WriteLine($"{type}: {name}");
    }
    
    // Поле для чтения readonly
    // Так же, как константа, но можно определить значение только в конструкторе
    // Ещё одно отличие, значение константы определяется во время компиляции
    // - а поля для чтения во время выполнения кода
    // Так же со static - константы нельзя, readonly можно

    // Структуры для чтения - все св-ва должны иметь get; поля - readonly
    // readonly struct PersonReadOnly
    // {
        // public readonly string name = "";         // указывать readonly обязательно
        // public readonly string Name { get; } // указывать readonly необязательно
        // public int Age { get; }              // свойство только для чтения
        // public PersonReadOnly(string name, int age)
        // {
            // Name = name;
            // Age = age;
        // }
    // }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Null и ссылочные типы
    // До C#8 можно было строком придавать значение null
    // C#8+ строком с пустым значениям нужно присваивать string? - nullable-типы
    // К примеру ReadLine - возвращает значение string?, а не просто string
    // Применение nullable - базы данных, где возможно нет объекта
    // Обычные же переменные ссылочного типа следует инициализировать
    // С .NET6 И C#10 при выполнении кода с null в ссылочном типе, выдаст предупреждение
    // Можно и другими способами, но прям не вижу прикладного смысла в этом

    // Обход предупреждения - походу он не работает, но был
    class NullableTypeString
    {
//      string? name = null;
 
//      PrintUpper(name!); // переменная НЕ null, в будующем будет присвоенно значение
        
        void PrintUpper(string text)
        {
            if(text == null) Console.WriteLine("null");
            else Console.WriteLine(text.ToUpper());
        } 
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Null и значимые типы
    // В отличии от ссылочных типов, значимым типам нельзя присвоить значение null
    // Хотя, было бы удобно, если делать запросы к БД (мало ли есть эллементы с пустым значение)
    // Присваиваивается nullable-тип аналогично ссылочному варианту
    // nullable проверяется на nullable тип, иначе проверить значение нельзя 

    // Проверка null-значения
    // Value - значение объекта 
    // HasValue - возвращает true, если значение есть
    class NullableTypeStringNoLiqud
    {
        //PrintNullable(5);       // 5
        //PrintNullable(null);    // параметр равен null

        void PrintNullable(int? number)
        {
            if (number.HasValue)    // если значение есть, то
            {
                Console.WriteLine(number.Value);    // бесполезный как по мне
                // аналогично
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("параметр равен null");
            }
        }
    }

    // Преобразование значимых nullable-типов
/*    class NullableTransform
    {
        // явное преобразование от T? к T
        int? x1 = null;
        if(x1.HasValue)
        {
            int x2 = (int)x1;
            Console.WriteLine(x2);
        }
        // Неявное преобразование от T к T?
        int x1 = 4;
        int? x2 = x1;
        Console.WriteLine(x2);
        // Неявные расширяющие преобразования от V к T?
        int x1 = 4;
        long? x2 = x1;
        Console.WriteLine(x2);
        // Явные сужающие преобразования от V к T?
        long x1 = 4;
        int? x2 = (int?)x1;
        // Подобным образом работают явные сужающие преобразования от V? к T?
        long? x1 = 4;
        int? x2 = (int?)x1;
        // Явные сужающие преобразования от V? к T
        long? x1 = null;
        if (x1.HasValue) 
        { 
            int x2 = (int)x1; 
        }
    }                                               */
    // Операции с nullable
    // Арифметика - если один из операндов null - то результат null
    // Сравнение - если один из операндов null - то результат false
    // При стандартном сравнении ( != , == ) - интуитивно понятно

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Проверка на null ? и ??

    // Проверка на null - Null guard(защита от null) - избегаем ошибки NullReferenceException
    class ValidNullable 
    {
        void PrintUpperDont(string? text)
        {
            // если не равняется nulL - то
            if (text!=null)
            {
                Console.WriteLine(text.ToUpper());
            }    
        }

        void PrintUpperIs(string? text)
        {
            // если это nulL - то
            if (text is  null) return;
                Console.WriteLine(text.ToUpper());
        }

        void PrintUpperIsNot(string? text)
        {
            // если не nulL - то
            if (text is not null) 
                Console.WriteLine(text.ToUpper());
        }

        // Оператор ?? - null-объеденение - значение по умолчанию для типов, которые имеют null
        // Так же можно использовать ??=, как int1+=int2, вместо int3 = int1+int2
        static string? text = null;
        static string name = text ?? "Tom";    // равно Tom, так как text равен null
//      text ??= "Tom"                  // аналогично тому, что выше
//      Console.WriteLine(name);        // Tom

        static int? id = 200;                  // с обычным int такое не прокатит
        static int personid = id ?? 1;         // равно 200, так как id не равен null
//      Console.WriteLine(personid);    // 200
        
        void PrintUpper(string? text)
        {
            // если не равняется nulL - то
            if (text!=null)
            {
                Console.WriteLine(text.ToUpper());
            }
        }
    }

    // Оператор условного null - ?. для объектов и компонентов
    // Иногда при работе с объектами, при обращении к ним, мы можем сталкнуться с ошибкой
    // Так, как они могут ровняться null
    // Например:

    class PrintWebSite
    {
        PrintWebSite(PersonNull? person)
        {
            // Громосткая конструкция, которую можно сократить
            // С помощью оператора условного null ?. - объект?.компонент
            if (person != null && person.Company != null && person.Company.WebSite != null)
                Console.WriteLine(person.Company.WebSite.ToUpper());
            // Аналогична конструкции выше, если каждый последующий компонент не имеет null, то запускается метод
            Console.WriteLine(person?.Company?.WebSite?.ToUpper());
        }
    }
    
    // Человек может иметь место работы, а может и не иметь
    class PersonNull
    {
        public CompanyNull? Company { get; set; }   // место работы
    }
    // Компания, которая может иметь вэб-сайт, а может и не иметь
    class CompanyNull
    {
        public string? WebSite { get; set; }    // веб-сайт компании
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Псевдонимы типов и статический импорт
    
    // Псевдонимы - например нам не нравиться вызывать Console.WrinteLine - дабы не писать постоянно Cosole, мы можем поменять
    // В самом начале файла, где подключаем пространства имён, мы помжем указать всевдонимы, например
    // using display = System.Console; - теперь вместо Console - будет display

    // Статический импорт
    // Подключая статические классы чрез using, в дальнейшем не следует обращаться к методам, через класс
    // using static System.Console
    // WriteLine("Http") - в таком случае, теперь не требуется обращатсья к классу Console

    //--------------------------------------------Конец-------------------------------------------------------------------------------------//

}