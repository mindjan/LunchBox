using System.Collections.Generic;
using HandyShop.BE.Models;

namespace LunchBox.BE.Models.Restourant
{
    public class Restourant : MongoModelBase
    {
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public Address Address { get; set; }
        public List<Offer.Offer> Offers { get; set; }
    }
}
