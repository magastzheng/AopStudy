using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AopStudy.Aop;

namespace AopStudy.AcmeCarRental
{
    public class LoyaltyAccrualService: ILoyaltyAccrualService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyaltyAccrualService(ILoyaltyDataService service)
        {
            _loyaltyDataService = service;
        }

        [DefensiveProgramming]
        [ExceptionAspect]
        [LoggingAspect]
        [TransactionManagement]
        public void Accrue(RentalAgreement agreement)
        {
            //defensive programming
            //if(agreement == null)
            //    throw new ArgumentNullException("agreement");

            //logging
            //Console.WriteLine("Accrue: {0}", DateTime.Now);
            //Console.WriteLine("Customer: {0}", agreement.Customer.Id);
            //Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);

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
                            var rentalTimeSpan = agreement.EndDate.Subtract(agreement.StartDate);
                            int numberOfDays = (int)Math.Floor(rentalTimeSpan.TotalDays);
                            int pointsPerDay = 1;
                            if (agreement.Vehicle.Size >= Size.Luxury)
                            {
                                pointsPerDay = 2;
                            }

                            int points = numberOfDays * pointsPerDay;
                            _loyaltyDataService.AddPoints(agreement.Customer.Id, points);

                            //scope.Complete();
                            //successed = true;

                            //logging
                            //Console.WriteLine("Accrue complete: {0}", DateTime.Now);
            //            }
            //            catch
            //            {
            //                if (retries >= 0)
            //                    retries--;
            //                else
            //                    throw;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            
        }
    }
}
