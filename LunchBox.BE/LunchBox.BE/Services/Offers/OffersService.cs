using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Offer;
using LunchBox.BE.Repositories.Offer;

namespace LunchBox.BE.Services.Offers
{
    public class OffersService : IOffersService
    {
        private readonly IOfferRepository _offerRepository;

        public OffersService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public Offer Get(Guid offerId)
        {
            return _offerRepository.Get(offerId);
        }

        public IEnumerable<Offer> GetByRestourantId(Guid id)
        {
            return _offerRepository.GetAllRestourantOffers(id);
        }

        public Offer Insert(Offer offer)
        {
            return _offerRepository.Insert(offer);
        }

    }
}
