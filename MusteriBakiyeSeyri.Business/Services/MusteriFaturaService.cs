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

        public async Task<List<MusteriFaturaListDto>> GetAllMusteriFaturaAsync()
        {
            var liste = await _uow.GetRepository<MusteriFatura>().GetQuery().Include(i=>i.MusteriTanim).Select(s => new MusteriFaturaListDto
            {
                FaturaTarihi=s.FaturaTarihi,
                FaturaTutari=s.FaturaTutari,
                Id= s.Id,
                MusteriId=s.MusteriId,
                MusteriUnvan = s.MusteriTanim.Unvan,
                OdemeTarihi = s.OdemeTarihi
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
