using System;
using System.Transactions;
using Castle.DynamicProxy;

namespace AopStudy.CastleAop
{
    public class TransactionWithRetries : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var trans = new TransactionScope();
            invocation.Proceed();
            trans.Complete();
        }
    }
}
