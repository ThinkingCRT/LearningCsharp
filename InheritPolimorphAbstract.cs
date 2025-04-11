namespace Basic.OOPMethods 
{
    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Наследование

    // Наследование - унаследование функционала другого класса, единственное, что не наслед. - конструкторы
    // Класс который наследует - дорчерний, от которого наследуется - родительский или (суперкласс).
    // Объект дочернего класса, так же является объектом родительского
    // Так же все классы наследуются от базового Object и имеют методы по умоллчанию
    // Object: ToString(), Equals(), GetHashCode() и GetType().
    // На примере класс InhtritPerson - класс, который будем наследовать
    // Employee - сотрудник

    class InheritPersone
    {
        private string _name = "Томас";
        private int _age = 23;
        public string Name { get {return _name;} set {_name = value;}}
        public int Age { get {return _age;} set {_age = value;}}

        public void PrintInherit()
        {
            Console.WriteLine($"Имя: {Name}, возвраст: {Age}");
        }
    }

    // Класс Employee - наследует класс InheritEmlpoyee
    // Класс Employee - объект класса InheritEmlpoyee
    class Employee : InheritPersone
    {
        internal Employee()
        {
            PrintInherit();
        }
    }

    // Пример создание объекта для класса, который наследуется:
    // Person person = new Person { Name = "Tom" };
    // person = new Employee { Name = "Sam" }; - либо через объект родителя
    // Person p = new Employee() - либо напрямую, без инициализации родителя
    // Но, в двух случаях наследник является объектом родителя

    // Ограничение у наследника:
    // Не поддерживается множественное наследование, класс может наследоваться только от одного класса.
    // Наследник должен иметь модиф. доступа такой же или более строгий:
    // То есть, если базовый класс у нас имеет тип доступа internal, то производный класс может иметь тип доступа:
    // internal или private, но не public. Если родитель и наследних в разных сборках, родитель => public, не строже
    // Класс с модификатором sealed - запрещает наследование, отличие от private: 
    // sealed запрещает наследовать и переопределять, обойти его нельзя, применим только к class, method()
    // Нельзя наследоваться от статики

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Порядок вызова конструктора и ключевое слово base - указание на родителя
    
    class InheritPersoneConstruct
    {
        protected string name = "";
        protected int age = 0;
    
        public InheritPersoneConstruct(string name)
        {
            this.name = name;
            Console.WriteLine("Person(string name)");
        }
        // Обращается к конструктору своего класса
        public InheritPersoneConstruct(string name, int age) : this(name) 
        {
            this.age = age;
            Console.WriteLine("Person(string name, int age)");
        }
    }
    // base обращается к конструктору родительскому конструктору
    // И того, конструкор наследника делегирует выполнение конструктора родителя и так далее до конструкьора System.Object
    // А потом System.Object выполняет возвращение конструкторов
    class EmployeeConstruct : InheritPersoneConstruct
    {
        string company = "";
    
        public EmployeeConstruct(string name, int age, string company) : base(name, age) 
        {
            this.company = company;
            Console.WriteLine("Employee(string name, int age, string company)");
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Виртуальные методы и св-ва - рекомендуется к использованию
    // Переопределение метода с таким же названием (полиморфизм)

    // virtual - объявляется для методов или св-в, которые можно переопределить
    // - определяются только в родительском классе
    // - должен иметь модификатор ниже private, для того, что бы мог наследоваться
    // - реализация полиморфизма

    // Ограничения - private, static, sealed, конструкторы
    class TransportVirtual
    {
        // Нужна базовая реализация, но в зависимости от наследника меняется
        public virtual void Move()
        {
            Console.WriteLine("Transport is moving");
        }

        // Будет меняться логика чтения\записи
        public virtual int Speed { get; set; } = 100;
    }

    // override - объявляется только в произвольном классе
    // override - используется для abstract или virtual
    class CarVirtual : TransportVirtual
    {
        public override void Move()
        {
            Console.WriteLine("Car is driving");
        }

        // override sealed - получает реализацию virtual, но переопределить след. наследнику запрещает
        public override sealed int Speed
        {
            // Повторюсь: base - обращение к базовой реализации класса
            get => base.Speed * 2;
            set => base.Speed = value;
        }
    }

    // TransportVirtual obj = new CarVirtual();
    // obj.Move(); // Выведет "Car is driving" (ожидаемо для неподготовленного разработчика, метод переопределён)

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Скрытие полей, методов и св-в 
    // Ключевое слово new - не целесообразное использование (использовать с осторожностью)!
    // Определение нового метода с таким же названием
    class TransportHidden 
    {
        public void Method() => Console.WriteLine("TransportHidden");
    }

    class CarHidden : TransportHidden 
    {
        public new void Method() => Console.WriteLine("CarHidden"); // Скрытие, не переопределение
    }

    // TransportHidden obj = new CarHidden();
    // obj.Method(); // Выведет "TransportHidden" (неожиданно для неподготовленного разработчика)

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // abstract class, поля, методы, св-ва - шаблоны для других классов

    // Абстрактный класс
    // Нельзя создать напрямую (нельзя new AbstractClass()).
    // Может содержать абстрактные (нереализованные) и обычные (реализованные) методы и свойства.
    // Предназначен для наследования (от него должны наследоваться другие классы).

    // Абстрактные методы
    // Методы, которые так же не реализуют функционал, имеют только сигнатуру
    // Обеспечивает полиморфизм
    // Используется только в абстрактных классах
    // Должны переопределяться наследниками через override - обязательно

    // Абстрактные св-ва
    // Всё так же как и в методах, только могут иметь или get и|или set

    // Конструкторы могут быть, но реализуются в наследниках

    abstract class Animal
    {
        // Поле - нужно для конструктора
        protected string _name = "";
        // Обычное свойство
        public int Age { get; set; }
        // Абстрактное свойство (без реализации)
        public abstract string Species { get; }
        // Абстрактный метод (без тела)
        public abstract void MakeSound();
        // Обычный метод (с реализацией)
        public void Sleep()
        {
            Console.WriteLine($"{_name} is sleeping...");
        }
        // Виртуальный метод (можно переопределить)
        public virtual void Eat()
        {
            Console.WriteLine("Eating generic food");
        }
        // Конструктор (вызывается при создании наследника)
        public Animal(string name)
        {
            _name = name;
        }
    }

    // Реализаация абстрактного класса
    // Заметим, обычный метод остаётся в абстракте, но фактически есть и здесь, не переопределён
    class Dog : Animal
    {
        // Реализация абстрактного свойства - можно только читать переопределён только в DOG
        public override string Species => "Canis lupus familiaris";
        // Реализация абстрактного метода - переопределён
        public override void MakeSound()
        {
            Console.WriteLine("Bark!");
        }
        // Переопределение виртуального метода (необязательно) - можно оставить в абстракте и не реализовывать
        public override void Eat()
        {
            Console.WriteLine("Eating dog food");
        }
        // Вызов конструктора базового класса - используем только инициализацию переменной
        public Dog(string name) : base(name) { }
    }

    // Animal myDog = new Dog("Rex");
    // myDog.MakeSound(); // "Bark!"
    // myDog.Eat();       // "Eating dog food"
    // myDog.Sleep();     // "Rex is sleeping..."
    // Console.WriteLine(myDog.Species); // "Canis lupus familiaris"

    // Отличие от интерфейсов:
    // Интерфейсы не имеют реализации, а только сигнатуры, 
    // Не имеет полей, конструкторов, доступно мн.наследование, 
    // Все модификаторы по дефолту public 
    // Интерфейсы для контрактов, абстракции для иерархии и общей логики

    // Так же можно спутать со static - т.к. тоже относиться один ко многим, но разница велика
    // static class для:
    // Нужен контейнер для вспомогательных методов (Math, FileHelper)
    // Требуется хранить глобальные константы или настройки
    // Не нужна возможность переопределения поведения

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Обобщения

    // Какую проблему решают обобщения? Разберёмся на примере:
    class Person
    {
        public int Id { get;}
        public string Name { get;}
        public Person(int id, string name)
        {
            Id = id; 
            Name = name;
        }
    }
    // Проблема св-ва Id в том, что  ID пользователя может быть числом, можнет быть строкой
    // В зависимости от предпочтения разработчиков, но для универсальности, можно использовать
    // boxing, unboxing пример ниже:
    class PersonObj
    {
        // боксовое св-во
        public object Id { get;}
        public string Name { get;}
        public PersonObj(object id, string name)
        {
            Id = id; 
            Name = name;
        }
    }
    // var tom = new PersonObj(546, "Tom");
    // var bob = new PersonObj("abc123", "Bob");

    // int tomId = (int)tom.Id;         // Распаковка типа object
    // string bobId = (string) bob.Id;  // Распаковка типа object

    // Console.WriteLine(tomId);        // 546
    // Console.WriteLine(bobId);        // abc123

    // С одной стороны, мол ничего же такого, но 
    // Во-первых больше кода,
    // Во-вторых вес значений тоже увеличивается,
    // В-третьих производительность тоже падает из-за преобразований,
    // В-четвёртых проблема с безопасностью типов - ошибка,
    // Посмотрим, как будет реализация через обобщения:

    // Класс с параметром универсального типа данных и конструктором
    class PersonGen<T>(T id, string name)
    {
        // Тип данных св-ва, зависит от контекста, в котором оно используется
        public T Id { get; set; } = id;
        public string Name { get; set; } = name;
    }

    // var tom = new PersonGen<int>(546, "Tom");         // Возвращает int, если другой тип - ошибка
    // var bob = new PersonGen<string>("abc123", "Bob"); // Возвращает string

    // int tomId = tom.Id;          // распаковка не нужна
    // string bobId = bob.Id;       // преобразование типов не нужно

    // Console.WriteLine(tomId);    // 546
    // Console.WriteLine(bobId);    // abc123

    // Обобщённые методы
    public class Printer
    {
        public void Print<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
    // var printer = new Printer();
    // printer.Print<int>(10);       // 10
    // printer.Print<string>("Hi");  // Hi
    // printer.Print(3.14);          // 3.14    // Можно опустить тип, компилятор выведет его сам:

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Ограничения обобщений - в том случае, когда следует указать ограничение к использованию

    // Класс имеет по умолчанию объекты
    class Messenger<T> where T : Message
    {
        // параметр принимает только объект от Message
        public void SendMessage(T message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }
    
    class Message
    {
        public string Text { get; } // текст сообщения
        public Message(string text)
        {
            Text = text;
        }
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }

    // var telegram = new Messenger<Message>();             // Использует объекты Message
    // telegram.SendMessage(new Message("Hello World"));    // Инициализация Message

    // var outlook = new Messenger<EmailMessage>();
    // outlook.SendMessage(new EmailMessage("Bye World"));

    // Список всех ограничений
    // where T : struct	    int, double	            T должен быть структурой
    // where T : class	    string, object	        T должен быть ссылочным типом
    // where T : new()	    T obj = new T();	    T должен иметь конструктор по умолчанию
    // where T : ИмяКласса	T : IDisposable	        T должен наследовать указанный класс/интерфейс
    // where T : U	        T : IComparable<T>	    T должен быть производным от U

    // Если для универсального параметра задано несколько ограничений, то они должны идти в определенном порядке:
    // Название класса, class, struct. Причем мы можем одновременно определить только одно из этих ограничений
    // Название интерфейса
    // new()

    public interface IEntity {}
    public class Repository<T> where T : class, IEntity, new()
    {
        public void Add(T entity)
        {
            var newEntity = new T();
            // ...
        }
    }

    // Использование нескольких универсальных параметром
    class Messenger<P,T> 
    where P : PersonObject
    where T : MessageObject
    {
        public void SendMessage(P sender, P receiver, T message)
        {
            Console.WriteLine($"Отправитель: {sender.Name}");
            Console.WriteLine($"Получатель: {receiver.Name}");
            Console.WriteLine($"Сообщение: {message.Text}");
        }
    }
    class PersonObject
    {
        public string Name { get;}
        public PersonObject(string name) => Name = name;
    }
    
    class MessageObject
    {
        public string Text { get; } // текст сообщения
        public MessageObject(string text) =>  Text = text;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------//

    // Наследование обобщённых типов

    // Обобщённые классы могут наследоваться, при этом можно:
    // Закрыть обобщённый тип (указать конкретный тип).
    // Оставить обобщённый тип открытым (передать его производному классу).
    // Добавить новые обобщённые параметры.

    public class Base<T>()
    {
        public T? Data { get; set; }
    }
    
    // Наследование с указанием конкретного типа
    public class IntDerived : Base<int>
    {
        public void PrintData()
        {
            Console.WriteLine(Data);
        }
    }
    
    // Использование
    // var obj = new IntDerived();
    // obj.Data = 42;
    // obj.PrintData(); // 42

    // Сохранение обобщения в наследнике
    public class BaseSave<T>
    {
        public T? Data { get; set; }
    }

    // Производный класс тоже обобщённый
    public class Derived<T> : BaseSave<T>
    {
        public void LogData()
        {
            Console.WriteLine($"Data: {Data}");
        }
    }

    // Использование
    // var stringObj = new Derived<string>();
    // stringObj.Data = "Hello";
    // stringObj.LogData(); // Data: Hello

    // Дополнительное обобщение в наследнике

    public class BaseAddition<T>
    {
        public T? Value { get; set; }
    }

    // Производный класс добавляет новый параметр U
    public class DerivedParams<T, U> : BaseAddition<T>
    {
        public U? AdditionalData { get; set; }
    }

    // Использование
    // var obj = new DerivedParams<int, string>();
    // obj.Value = 100;
    // obj.AdditionalData = "Extra";
}