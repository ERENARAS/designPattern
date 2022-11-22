using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }



    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with Memcache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with Rediscache");
        }
    }



    public abstract class CrossCuttingConcersFactory
    {
        public abstract Logging CreateLogging();
        public abstract Caching CreateCaching();
    }

    public class Factory1:CrossCuttingConcersFactory
    {
        public override Logging CreateLogging()
        {
            return new Log4NetLogger();
        }
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }
    public class Factory2 : CrossCuttingConcersFactory
    {
        public override Logging CreateLogging()
        {
            return new NLogger();
        }
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcersFactory _crossCuttingFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcersFactory crossCuttingFactory)
        {
            _crossCuttingFactory = crossCuttingFactory;
        }


        public void GetAll()
        {
            _logging.Log("Loogged");
            _caching.Cache("Cacheed");

            Console.WriteLine("List Products");
        }
    }




}
