using System;
using System.Collections.Generic;
using System.Text;

namespace LB9
{
    class Director
    {
        public void Up()
        {
            Console.WriteLine("Повышение!");
        }
        public void Down()
        {
            Console.WriteLine("Штраф!");
        }
    }
    class Student
    {
        private string name;

        public delegate void del();
        public del _del;
       
        public void CallDelegate()
        {

            if (_del != null)
            {
                Console.WriteLine("Объект Student " + name + ' ');
                _del();
            }
            else
                Console.WriteLine("Объект Student " + name + " пустой делегат");
            //_del?.Invoke();
        }
        public Student(string name) => this.name = name;

    }
    class Turner
    {
        public Turner(string name) => this.name = name;
        private string name;
        public delegate void del();
        private del _deleg;
        public event del deleg
        {
            add
            {
                _deleg += value;
            }
            remove
            {
                _deleg -= value;
            }
        }
        public void CallDelegate()
        {


            if (_deleg != null)
            {
                Console.WriteLine("Объект Turner " + name + ' ');
                _deleg.Invoke();
            }
            else
                Console.WriteLine("Объект Turner " + name + " пустой делегат");
            //_del?.Invoke();


        }
    }
}
