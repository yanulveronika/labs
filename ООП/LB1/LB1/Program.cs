using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            int iVar;
            char cVar;
            bool bVar;
            string sVar;
            double dVar;
            Console.WriteLine("Введите целое, символ, булевое, строку и дробное значения");
            iVar = int.Parse(Console.ReadLine());
            cVar = char.Parse(Console.ReadLine());
            bVar = bool.Parse(Console.ReadLine());
            sVar = Console.ReadLine();
            dVar = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"iVar =  {iVar}\ncVar =  { cVar}\nbVar =  {bVar}\nsVar =  {sVar}\ndVar =  {dVar}");
          
            object oiVar = iVar;
            Console.WriteLine($"oiVar = {oiVar}");
            iVar = (int)oiVar + 1;
            Console.WriteLine($"iVar = {iVar}");

            int imyGroup = 1;
            long lmyGroup = imyGroup;
            imyGroup = (int)lmyGroup;
            string smyGroup = Convert.ToString(imyGroup);
            imyGroup = int.Parse(smyGroup);
            Console.WriteLine($"imyGroup = {imyGroup}, lmyGroup = {lmyGroup}, smyGroup = {smyGroup}");

            string myName = "Антон";
            Console.WriteLine("My name is {0}", myName);
            Console.WriteLine($"My name is {myName}");

            int firstNum = 1;
            int secondNum = 8;
            string sum = firstNum.ToString() + secondNum.ToString();
            Console.WriteLine($"sum = {sum}\nsum type - {sum.GetType()}");


            string str1 = "abc";
            string str2 = "bc";
            Console.WriteLine("Сравнение строк: " + String.Compare(str1, str2));
            Console.WriteLine("Содержит ли первая строка вторую: " + str1.Contains(str2));
            Console.WriteLine("Подстрока, начиная с символа 1: " + str1.Substring(1));
            Console.WriteLine("Вставка в строку,начиная с символа 1: " + str1.Insert(1,str2));///
            Console.WriteLine("Замена букв b на D: " + str1.Replace('b', 'D'));

            string emptyString = "";
            string nullString = null;
            Console.WriteLine($"emptyString is null or empty: {string.IsNullOrEmpty(emptyString)}\nnullString is null or empty: {string.IsNullOrEmpty(nullString)}\nstr1 is null or empty: {string.IsNullOrEmpty(str1)}");

            dynamic variable = ""; //var variable = "";
            variable = 5;

            int? nullableVar = null;
            if (nullableVar.HasValue)
                Console.WriteLine(nullableVar.Value);
            else
                Console.WriteLine("nullableVar = null"); //nullableVar.value - нельзя
            
            ShowTuple((2, 3));

            var namedTuple = (Name: "Vasya", age: 20, city: "Minsk");

            (string name, int age, string city) = namedTuple;
            var (name2, age2, city2) = namedTuple;
            (var name3, int age3, var city3) = namedTuple;
            string name4;
            int age4;
            string city4;
            (name4, age4, city4) = namedTuple;
            (_, int onlyAge, _) = namedTuple;



            Console.WriteLine($"Unchecked: {UncheckedFunc()}\n");
           // Console.WriteLine($"Checked: { CheckedFunc()}\n"); ///////

            using (Example ex1 = new Example(23))
            {
                Console.WriteLine($"ex1.state = {ex1.GetState()}\n");
            }

           

            void ShowTuple((int,int) tuple)
            {
                Console.WriteLine($"\nПервое поле кортежа: {tuple.Item1}\nВторое поле кортежа: {tuple.Item2}\n");
            }
            int UncheckedFunc()
            {
                int one = 1;
                int a = Int32.MaxValue + one;
                return a;
            }
            int CheckedFunc()
            {
                checked
                {
                    int one = 1;
                    int a = Int32.MaxValue + one;
                    return a;
                } 
            }
        }
      
           
    }
    class Example : IDisposable
    {
        private readonly int _state;

        public Example(int state)
        {
            _state = state;
        }

        public int GetState() => _state;
        public void Dispose() { }
    }
}
