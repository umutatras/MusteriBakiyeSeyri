using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriBakiyeSeyri.Entities.Fatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.DataAccess.Configuration
{
    public class MusteriFaturaConfiguration : IEntityTypeConfiguration<MusteriFatura>
    {
        public void Configure(EntityTypeBuilder<MusteriFatura> builder)
        {
            builder.ToTable("musteri_fatura_table");
            builder.HasIndex(i => i.Id);

            builder.Property(p => p.FaturaTarihi)
                   .HasColumnName("fatura_tarihi")
                   .HasColumnType("datetime");

            builder.Property(p => p.FaturaTutari).HasColumnType("decimal(18,2)")
                   .HasColumnName("fatura_tutari");

            builder.Property(p => p.OdemeTarihi)
                   .HasColumnName("odeme_tarihi")
                   .HasColumnType("datetime");

            builder.HasOne(x=>x.MusteriTanim).WithMany(y => y.MusteriFaturalari).HasForeignKey(z => z.MusteriId);   
        }
    }
}
