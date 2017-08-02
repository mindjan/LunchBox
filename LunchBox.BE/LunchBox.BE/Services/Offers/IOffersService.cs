using System.Collections.Generic;
using LunchBox.BE.Models.Offer;

namespace LunchBox.BE.Services.Offers
{
    public interface IOffersService
    {
        Offer Get(string offerId);
        IEnumerable<Offer> GetByRestourantId(string id);
        Offer Insert(Offer offer);
    }
}
