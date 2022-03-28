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

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string Name { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? ProfileImage { get; set; }
        public string? Biography { get; set; }


        #region relations

        public virtual ICollection<Article> Articles { get; set; }

        public virtual Role Role { get; set; }
        public string RoleId { get; set; }




        #endregion
    }
}
