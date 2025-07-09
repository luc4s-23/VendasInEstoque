﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasInEstoque.Migrations
{
    /// <inheritdoc />
    public partial class BD_reformulado_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_item_FK = table.Column<int>(type: "int", nullable: false),
                    QntAtual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QntMinima = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Item_FK = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuantidadeEntrada = table.Column<int>(type: "int", nullable: true),
                    Id_LancamentoEntrada_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensEntrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensSaida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Item_FK = table.Column<int>(type: "int", nullable: false),
                    QuantidadeSaida = table.Column<int>(type: "int", nullable: true),
                    Id_LancamentoSaida_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensSaida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoEntradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNF_Entrada = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoEntradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoSaidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente_FK = table.Column<int>(type: "int", nullable: false),
                    NumeroNF_Saida = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoSaidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "ItensEntrada");

            migrationBuilder.DropTable(
                name: "ItensSaida");

            migrationBuilder.DropTable(
                name: "LancamentoEntradas");

            migrationBuilder.DropTable(
                name: "LancamentoSaidas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
