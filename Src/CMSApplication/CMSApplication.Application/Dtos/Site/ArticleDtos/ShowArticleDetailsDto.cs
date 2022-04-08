using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.ArticleDtos
{
    public class ShowArticleDetailsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string MainImage { get; set; }
        public int Visit { get; set; }
        public int CommentCount { get; set; }
        public string Category { get; set; }
        public string CreateDate { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
    }
}
