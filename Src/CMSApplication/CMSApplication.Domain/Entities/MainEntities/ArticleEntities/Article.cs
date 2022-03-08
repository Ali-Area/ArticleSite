using CMSApplication.Domain.Entities.CommonEntities;
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
        public string Visite { get; set; }
        public string MainImage { get; set; }
        public int CommentsCount { get; set; }


        #region relations
        
        public virtual User User { get; set; }
        public string UserId { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        

        #endregion

    }
}
