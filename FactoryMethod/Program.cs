using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CostumerManager costumerManager = new CostumerManager(new LoggerFactory());
            costumerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        // Business to decide factory 
        public ILogger CreateLogger()
        {
            return new EaLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        // Business to decide factory 
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EaLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ealogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    public class CostumerManager
    {
        private ILoggerFactory _loggerFactory;   // burada new lememek icin loggerfactoryi bu sekilde kullaniyoruz 

        public CostumerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save ()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
