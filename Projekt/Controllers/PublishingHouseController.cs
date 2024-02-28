using Core.IRepositories;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Controllers
{
    public class PublishingHouseController : Controller
    {
        private readonly IPublishingHouseService _service;

        public PublishingHouseController(IPublishingHouseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
