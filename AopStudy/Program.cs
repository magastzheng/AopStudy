using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopStudy.AcmeCarRental;

namespace AopStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAcmeCarRental();
        }

        private static void TestAcmeCarRental()
        {
            SimulateAddingPoints();
            Console.WriteLine();
            Console.WriteLine(" ***");
            Console.WriteLine();

            SimulateRemovingPoints();

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void SimulateAddingPoints()
        {
            var dataService = new FakeLoyaltyDataService();
            var service = new LoyaltyAccrualService(dataService);
            var rentalAgreement = new RentalAgreement
                {
                    Customer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Matthew D. Groves",
                            DateOfBirth = new DateTime(1980, 2, 10),
                            DriversLicense = "RR123456"
                        },
                    Vehicle = new Vehicle
                        {
                            Id = Guid.NewGuid(),
                            Make = "Honda",
                            Model = "Accord",
                            Size = Size.Compact,
                            Vin = "1HABC123"
                        },
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now
                };

            service.Accrue(rentalAgreement);
            //service.Accrue(null);
        }

        private static void SimulateRemovingPoints()
        {
            var dataService = new FakeLoyaltyDataService();
            var service = new LoyaltyRedemptionService(dataService);
            var invoice = new Invoice
                {
                    Customer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Jacob Watson",
                            DateOfBirth = new DateTime(1977, 4, 15),
                            DriversLicense = "RR009911"
                        },
                    Vehicle = new Vehicle
                        {
                            Id = Guid.NewGuid(),
                            Make = "Cadillac",
                            Model = "Sedan",
                            Size = Size.Luxury,
                            Vin = "2DBI"
                        },
                    CostPerDay = 29.95m,
                    Id = Guid.NewGuid()
                };

            service.Redeem(invoice, 3);
            //service.Redeem(null, -3);
        }
    }
}
