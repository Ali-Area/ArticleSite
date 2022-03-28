using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.EndPoint.Models.SiteViewModels.ArticleViewModels
{
    public class AddArticleViewModel
    {

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Title { get; set; }
        [Required]
        [StringLength(10000, MinimumLength = 1000)]
        public string Body { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public IFormFile MainImage { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 100)]
        public string Summary { get; set; }
    }
}
