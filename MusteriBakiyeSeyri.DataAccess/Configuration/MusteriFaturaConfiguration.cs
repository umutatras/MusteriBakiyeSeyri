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
            throw new NotImplementedException();
        }
    }
}
