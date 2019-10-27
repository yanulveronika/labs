using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    interface ICollection<T>
    {
        void Add(T obj);
        T Get(int num);
        void Delete(int num);
    }
    //public class CollectionType<T>: ICollection<T> where T : struct
    //{
    //    public T[] data; //private

    //    public CollectionType()
    //    {
    //        data = new T[0];
    //    }
    //    public CollectionType(T[] data)
    //    {
    //        this.data = data;
    //    }
    //    public void Add(T t)
    //    {
    //        Array.Resize(ref data, data.Length + 1);
    //        data[data.Length - 1] = t;//-1
    //    }
    //    public T Get(int num)
    //    {
    //        try
    //        {
    //            return data[num];
    //        }
    //        catch(Exception e)
    //        {
    //            Console.WriteLine($"{e.Message}");
    //            throw;
    //        }
    //           // return default(T);
    //    }
    //    public void Delete(int num)
    //    {
    //        if ((data.Length > 0) && (num < data.Length) && (num >= 0))
    //        {
    //            for (int i = num; i < data.Length - 1; i++)
    //                data[i] = data[i + 1];
    //            Array.Resize(ref data, data.Length - 1);
    //        }
    //        else
    //            Console.WriteLine("Ошибка удаления элемента");
    //    } 
    //    public T this[int index]
    //    {
    //        get
    //        { return data[index]; }
    //        set
    //        { data[index] = value; }
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder temp = new StringBuilder();
    //        foreach (var i in data)
    //            temp.Append(i.ToString()+" ");
    //        return temp.ToString();
    //    }
    //}

    public class CollectionType<T> : ICollection<T> where T : MyString,new()
    {
        public T[] data; //private

        public CollectionType()
        {
            data = new T[0];
        }
        public CollectionType(T[] data)
        {
            this.data = data;
        }
        public void Add(T t)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = t;//-1
        }
        public T Get(int num)
        {
            try
            {
                return data[num];
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                throw;
            }
            // return default(T);
        }
        public void Delete(int num)
        {
            if ((data.Length > 0) && (num < data.Length) && (num >= 0))
            {
                for (int i = num; i < data.Length - 1; i++)
                    data[i] = data[i + 1];
                Array.Resize(ref data, data.Length - 1);
            }
            else
                Console.WriteLine("Ошибка удаления элемента");
        }
        public T this[int index]
        {
            get
            { return data[index]; }
            set
            { data[index] = value; }
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (var i in data)
                temp.Append(i.ToString() + " ");
            return temp.ToString();
        }
        public void WriteFile()
        {
            
            string text = this.ToString();
            // запись в файл
            using (FileStream fstream = new FileStream(@"D:\file.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }
        public void ReadFile()
        {
            
            using (FileStream fstream = File.OpenRead(@"D:\file.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                int num = 0;
                foreach (char i in textFromFile)
                    if (i == ' ') num++;
                this.data = new T[num];
                int j = 0, count = 0;
                for (int i = 0; i < textFromFile.Length; i++)
                {
                    if (textFromFile[i]==' ')
                    {
                        data[count] = new T();
                        for (int q = j; q < i; q++)
                            data[count].Append(textFromFile[q]);
                        count++;
                        j = i;
                    }
                }

            }
        }
    }
}
