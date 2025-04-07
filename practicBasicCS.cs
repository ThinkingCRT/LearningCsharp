namespace Basic.Practic
{
    // Во-время изучения основ
    class CalculatorBegin 
    {
        public static void Practic() 
        {
            // Калькулятор
            double kalkResult = 0;
            bool checkAct = true;
            
            Console.Write("Введите первое значение: ");
            string? input1 = Console.ReadLine();
            if (double.TryParse(input1, out double value1))
            {
                Console.Write("Введите действие (+, -, *, /): ");
                string? action = Console.ReadLine();

                Console.Write("Введите второе значение: ");
                string? input2 = Console.ReadLine();

                if (double.TryParse(input2, out double value2))
                {
                    switch (action) 
                    {
                        case "+":
                            kalkResult = value1 + value2;
                            break;
                        case "-":
                            kalkResult = value1 - value2;
                            break;
                        case "*":
                            kalkResult = value1 * value2;
                            break;
                        case "/":
                            if (value2 != 0)
                            {
                                kalkResult = value1 / value2;
                            }
                            else 
                            {
                                Console.Write("На ноль делить нельзя! ");
                            }
                            break;
                        default:
                            Console.WriteLine("Неверный формат действия");
                            checkAct = false;
                            break;

                    }
                    if (checkAct == true)
                    {
                        Console.WriteLine($"Результат: {kalkResult}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: неверный формат значения!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: неверный формат значения!");
            }
        }
    }
//--------------------------------------------------------------------------------------------------------------------------------------//
//-------------------------------Условные конструкции-----------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//

    // Во-время изучения class, structure, namespace 

    // Напишите консольную программу, в которую пользователь вводит с клавиатуры два числа. 
    // А программа сранивает два введенных числа и выводит на консоль результат сравнения 
    // (два числа равны, первое число больше второго или первое число меньше второго).
    class ComparingTwoNumbs
    {
        protected double numInt1;
        protected double numInt2;
        internal ComparingTwoNumbs()
        {
            Console.Write("Введите первое значение: ");
            // Пока условие цикла не будет выполненно, ввод числа будет продолжаться
            // Условие - пока не будет числа, цикл будет выдавать исключение
            // Если условие выполненно, то input1 помещает значение в numInt1
            string? input1 = Console.ReadLine();
            while(!double.TryParse(input1, out numInt1))
            {
                Console.WriteLine("Некорректный ввод, введите число!");
                Console.Write("Введите первое значение: ");
                input1 = Console.ReadLine();
            }
            Console.Write("Введите второе значение: ");
            string? input2 = Console.ReadLine();
            // Аналогично циклу выше
            while(!double.TryParse(input2, out numInt2))
            {
                Console.WriteLine("Некорректный ввод, введите число!");
                Console.Write("Введите второе значение: ");
                input2 = Console.ReadLine();
            }
            // После полученных значений, сравниваем их
            ComparingNumbs();
        }
        
        internal void ComparingNumbs()
        {
            if (numInt1 == numInt2)
                Console.WriteLine("Два значения равны");
            else if (numInt1 > numInt2)
                Console.WriteLine("Первое число больше второго");
            else if (numInt1 < numInt2)
                Console.WriteLine("Первое число меньше второго"); 
        }       
    }
    
    // Напишите консольную программу, в которую пользователь вводит с клавиатуры число. 
    // Если число одновременно больше 5 и меньше 10, то программа выводит 
    // "Число больше 5 и меньше 10". Иначе программа выводит сообщение "Неизвестное число".
    class RangeNumbs
    {
        private double _num;

        internal RangeNumbs()
        {
            Console.Write("Введите значение в диапозоне от 5-10: ");
            _num = TransformStringToDouble();
        }

        private double TransformStringToDouble()
        {
            // Бесконечный цикл
            while (true)
            {
                // Инициализация строки с записью в коньсоль
                string? input = Console.ReadLine();

                // Проверка на число
                if (!double.TryParse(input, out double number))
                {
                    Console.WriteLine("Некорректное значение, введите число!");
                    Console.Write("Введите значение в диапазоне от 5 до 10: ");
                    // Продолжеает цикл, пока не будет - true
                    continue;
                }

                // Проверка диапазона
                if (number >= 5 && number <= 10)
                {
                    return number;
                }

                Console.WriteLine($"Число {number} не входит в диапазон от 5 до 10");
                Console.Write("Введите значение в диапазоне от 5 до 10: ");
            }
        }
    }
    
    // В банке в зависимости от суммы вклада начисляемый процент по вкладу может отличаться. 
    // Напишите консольную программу, в которую пользователь вводит сумму вклада. 
    // Если сумма вклада меньше 100, то начисляется 5%. 
    // Если сумма вклада от 100 до 200, то начисляется 7%. 
    // Если сумма вклада больше 200, то начисляется 10%. 
    // В конце программа должна выводить сумму вклада с начисленными процентами.
    class Deposit
    {
        private const string AmountInputMessage = "Введите сумму вклада: ";
        private const string AmountIncorrectInputMessage = "Некорректное значение, введите положительное число";
        private const string AmountPercentMessage = "Процентная ставка: ";
        private const string AmountWithPercentMessage = "Сумма вклада с процентом: ";
        private const string AmountWithCashbackMessage = "Сумма вклада с бонусом 15 едениц: ";
        private const string FinalAmountMessage = "Сумма вклада с процентами и бонусом: ";

        

        public double DepositAmount { get; private set; }
        public double DepositAmountPercent { get; private set; }
        public double DepositAmountWhithPercent { get; private set; }
        public double DepositAmountWhithCashback { get; private set; }
        public double DepositAmountResult { get; private set; }

        internal Deposit()
        {
            Console.Write(AmountInputMessage);
            DepositAmount = AmountInitial();
            DepositAmountWhithPercent = AmountPercentResult();
            DepositAmountWhithCashback = AmountCashbackResult();
            DepositAmountResult = FinalAmountResult();
            DisplayProgramMessage();
        }

        private double AmountInitial()
        {
            while (true)
            {
                string? inputValue = Console.ReadLine();
                // Если не число или отрицательное число, начинается заново
                if(!double.TryParse(inputValue, out double amount) || amount <= 0)
                {
                    Console.WriteLine(AmountIncorrectInputMessage);
                    Console.Write(AmountInputMessage);
                    continue;
                }
                return amount;
            }
        }
        
        private double AmountPercentResult()
        {
            // структура switch exeption конструкции - 
            // DepositAmount < 100 AppliedPercent = 5, 
            // DepositAmount < 200 AppliedPercent = 7, 
            // DepositAmount > 200 AppliedPercent= 10
            DepositAmountPercent = DepositAmount switch 
            { 
                <= 100 => 5, 
                <= 200 => 7,
                     _ => 10
            };
            return DepositAmount * (1 + DepositAmountPercent / 100);
        }
        
        // Задание 4
        // Допустим, банк периодически начисляет по всем вкладам, кроме процентов бонусы. 
        // И, допустим, сейчас банк решил доначислить по всем вкладам 15 единиц вне зависимости от их суммы.
        private double AmountCashbackResult()
        {
            return DepositAmount + 15;
        }

        // Самодеятельность
        private double FinalAmountResult()
        {
            double Percent = DepositAmountWhithPercent - DepositAmount;
            double Cashback = DepositAmountWhithCashback - DepositAmount;
            double Result = DepositAmount + Percent + Cashback;
            return Result;
        }

        private void DisplayProgramMessage()
        {
            Console.WriteLine($"{AmountPercentMessage}{DepositAmountPercent}");
            Console.WriteLine($"{AmountWithPercentMessage}{DepositAmountWhithPercent:N2}");
            Console.WriteLine($"{AmountWithCashbackMessage}{DepositAmountWhithCashback:N2}");
            Console.WriteLine($"{FinalAmountMessage}{DepositAmountResult:N2}");
        }

    }


    // Задание 5
    // Данны три вещественных числа a,b,c проверьте 
    // 1) является ли равенство a<b<c true
    // 2) является ли равенство b>a>c true
    class EqualityTreeNumbers 
    {
        private const string InputNumbersMessage = "Введите число: ";
        private const string InputNumbers1Message = "Введите первое число: ";
        private const string InputNumbers2Message = "Введите второе число: ";
        private const string InputNumbers3Message = "Введите третье число: ";
        private const string InputIncorrectNumbersMessage = "Некорректное введение числа!";
        private const string FirstResultEqualityMessage = "Равенство a<b<c верно!";
        private const string SecondResultEqualityMessage = "Равенство b>a>c верно!";
        private const string TreeResultEqualityMessage = "Равенство a<b<c НЕверно!\nРавенство b>a>c НЕверно!";
        
        internal EqualityTreeNumbers()
        {
            Print(InputNumbers1Message);
            Numbers1 = InputNumbers();
            Print(InputNumbers2Message);
            Numbers2 = InputNumbers();
            Print(InputNumbers3Message);
            Numbers3 = InputNumbers();
            DisplayDanoResult();
            DisplayEqualityFirstResult();
        }

        public double Numbers1 { get; private set;}
        public double Numbers2 { get; private set;}
        public double Numbers3 { get; private set;}

        private double InputNumbers()
        {
            while(true)
            {
                string? transormToNum = Console.ReadLine();
                if(!double.TryParse(transormToNum, out double numbers) || numbers < -9000000000000 || numbers > 9000000000000)
                {
                    PrintLine(InputIncorrectNumbersMessage);
                    Print(InputNumbersMessage);
                    continue;
                }
                return numbers;
            }
        }

        private void DisplayDanoResult()
        {
            PrintLine($"a = {Numbers1:N2}, b = {Numbers2:N2}, c = {Numbers3:N2}");
        }

        private void DisplayEqualityFirstResult()
        {
            if (Numbers1 < Numbers2 && Numbers2 < Numbers3)
                PrintLine(FirstResultEqualityMessage);
            else if (Numbers2 > Numbers1 && Numbers1 > Numbers3)
                PrintLine(SecondResultEqualityMessage);
            else
                PrintLine(TreeResultEqualityMessage);
        }

        private void Print(string message)
        {
            Console.Write(message);
        }

        private void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }

//--------------------------------------------------------------------------------------------------------------------------------------//
//-------------------------------Циклы--------------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------------------------//
}