using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.CategoryServiceDtos.GetAllChildCategoriesDto
{
    public class ChildCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
