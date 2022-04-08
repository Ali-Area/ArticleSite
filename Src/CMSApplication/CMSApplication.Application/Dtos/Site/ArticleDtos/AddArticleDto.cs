using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.ArticleDtos
{
    public class AddArticleDto
    {
        public string Title { get; set; }
        public string MainContent { get; set; }
        public IFormFile MainImage { get; set; }
        public string CategoryId { get; set; }
        public string AuthorId { get; set; }
        public string Summary { get; set; }

    }
}
