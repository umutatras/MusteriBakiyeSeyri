using MusteriBakiyeSeyri.Entities.Fatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.Entities.Musteri;

public class MusteriTanim : BaseEntity
{
    public string Unvan { get; set; }

    #region Navigation Property
    public ICollection<MusteriFatura> MusteriFaturalari { get; set; } = new List<MusteriFatura>();
    #endregion
}
