// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using System;
using CountPad.Application.Interfaces.ServiceInterfaces;
using EKundalik.ConsoleLayer;
using CountPad.Domain.Models.Products;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Services;

namespace ConsoleUI.ConsoleLayer
{
    public partial class ProductUI
    {
        private readonly IProductService productService;

        public ProductUI(IProductRepository productRepository) =>
            this.productService = new ProductService(productRepository);

        public async Task StudentCase()
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                int choice = General.PrintCrudOptions(nameof(Product));
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
    }
}
