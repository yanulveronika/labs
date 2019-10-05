using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyString s1 = new MyString("abc, defgabc! ijk...");
            MyString s2 = new MyString("ab cdefgjhkkf kk");

            s1.SetOwner("abc", "Mike", "Example Corp.");
            s2.SetOwner("dgc", "Bob", "ABC Corp.");
            s1.SetDate(23, 6, 2001);
            s2.SetDate(26, 4, 1986);

            Console.WriteLine(s1 < s2);
            Console.WriteLine(s1 + 5);
            Console.WriteLine(--s2);
            Console.WriteLine(s2 * 'd');
            Console.WriteLine(s1[2]);


            MyString s3 = new MyString("abcd /efgh");
            Console.WriteLine($"{s1.ServiceCheck()}\n{s3.ServiceCheck()}");
            Console.WriteLine(s1.DeletePunctuation());
        }
    }
}
