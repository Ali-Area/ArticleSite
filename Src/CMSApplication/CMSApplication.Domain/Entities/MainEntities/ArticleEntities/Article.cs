using CMSApplication.Domain.Entities.CommonEntities;
using CMSApplication.Domain.Entities.MainEntities.CategoryEntities;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.ArticleEntities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public int Visite { get; set; } = 0;
        public string MainImage { get; set; }
        public int CommentsCount { get; set; } = 0;
        public bool IsSpecial { get; set; } = false;


        #region relations
        
        public virtual User Author { get; set; }
        public string AuthorId { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }

        #endregion

    }
}
