using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { City = "Bursa" , Id = 001 , Name = "Eren ARAS"};

            // asagida yeni bir customer olusturdugumuzda tekrardan newlemek yerine clonlayarak performans saglariz
            Customer customer2 = (Customer)customer1.Clone();  // burada Clone methodu Person nesnesi oldugu icin mecburen customera donusturmemiz gerekir 

            customer2.City = "Istanbul";

            Console.WriteLine(customer2.City);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {

        // klon yapisini kullanmak icin abstract nesnene alttaki kullanarak clonlamak istedigin nesneye inherit edebilirsin
        public abstract Person Clone();  // Klon yani prototype designi new'lemek icin harcanilan performansi dusurmek kullanilmasi gerekilir
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Customer : Person
    {

        // elindeki customer nesnesini klonlamayi saglar
        public override Person Clone() 
        {
            // klonlamanin ozel kodu .Net ' ten gelen bir kod blogudur
            return (Person)MemberwiseClone();
        }
        public string City { get; set; }
    }
}
