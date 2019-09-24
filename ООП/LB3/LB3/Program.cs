using System;

namespace LB3
{
    public partial class Table
    {
        public static bool isBroken;
        public static void BreakTheTables()
        {
            isBroken = true;
        }
        public static void RepareTheTables()
        {
            isBroken = false;
        }
        public Table()
        {
            model = "Unknown";
            isBroken = false;
        }
        public Table(int a, int b, int c,int d)
        {
           if (a > 0) height = a;
           if (b > 0) width = b;
           if (c > 0) depth = c;
           if (d > 0) price = d;
        }
        public Table(int a, int b, int c,int d, string str)
        {
            if (a > 0) height = a;
            if (b > 0) width = b;
            if (c > 0) depth = c;
            if (d > 0) price = d;
            model = str;
        }
        public Table(string str)
        {
            model = str;
        }
        public Table(Table tbl)
        {
            this.model = tbl.model;
            this.height = tbl.height;
            this.width = tbl.width;
            this.depth = tbl.depth;
            this.price = tbl.price;
        }

        static Table()
        {
            Console.WriteLine("Table created");
        }

        

        ~Table()
        { }

        public int height { get; set; }
        public readonly int width;
        private int depth;
        public int Depth
        {
            get { return depth; }
            set { if (value > 0) this.depth = value; }
        }
        private int price;
        private string model;

        public int Price
        {
            get
            {
                return price;
            }
         }
        public string Model
        {
            set
            {
                if (value is string)
                    model = value;
                else
                    Console.WriteLine("Попытка присвоить не строковое значение");
            }
        }
       
    }

    static class TableInfo
    {
        public static void GetInfo(Table t)
        {
            if (t!=null)
                Console.WriteLine( t.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Table t1 = new Table(10, 20, 30, 100, "T-1");
            Table t2 = new Table(30, 20, 10, 80, "T-2");
            TableInfo.GetInfo(t1);
            var anon = new { height = 40, width = 20, depth = 30, price = 300, model = "B-4" };

            TableCollection col1 = new TableCollection();
            col1.Add(t1);
            col1.Add(t2);
            Table[] m1 = new Table[2];
            m1[0] = t1;
            m1[1] = t2;
            TableCollection col2 = new TableCollection(m1);
           Console.WriteLine($"Равны ли коллекции col1 и col2: {col1.Equals( col2 )}\nХеш col1: {col1.GetHashCode()}\nХеш col2: {col2.GetHashCode()}");

            Table t3 = new Table(5, 15, 20, 40, "T-3");
            Table t4 = new Table(35, 25, 20, 40, "T-4");
            TableCollection col3 = new TableCollection();
            col3.Add(t3);
            col3.Add(t1);
            col3.Add(t2);
            col3.Add(t1);

            //TableCollection mt1 = col1.Merge(col3);
            //TableCollection mt2 = col3.Merge(col1);
            //Console.WriteLine("///\n" + col3.ToString());
            //Console.WriteLine(mt1.ToString());
            //Console.WriteLine(mt2.ToString());

            TableCollectionSingleton tcs1;
            tcs1 = TableCollectionSingleton.GetInstance();
            tcs1.Add(t3);
            tcs1.Add(t2);
            tcs1.Add(t1);
            Console.WriteLine(TableCollectionSingleton.GetInstance().ToString());
            TableCollectionSingleton tcs2 = TableCollectionSingleton.GetInstance();
            tcs2.Delete(0);
            Console.WriteLine(TableCollectionSingleton.GetInstance().ToString());
            Console.WriteLine(tcs1.ToString());
        }
    }
    
}
