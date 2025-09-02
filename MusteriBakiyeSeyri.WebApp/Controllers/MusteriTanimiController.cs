using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.DataAccess.UnitOfWork;
using MusteriBakiyeSeyri.DTOs.MusteriTanim;

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MusteriTanimAddDto model)
        {

            await _ms.AddMusteriTanimAsync(model);          
           return RedirectToAction(nameof(Index)); // Liste sayfasına dön
            
        }
    }
}
