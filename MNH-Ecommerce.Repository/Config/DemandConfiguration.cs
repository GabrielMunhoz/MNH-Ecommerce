using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNH_Ecommerce.Domain.Entity;
using System;

namespace MNH_Ecommerce.Repository.Config
{
    public class DemandConfiguration : IEntityTypeConfiguration<Demand>
    {
        public void Configure(EntityTypeBuilder<Demand> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.DeliveryDate).IsRequired();
            builder.Property(d => d.DemandDate).IsRequired();
        }
    }
}
