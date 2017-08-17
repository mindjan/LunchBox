using AutoMapper;
using LunchBox.BE.Contracts.Offer;
using LunchBox.BE.Services.Offers;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class OffersController
    {
        private readonly IOffersService _offersService;
        private readonly IMapper _mapper;

        public OffersController(IOffersService offersService, IMapper mapper)
        {
            _offersService = offersService;
            _mapper = mapper;
        }

        [HttpPost]
        public Offer Post([FromBody]Offer offerContract)
        {
            var offer = _mapper.Map<Models.Offer.Offer>(offerContract);

            var insertedOffer = _offersService.Insert(offer);

            var result = _mapper.Map<Offer>(insertedOffer);

            return result;
        }

        [HttpGet]
        public Offer Get(string id)
        {
            var offer = _offersService.Get(id);

            var result = _mapper.Map<Offer>(offer);

            return result;
        }
    }
}
