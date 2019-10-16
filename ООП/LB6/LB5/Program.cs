using System;

namespace LB5
{
    class Program
    {
        static void Main(string[] args)
        {

            Hunter h1 = new Hunter(5);
           
            Shaman s1 = new Shaman();
            
            Army armyCol1 = new Army();
            armyCol1.Add(h1);
            armyCol1.Add(s1);
            Fighter f1 = new Fighter(3);
            Marksman m1 = new Marksman(8);
            armyCol1.Add(f1);
            armyCol1.Add(m1);
            armyCol1.Add(f1);
            armyCol1.Write();
            armyCol1.Delete(2);
            Console.WriteLine();
            armyCol1.Write();
            Console.WriteLine(armyCol1.GetAttack());
            Console.WriteLine();
            Console.WriteLine(ArmyController.GetTheStrongest(armyCol1));
            Console.WriteLine();
            ArmyController.Sort(armyCol1);
            armyCol1.Write();
            
        }
        
    }
    class Test
    {

    }
    class Fighter : IActions
    {
        public int CompareTo(object obj)
        {
            IActions i = obj as IActions;
            if (GetAttack() > i.GetAttack())
                return 1;
            if (GetAttack() == i.GetAttack())
                return 0;
            else return -1;
        }
        virtual public void Say(string str)
        {
            Console.WriteLine("Fighter says: <<" + str + ">>");
        }
        public int hp { get; set; } = 100;
        private int atk;
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
            return $"Class = Fighter, hp = {hp}, atk = {atk}";
        }
        public Fighter(int atk)
        {
            this.atk = atk;
        }
        public int GetAttack()
        {
            return atk;
        }
    }
    public interface IActions : IComparable
    {
        void Say(string str);
        int GetAttack();
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
            return $"Class = Hunter, atk = {GetAttack()}";
        }
        public Hunter(int atk):base(atk)
        { }
        
    }
    class Marksman : Fighter
    {
        public Marksman(int atk):base(atk) { }
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
            return $"Class = Marksman, atk = {GetAttack()}";
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
        public int CompareTo(object obj)
        {
            IActions i = obj as IActions;
            if (GetAttack() > i.GetAttack())
                return 1;
            if (GetAttack() == i.GetAttack())
                return 0;
            else return -1;
        }
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
            return $"Class = Shaman, atk = {GetAttack()}";
        }
        public Shaman(int atk)
        {
        }
        public int GetAttack()
        {
            return 0;
        }
        public Shaman() { }
    }

    class Printer
    {
        public virtual void IAmPrinting(IActions someobj)
        {
            Console.WriteLine("Printer: "+someobj.ToString());
        }
    }

    enum TestEnum
    {
        Melee = 0,
        Range
    }
    struct Car
    {
        public int horsePower;
        public int numberOfDoors;
        public int speed;
    }

    public partial class Army
    {
        public IActions[] data;
        public Army()
        {
            data = new IActions[0];
        }
        public void Add(IActions t)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = t;//-1
        }
        public IActions Delete(int num)
        {
            if ((data.Length > 0) && (num < data.Length) && (num >= 0))
            {
                IActions temp = data[num];
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
        public IActions this[int n]
        {
            get { return data[n]; }
            set {if ((n>=0)&&(n<data.Length)) data[n] = value; }
        }
    }
}

   