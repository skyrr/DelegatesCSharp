using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateMy
{
    public class MyMath {
        public delegate void MyDelegate(string message);
        public event MyDelegate myEvent;
        private int amount;
        //public int Amount { get; set; }
        public MyMath(int amount)
        {
            this.amount = amount;
        }

        public void Add(int sum)
        {
            
            this.amount += sum;
            if (myEvent != null)
            {
                myEvent("-- (from method) added on account " + sum);
            }
            else
            {
                Console.WriteLine("the event listener was not added");
            }
        }

        public int GetAmount()
        {
            return this.amount;
        }
        public async void AddAsync()
        {
            Thread.Sleep(1000);
            await Task.Run(() => Add(10));
            Console.WriteLine("after async current amount = {0}", GetAmount());
        }

    }
    class Program
    {
        
        static public void MyMessage(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            //MyDelegate myDelegate;
            //myDelegate = MyMessage;
            //myDelegate();

            MyMath math = new MyMath(150);
            math.myEvent += MyMessage;
            math.Add(30);
            Console.WriteLine("current amount = {0}",math.GetAmount());

            //math.myEvent -= MyMessage;
            math.Add(30);
            Console.WriteLine("current amount = {0}", math.GetAmount());
            math.myEvent -= MyMessage;
            math.AddAsync();
            //Thread.Sleep(2000);
            Console.Read();
        }
    }
}
