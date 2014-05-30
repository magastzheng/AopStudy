using System;
using Castle.DynamicProxy;

namespace AopStudy.CastleAop
{
    public class CastleInterceptorAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("CastleInterceptorAspect interceptor 1");
            invocation.Proceed();
            Console.WriteLine("CastleInterceptorAspect interceptor 1");
        }
    }
}
