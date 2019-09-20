using System;
using System.Collections.Generic;
using System.Text;

namespace LB3
{
    class TableCollection
    {
        Table[] data = new Table[0];

        public void Add(Table t)
        {            
            Array.Resize(ref data, data.Length+1);
            data[data.Length - 1 ] = t;//-1
        }
        public Table Delete(int num)
        {
            if ((data.Length > 0) && (num < data.Length) && (num >= 0))
            {
                Table temp = data[num];
                for (int i = num; i < data.Length - 1; i++)
                    data[i] = data[i + 1];
                Array.Resize(ref data, data.Length - 1);
                return temp;

            }
            else
            {
                Console.WriteLine("Ошибка удаления элемента");
                return null;
            }
        }
       
        public int Count
        {
            get
            {
                return data.Length;
            }
        }
        public void Search()
        {
            Table[] temp = new Table[0];
            int answer;
            do
            {
                Console.WriteLine("Выберите поле для поиска:\n1 - Высота\n2 - Ширина\n3 - Длина\n4 - Цена");
                answer = Convert.ToInt32(Console.ReadLine());
            } while (!(answer > 0) && (answer < 5));
            Console.WriteLine("Введите значение поля: ");
            string val = Console.ReadLine();
            int num;
            if (int.TryParse(val, out num))
            {
                switch (answer)
                {
                    case 1:
                        temp = Array.FindAll(data, i => i.height == num);
                        //return temp;
                     break;
                    case 2:
                        temp = Array.FindAll(data, i => i.width == num);
                        //return temp;
                     break;
                    case 3:
                        temp = Array.FindAll(data, i => i.Depth == num);
                       // return temp;
                     break;
                    case 4:
                        temp = Array.FindAll(data, i => i.Price == num);
                        //return temp;
                         break;
                }
            }
            else Console.WriteLine("Ошибка ввода");
            //return null;
            if (temp.Length == 0)
            {
                Console.WriteLine("Не найдено элементов ");
            }
            else
            {
                foreach (Table i in temp)
                    Console.WriteLine(i.ToString());
            }

        }

        ////public override bool Equals(object obj) /////////
        ////{
        ////    if (obj == null)
        ////        return false;
        ////    TableCollection t2 = obj as TableCollection;

        ////}
        //public override int GetHashCode()
        //{ }
        // public override string ToString()
        //{ }
        public Table this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
}
