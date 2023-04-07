using System;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace ConsoleUI
{
    public class Program
    {
        static async Task Main(string[] args)
        {

        }

        public static Filler<T> CreateObjectFiller<T>() where T : class
        {
            var filler = new Filler<T>();

            filler.Setup().OnType<DateTime>()
                .Use(new DateTimeRange(DateTime.UnixEpoch).GetValue);

            return filler;
        }
    }
}
