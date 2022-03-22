namespace CMSApplication.EndPoint.Areas.Admin.ViewComponents
{
    public class PaginationComponentRequestDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchKey { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

}
