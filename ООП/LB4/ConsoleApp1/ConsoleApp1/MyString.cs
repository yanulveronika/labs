using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MyString
    {
        private StringBuilder data;
        private Date date;
        private Owner owner;
        public MyString(string str)
        {
            SetString(str);
        }
        public MyString()
        {
            SetString("");
        }
        public MyString(MyString copy)
        {
            this.data = copy.data;
            this.date = copy.date;
            this.owner = copy.owner;
        }
        public void SetString(string str)
        {
            this.data = new StringBuilder(str);
        }
        public string GetString()
        {
            return data.ToString();
        }
        public override string ToString()
        {
            return GetString();
        }
        public MyString(char[] arr)
        {
            foreach (char i in arr)
                data.Append(i);
        }
        public char this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                data[i] = value;
            }
        }
        public void SetOwner(string i, string n, string o)//ID, Name, Organization
        {
            this.owner = new Owner(i, n, o);
        }
        public Owner GetOwner()
        {
            return this.owner;
        }
        public void SetDate(uint d, uint m, uint y) //Day, Month, Year
        {
            this.date = new Date(d, m, y);
        }
        public Date GetDate()
        {
            return this.date;
        }

        public static bool operator < (MyString s1, MyString s2)
        {
            int num1 = 0;
            int num2 = 0;
            int l = 0;
            int r = l;
            for (r = 0; r < s1.ToString().Length; r++)
            {
                if (s1[r]==' ')
                {
                    if (num1 < r - l - 1)
                        num1 = r - l - 1;
                    if (r + 1 < s1.ToString().Length)
                        l = r + 1;
                   
                }
            }
            l = 0;
            for (r = 0; r < s2.ToString().Length; r++)
            {
                if (s2[r] == ' ')
                {
                    if (num2 < r - l - 1)
                        num2 = r - l - 1;
                    if (r + 1 < s2.ToString().Length)
                        l = r + 1;

                }
            }
            return num1 < num2;
        }
        public static bool operator >(MyString s1, MyString s2)
        {
            return !(s1 < s2);
        }
        public static MyString operator +(MyString s,int num)
        {
            MyString ret = new MyString(s);
            ret.data.Append(num.ToString());
            return ret;
        }
        public static MyString operator --(MyString s)
        {
            MyString ret = new MyString(s);
            ret.data = ret.data.Remove((ret.ToString().Length - 1),1);
            return ret;
        }
        public static MyString operator *(MyString s,char c)
        {
            MyString ret = new MyString(s);
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < ret.data.ToString().Length; i++)
                temp.Append(c);
            ret.data = temp;
            return ret;
        }

        public class Owner
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Organization { get; set; }

            public Owner()
            {
                Id = "unknown";
                Name = "unknown";
                Organization = "unknown";
            }
            public Owner(string i, string n, string o)
            {
                Id = i;
                Name = n;
                Organization = o;
            }
        }

        public class Date
        {
            public uint day { get; set; }
            public uint month { get; set; }
            public uint year { get; set; }
            public Date()
            {
                day = 0;
                month = 0;
                year = 0;
            }
            public Date(uint d,uint m, uint y)
            {
                day = d;
                month = m;
                year = y;
            }
        }
    }
}
