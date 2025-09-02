namespace MusteriBakiyeSeyri.DTOs.MusteriFatura
{
    public class MusteriFaturaGetById
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public string MusteriUnvan { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public decimal FaturaTutari { get; set; }
        public DateTime? OdemeTarihi { get; set; }
    }
}
