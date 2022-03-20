using CMSApplication.Domain.Entities.CommonEntities;
using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.CategoryEntities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        #region Relations 

        public virtual ICollection<Article>? Articles { get; set; }


        public virtual ICollection<Category>? Childs { get; set; }
        
        public virtual Category ParentCategory { get; set; }
        [ForeignKey("ParentCategoryId")]
        public string? ParentCategoryId { get; set; }


        #endregion

    }
}
