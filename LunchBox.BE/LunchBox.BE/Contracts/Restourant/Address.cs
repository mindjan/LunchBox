namespace LunchBox.BE.Contracts.Restourant
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public Location Location { get; set; }
    }
}
