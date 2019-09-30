using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNH_Ecommerce.Domain.Entity;
using System;

namespace MNH_Ecommerce.Repository.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email)
                .IsRequired()
                 .HasMaxLength(50);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.HasMany(u => u.Demands).WithOne(p => p.User);

            
        }
    }
}
