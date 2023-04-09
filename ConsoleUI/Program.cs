// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                bool isActive = true;

                while (isActive)
                {
                    Console.Clear();

                    Console.Write("1.Users\n" +
                                  "2.Products\n" +
                                  "3.Packages\n" +
                                  "4.Orders\n" +
                                  "5.Solds\n" +
                                  "6.Distributors\n" +
                                  "choose option: ");

                    string choose = Console.ReadLine();
                    int choice;
                    int.TryParse(choose, out choice);
                    Console.Beep();

                    switch (choice)
                    {
                        case 1:
                            {

                            }
                            break;
                        case 2:
                            {

                            }
                            break;
                        case 3:
                            {

                            }
                            break;
                        case 4:
                            {

                            }
                            break;
                        case 5:
                            {

                            }
                            break;
                    }
                }
            }
        }
    }
}
