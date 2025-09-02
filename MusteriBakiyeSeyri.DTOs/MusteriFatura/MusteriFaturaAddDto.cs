namespace MusteriBakiyeSeyri.DTOs.MusteriFatura
{
    public class MusteriFaturaAddDto
    {
        public int MusteriId { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public decimal FaturaTutari { get; set; }
        public DateTime OdemeTarihi { get; set; }
    }
}
