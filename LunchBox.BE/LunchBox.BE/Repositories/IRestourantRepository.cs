using System;
using System.Collections.Generic;
using LunchBox.BE.Models.Restourant;

namespace LunchBox.BE.Repositories
{
    public interface IRestourantRepository
    {
        void Insert(Restourant restourant);
        Restourant Get(Guid id);
        void Delete(Guid id);
        IList<Restourant> GetAll();
    }
}
