using AutoMapper;
using LunchBox.BE.Contracts.Offer;
using LunchBox.BE.Services.Ideintity;
using LunchBox.BE.Services.Offers;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class OffersController
    {
        private readonly IOffersService _offersService;
        private readonly IFacebookIdentityService _facebookIdentityService;
        private readonly IMapper _mapper;

        public OffersController(IOffersService offersService, IMapper mapper, IFacebookIdentityService facebookIdentityService)
        {
            _offersService = offersService;
            _mapper = mapper;
            _facebookIdentityService = facebookIdentityService;
        }

        [HttpPost]
<<<<<<< HEAD
        public void Post([FromBody]Offer offerContract, string accessToken)
=======
        public Offer Post([FromBody]Offer offerContract)
>>>>>>> e7ece01ec29677c991aa62826dd13b67938b1187
        {
            var userInfo = _facebookIdentityService.VerifyFacebookAccessToken(accessToken).Result;

            if (string.IsNullOrEmpty(userInfo.ID))
            {
                return;
            }

            var offer = _mapper.Map<Models.Offer.Offer>(offerContract);

            var insertedOffer = _offersService.Insert(offer);

            var result = _mapper.Map<Offer>(insertedOffer);

            return result;
        }

        [HttpGet]
        public Offer Get(string id, string accessToken)
        {
            var offer = _offersService.Get(id);

            var result = _mapper.Map<Offer>(offer);

            return result;
        }
    }
}
