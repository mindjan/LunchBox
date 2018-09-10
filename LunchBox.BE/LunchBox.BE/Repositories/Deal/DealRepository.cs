using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace LunchBox.BE.Repositories.Deal
{
    public class DealRepository : MongoRepositoryBase<Models.Deal.Deal>, IDealRepository
    {
        public DealRepository(string connectionString, string collectionName) : base(connectionString, collectionName)
        {
        }

        public IEnumerable<Models.Deal.Deal> GetAllDeals()
        {
            var builder = Builders<Models.Deal.Deal>.Filter;
            var filter = builder.Exists("Id");
            return  base.GetMany(filter);
        }


      

        public IEnumerable<Models.Deal.Deal> GetAllDeals(double lon, double lat, double radius)
        {
//            var builder = Builders<Models.Deal.Deal>.Filter;
//
//            var filter = builder.Lte("Restaurant.location.latitude", lat + radius) 
//                         & builder.Gte("Restaurant.location.latitude", lat - radius) 
//                         & builder.Gte("Restaurant.location.longitude", lon - radius) 
//                         & builder.Lte("Restaurant.location.longitude", lon + radius);

            var gp =new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(lon, lat));
            var query=Builders<Models.Deal.Deal>.Filter.Near("Restaurant.location",gp,radius);
            //var result = await col.Find(query).ToListAsync();

            var products = base.GetMany(query);

            return products;
        }

        
    }

    public interface IDealRepository
    {
        IEnumerable<Models.Deal.Deal> GetAllDeals();
        IEnumerable<Models.Deal.Deal> GetAllDeals(double lon, double lat, double radius);
    }
}
