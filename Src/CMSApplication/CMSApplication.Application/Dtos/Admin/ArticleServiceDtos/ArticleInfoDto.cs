using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Admin.ArticleServiceDtos
{
    public class ArticleInfoDto
    {
        public string Id { get; set; }
        public string MainImage { get; set; }
        public string Title { get; set; }
        public bool IsSpecial { get; set; }
        public int Visit { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int CommentCount { get; set; }
    }
}
