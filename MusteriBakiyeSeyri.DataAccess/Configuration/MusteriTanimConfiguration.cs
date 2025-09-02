using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriBakiyeSeyri.Entities.Musteri;

namespace MusteriBakiyeSeyri.DataAccess.Configuration;

public class MusteriTanimConfiguration : IEntityTypeConfiguration<MusteriTanim>
{
    public void Configure(EntityTypeBuilder<MusteriTanim> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.ToTable("musteri_tanim_table");

        builder.Property(x => x.Unvan).HasColumnName("UNVAN").HasColumnType("char(255)");
    }
}
