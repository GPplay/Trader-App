using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trade.Domain.Entities;

namespace Trade.persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasPrecision(9,0)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Symbol)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.side)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.transcTime)
                .IsRequired();

            builder.Property(x => x.quantity)
                .HasPrecision(9,0)
                .IsRequired();

            builder.Property(x => x.type)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.price)
                .HasPrecision(9,4)
                .IsRequired();
        }
    }
}
