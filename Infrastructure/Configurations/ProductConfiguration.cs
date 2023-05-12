﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
