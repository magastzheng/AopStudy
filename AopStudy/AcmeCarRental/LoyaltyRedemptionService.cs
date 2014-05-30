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
            int pointsPerDay = 10;
            if (invoice.Vehicle.Size >= Size.Luxury)
            {
                pointsPerDay = 15;
            }
            int points = pointsPerDay*numberOfDays;
            _loyaltyDataService.SubstractPoints(invoice.Customer.Id, points);
            invoice.Discount = numberOfDays*invoice.CostPerDay;
        }
    }
}
