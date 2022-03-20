using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; } = false;
        public int SubCount { get; set; } = 0;
        public CategoryDto? Parent { get; set; }
    }
}
