using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.ArticleServiceDtos
{
    public class GetArticleListResultDto
    {
        public List<ArticleInfoDto> ArticleList { get; set; }
        public int RowsCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
    }
}
