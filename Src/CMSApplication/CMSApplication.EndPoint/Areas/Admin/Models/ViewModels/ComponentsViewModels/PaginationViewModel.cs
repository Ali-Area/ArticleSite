namespace CMSApplication.EndPoint.Areas.Admin.Models.ViewModels.ComponentsViewModels
{
    public class PaginationViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchKey { get; set; }


    }
}
