using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Domain.Entities.CommonEntities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        
    }


    public class BaseEntity : BaseEntity<string>
    {

    }


}
