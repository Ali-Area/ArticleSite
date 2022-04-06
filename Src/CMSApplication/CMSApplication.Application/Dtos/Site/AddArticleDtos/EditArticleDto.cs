using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Dtos.Site.AddArticleDtos
{
    public class EditArticleDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BodY { get; set; }
        public string Summary { get; set; }
        public string MainImage { get; set; }
    }
}
