using System;
using System.Threading;

namespace OutParameter
{
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param></param>
          
        public static void Main()
        {
            int number = 101;
            Console.WriteLine("\n number value in main:" + number);
            Thread thread = new Thread(() => OutMethod(out number));
            thread.Start();
            //main thread sleep for 50ms
            Thread.Sleep(50);
            Console.WriteLine("\n In OutMethod after init:" + number);
            Console.ReadLine();
        }
        
        /// <summary>
        /// method containing an out Parameter
        /// </summary>
        /// <param name="temp">out parameter</param>
        public static void OutMethod(out int temp)
        {
            Console.WriteLine("Entered OutMethod....");
            //OutMethod thread sleep for 100ms 
            Thread.Sleep(100);
            temp = 62;
        }
    }
}