using System;

namespace AopStudy.AcmeCarRental
{
    public enum Size
    {
        Compact = 0,
        Midsize,
        Fullsize,
        Luxury,
        Truck,
        SUV
    }

    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Size Size { get; set; }
        public string Vin { get; set; }
    }
}
