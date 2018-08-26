using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Impl.Configuration
{
    public class SalesConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.ToTable("SALE");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(e => e.PurchaseDate).HasColumnName("PURCHASE_DATE").HasColumnType("datetime2");
            entity.Property(e => e.Value).HasColumnName("Value").IsRequired();
            entity.Property(e => e.EnableSale).HasColumnName("ENABLE_SALE").IsRequired();
            entity.Property(e => e.CreadiarioId).HasColumnName("CREDIARIO_ID").IsRequired(false);

            entity.HasOne<Crediario>(x => x.Crediario).WithMany(x => x.Sales).HasConstraintName("FK_SALE_CREDIARIO_CREDIARIO_ID").HasForeignKey(x => x.CreadiarioId);
        }
    }
}
