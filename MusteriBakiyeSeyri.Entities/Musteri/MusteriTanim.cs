using MusteriBakiyeSeyri.Entities.Fatura;

namespace MusteriBakiyeSeyri.Entities.Musteri;

public class MusteriTanim : BaseEntity
{
    public string Unvan { get; set; }

    #region Navigation Property
    public ICollection<MusteriFatura> MusteriFaturalari { get; set; } = new List<MusteriFatura>();
    #endregion
}
