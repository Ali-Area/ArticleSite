

namespace CMSApplication.EndPoint.Models.SiteViewModels.ArticleViewModels
{
    public class ShowArticleDetailsViewModel
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
