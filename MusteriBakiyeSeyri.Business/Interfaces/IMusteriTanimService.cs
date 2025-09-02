using MusteriBakiyeSeyri.DTOs.MusteriTanim;

namespace MusteriBakiyeSeyri.Business.Interfaces
{
    public interface IMusteriTanimService
    {
        Task<List<MusteriTanimListDto>> GetAllMusteriTanimAsync();
        Task<MusteriTanimGetByIdDto> GetMusteriTanimByIdAsync(int id);
        Task AddMusteriTanimAsync(MusteriTanimAddDto musteriTanim);
        Task UpdateMusteriTanim(MusteriTanimUpdateDto musteriTanim);
        Task DeleteProductAsync(int id);
    }
}
