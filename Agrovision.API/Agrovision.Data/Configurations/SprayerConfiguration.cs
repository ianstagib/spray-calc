﻿using Agrovision.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agrovision.Data.Configurations
{
    class SprayerConfiguration : IEntityTypeConfiguration<Sprayer>
    {
        public void Configure(EntityTypeBuilder<Sprayer> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
        }
    }
}