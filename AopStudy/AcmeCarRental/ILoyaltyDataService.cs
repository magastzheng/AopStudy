using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopStudy.AcmeCarRental
{
    public interface ILoyaltyDataService
    {
        void AddPoints(Guid customerId, int points);
        void SubstractPoints(Guid customerId, int points);
    }
}
