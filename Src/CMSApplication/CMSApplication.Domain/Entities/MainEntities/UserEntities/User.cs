using CMSApplication.Domain.Entities.CommonEntities;
using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.UserEntities
{
    public class User : IdentityUser
    {

        public bool IsDeleted { get; set; }



        #region relations

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<UsersInRoles> Roles { get; set; }




        #endregion
    }
}
