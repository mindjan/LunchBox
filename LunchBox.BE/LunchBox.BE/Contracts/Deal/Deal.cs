using System.Collections.Generic;

namespace LunchBox.BE.Contracts.Deal
{
    public class Deal
    {
        public Restourant.Restourant Restourant { get; set; }
        public IEnumerable<Offer.Offer> Offers { get; set; }
    }
}
