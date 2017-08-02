using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Restourant;
using LunchBox.BE.Repositories.Restourant;

namespace LunchBox.BE.Services.Restourants
{
    public class RestourantService : IRestourantService
    {
        private readonly IRestourantRepository _restourantRepository;

        public RestourantService(IRestourantRepository restourantRepository)
        {
            this._restourantRepository = restourantRepository;
        }

        public void Insert(Restourant restourant)
        {
            _restourantRepository.Insert(restourant);
        }

        public Restourant Get(string id)
        {
            return _restourantRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            _restourantRepository.Delete(id);
        }

        public IList<Restourant> GetAll()
        {
            return _restourantRepository.GetAll();
        }

        public IList<Restourant> GetInRadius(double lat, double lon, double radius)
        {
            return _restourantRepository.GetInRadius(lat, lon, radius);
        }
    }
}
