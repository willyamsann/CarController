using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CarUseMap : IEntityTypeConfiguration<CarUse>
    {
        public void Configure(EntityTypeBuilder<CarUse> builder)
        {
            builder.ToTable("CarUses");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.ReasonForUse)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(500)");

        }
    }
}
