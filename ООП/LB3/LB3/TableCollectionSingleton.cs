using System;
using System.Collections.Generic;
using System.Text;


namespace LB3
{
    public class TableCollectionSingleton : IDisposable
    {
        public void Dispose()
        {
            //Удаление объекта
        }

        private static TableCollectionSingleton instance;

        public static TableCollectionSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new TableCollectionSingleton();
            }
            return instance;
        }

        public static TableCollectionSingleton GetInstance(Table[] data)
        {
            if (instance == null)
            {
                instance = new TableCollectionSingleton(data);
            }
            return instance;
        }

        public Table[] data; //private



        private TableCollectionSingleton()
        {
            data = new Table[0];
        }
        private TableCollectionSingleton(Table[] data)
        {
            this.data = data;
        }
        public void Add(Table t)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = t;//-1
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
            { return data.Length; }
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

        public override bool Equals(object obj) /////////
        {
            if (obj == null)
                return false;
            TableCollectionSingleton t2 = obj as TableCollectionSingleton;
            if ((t2 == null) || (this.data.Length != t2.data.Length))
                return false;
            // return (this.data == t2.data);

            for (int i = 0; i < t2.data.Length; i++)
                if (this.data[i] != t2.data[i])
                    return false;
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (Table i in data)
                hash += i.GetHashCode();

            return hash;
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder("Список элементов\n");
            foreach (Table i in data)
            {
                //temp +=(StringBuilder)($"\n{i.ToString()}\n");
                temp.Append($"\n{i.ToString()}\n");
            }
            string rez = temp.ToString();
            return rez;

        }
        public Table this[int index]
        {
            get
            { return data[index]; }
            set
            { data[index] = value; }
        }

        public TableCollectionSingleton Merge(TableCollectionSingleton col)
        {
            TableCollectionSingleton rez = new TableCollectionSingleton();
            foreach (Table i in col.data)
                foreach (Table j in this.data)
                    if (i == j)
                        rez.Add(i);
            for (int i = 0; i < rez.data.Length; i++)
                for (int j = i + 1; j < rez.data.Length; j++)
                    if (rez.data[i] == rez.data[j])
                        rez.Delete(j);
            return rez;
        }
    }
}
