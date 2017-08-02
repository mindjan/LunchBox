using System.Collections.Generic;
using AutoMapper;
using LunchBox.BE.Contracts.Deal;
using LunchBox.BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class DealsController
    {
        private readonly IMapper _mapper;
        private readonly IDealsAggregate _dealsAggregate;

        public DealsController(IMapper mapper, IDealsAggregate dealsAggregate)
        {
            _mapper = mapper;
            _dealsAggregate = dealsAggregate;
        }

        [HttpGet]
        public List<Deal> Get(double lat, double lon, double radius)
        {
            var deals = _dealsAggregate.GetDeals(lat, lon, radius);

            var result = _mapper.Map<List<Deal>>(deals);

            return result;
        }

    }
}
