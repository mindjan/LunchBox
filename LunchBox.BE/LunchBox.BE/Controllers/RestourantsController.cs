using System;
using AutoMapper;
using LunchBox.BE.Contracts.Restourant;
using LunchBox.BE.Services;
using LunchBox.BE.Services.Restourants;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class RestourantController
    {
        private readonly IRestourantService _restourantService;
        private readonly IMapper _mapper;

        public RestourantController(IRestourantService restourantService, IMapper mapper)
        {
            _restourantService = restourantService;
            _mapper = mapper;
        }

        [HttpPost]
        public void Post([FromBody]Restourant restourantContract)
        {
            var restourant = _mapper.Map<Models.Restourant.Restourant>(restourantContract);

            _restourantService.Insert(restourant);
        }

        [HttpGet]
        public Restourant Get(string id)
        {
            var restourant = _restourantService.Get(id);

            var result = _mapper.Map<Restourant>(restourant);

            return result;
        }
    }
}
