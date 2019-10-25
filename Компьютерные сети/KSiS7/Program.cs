using System;
using System.Threading;
using System.Net.NetworkInformation;

namespace ip
{
    class Program
    {
        public static void Main(string[] args)
        {
            Ping obj = new Ping();

            //Console.Write("Адрес: ");
            //string addr = Convert.ToString(Console.ReadLine());
            //Console.Write("Число пакетов: ");
            //int bundle = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Сообщение: ");
            //string data = Console.ReadLine();
            //byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
            //Console.Write("Время: ");
            //int timeSleep = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            int count = 0;
            
            string addr = args[1];
            int timeSleep = 60;
            int bundle = 4;
            int size = 32;
            if (args[0] != "ping")
            {
                System.Console.WriteLine("Неверная утилита");
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-n")
                        bundle = Int32.Parse(args[i + 1]);
                    if (args[i] == "-w")
                        timeSleep = Int32.Parse(args[i + 1]);
                    if (args[i] == "-l")
                        size = Int32.Parse(args[i + 1]);
                }
                byte[] buffer = new byte[size];

                int[] timeSend = new int[bundle];

                for (int i = 0; i < bundle; i++)
                {
                    try
                    {
                        PingReply res = obj.Send(addr, timeSleep, buffer);

                        Console.Write("Ответ: {0}: байт {1}, время {2} мс, TTL {3}",
                            res.Address,
                            res.Buffer.Length,
                            (Convert.ToInt32(res.RoundtripTime) < 1) ? "<1" : res.RoundtripTime.ToString(),
                            res.Options.Ttl
                            );

                        timeSend[i] = Convert.ToInt32(res.RoundtripTime);

                        if (res.Status.ToString() == "Success")
                        {
                            count++;
                        }
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка! Код ошибки - время обработки пакета превышает " + timeSleep + " мс");
                        //Console.WriteLine(e.Message);
                    }
                }

                int timeMax = timeSend[0];
                int timeMin = timeSend[0];
                float average = 0;
                foreach (int item in timeSend)
                {
                    if (item > timeMax)
                    {
                        timeMax = item;
                    }
                    if (item < timeMin)
                    {
                        timeMin = item;
                    }
                    average += item;
                }

                Console.WriteLine();
                Console.WriteLine("Статистика для " + addr);
                Console.WriteLine("Послано: {0}, получено: {1}, потеряно: {2}",
                    bundle,
                    count,
                    bundle - count
                    );

                Console.WriteLine("Максимальное: {0} мс, минимальное: {1} мс, среднее: {2} мс",
                    timeMax.ToString(),
                    timeMin.ToString(),
                    (average / bundle).ToString()
                    );

                Console.WriteLine();

                Console.ReadKey();
            }
            
        }
    }
}