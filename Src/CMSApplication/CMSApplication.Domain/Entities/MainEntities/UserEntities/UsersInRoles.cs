using CMSApplication.Domain.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.MainEntities.UserEntities
{
    public class UsersInRoles : BaseEntity
    {

        #region relations

        public virtual Role Role { get; set; }
        public string RoleId { get; set; }


        public virtual User User { get; set; }
        public string UserId { get; set; }


        #endregion
    }
}
