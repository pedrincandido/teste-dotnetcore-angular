using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Impl.Configuration
{
    public class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> entity)
        {
            entity.ToTable("tb_Gender");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

        }
    }
}


