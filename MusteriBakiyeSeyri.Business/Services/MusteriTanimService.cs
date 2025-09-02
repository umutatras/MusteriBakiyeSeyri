using MusteriBakiyeSeyri.Business.Exceptions;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.DataAccess.UnitOfWork;
using MusteriBakiyeSeyri.DTOs.MusteriTanim;
using MusteriBakiyeSeyri.Entities.Musteri;

namespace MusteriBakiyeSeyri.Business.Services
{
    public class MusteriTanimService : IMusteriTanimService
    {
        private readonly IUnitOfWork _uow;

        public MusteriTanimService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddMusteriTanimAsync(MusteriTanimAddDto musteriTanim)
        {
            MusteriTanim entity = new MusteriTanim
            {
                Unvan = musteriTanim.Unvan
            };
            await _uow.GetRepository<MusteriTanim>().AddAsync(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            MusteriTanim entity = await _uow.GetRepository<MusteriTanim>().GetById(id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {id} not found.");

            _uow.GetRepository<MusteriTanim>().Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<MusteriTanimListDto>> GetAllMusteriTanimAsync()
        {
            List<MusteriTanimListDto> dto = new List<MusteriTanimListDto>();

            var liste = await _uow.GetRepository<MusteriTanim>().GetAllAsync();

            dto = liste.Select(s => new MusteriTanimListDto
            {
                Id = s.Id,
                Unvan = s.Unvan
            }).ToList();
            return dto;
        }

        public async Task<MusteriTanimGetByIdDto> GetMusteriTanimByIdAsync(int id)
        {
            MusteriTanim entity = await _uow.GetRepository<MusteriTanim>().GetById(id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {id} not found.");

            MusteriTanimGetByIdDto dto = new MusteriTanimGetByIdDto();
            dto.Id = id;
            dto.Unvan = entity.Unvan;
            return dto;
        }

        public async Task UpdateMusteriTanim(MusteriTanimUpdateDto musteriTanim)
        {
            MusteriTanim entity = await _uow.GetRepository<MusteriTanim>().GetById(musteriTanim.Id);
            if (entity is null)
                throw new NotFoundException($"Musteri with Id {musteriTanim.Id} not found.");

            entity.Unvan = musteriTanim.Unvan;
            await _uow.GetRepository<MusteriTanim>().UpdateAsync(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
