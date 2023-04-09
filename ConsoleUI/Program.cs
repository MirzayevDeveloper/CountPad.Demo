// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using Tynamix.ObjectFiller;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
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
