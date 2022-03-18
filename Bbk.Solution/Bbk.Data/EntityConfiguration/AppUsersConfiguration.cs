using Bbk.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.EntityConfiguration
{
    public class AppUsersConfiguration : IEntityTypeConfiguration<AppUsers>
    {
        public void Configure(EntityTypeBuilder<AppUsers> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.FistName).HasMaxLength(100); 
        }
    }
}
