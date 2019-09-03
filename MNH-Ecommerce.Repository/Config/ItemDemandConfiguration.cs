using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNH_Ecommerce.Domain.Entity;
using System;

namespace MNH_Ecommerce.Repository.Config
{
    public class ItemDemandConfiguration : IEntityTypeConfiguration<ItemDemand>
    {
        public void Configure(EntityTypeBuilder<ItemDemand> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();
        }
    }
}
