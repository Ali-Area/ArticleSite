using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using CMSApplication.Persistance.Context;

namespace CMSApplication.Persistance
{
    public class UnitOfWorkInterceptor : IInterceptor
    {


        private readonly ApplicationDbContext _context;

        public UnitOfWorkInterceptor(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Intercept(IInvocation invocation)
        {
            try
            {
                if (ShouldProceedInTransactin(invocation))
                {
                    ProceedWithoutTransaction(invocation);
                    return;
                }

                ProceedWithoutTransaction(invocation);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void ProceedWithoutTransaction(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ProceedWithTransaction(IInvocation invocaiton)
        {
            try
            {
                if(!_context.IsBegan)
                {
                    _context.Begin();
                }

                invocaiton.Proceed();

                _context.Commit();

            }
            catch (Exception ex)
            {
                _context.RollBack();
                throw;
            }
        }


        public bool ShouldProceedInTransactin(IInvocation invocation)
        {
            if (invocation.Method.Name.ToLower().StartsWith("get")) return false;
            if (invocation.Method.Name.ToLower().StartsWith("sign")) return false;
            return true;
        }

    }
}
