using ApiUsuarios.Domain.Models;
using Delivery.Notification.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Notification.SqlData.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDERITEM");

            builder.HasKey(u => u.OrderItemId);

            builder.Property(u => u.OrderItemId)
                .HasColumnName("ORDERITEMID");

            builder.Property(u => u.ProductId)
                .HasColumnName("PORDUCTID");

            builder.Property(u => u.Quantity)
                .HasColumnName("QUANTITY");

            builder.Property(u => u.Total)
               .HasColumnName("TOTAL");
        }
    }
}
