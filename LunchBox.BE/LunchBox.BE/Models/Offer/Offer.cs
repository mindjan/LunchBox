using System;
using System.Collections.Generic;
using HandyShop.BE.Models;

namespace LunchBox.BE.Models.Offer
{
    public class Offer : MongoModelBase
    {
        public string Name { get; set; }
        public Guid RestourantId { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public List<string> PhotosUrls { get; set; }
        public OfferType Type { get; set; }
    }
}
