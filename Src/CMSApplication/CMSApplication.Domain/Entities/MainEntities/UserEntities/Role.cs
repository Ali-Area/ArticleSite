using CMSApplication.Domain.Entities.CommonEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.UserEntities
{
    public class Role : IdentityRole
    {
        public bool IsDeleted { get; set; }

        #region relations 

        public virtual ICollection<User> Users { get; set; }


        #endregion
    }
}
