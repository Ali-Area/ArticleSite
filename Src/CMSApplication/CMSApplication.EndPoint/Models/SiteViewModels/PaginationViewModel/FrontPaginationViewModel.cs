namespace CMSApplication.EndPoint.Models.SiteViewModels.PaginationViewModel
{
    public class FrontPaginationViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchKey { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
