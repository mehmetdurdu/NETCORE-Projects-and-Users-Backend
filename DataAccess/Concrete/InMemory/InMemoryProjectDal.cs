using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProjectDal : IProjectDal
    {
        List<Project> _projects;
        public InMemoryProjectDal()
        {
            _projects = new List<Project> {
                new Project{Id=1,CategoryId=1,ProjectName="Akıllı Ulaşım Projesi"},
                new Project{Id=2,CategoryId=2,ProjectName="Biyoteknoloji Projesi"}
            };
        }
        public void Add(Project project)
        {
            _projects.Add(project);
        }

        public void Delete(Project project)
        {

            Project projectToDelete = _projects.SingleOrDefault(p=>p.Id==project.Id);

            _projects.Remove(projectToDelete);
        }

        public Project Get(Expression<Func<Project, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            return _projects;
        }

        public List<Project> GetAll(Expression<Func<Project, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllByCategory(int categoryId)
        {
            return _projects.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProjectDetailDto> GetProjectDetils()
        {
            throw new NotImplementedException();
        }

        public void Update(Project project)
        {

            Project projectToUpdate = _projects.SingleOrDefault(p => p.Id == project.Id);

            projectToUpdate.Id = project.Id;
            projectToUpdate.ProjectName = project.ProjectName;
            projectToUpdate.CategoryId = project.CategoryId;
        }
    }
}
