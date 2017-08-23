using AutoMapper;
<<<<<<< HEAD
using LunchBox.BE.Contracts.Identity;
=======
>>>>>>> e7ece01ec29677c991aa62826dd13b67938b1187
using LunchBox.BE.Contracts.Restourant;
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
<<<<<<< HEAD
        public void Post([FromBody]Restourant restourantContract, string accessToken)
=======
        public Restourant Post([FromBody]Restourant restourantContract)
>>>>>>> e7ece01ec29677c991aa62826dd13b67938b1187
        {
            var restourant = _mapper.Map<Models.Restourant.Restourant>(restourantContract);

            var insertedRestourant = _restourantService.Insert(restourant);

            var result = _mapper.Map<Restourant>(insertedRestourant);

            return result;
        }

        [HttpGet]
        public Restourant Get(string id, string accessToken)
        {
            var restourant = _restourantService.Get(id);

            var result = _mapper.Map<Restourant>(restourant);

            return result;
        }
    }
}
