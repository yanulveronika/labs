using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class StatisticOperation
    {
        public static int Count(this MyString str)
        {
            return str.ToString().Length;
        }
        public static bool ServiceCheck(this MyString str)
        {
            HashSet<char> serviceSymbols = new HashSet<char>();
            serviceSymbols.Add('/');
            serviceSymbols.Add('\\');
            serviceSymbols.Add('"');
            serviceSymbols.Add('$');
            foreach (var i in str.ToString())
                if (serviceSymbols.Contains(i))
                    return true;
            return false;
        }
        public static MyString DeletePunctuation(this MyString str)
        {
            MyString temp = new MyString(str);
            HashSet<char> serviceSymbols = new HashSet<char>();
            serviceSymbols.Add('.');
            serviceSymbols.Add(',');
            serviceSymbols.Add(':');
            serviceSymbols.Add('?');
            serviceSymbols.Add('!');
            serviceSymbols.Add('-');
            string tempString = str.ToString();
            for(int i = 0;i < tempString.Length; i++)
                if (serviceSymbols.Contains(tempString[i]))
                    tempString = tempString.Remove(i, 1);
            temp.SetString(tempString);
            return temp;
        }
    }
}
