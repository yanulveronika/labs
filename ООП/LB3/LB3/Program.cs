using System;

namespace LB3
{
    partial class Table
    {
        public static bool isBroken;
        public static void BreakTheTable()
        {
            isBroken = true;
        }
        public static void RepareTheTable()
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
           if (d > 0) price = c;
        }
        public Table(int a, int b, int c,int d, string str)
        {
            if (a > 0) height = a;
            if (b > 0) width = b;
            if (c > 0) depth = c;
            if (d > 0) price = c;
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
            
            TableInfo.GetInfo(t1);
            var anon = new { height = 10, width = 20, depth = 30, price = 100, model = "T-1" };
           
        }
    }
    
}
