using Microsoft.AspNetCore.Mvc;
using MLT.MayLocNuocViet.Services.Interfaces;

namespace MayLocNuocViet.Web.Controllers
{
    public class PositionController : Controller
    {
        IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }



    }
}