using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Restourant;

namespace LunchBox.BE.Services.Restourants
{
    public interface IRestourantService
    {
        void Insert(Restourant restourant);
        Restourant Get(string id);
        void Delete(Guid id);
        IList<Restourant> GetAll();
        IList<Restourant> GetInRadius(double lat, double lon, double radius);
    }
}