using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto
{
    public class GetCategoryListResultDto
    {
        public List<CategoryDto> CategoryList { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowsCount { get; set; } = 0;
        public string? SearchKey { get; set; }
        
    }
}
