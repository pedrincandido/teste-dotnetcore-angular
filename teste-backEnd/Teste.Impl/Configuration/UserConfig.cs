using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Impl.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("USER");


            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(e => e.Login).HasColumnName("NAME").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Password).HasColumnName("PASSWORD").HasMaxLength(20).IsRequired();
        }
    }
}
