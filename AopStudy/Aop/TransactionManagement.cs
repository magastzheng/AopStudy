using System;
using System.Transactions;
using PostSharp.Aspects;

namespace AopStudy.Aop
{
    [Serializable]
    public class TransactionManagement : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Console.WriteLine("Starting transaction");
            //start new transaction
            using (var scope = new TransactionScope())
            {
                var retries = 3;
                var succeeded = false;
                while (!succeeded)
                {
                    try
                    {
                        args.Proceed();

                        if(retries >1)
                            throw new Exception("retries");
                        //complete transaction
                        scope.Complete();
                        succeeded = true;
                    }
                    catch
                    {
                        Console.WriteLine("Retries: " + retries);
                        if (retries >= 0)
                            retries--;
                        else
                            throw;
                    }
                }
            }
        }
    }
}
