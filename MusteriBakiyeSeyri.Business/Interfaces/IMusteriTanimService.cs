using MusteriBakiyeSeyri.DTOs.MusteriTanim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
