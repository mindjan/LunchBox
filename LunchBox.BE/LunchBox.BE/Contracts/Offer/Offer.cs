using System;
using System.Collections.Generic;

namespace LunchBox.BE.Contracts.Offer
{
    public class Offer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RestourantId { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public List<string> PhotosUrls { get; set; }
        public OfferType Type { get; set; }
    }
}
