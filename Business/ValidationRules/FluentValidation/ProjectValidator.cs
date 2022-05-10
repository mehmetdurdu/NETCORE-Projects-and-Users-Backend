using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.ProjectName).NotEmpty();
            RuleFor(p => p.ProjectName).MinimumLength(2);
            RuleFor(p => p.ProjectName).Must(StartWithA).WithMessage("Projeler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
