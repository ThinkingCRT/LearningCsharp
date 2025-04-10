namespace Basic.OOPMethods 
{
    // Наследование - унаследование функционала другого класса, единственное, что не наслед. - конструкторы
    // Класс который наследует - дорчерний, от которого наследуется - родительский или (суперкласс).
    // Объект дочернего класса, так же является объектом родительского
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
}