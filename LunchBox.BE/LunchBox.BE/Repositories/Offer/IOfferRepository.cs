﻿using System.Collections.Generic;

namespace LunchBox.BE.Repositories.Offer
{
    public interface IOfferRepository
    {
        Models.Offer.Offer Insert(Models.Offer.Offer offer);
        Models.Offer.Offer Get(string id);
        IEnumerable<Models.Offer.Offer> GetAllRestourantOffers(string restourantId);
    }
}
