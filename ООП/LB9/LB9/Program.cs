using System;

namespace LB9
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Director dir = new Director();
            Student s1 = new Student("Vasya");
            s1.CallDelegate();
            s1._del = dir.Down;
            s1._del += dir.Up;
            s1._del();
            s1.CallDelegate();
            Turner t1 = new Turner("Petya");
            t1.deleg += dir.Up;
            t1.deleg += dir.Down;
            t1.deleg += dir.Up;
            t1.deleg += dir.Down;
            t1.deleg -= dir.Down;
            //t1.deleg();
            t1.CallDelegate();
            t1.deleg += delegate
             {
                 Console.WriteLine("Анонимная функция");
             };
            t1.deleg += () => Console.WriteLine("Лямбда-функция");
            t1.CallDelegate();
        }
        
    }
}
