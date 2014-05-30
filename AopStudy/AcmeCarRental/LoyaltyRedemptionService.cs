using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AopStudy.Aop;

namespace AopStudy.AcmeCarRental
{
    public class LoyaltyRedemptionService : ILoyaltyRedemptionService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyaltyRedemptionService(ILoyaltyDataService service)
        {
            _loyaltyDataService = service;
        }

        [DefensiveProgramming]
        [ExceptionAspect]
        [LoggingAspect]
        [TransactionManagement]
        public void Redeem(Invoice invoice, int numberOfDays)
        {
            //defensive programming
            //if(invoice == null)
            //    throw new ArgumentNullException("invoice");
            //if(numberOfDays <= 0)
            //    throw new ArgumentNullException("", "numberOfDays");

            //logging
            //Console.WriteLine("Redeem: {0}", DateTime.Now);
            //Console.WriteLine("Invoice: {0}", invoice.Id);

            //try
            //{
            //    //start new transaction
            //    using (var scope = new TransactionScope())
            //    {
            //        int retries = 3;
            //        bool successed = false;
            //        while (!successed)
            //        {
            //            try
            //            {
                            int pointsPerDay = 10;
                            if (invoice.Vehicle.Size >= Size.Luxury)
                            {
                                pointsPerDay = 15;
                            }
                            int points = pointsPerDay * numberOfDays;
                            _loyaltyDataService.SubstractPoints(invoice.Customer.Id, points);
                            invoice.Discount = numberOfDays * invoice.CostPerDay;

                            //scope.Complete();
                            //successed = true;

                            //logging
                            //Console.WriteLine("Redeem complete: {0}", DateTime.Now);
        //                }
        //                catch
        //                {
        //                    if (retries >= 0)
        //                        retries--;
        //                    else
        //                        throw;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        }
    }
}
