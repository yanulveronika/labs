using System;
using System.Collections.Generic;
using System.Text;

namespace LB3
{
    public static class isExistsExtension
    {
        public static bool isExists(this TableCollection col)
        {
           // Table[] temp = new Table[0];
            int answer;
            do
            {
                Console.WriteLine("Выберите поле для поиска:\n1 - Высота\n2 - Ширина\n3 - Длина\n4 - Цена");
                answer = Convert.ToInt32(Console.ReadLine());
            } while (!(answer > 0) && (answer < 5));
            Console.WriteLine("Введите значение поля: ");
            string val = Console.ReadLine();
            int num;
            if (int.TryParse(val, out num))
            {
                switch (answer)
                {
                    case 1:
                        return Array.Exists(col.data, i => i.height == num);
                        //return temp;
                        break;
                    case 2:
                        return Array.Exists(col.data, i => i.width == num);
                        //return temp;
                        break;
                    case 3:
                        return Array.Exists(col.data, i => i.Depth == num);
                        // return temp;
                        break;
                    case 4:
                        return Array.Exists(col.data, i => i.Price == num);
                        //return temp;
                        break;
                }
            }
            else Console.WriteLine("Ошибка ввода");
            //return null;
            
           
        }
    }
}
