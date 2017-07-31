using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Restourant;

namespace LunchBox.BE.Services
{
    public interface IRestourantService
    {
        void Insert(Restourant restourant);
        Restourant Get(Guid id);
        void Delete(Guid id);
        IList<Restourant> GetAll();
        IList<Restourant> GetInRadius(double lat, double lon, double radius);
    }
}