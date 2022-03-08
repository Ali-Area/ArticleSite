using CMSApplication.Domain.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.UserEntities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        #region relations 

        public virtual ICollection<UsersInRoles> Users { get; set; }

        #endregion
    }
}
