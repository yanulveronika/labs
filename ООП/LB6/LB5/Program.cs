using System;
using System.Diagnostics;

namespace LB5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hunter h1 = new Hunter(3);
                //Hunter h2 = new Hunter(-3);

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


                armyCol1.Add(null);
                Console.WriteLine(armyCol1[10]);
                armyCol1.Delete(20);

                Console.WriteLine();
                armyCol1.Write();
                Console.WriteLine(armyCol1.GetAttack());
                Console.WriteLine();
                Console.WriteLine(ArmyController.GetTheStrongest(armyCol1));
                Console.WriteLine();
                ArmyController.Sort(armyCol1);
                armyCol1.Write();
            }
            catch (ZeroAttackInputException e)
            {
                Console.WriteLine("Исключение " + e.Message + "\n" + "Неверное значение: " + e.wrongValue.ToString());
                Console.WriteLine($"Метод: { e.TargetSite}");
            }
            catch (AttackInputException e)
            {
                Console.WriteLine("Исключение " + e.Message + "\n" + "Неверное значение: " + e.wrongValue.ToString());
                Console.WriteLine($"Метод: { e.TargetSite}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Исключение " + e.Message);
                Console.WriteLine($"Метод: { e.TargetSite}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Метод: { e.TargetSite}");
            }
            finally
            {
                Console.WriteLine("\nКонец работы программы");
            }
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
        public Fighter(object atk)
        {
            if (!(atk is int))
                throw new AttackInputException("В поле атаки введено не число!", atk);
            else
                if ((int)atk <= 0)
                throw new ZeroAttackInputException("Атака меньше или равна 0!", (int)atk);
            this.atk = (int)atk;
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
        public override int GetHashCode()
        {
            return this.hp+1;
        }
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
        public Hunter(object atk):base(atk)
        { }
        
    }
    class Marksman : Fighter
    {
        public override int GetHashCode()
        {
            return this.hp+2;
        }
        public Marksman(object atk):base(atk) { }
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
    sealed class Shaman : Extrasence, IActions 
    {
        public override int GetHashCode()
        {
            return 0;
        }
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
        public Shaman(object atk)
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
            Debug.Assert(t != null,"Попытка добавить пустое значение в Army");
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
                //Console.WriteLine("Ошибка удаления элемента");
                throw new IndexOutOfRangeException("Ошибка удаления элемента номер " + num.ToString());
                //return null;
            }
        }
        public IActions this[int n]
        {
            get
            {
                if ( (n>=0) && (n<data.Length) )
                    return data[n];
                else
                    throw new IndexOutOfRangeException("Попытка получить доступ к несуществующему элементу номер "+n.ToString());
            }
            set
            {
                if ((n>=0)&&(n<data.Length))
                    data[n] = value;
                else
                    throw new IndexOutOfRangeException("Попытка получить доступ к несуществующему элементу номер " + n.ToString());
            }
        }
    }
}

   