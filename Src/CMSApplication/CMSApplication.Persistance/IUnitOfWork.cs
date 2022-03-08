using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Persistance
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        bool IsBegan { get; }
        void RollBack();

    }
}
