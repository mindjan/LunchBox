using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace LunchBox.BE.Repositories.Restourant
{
    public class RestourantRepository : MongoRepositoryBase<Models.Restourant.Restourant>, IRestourantRepository
    {
        public RestourantRepository(string connectionString, string collectionName) : base(connectionString, collectionName)
        {

        }

        public void Insert(Models.Restourant.Restourant restourant)
        {
            base.Insert(restourant);
        }

        public Models.Restourant.Restourant Get(string id)
        {
            var builder = Builders<Models.Restourant.Restourant>.Filter;
            var filter = builder.Eq("_id", id);

            var restourant = base.GetOne(filter);

            return restourant;
        }

        public void Delete(Guid id)
        {
            var builder = Builders<Models.Restourant.Restourant>.Filter;
            var filter = builder.Eq("Id", id);

            base.Delete(filter);
        }

        public IList<Models.Restourant.Restourant> GetAll()
        {
            var builder = Builders<Models.Restourant.Restourant>.Filter;
            var filter = builder.SizeGt("Offers", 0);

            var products = base.GetMany(filter);

            return products;
        }

        public IList<Models.Restourant.Restourant> GetInRadius(double lat, double lon, double radius)
        {
            var builder = Builders<Models.Restourant.Restourant>.Filter;

            var filter = builder.Lte("Address.Location.Lat", lat + radius) 
                & builder.Gte("Address.Location.Lat", lat - radius) 
                & builder.Gte("Address.Location.Long", lon - radius) 
                & builder.Lte("Address.Location.Long", lon + radius);

            var products = base.GetMany(filter);

            return products;
        }
    }
}
