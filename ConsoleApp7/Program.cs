using System;
using System.Threading;

namespace ConsoleApp7
{
    public delegate void ImDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Print print = new Print();
            Test test = new Test();
            print.youDelegate += test.TiChegoNadelal;
            print.OnKeyPressed += CharPrint;//подписка на OnKeyPressed
            print.Run();
        }
        static void CharPrint(object sender, char a)//вывод введенного символа 
        {
            Console.WriteLine($"Ты ввел {a}");
        }
    }
    class Print
    {
        public event EventHandler<char> OnKeyPressed;
        public event ImDelegate youDelegate;
        public void Run()
        {
            while(true)
            {
                var a = Console.ReadLine();
                if (a.Equals("c"))
                {
                    youDelegate();
                    break;
                }
                try
                {
                    OnKeyPressed?.Invoke(this, Convert.ToChar(a));
                }
                catch(FormatException)
                {
                    Console.WriteLine("Я тебя непонял, вводи только один символ");
                }
            }
        }
    }

    class Test
    {
        public void TiChegoNadelal()
        {
            int a = 1000;
            Console.WriteLine("Ты чего наделал....");
            Thread.Sleep(1000);

            Console.WriteLine(a);
            Thread.Sleep(50);
            while (a > 0)
            {
                Console.WriteLine(a -= 7);
                Thread.Sleep(50);
            }
        }
    }
}
