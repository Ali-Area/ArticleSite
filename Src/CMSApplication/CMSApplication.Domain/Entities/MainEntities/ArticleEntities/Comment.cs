using CMSApplication.Domain.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.ArticleEntities
{
    public class Comment : BaseEntity
    {
        public string Body { get; set; }


        #region relations
        
        public virtual Comment ParentCommant { get; set; }
        public string? CommentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public virtual Article Article { get; set; }
        public string ArticleId { get; set; }




        #endregion
    }
}
