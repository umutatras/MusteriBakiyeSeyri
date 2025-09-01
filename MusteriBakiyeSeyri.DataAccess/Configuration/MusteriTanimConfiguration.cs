using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriBakiyeSeyri.Entities.Musteri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.DataAccess.Configuration;

public class MusteriTanimConfiguration : IEntityTypeConfiguration<MusteriTanim>
{
    public void Configure(EntityTypeBuilder<MusteriTanim> builder)
    {
        throw new NotImplementedException();
    }
}
