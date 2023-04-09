// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using EKundalik.ConsoleLayer;
using System.Threading.Tasks;
using System;
using CountPad.Domain.Models.Products;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private async Task<Product> UpdateProduct()
        {
            bool isActive = true;
            Product student = SelectStudent().Result;

            if (student != null)
            {
                await WriteToFile(student);
            }

            while (isActive && student != null)
            {
                if (ReadFromFile().Id != default)
                {
                    Console.Clear();
                    General.PrintObjectProperties(student);

                    Console.Write("1.Username\n" +
                                    "2.FullName\n" +
                                    "3.BirthDate\n" +
                                    "4.Exit\n" +
                                    "Which property do you want to change: ");

                    string choose = Console.ReadLine();
                    int choice;
                    int.TryParse(choose, out choice);

                    Console.Beep();

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Create new username: ");
                                string user = Console.ReadLine();

                                student.UserName = user;
                            }
                            break;
                        case 2:
                            {
                                Console.Write("Enter new Full name: ");
                                string name = Console.ReadLine();

                                student.FullName = name;
                            }
                            break;
                        case 3:
                            {
                                Console.Write("Enter a new birth date: ");
                                string birth = Console.ReadLine();
                                DateTime birthDate;
                                DateTime.TryParse(birth, out birthDate);

                                student.BirthDate = birthDate;
                            }
                            break;
                        case 4:
                            isActive = false;
                            break;
                    }
                    await WriteToFile(student);

                    if (choice != 4 && choice != 0) General.Sleep();
                }
            }
            Console.Clear();
            Student updatedStudent = ReadFromFile();

            File.WriteAllText(
                "../../../ConsoleLayer/data.json", "");

            return updatedStudent;
        }
    }
}
