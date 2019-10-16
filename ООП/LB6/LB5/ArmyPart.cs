using System;
using System.Collections.Generic;
using System.Text;

namespace LB5
{
    partial class Army
    {
        public void Write()
        {
            foreach (var i in data)
                Console.WriteLine(i.ToString());
        }
        public int GetAttack()
        {
            int sum = 0;
            foreach (IActions i in data)
                sum += i.GetAttack();
            return sum;
        }
        
        
    }
    static class ArmyController
    {
        public static void Sort(Army obj)
        {
            Array.Sort(obj.data);
        }
        public static IActions GetTheStrongest(Army obj)
        {
            int s = 0;
            IActions temp = obj.data[0];
            foreach (IActions i in obj.data)
                if (i.GetAttack() > s)
                {
                    s = i.GetAttack();
                    temp = i;
                }
            return temp;
        }
    }
}
