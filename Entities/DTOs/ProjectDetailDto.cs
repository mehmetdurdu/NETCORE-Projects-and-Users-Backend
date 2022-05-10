using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProjectDetailDto : IDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CategoryName { get; set; }
    }
}
