using System.Collections.Generic;
using System.Linq;
using LunchBox.BE.Repositories.Deal;
using Microsoft.AspNetCore.Mvc;

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class DealsController
    {
        private readonly IDealRepository _dealRepository;

        public DealsController(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        [HttpGet("GetAll1")]
        public List<Models.Deal.Deal> GetAll()
        {
            var deals = _dealRepository.GetAllDeals();


            return deals.ToList();
        }

        [HttpGet]
        public List<Models.Deal.Deal> GetAllNearby(double lat, double lon, double radius)
        {
            var deals = _dealRepository.GetAllDeals(lon, lat, radius);

            return deals.ToList();
        }

    }
}
