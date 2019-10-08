using System;

namespace LB5
{
    class Program
    {
        static void Main(string[] args)
        {

            Hunter h1 = new Hunter();
            Console.WriteLine(h1.ToString());
            Shaman s1 = new Shaman();
            Console.WriteLine(s1.ToString());

            IActions[] actionsArr = new IActions[4];
            actionsArr[0] = h1;
            actionsArr[1] = s1;
            actionsArr[2] = new Fighter();
            actionsArr[3] = new Marksman();
            Printer p1 = new Printer();
            foreach (IActions i in actionsArr)
                p1.IAmPrinting(i);

            IActions ref1 = h1 as IActions;
            Console.WriteLine(h1 is IActions);
            Console.WriteLine(ref1 is IActions);
            Console.WriteLine((ref1 != null));
            Test test1 = new Test();
            IActions ref2 = test1 as IActions;
            Console.WriteLine((ref2 != null));
        }
    }
    class Test
    {

    }
    class Fighter : IActions
    {
        virtual public void Say(string str)
        {
            Console.WriteLine("Fighter says: <<" + str + ">>");
        }
        public int hp { get; set; } = 100;
        public virtual void Attack()
        {
            Console.WriteLine("Fighter attacks");
        }
        public override bool Equals(object obj)
        {
            return (this == obj);
        }
        public override int GetHashCode()
        {
            return this.hp;
        }
        public override string ToString()
        {
            return "Class = Fighter, hp = " + hp;
        }

    }
    interface IActions
    {
        void Say(string str);
    }
    class Hunter : Fighter
    {
        public override void Say(string str)
        {
            Console.WriteLine("Hunter says: <<" + str + ">>");
        }
        public override void Attack()
        {
            Console.WriteLine("Hunter... hunts");
        }
        public override string ToString()
        {
            return "Class = Hunter";
        }
    }
    class Marksman : Fighter
    {
        public override void Attack()
        {
            Console.WriteLine("Marksman shoots");
        }
        public override void Say(string str)
        {
            Console.WriteLine("Marksman says: <<" + str + ">>");
        }
        public override string ToString()
        {
            return "Class = Marksman";
        }
    }
    abstract class Extrasence
    {
        public abstract void Say(string str);
        public void MakePrediction()
        {
            Console.WriteLine("Extrasence makes a prediction");
        }
        public override abstract string ToString();

    }
    sealed class Shaman : Extrasence, IActions //одноменные
    {
        public override void Say(string a)
        {
            Console.WriteLine($"Shaman says: <<{a}>>");
        }
        public void Heal()
        {
            Console.WriteLine("Shaman heals");
        }
        public override string ToString()
        {
            return "Class = Shaman";
        }
    }

    class Printer
    {
        public virtual void IAmPrinting(IActions someobj)
        {
            Console.WriteLine("Printer: "+someobj.ToString());
        }
    }
}

   