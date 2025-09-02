using Microsoft.EntityFrameworkCore;
using MusteriBakiyeSeyri.Entities.Fatura;
using MusteriBakiyeSeyri.Entities.Musteri;

namespace MusteriBakiyeSeyri.DataAccess.Context;

public class MusteriBakiyeSeyriDb : DbContext
{
    public MusteriBakiyeSeyriDb(DbContextOptions<MusteriBakiyeSeyriDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(MusteriBakiyeSeyriDb).Assembly);
    }

    public DbSet<MusteriTanim> MusteriTanimlari { get; set; } = null!;
    public DbSet<MusteriFatura> MusteriFaturalari { get; set; } = null!;
}

