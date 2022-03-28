using System.ComponentModel.DataAnnotations;

namespace CMSApplication.EndPoint.Models.SiteViewModels.ArticleViewModels
{
    public class AddArticleInfoViewModel
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
