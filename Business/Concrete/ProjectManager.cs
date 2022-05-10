using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Core.Utilities.Bussiness;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        ICategoryService _categoryService;

        //CategoryDal ile çalışma yapıyoruz. Kategori tablosu kullanmamız gerekli.
        //Ancak bir manager içerisine başka bir manager üyesi injekte edemeyiz.(CategoryDal gibi)
        //ICategoryDal _categoryDal;  gibi...
        //Dolayısıyla CategoryService kullanılır. Kategori tablosu rahatlıkla kullanılır.

        public ProjectManager(IProjectDal projectDal, ICategoryService categoryService)
        {
            _projectDal = projectDal;
            _categoryService = categoryService;
        }


        //[SecuredOperation("product.add,admin")]
        [ValidationAspects(typeof(ProjectValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Project project)
        {
            IResult result = BusinessRules.Run(CheckIfProjectNameExists(project.ProjectName),
                CheckIfProjectCountOfCategoryCorrect(project.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _projectDal.Add(project);

            return new SuccessResult(Messages.ProjectAdded);
        }

        [CacheAspect]
        public IDataResult<List<Project>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Project>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(),Messages.ProjectsListed);
        }

        public IDataResult<List<Project>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Project> GetById(int projectId)
        {
            return new SuccessDataResult<Project>(_projectDal.Get(p => p.Id == projectId));
        }

        public IDataResult<List<ProjectDetailDto>> GetProjectDetails()
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetProjectDetils()); ;
        }

        [ValidationAspects(typeof(ProjectValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Project project)
        {
            var result = _projectDal.GetAll(p => p.CategoryId == project.CategoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProjectCountOfCategoryError);
            }

            return new SuccessResult(Messages.ProjectUpdated);
        }

        private IResult CheckIfProjectNameExists(string projectName)
        {
            var result = _projectDal.GetAll(p => p.ProjectName == projectName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProjectNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProjectCountOfCategoryCorrect(int categoryId)
        {
            var result = _projectDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProjectCountOfCategoryError);
            }
            return new SuccessResult();
        }
    }
}
