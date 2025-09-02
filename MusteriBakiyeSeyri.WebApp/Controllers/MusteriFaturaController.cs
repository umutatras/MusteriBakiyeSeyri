using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.DTOs.MusteriFatura;

namespace MusteriBakiyeSeyri.WebApp.Controllers
{
    public class MusteriFaturaController : Controller
    {
        private readonly IMusteriFaturaService _musteriFaturaService;
        private readonly IMusteriTanimService _musteriTanimService;
        public MusteriFaturaController(IMusteriFaturaService musteriFaturaService, IMusteriTanimService musteriTanimService)
        {
            _musteriFaturaService = musteriFaturaService;
            _musteriTanimService = musteriTanimService;
        }

        public async Task<IActionResult> Index()
        {
            var liste=await _musteriFaturaService.GetAllMusteriFaturaAsync();
            return View(liste);
        }
        public async Task<IActionResult> EnYuksekBorcDonemi(int musteriId)
        {
           ViewBag.EnYuksekBorc = await _musteriFaturaService.EnYuksekBorcDonemiHesapla(musteriId);
            var value = await _musteriFaturaService.GrafikVerisi(musteriId);
            ViewBag.SeyirJson = System.Text.Json.JsonSerializer.Serialize(value);

            return View();
        }

        public async Task<IActionResult> Create()
        {
            var Liste = await _musteriTanimService.GetAllMusteriTanimAsync();
            ViewBag.MusteriListe = new SelectList(Liste, "Id", "Unvan");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(MusteriFaturaAddDto dto)
        {
            await _musteriFaturaService.AddMusteriFaturaAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
