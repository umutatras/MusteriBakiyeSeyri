using Microsoft.AspNetCore.Mvc;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.DataAccess.UnitOfWork;

namespace MusteriBakiyeSeyri.WebApp.Controllers
{
    public class MusteriTanimiController : Controller
    {
        private readonly IMusteriTanimService _ms;

        public MusteriTanimiController(IMusteriTanimService ms)
        {
            _ms = ms;
        }

        public async Task<IActionResult> Index()
        {
            var liste=await _ms.GetAllMusteriTanimAsync();
            return View(liste);
        }
    }
}
