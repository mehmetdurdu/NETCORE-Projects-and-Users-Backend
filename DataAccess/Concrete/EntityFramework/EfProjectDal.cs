using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    //Entity Framework is Microsoft's ORM product.
    //ORM means as if you associate the table in the database with it as if it were a class. 
    //From now on, it is the environment where we do all the operations with LINQ.(SQL operations)
    //The process of establishing a relationship between ORM database objects and code and doing database work.

    public class EfProjectDal : EfEntityRepositoryBase<Project, ProjectContext>, IProjectDal
    {
        public List<ProjectDetailDto> GetProjectDetils()
        {
            using (ProjectContext context = new ProjectContext())
            {
                var result = from p in context.Project
                    join c in context.Categories
                        on p.CategoryId equals c.Id
                    select new ProjectDetailDto{ProjectId = p.Id, ProjectName = p.ProjectName,
                        CategoryName = c.CategoryName};
                return result.ToList();
            }
        }
    }
}
