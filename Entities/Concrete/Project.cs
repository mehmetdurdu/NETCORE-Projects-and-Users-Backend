using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProjectName { get; set; }
    }
}
