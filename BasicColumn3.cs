namespace Basic.BasicColumn3
{
    class BasicCS3
    {
        public static void Column3() 
        {
            //--------------------------------------------------------------------------------------------------------------------------------------//
            // Условные конструкции
            /******************************************************************* 
            if, else if, else - есть ещё switch/case ниже - алтернатива
            if, else if, else:
            для сложных условий - диапозоны, комбинированные проверки
            условия от 3-5
            для сложной логики
            любые логические выражения
            ******************************************************************/
            bool accessLuck = true;
            string isAdmin = "Admin";
            // два условия с логическим оператором "И" (для простой логики, сложнее отладка, производительность выше, чем у влож.if)
            if (accessLuck == true && isAdmin == "Admin")
            {
                Console.WriteLine("Разрешён полный доступ!");
            }
            // одно условие совпало
            else if (accessLuck == true)
            {
                Console.WriteLine("Разрешён доступ для чтения!");
            }
            // если два условия не совпадают, то отрабатывает этот код
            // по сути, ecли конструкция с одной строкой, то можно убрать скобки, if>1=>ошибка
            else
                Console.WriteLine("Доступе запрещён!"); 
            // альтернатива конструкции выше (для сложной логики, легче отладка, производительность меньше)
            if (accessLuck == true)                             
            {
                if (isAdmin == "Admin")
                {
                    Console.WriteLine("Разрешён полный доступ!");
                }
            }
            else if (accessLuck == true)
            {
                Console.WriteLine("Разрешён доступ для чтения!");
            }

            /*******************************************************************
            switch/case:
            проверка одной переменной на мн.значений
            условия 5+
            работа с перечислениями enum
            Pattern Maching C#7+
            поддержка сложных условий when
            switch expression C#8+
            в case можно использовать return - case значение: return;
            *******************************************************************/
            // Стандартный switch
            string days = "Night";
            string? dbAD = null;
            switch (days) 
            {
                case "Moning":
                    dbAD = "Moning";
                    break;
                case "Aftenoon":
                    dbAD = "Aftenoon";
                    break;
                case "Evening":
                    dbAD = "Evening";
                    break;
                case "Night":
                    dbAD = "Night";        // игнорит эту операцию
                    goto case "Midnight";  // переходи в midnight
                case "Midnight":
                    dbAD = "Midnight";     // получает значение от сюда
                    break;
                default:                   // аналог - else
                    Console.WriteLine("Это НЕ время дня!");
                    break;
            }
            Console.WriteLine($"Добавление данных в db: {dbAD}");
            // switch expression C#8+
            int? operation = 2;
            int vol1 = 61;
            int vol2 = 32;
            int result = operation switch
            {
                1 => vol1 + vol2,
                2 => vol1 - vol2,
                _ => 0
            };
            Console.WriteLine(result);

            //--------------------------------------------------------------------------------------------------------------------------------------//
            // Циклы
            /*******************************************************************
            For, Foreach, While, Do While
            for → Когда нужен индекс или точно известно число итераций.
            while → Когда условие выхода неизвестно заранее (например, ожидание события).
            foreach → Для простого перебора коллекций без управления индексом.
            ********************************************************************/
            int x = 10;
            for (; x>0; x--)
            {
                Console.WriteLine($"Значение x = {x}"); //1
            }
            int y = 10;
            do
            {
                Console.WriteLine($"Значение i = {y}"); //1
                y--;
            }
            while (y>0); 
            int z = 10;
            while(z>0)
            {
                Console.WriteLine($"Значение y = {z}"); //1
                z--;
            }
            // циклы в цикле
            // всего выполняется 9 итераций
            for (int i = 1; i < 10; i++)
            {
                // в рамках каждой итерации массив(родитель) выполняет одну, а дочерний 9         
                for (int j = 1; j < 10; j++)
                {
                    Console.Write($"{i * j} \t");
                }
                // каждая последующая итерация, после 9-ти дочерних, переносит на новую строку
                Console.WriteLine();              
            }
            // continue, break
            for(int br = 10; br>0; br--)
            {
                // четные числа не удовлетворяют условия и цикл продолжается
                if(br % 2 == 0) continue;
                // как только итерация доходит до 3-ки, цикл останавливается и 3-ку не выводит
                if(br == 3) break;
                Console.WriteLine($"Переменная br = {br}");
            }
            //--------------------------------------------------------------------------------------------------------------------------------------//

            // Массивы
            /******************************************************************* 

            Способы написание массивов
            // Одномерные массивы
            // Самый лаконичный, но нельзя использовать в методах, где тип не ясен
            int[] numbers = { 1, 2, 3, 4, 5 };
            // Тип выводится автоматически (int[]), можно использовать, где тип не ясен
            var numbers = new[] { 1, 2, 3 };
            // Избыточный, в старых версиях C#
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            // Самый удобный с C#12+, так же и в коллекциях
            int[] numbers = [ 1, 2, 3, 4, 5 ];
            // Самый оптимальный метод для написания пустого массива
            int[] empty1 = Array.Empty<int>(); // Оптимально (переиспользует память)
            // Многомерные массивы
            int[строка,столбец] dvm = new int[2,3] 	// [,] - два измерения массива (ранг, rank)
                                                    // длина измерений (2,3 dimension length)   								
                                                    // длина массива (5 array length)
            {1,2,3}, 	// (row, x, длинна)Строка 0, (column, y, высота)Столбец 0,1,2
            {4,5,6} 	// (row, x, длинна)Строка 1, (column, y, высота)Столбец 0,1,2


            св-ва:  array.GetLength(0) - число строк, 
                    array.GetLength(1) - число столбцов
                    array.Length	   - число эллементов в массиве
                    array.Rank         - число измерений
            // Массивы в массиве
            int[][] ZB = {
                new int[] { 1, 2 }, 
                new int[] { 1, 2, 3 }, 
                new int[] { 1, 2, 3, 4, 5 } 
            };
            ********************************************************************/
            // Перебор массивов с помощью циклов
            // Одномерный массив
            int[] nump = [4, 4, 5, 7, 8, 10, 23, 435];  // обозначение одномерного массива

            // для чтения
            foreach (int i in nump) 
            {                   // из массива nump всё помещается в i
                Console.Write(" " + i + " ");           // все данные в i
                //Console.WriteLine(nump);              // массив пустой
            }
            // для перебора с изменениями
            // переменная i пустая, идёт просчитывание эллементов в массиве и помещается в i
            for (int i = 0; i < nump.Length; i++) 
            {
                nump[i] = nump[i] * 2;                  // можно изменять значения в массиве
                Console.Write(" " + nump[i] + " ");     // аналогично foreach
                //Console.Write(nump);                  // аналогично foreach
            }
            int i1 = 0;
            // идёт просчитывание эллементов в массиве и помещается в i1
            while (i1 < nump.Length) 
            {
                Console.Write(" " + nump[i1] + " ");    // аналогично foreach
                //Console.Write(nump);                  // аналогично foreach
                i1++;
            }
            Console.WriteLine("");  // для переноса строрки
            //--------------------------------------------------------------------------------------------------------------------------------------//
            // Многомерные массивы
            int[,] matrix = {
                {1,2,3},
                {4,5,6}
            };
            int columnY = matrix.GetLength(0);                 // индексы колон массива передаются в Y
            int rowX = matrix.GetLength(1);                    // индексы строк массива передаются в X
            // для перебора с изменениями
            for (int i = 0; i < columnY; i++) {                // в i помещаются индексы колонок
                for (int j = 0; j < rowX; j++) {               // в j помещаются индексы строк
                    Console.Write(matrix[i,j] + "\t" );        // итерация->инициализирует ячейку по индексам->значение->tab
                } 
                Console.WriteLine();
            }

            //--------------------------------------------------------------------------------------------------------------------------------------//
            // Массивы в массиве
            int[][] ZB = {
                new int[] { 1, 2 }, 
                new int[] { 1, 2, 3 }, 
                new int[] { 1, 2, 3, 4, 5 } 
            };

            //Для перебора с изменениями
            for (int i = 0; i < ZB.Length; i++){          // в переменную i помещает индексы колонок, проводится 3 итерации 1-2, 1-3, 1-5
                for(int j = 0; j < ZB[i].Length; j++){    // в переменную j помещает индексы строк, проводит 10 итераций 1-2, 1-3, 1-5
                    Console.Write(ZB[i][j] + "\t");       // итерация->инициализирует ячейку по индексам->значение->tab
                }
                Console.WriteLine();                        // Отсупаем строку
            }

            // для чтения
            foreach(int[] row in ZB){               // из ZB - перемещает колонки, т.к. берёт int[]
                foreach(int index in row){          // по какой-то причине от сюда берёт строки
                    Console.Write($"{index} \t");
                }
                Console.WriteLine();
            }
        }
    }
}