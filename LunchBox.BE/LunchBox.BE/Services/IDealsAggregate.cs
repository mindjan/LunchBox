using System.Collections.Generic;
using LunchBox.BE.Models.Deal;

namespace LunchBox.BE.Services
{
    public interface IDealsAggregate
    {
        IEnumerable<Deal> GetDeals(double lat, double lon, double radius);
    }
}
