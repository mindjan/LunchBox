using System;
using LunchBox.BE.Models.Restourant;
using LunchBox.BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class RestourantController
    {
        private readonly IRestourantService _restourantService;

        public RestourantController(IRestourantService restourantService)
        {
            this._restourantService = restourantService;
        }

        [HttpPost]
        public string Post([FromBody]Restourant restourant)
        {
            _restourantService.Insert(restourant);
            return "OK";
        }

        [HttpGet]
        public Restourant Get(Guid id)
        {
            return _restourantService.Get(id);
        }

        [HttpPut]
        public Restourant Get2()
        {
            return new Restourant();
        }

        //        [HttpGet]
        //        public List<Restourant> GetAll()
        //        {
        //            return restourantService.GetAll().ToList();
        //        }
    }
}
