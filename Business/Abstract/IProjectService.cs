using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<List<Project>> GetAllByCategoryId(int id);
        IDataResult<List<ProjectDetailDto>> GetProjectDetails();
        IDataResult<Project> GetById(int projectId);
        IResult Add(Project project);
        IResult Update(Project project);
    }
}
