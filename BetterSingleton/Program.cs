using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterSingleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = Customer.CreateAsSingleton();

            customer.Save();
            Console.ReadLine();

        }
    }


    class Customer
    {
        private static Customer _customer;
        static object _lock = new object();

        public Customer()
        {

        }

        public static Customer CreateAsSingleton()
        {
            lock (_lock)
            {
                if (_customer == null)
                {
                    _customer = new Customer();
                }
            }
            return _customer;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }

    }
}
