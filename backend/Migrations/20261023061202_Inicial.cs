using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogoCursos.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    NomeBreve = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Modalidade = table.Column<string>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicoAlvo = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    ImagemUrl = table.Column<string>(type: "TEXT", nullable: false),
                    DataDisponibilizacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia" },
                    { 2, "Gestão" },
                    { 3, "Saúde e Segurança" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "CargaHoraria", "CategoriaId", "DataDisponibilizacao", "Descricao", "ImagemUrl", "Modalidade", "NomeBreve", "NomeCompleto", "PublicoAlvo", "Status" },
                values: new object[,]
                {
                    { 1, 40, 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprenda lógica de programação e os fundamentos do Python com exercícios práticos.", "/img/curso-1.svg", "Online", "Python Básico", "Introdução à Programação com Python", "Iniciantes em tecnologia", "Disponível" },
                    { 2, 30, 1, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tabelas dinâmicas, fórmulas avançadas e dashboards para apoiar decisões.", "/img/curso-2.svg", "Online", "Excel Avançado", "Excel Avançado para Análise de Dados", "Profissionais administrativos", "Disponível" },
                    { 3, 60, 2, new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scrum, Kanban e práticas ágeis para planejar e entregar projetos.", "/img/curso-3.svg", "Híbrido", "Projetos Ágeis", "Gestão de Projetos Ágeis", "Coordenadores e líderes de equipe", "Em breve" },
                    { 4, 24, 2, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolva comunicação clara, feedback e condução de equipes.", "/img/curso-4.svg", "Híbrido", "Liderança", "Comunicação e Liderança", "Gestores e futuros líderes", "Disponível" },
                    { 5, 20, 3, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normas, prevenção de acidentes e uso correto de equipamentos de proteção.", "/img/curso-5.svg", "Híbrido", "Segurança do Trabalho", "Segurança do Trabalho na Prática", "Colaboradores de áreas operacionais", "Encerrado" },
                    { 6, 16, 3, null, "Como agir em emergências até a chegada do atendimento especializado.", "/img/curso-6.svg", "Online", "Primeiros Socorros", "Primeiros Socorros no Ambiente de Trabalho", "Todos os colaboradores", "Em breve" }
                });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Id", "CursoId", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "Variáveis, condições e repetições.", "Lógica de programação" },
                    { 2, 1, "Funções, listas e pequenos projetos.", "Python na prática" },
                    { 3, 2, "PROCV, ÍNDICE/CORRESP e funções lógicas.", "Fórmulas avançadas" },
                    { 4, 2, "Tabelas dinâmicas e gráficos interativos.", "Dashboards" },
                    { 5, 3, "Valores, princípios e papéis no Scrum.", "Fundamentos ágeis" },
                    { 6, 3, "Planejamento, reuniões e fluxo de trabalho.", "Cerimônias e Kanban" },
                    { 7, 4, "Escuta ativa e clareza na mensagem.", "Comunicação eficaz" },
                    { 8, 4, "Como dar e receber feedback.", "Feedback e liderança" },
                    { 9, 5, "Principais normas e identificação de riscos.", "Normas e riscos" },
                    { 10, 5, "EPIs e procedimentos seguros.", "Prevenção na prática" },
                    { 11, 6, "Como avaliar a cena e pedir ajuda.", "Avaliação da situação" },
                    { 12, 6, "Ações iniciais em emergências comuns.", "Técnicas básicas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaId",
                table: "Cursos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_CursoId",
                table: "Modulos",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
