using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.UserServiceDtos.GetProfileDetailsDto
{
    public class ArticleDto
    {
        public string ArticleId { get; set; }
        public string MainImage { get; set; }
        public string AuthorName { get; set; }
        public int CommentsCount { get; set; }
        public DateTime Created { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? Tags { get; set; }
        public bool IsSpecial { get; set; }
    }
}
