using MusteriBakiyeSeyri.DTOs.MusteriFatura;

namespace MusteriBakiyeSeyri.Business.Interfaces
{
    public interface IMusteriFaturaService
    {
        Task<List<MusteriFaturaListDto>> GetAllMusteriFaturaAsync();
        Task<MusteriFaturaGetById> GetMusteriFaturaByIdAsync(int id);
        Task AddMusteriFaturaAsync(MusteriFaturaAddDto musteriFatura);
        Task UpdateMusteriFatura(MusteriFaturaUpdateDto MusteriFatura);
        Task DeleteProductAsync(int id);

        Task<MusteriFaturaEnYuksekBorcDonemiDto> EnYuksekBorcDonemiHesapla(int musteriId);
        Task<List<GrafikVerisiDto>> GrafikVerisi(int musteriId);
    }
}
