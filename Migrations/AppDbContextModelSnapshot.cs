﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendasInEstoque.Data;

#nullable disable

namespace VendasInEstoque.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VendasInEstoque.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_item_FK")
                        .HasColumnType("int");

                    b.Property<string>("NomeItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PedidoVendaId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("PedidoVendaId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.PedidoVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DataVenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClienteFK")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PedidoVendas");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Item", b =>
                {
                    b.HasOne("VendasInEstoque.Entities.Compra", null)
                        .WithMany("ItensComprados")
                        .HasForeignKey("CompraId");

                    b.HasOne("VendasInEstoque.Entities.PedidoVenda", null)
                        .WithMany("ItensVendidos")
                        .HasForeignKey("PedidoVendaId");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.Compra", b =>
                {
                    b.Navigation("ItensComprados");
                });

            modelBuilder.Entity("VendasInEstoque.Entities.PedidoVenda", b =>
                {
                    b.Navigation("ItensVendidos");
                });
#pragma warning restore 612, 618
        }
    }
}
