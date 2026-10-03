using System;
using System.Threading;

namespace OS_Problem_02
{
    class Thread_safe_buffer
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;

        private static readonly object _lock = new object();

        static void EnQueue(int eq, object t)
        {
            lock (_lock)
            {
                while (Count == 10)
                {
                    Console.WriteLine($"[Thread-{t}]: Queue full, waiting.........");
                    Monitor.Wait(_lock);
                }

                TSBuffer[Back] = eq;
                Back++;
                Back %= 10;
                Count += 1;
                
                Monitor.PulseAll(_lock);
            }
        }

        static int DeQueue(object t)
        {
            int x = 0;
            lock (_lock)
            {
                while (Count == 0)
                {
                    Console.WriteLine($"[Thread-{t}]: Queue empty, waiting for item.........");
                    Monitor.Wait(_lock);
                }

                x = TSBuffer[Front];
                Front++;
                Front %= 10;
                Count -= 1;
                
                Monitor.PulseAll(_lock);
                return x;
            }
        }

        static void th01(object t)
        {
            int i;
            for (i = 0; i < 51; i++)
            {
                EnQueue(i, t);
                Thread.Sleep(5); //ห้ามแก้ไขหรือเปลี่ยนแปลงบรรทัดนี้/Editing or Modification of this line is forbidden
            }
            Console.WriteLine("Thread {0} exit",t);
        }

        static void th011(object t)
        {
            int i;
            for (i = 100; i < 151; i++)
            {
                EnQueue(i, t);
                Thread.Sleep(7); //ห้ามแก้ไขหรือเปลี่ยนแปลงบรรทัดนี้/Editing or Modification of this line is forbidden
            }
            Console.WriteLine("Thread {0} exit",t);
        }

        static void th02(object t)
        {
            int i;
            int j;
            for (i = 0; i < 34; i++)
            {
                j = DeQueue(t);
                Console.WriteLine("j={0,-5} thread:{1}", j, t);
                Thread.Sleep(16); //ห้ามแก้ไขหรือเปลี่ยนแปลงบรรทัดนี้/Editing or Modification of this line is forbidden
            }
            Console.WriteLine("Thread {0} exit",t);
        }
        
        static void Main(string[] args)
        {
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            Console.WriteLine("--- Starting all threads ---");
            t1.Start(100);
            t11.Start(200);
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);

            t1.Join();
            t11.Join();
            t2.Join();
            t21.Join();
            t22.Join();
            
            Console.WriteLine("\n--- All threads have completed their tasks. ---");
            Console.WriteLine("Press any key to exit.");
            
            Console.ReadKey();
        }
    }
}