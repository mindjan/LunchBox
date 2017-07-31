using LunchBox.BE.Models.Restourant;
using LunchBox.BE.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LunchBox.BE.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IRestourantService _restourantService;

        public HomeController(IRestourantService restourantService)
        {
            _restourantService = restourantService;
        }

        // GET: /<controller>/
        [HttpPost]
        public string Index([FromBody] Restourant restourant)
        {
            _restourantService.Insert(restourant);
            return restourant.Name;
        }
    }
}
