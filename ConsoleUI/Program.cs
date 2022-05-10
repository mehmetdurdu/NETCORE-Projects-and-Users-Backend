using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DTO --> Data Transformation Object
            ProjectTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProjectTest()
        {
            ProjectManager projectManager = new ProjectManager(new EfProjectDal(), new CategoryManager(new EfCategoryDal()));

            var result = projectManager.GetProjectDetails();

            if (result.Success == true)
            {
                foreach (var project in result.Data)
                {
                    Console.WriteLine(project.ProjectName + "/" + project.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
