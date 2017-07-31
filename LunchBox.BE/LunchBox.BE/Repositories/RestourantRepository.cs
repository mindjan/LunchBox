using System;
using System.Collections.Generic;
using HandyShop.BE.Repositories;
using LunchBox.BE.Models.Restourant;
using MongoDB.Driver;

namespace LunchBox.BE.Repositories
{
    public class RestourantRepository : MongoRepositoryBase<Restourant>, IRestourantRepository
    {
        public RestourantRepository(string connectionString, string collectionName) : base(connectionString, collectionName)
        {

        }

        public void Insert(Restourant restourant)
        {
            base.Insert(restourant);
        }

        public Restourant Get(Guid id)
        {
            var builder = Builders<Restourant>.Filter;
            var filter = builder.Eq("Id", id);

            var restourant = base.GetOne(filter);

            return restourant;
        }

        public void Delete(Guid id)
        {
            var builder = Builders<Restourant>.Filter;
            var filter = builder.Eq("Id", id);

            base.Delete(filter);
        }

        public IList<Restourant> GetAll()
        {
            var builder = Builders<Restourant>.Filter;
            var filter = builder.SizeGt("Offers", 0);

            var products = base.GetMany(filter);

            return products;
        }
    }
}
