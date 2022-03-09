using CMSApplication.Domain.Entities.CommonEntities;
using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.UserEntities
{
    public class User : IdentityUser
    {

        public bool IsDeleted { get; set; }
        public string Name { get; set; }


        #region relations

        public virtual ICollection<Article> Articles { get; set; }

        public virtual Role Role { get; set; }
        [ForeignKey("RoleId")]
        public string RoleId { get; set; }




        #endregion
    }
}
