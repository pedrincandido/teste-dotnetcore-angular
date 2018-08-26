using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Impl.Configuration
{
    public class CrediarioConfig : IEntityTypeConfiguration<Crediario>
    {
        public void Configure(EntityTypeBuilder<Crediario> entity)
        {
            entity.ToTable("CREDIARIO");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(e => e.SchedulingPayment).HasColumnName("SCHEDULING_PAYMENT").HasColumnType("datetime2").IsRequired();
            entity.Property(e => e.Rate).HasColumnName("RATES").IsRequired(false);
            entity.Property(e => e.FinalValue).HasColumnName("FINAL_VALUE").IsRequired();

            entity.HasOne<Person>(e => e.Person).WithMany()
            .HasForeignKey(e => e.PersonId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>(e => e.User).WithMany()
           .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}


