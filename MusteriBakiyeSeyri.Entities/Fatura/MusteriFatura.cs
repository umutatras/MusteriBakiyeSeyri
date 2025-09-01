using MusteriBakiyeSeyri.Entities.Musteri;

namespace MusteriBakiyeSeyri.Entities.Fatura;

public class MusteriFatura : BaseEntity
{
    public int MusteriId { get; set; }
    public DateTime FaturaTarihi { get; set; }
    public decimal FaturaTutari { get; set; }
    public DateTime OdemeTarihi { get; set; }

    #region Navigation Property
    public MusteriTanim MusteriTanim { get; set; }
    #endregion
}
