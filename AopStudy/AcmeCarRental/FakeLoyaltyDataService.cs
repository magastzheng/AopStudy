using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopStudy.AcmeCarRental
{
    public class FakeLoyaltyDataService : ILoyaltyDataService
    {
        public void AddPoints(Guid customerId, int points)
        {
            Console.WriteLine("Adding {0} points for customer '{1}'", points, customerId);
        }

        public void SubstractPoints(Guid customerId, int points)
        {
            Console.WriteLine("Substracting {0} points for customer '{1}'", points, customerId);
        }
    }
}
