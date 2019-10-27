using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectionType<int> col = new CollectionType<int>();
            //col.Add(5);
            //col.Add(7);

            //CollectionType<bool> col2 = new CollectionType<bool>();
            //col2.Add(true);
            //col2.Add(false);
            //col2.Add(false);
            //col2.Add(true);
            //Console.WriteLine(col2.ToString());
            //Console.WriteLine(col2.Get(3));
            //Console.WriteLine(col2.Get(-2));
            CollectionType<MyString> col = new CollectionType<MyString>();
            col.Add(new MyString("abc"));
            col.Add(new MyString("xyz"));
            Console.WriteLine(col.ToString());
            col.WriteFile();
            CollectionType<MyString> col2 = new CollectionType<MyString>();
            col2.ReadFile();
            Console.WriteLine(col2.ToString());
        }
    }
}
