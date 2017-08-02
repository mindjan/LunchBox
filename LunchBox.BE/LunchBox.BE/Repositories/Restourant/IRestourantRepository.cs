using System;
using System.Collections.Generic;

namespace LunchBox.BE.Repositories.Restourant
{
    public interface IRestourantRepository
    {
        void Insert(Models.Restourant.Restourant restourant);
        Models.Restourant.Restourant Get(Guid id);
        void Delete(Guid id);
        IList<Models.Restourant.Restourant> GetAll();
        IList<Models.Restourant.Restourant> GetInRadius(double lat, double lon, double radius);
    }
}
