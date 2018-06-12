using System;
using System.Collections.Generic;
using System.Linq;
using LunchBox.BE.Models.Deal;
using LunchBox.BE.Services.Offers;
using LunchBox.BE.Services.Restourants;

namespace LunchBox.BE.Services
{
    public class DealsAggregate : IDealsAggregate
    {
        private readonly IOffersService _offersService;
        private readonly IRestourantService _restourantService;

        public DealsAggregate(IRestourantService restourantService, IOffersService offersService)
        {
            _restourantService = restourantService;
            _offersService = offersService;
        }

        public IEnumerable<Deal> GetDeals(double lat, double lon, double radius)
        {
            var deals = new List<Deal>();

            var restourants = _restourantService.GetInRadius(lat, lon, radius);

            foreach (var restourant in restourants)
            {
                var restourantOffers = _offersService.GetByRestourantId(restourant.Id);
                var validOffers = restourantOffers.Where(x => x.ValidFrom > DateTime.Now && x.ValidTo < DateTime.Now);

                var deal = new Deal
                {
                    Restourant = restourant,
                    Offers = validOffers
                };

                deals.Add(deal);
            }

            return deals;
        }
    }
}
