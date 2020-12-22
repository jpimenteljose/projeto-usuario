using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBRQ.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 30, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Endereco = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(maxLength: 20, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
