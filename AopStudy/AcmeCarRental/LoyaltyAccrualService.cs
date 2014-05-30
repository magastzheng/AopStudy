using System;
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
            var rentalTimeSpan = agreement.EndDate.Subtract(agreement.StartDate);
            int numberOfDays = (int) Math.Floor(rentalTimeSpan.TotalDays);
            int pointsPerDay = 1;
            if (agreement.Vehicle.Size >= Size.Luxury)
            {
                pointsPerDay = 2;
            }

            int points = numberOfDays*pointsPerDay;
            _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
        }
    }
}
