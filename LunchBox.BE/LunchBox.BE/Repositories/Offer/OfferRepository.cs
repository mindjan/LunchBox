using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LunchBox.BE.Repositories.Offer
{
    public class OfferRepository : MongoRepositoryBase<Models.Offer.Offer>, IOfferRepository
    {
        public OfferRepository(string connectionString, string collectionName) : base(connectionString, collectionName)
        {
        }

        public Models.Offer.Offer Insert(Models.Offer.Offer offer)
        {
            base.Insert(offer);

            return offer;
        }

        public Models.Offer.Offer Get(Guid id)
        {
            var builder = Builders<Models.Offer.Offer>.Filter;
            var filter = builder.Eq("Id", id);

            var offer = base.GetOne(filter);

            return offer;
        }

        public IEnumerable<Models.Offer.Offer> GetAllRestourantOffers(Guid restourantId)
        {
            var builder = Builders<Models.Offer.Offer>.Filter;
            var filter = builder.Eq("RestourantId", restourantId);

            var offers = base.GetMany(filter);

            return offers;
        }
    }
}
