using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenSoftware.EntityFrameworks
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindEntities();
            foreach(Customer customer in context.Customers)
            {
                Console.WriteLine(customer.ContactTitle + ":" + customer.ContactName);
            }
            Console.ReadKey();
        }
    }
}
