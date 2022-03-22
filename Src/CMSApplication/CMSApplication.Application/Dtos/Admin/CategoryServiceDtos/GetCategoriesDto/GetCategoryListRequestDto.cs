using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.CategoryServiceDtos.GetCategoriesDto
{
    public class GetCategoryListRequestDto
    {
        public string? ParentId { get; set; }
        public string? SearchKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
