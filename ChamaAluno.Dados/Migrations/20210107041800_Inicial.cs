using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace ChamaAluno.Dados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERFIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODIGOINTERNO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSAVEIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CARTAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOTO = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSAVEIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COLABORADORES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TELEFONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOISFATORES = table.Column<bool>(type: "bit", nullable: false),
                    CHAVEDOISFATORES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAILCONFIRMADO = table.Column<bool>(type: "bit", nullable: false),
                    IDDOPERFIL = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOTO = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLABORADORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COLABORADORES_PERFIS_IDDOPERFIL",
                        column: x => x.IDDOPERFIL,
                        principalTable: "PERFIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ALUNOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDATURMA = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOTO = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALUNOS_TURMAS_IDDATURMA",
                        column: x => x.IDDATURMA,
                        principalTable: "TURMAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ALUNOSRESP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDOALUNO = table.Column<int>(type: "int", nullable: false),
                    IDDORESPONSAVEL = table.Column<int>(type: "int", nullable: false),
                    INICIODAVALIDADE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TERMINODAVALIDADE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOMINGO = table.Column<bool>(type: "bit", nullable: false),
                    SEGUNDA = table.Column<bool>(type: "bit", nullable: false),
                    TERCA = table.Column<bool>(type: "bit", nullable: false),
                    QUARTA = table.Column<bool>(type: "bit", nullable: false),
                    QUINTA = table.Column<bool>(type: "bit", nullable: false),
                    SEXTA = table.Column<bool>(type: "bit", nullable: false),
                    SABADO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNOSRESP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALUNOSRESP_ALUNOS_IDDOALUNO",
                        column: x => x.IDDOALUNO,
                        principalTable: "ALUNOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALUNOSRESP_RESPONSAVEIS_IDDORESPONSAVEL",
                        column: x => x.IDDORESPONSAVEL,
                        principalTable: "RESPONSAVEIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PERFIS",
                columns: new[] { "ID", "CODIGOINTERNO", "DESCRICAO" },
                values: new object[] { 1, "0001", "Administrador" });

            migrationBuilder.InsertData(
                table: "COLABORADORES",
                columns: new[] { "ID", "CPF", "CHAVEDOISFATORES", "DOISFATORES", "EMAIL", "EMAILCONFIRMADO", "FOTO", "IDDOPERFIL", "NOME", "RG", "SENHA", "TELEFONE" },
                values: new object[] { 1, null, null, false, "Mestre", false, null, 1, "Usuário Mestre", null, "CclrsUlmNI3cQWINMvkUDT+7BdV1P92R3uMDlVoeKku4wcMI", null });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNOS_IDDATURMA",
                table: "ALUNOS",
                column: "IDDATURMA");

            migrationBuilder.CreateIndex(
                name: "IX_ALUNOSRESP_IDDOALUNO",
                table: "ALUNOSRESP",
                column: "IDDOALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_ALUNOSRESP_IDDORESPONSAVEL_INICIODAVALIDADE_TERMINODAVALIDADE",
                table: "ALUNOSRESP",
                columns: new[] { "IDDORESPONSAVEL", "INICIODAVALIDADE", "TERMINODAVALIDADE" });

            migrationBuilder.CreateIndex(
                name: "IX_COLABORADORES_IDDOPERFIL",
                table: "COLABORADORES",
                column: "IDDOPERFIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNOSRESP");

            migrationBuilder.DropTable(
                name: "COLABORADORES");

            migrationBuilder.DropTable(
                name: "ALUNOS");

            migrationBuilder.DropTable(
                name: "RESPONSAVEIS");

            migrationBuilder.DropTable(
                name: "PERFIS");

            migrationBuilder.DropTable(
                name: "TURMAS");
        }
    }
}
