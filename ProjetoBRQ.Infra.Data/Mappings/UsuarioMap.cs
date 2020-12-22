using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBRQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Infra.Data.Mappings
{
    public class UsuarioMap
        : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Id");

            builder.Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(m => m.Sobrenome)
            .HasColumnName("Sobrenome")
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(m => m.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();

            builder.Property(m => m.DataNascimento)
                .HasColumnName("Data")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(m => m.Cep)
            .HasColumnName("Cep")
            .HasMaxLength(8)
            .IsRequired();

            builder.Property(m => m.Endereco)
            .HasColumnName("Endereco")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(m => m.Numero)
            .HasColumnName("Numero")
            .HasMaxLength(10)
            .IsRequired();

            builder.Property(m => m.Complemento)
            .HasColumnName("Complemento")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(m => m.Cidade)
            .HasColumnName("Cidade")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(m => m.Estado)
            .HasColumnName("Estado")
            .HasMaxLength(2)
            .IsRequired();

        }
    }
}
