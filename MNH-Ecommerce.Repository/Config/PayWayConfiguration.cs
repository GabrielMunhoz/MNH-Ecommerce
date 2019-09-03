using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNH_Ecommerce.Domain.Utils;

namespace MNH_Ecommerce.Repository.Config
{
    public class PayWayConfiguration : IEntityTypeConfiguration<PayWay>
    {
        public void Configure(EntityTypeBuilder<PayWay> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
