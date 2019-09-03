using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNH_Ecommerce.Domain.Entity;
using System;

namespace MNH_Ecommerce.Repository.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
