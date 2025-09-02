using Microsoft.AspNetCore.Mvc;
using MusteriBakiyeSeyri.Business.Interfaces;

namespace MusteriBakiyeSeyri.WebApp.Controllers
{
    public class MusteriFaturaController : Controller
    {
        private readonly IMusteriFaturaService _musteriFaturaService;

        public MusteriFaturaController(IMusteriFaturaService musteriFaturaService)
        {
            _musteriFaturaService = musteriFaturaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
