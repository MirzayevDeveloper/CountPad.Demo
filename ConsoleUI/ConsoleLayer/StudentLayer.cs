// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EKundalik.ConsoleLayer;
using Newtonsoft.Json;
using School.Application.Interfaces.RepositoryInterfaces;
using School.Application.Interfaces.ServiceInterfaces;
using School.Application.Services;
using School.Domain.Models;

namespace School.Presentation.ConsoleLayer
{
    public class StudentLayer
    {
        private readonly IStudentService studentService;

        public StudentLayer(IStudentRepository studentRepository) =>
            this.studentService = new StudentService(studentRepository);

        public async Task StudentCase()
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                int choice = General.PrintCrudOptions(nameof(Student));
                Console.Beep();

                switch (choice)
                {
                    case 1:
                        {
                            Student maybeStudent =
                                await AddStudentMenu();

                            await this.studentService
                                .AddStudentAsync(maybeStudent);
                        }
                        break;
                    case 2:
                        {
                            await SelectStudent();
                        }
                        break;
                    case 3:
                        {
                            Student student = await UpdateStudent();

                            await this.studentService.AddStudentAsync(student);
                        }
                        break;
                    case 4:
                        {
                            Student maybeStudent = DeleteStudent();

                            await this.studentService.DeleteStudentAsync(
                                maybeStudent.StudentId);
                        }
                        break;
                    case 5:
                        {
                            General.SelectAll(await this.studentService.GetAllStudentAsync());
                        }
                        break;
                    case 6:
                        AddStudent();
                        break;
                    case 7:
                        isActive = false;
                        break;
                }
                General.Pause();
            }
        }

        private Student DeleteStudent()
        {
            Student student = SelectStudent().Result ?? new();

            return student;
        }

        private async ValueTask<Student> UpdateStudent()
        {
            bool isActive = true;
            Student student = SelectStudent().Result;

            if (student != null)
            {
                await WriteToFile(student);
            }

            while (isActive && student != null)
            {
                if (ReadFromFile().StudentId != default)
                {
                    Console.Clear();
                    General.PrintObjectProperties(student);

                    Console.Write("1.FullName\n" +
                                    "2.BirthDate\n" +
                                    "3.Class\n" +
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
                                Console.Write("Enter new Full name: ");
                                string name = Console.ReadLine();

                                student.FullName = name;
                            }
                            break;
                        case 2:
                            {
                                Console.Write("Enter a new birth date: ");
                                string birth = Console.ReadLine();
                                DateTime birthDate;
                                DateTime.TryParse(birth, out birthDate);

                                student.BirthDate = birthDate;
                            }
                            break;
                        case 3:
                            {
                                Console.Write("Enter a new Class id: ");
                                string birth = Console.ReadLine();
                                int id;
                                int.TryParse(birth, out id);

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

        private async ValueTask WriteToFile(Student student)
        {
            File.WriteAllText("../../../ConsoleLayer/data.json",
                JsonConvert.SerializeObject(student, Formatting.Indented));
        }

        private Student ReadFromFile()
        {
            return JsonConvert.DeserializeObject<Student>(
                File.ReadAllText("../../../ConsoleLayer/data.json"));
        }

        private async Task<Student> SelectStudent()
        {
            Console.Write("Enter Id: ");
            string answer = Console.ReadLine();
            int choice;
            int.TryParse(answer, out choice);

            Student maybeStudent =
                await this.studentService
                .GetStudentByIdAsync(choice);

            General.PrintObjectProperties(maybeStudent);

            return maybeStudent;
        }

        private async void AddStudent()
        {
            Console.Write("Nechta Student Objectni Tablega kiritmoqchisiz: ");
            string choice = Console.ReadLine();
            int count;
            int.TryParse(choice, out count);

            if (count is 0) return;

            List<Student> list = new List<Student>();
            Student maybeStudent = new();

            for (int i = 0; i < count; i++)
            {
                await this.studentService.AddStudentAsync(
                    General.CreateObjectFiller<Student>().Create());

                list.Add(maybeStudent);
            }

            Console.WriteLine($"Successfully added {count} student objects...");
            Console.ReadKey();
        }

        private async Task<Student> AddStudentMenu()
        {
            Console.Write("enter Full name: ");
            string fullName = Console.ReadLine();

            Console.Write("enter BirthDate [month:day:year]: ");
            string dateTime = Console.ReadLine();
            DateTime birthDate;
            DateTime.TryParse(dateTime, out birthDate);

            Console.Write("enter School name: ");
            string schoolName = Console.ReadLine();

            Console.Write("Gender[m/f]: ");
            string gender = Console.ReadLine();
            bool genderBool = gender == "m" ? true : false;

            var student = new Student()
            {
                FullName = fullName,
                BirthDate = birthDate,
                Gender = genderBool,
                SchoolClass = new SchoolClass()
                {
                    Name = schoolName
                }
            };

            return student;
        }
    }
}
