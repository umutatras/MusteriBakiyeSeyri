using Microsoft.EntityFrameworkCore;
using MusteriBakiyeSeyri.Business.Exceptions;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.DataAccess.UnitOfWork;
using MusteriBakiyeSeyri.DTOs.MusteriFatura;
using MusteriBakiyeSeyri.Entities.Fatura;
using MusteriBakiyeSeyri.Entities.Musteri;

namespace MusteriBakiyeSeyri.Business.Services
{
    public class MusteriFaturaService : IMusteriFaturaService
    {
        private readonly IUnitOfWork _uow;

        public MusteriFaturaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddMusteriFaturaAsync(MusteriFaturaAddDto musteriFatura)
        {
           await _uow.GetRepository<MusteriFatura>().AddAsync(new MusteriFatura
            {
                FaturaTarihi = musteriFatura.FaturaTarihi,
                FaturaTutari = musteriFatura.FaturaTutari,
                MusteriId = musteriFatura.MusteriId,
                OdemeTarihi = musteriFatura.OdemeTarihi,
            });
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            MusteriFatura entity = await _uow.GetRepository<MusteriFatura>().GetById(id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {id} not found.");

            _uow.GetRepository<MusteriFatura>().Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<MusteriFaturaEnYuksekBorcDonemiDto> EnYuksekBorcDonemiHesapla(int musteriId)
        {
            var kesimTarihleri = _uow.GetRepository<MusteriFatura>().GetQuery().Where(f => f.MusteriId == musteriId)
                .GroupBy(f => f.FaturaTarihi.Date)
                .Select(g => new { Tarih = g.Key, Degisim = g.Sum(s => s.FaturaTutari) });

            var odemeler = _uow.GetRepository<MusteriFatura>().GetQuery().Where(f => f.MusteriId == musteriId&&f.OdemeTarihi!=null)
               .GroupBy(f => f.OdemeTarihi.Value.Date)
               .Select(g => new { Tarih = g.Key, Degisim = -g.Sum(s => s.FaturaTutari) });

            var hareketler=kesimTarihleri.Union(odemeler)
                .OrderBy(h => h.Tarih)
                .ToList();

            decimal bakiye = 0;
            var seyir = hareketler
                .Select(h => new
                {
                    h.Tarih,
                    h.Degisim,
                    Bakiye = (bakiye += h.Degisim)
                })
                .ToList();

            var maxBorcluAn = seyir.OrderByDescending(s => s.Bakiye).FirstOrDefault();
            var sonuc = new MusteriFaturaEnYuksekBorcDonemiDto();
            sonuc.FaturaTutari = maxBorcluAn.Bakiye;
            sonuc.Tarih = maxBorcluAn.Tarih;
            return sonuc;
        }

        public async Task<List<MusteriFaturaListDto>> GetAllMusteriFaturaAsync()
        {
            var liste = await _uow.GetRepository<MusteriFatura>().GetQuery().Include(i=>i.MusteriTanim).Select(s => new MusteriFaturaListDto
            {
                FaturaTarihi=s.FaturaTarihi,
                FaturaTutari=s.FaturaTutari,
                Id= s.Id,
                MusteriId=s.MusteriId,
                MusteriUnvan = s.MusteriTanim.Unvan,
                OdemeTarihi = s.OdemeTarihi==null?null: s.OdemeTarihi
            }).ToListAsync();
            return liste;
        }

        public async Task<MusteriFaturaGetById> GetMusteriFaturaByIdAsync(int id)
        {
            MusteriFatura entity = await _uow.GetRepository<MusteriFatura>().GetQuery().Include(i=>i.MusteriTanim).FirstOrDefaultAsync(s=>s.Id==id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {id} not found.");

            MusteriFaturaGetById dto = new MusteriFaturaGetById();
            dto.FaturaTutari = entity.FaturaTutari;
            dto.FaturaTarihi = entity.FaturaTarihi;
            dto.MusteriId = entity.MusteriId;
            dto.MusteriUnvan = entity.MusteriTanim.Unvan;
            dto.MusteriId = entity.MusteriId;
            dto.OdemeTarihi = entity.OdemeTarihi;
            return dto;
        }

        public async Task<List<GrafikVerisiDto>> GrafikVerisi(int musteriId)
        {
            var kesimTarihleri = _uow.GetRepository<MusteriFatura>().GetQuery().Where(f => f.MusteriId == musteriId)
               .GroupBy(f => f.FaturaTarihi.Date)
               .Select(g => new { Tarih = g.Key, Degisim = g.Sum(s => s.FaturaTutari) });

            var odemeler = _uow.GetRepository<MusteriFatura>().GetQuery().Where(f => f.MusteriId == musteriId && f.OdemeTarihi != null)
               .GroupBy(f => f.OdemeTarihi.Value.Date)
               .Select(g => new { Tarih = g.Key, Degisim = -g.Sum(s => s.FaturaTutari) });

            var hareketler = kesimTarihleri.Union(odemeler)
                .OrderBy(h => h.Tarih)
                .ToList();

            decimal bakiye = 0;
            var seyir = hareketler
                .Select(h => new GrafikVerisiDto
                {
                    Tarih=h.Tarih.ToString("yyyy-MM-dd"),
                    Degisim=h.Degisim,
                    Bakiye = (bakiye += h.Degisim)
                })
                .ToList();
            return seyir;
        }

        public async Task UpdateMusteriFatura(MusteriFaturaUpdateDto MusteriFatura)
        {
            MusteriFatura entity = await _uow.GetRepository<MusteriFatura>().GetById(MusteriFatura.Id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {MusteriFatura.Id} not found.");

            entity.FaturaTarihi = MusteriFatura.FaturaTarihi;   
            entity.OdemeTarihi = MusteriFatura.OdemeTarihi;
            entity.FaturaTutari = MusteriFatura.FaturaTutari;
            await _uow.GetRepository<MusteriFatura>().UpdateAsync(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
