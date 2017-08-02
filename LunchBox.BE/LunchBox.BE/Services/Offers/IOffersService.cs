using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Offer;

namespace LunchBox.BE.Services.Offers
{
    public interface IOffersService
    {
        Offer Get(Guid offerId);
        IEnumerable<Offer> GetByRestourantId(Guid id);
        Offer Insert(Offer offer);
    }
}
