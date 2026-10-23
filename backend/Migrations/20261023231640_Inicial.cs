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
                    { 1, "Matemática" },
                    { 2, "Ciências da Natureza" },
                    { 3, "Linguagens" },
                    { 4, "Sustentabilidade" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "CargaHoraria", "CategoriaId", "DataDisponibilizacao", "Descricao", "ImagemUrl", "Modalidade", "NomeBreve", "NomeCompleto", "PublicoAlvo", "Status" },
                values: new object[,]
                {
                    { 1, 40, 1, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aplicação de grandezas, proporções e escalas em processos de corte, furação e usinagem.", "img/metalurgia.jpg", "Online", "Matemática na Metalurgia", "Matemática para a Precisão: Medidas e Escalas na Metalurgia", "Estudantes e profissionais da área metalmecânica", "Em andamento" },
                    { 2, 30, 1, new DateTime(2026, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explora formas geométricas, simetria e padrões matemáticos presentes em tecidos e estampas.", "img/textil.jpg", "Híbrido", "Geometria no Design Têxtil", "Geometria e Modelagem no Design Têxtil", "Estudantes de moda e design e profissionais da indústria têxtil", "Inscrições abertas" },
                    { 3, 60, 1, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leitura e interpretação de dados de controle de qualidade e produtividade.", "img/equipe.jpg", "Online", "Estatística na Produção", "Estatística e Controle de Qualidade na Produção", "Analistas e líderes de produção", "Em andamento" },
                    { 4, 45, 2, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estudo de forças, atrito, calor e energia em máquinas, fornos e prensas.", "img/metalurgia.jpg", "Híbrido", "Física na Metalurgia", "Física do Movimento e da Energia na Metalurgia", "Operadores e técnicos de manutenção", "Inscrições abertas" },
                    { 5, 36, 2, new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estudo das reações envolvidas em tratamentos e acabamentos, com foco em reduzir resíduos.", "img/equipe.jpg", "Online", "Química Sustentável", "Química Sustentável nos Processos de Acabamento", "Técnicos e estudantes de química industrial", "Em breve" },
                    { 6, 24, 3, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prática de leitura, escrita e interpretação de manuais, ordens de serviço e relatórios.", "img/equipe.jpg", "Online", "Comunicação Técnica", "Comunicação Técnica e Leitura de Manuais Industriais", "Colaboradores de áreas operacionais e administrativas", "Inscrições abertas" },
                    { 7, 20, 4, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Como reduzir, reaproveitar e destinar resíduos industriais de forma responsável.", "img/textil.jpg", "Híbrido", "Economia Circular", "Gestão de Resíduos e Economia Circular na Indústria", "Gestores, supervisores e equipes de meio ambiente", "Encerrado" },
                    { 8, 50, 3, null, "Vocabulário e expressões em inglês para manuais, normas e comunicação com fornecedores.", "img/textil.jpg", "Online", "Inglês Técnico", "Inglês Técnico para a Indústria", "Profissionais que lidam com equipamentos e documentação importados", "Em breve" }
                });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Id", "CursoId", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "Sistema métrico, conversões e leitura de paquímetro e micrômetro.", "Grandezas e unidades" },
                    { 2, 1, "Ampliação e redução em desenhos técnicos de peças.", "Proporção e escala" },
                    { 3, 1, "Velocidade de corte, avanço e tolerâncias na prática.", "Cálculos de usinagem" },
                    { 4, 2, "Figuras planas, rotações e reflexões em padrões de tecidos.", "Formas e simetrias" },
                    { 5, 2, "Repetição de módulos e encaixe de estampas em tecidos.", "Modelagem de estampas" },
                    { 6, 2, "Cálculo de áreas e aproveitamento de tecido.", "Medidas e moldes" },
                    { 7, 3, "Planilhas, amostragem e registro de medições da linha.", "Coleta e organização de dados" },
                    { 8, 3, "Média, desvio padrão e limites de controle.", "Gráficos de controle" },
                    { 9, 3, "Como usar os números para reduzir perdas e retrabalho.", "Melhoria contínua" },
                    { 10, 4, "Leis de Newton aplicadas a prensas e esteiras.", "Forças e movimento" },
                    { 11, 4, "Lubrificação, perdas de energia e vida útil de peças.", "Atrito e desgaste" },
                    { 12, 4, "Troca de calor em fornos e eficiência energética.", "Calor e energia" },
                    { 13, 5, "Reações comuns em tratamentos de superfície.", "Reações e materiais" },
                    { 14, 5, "Alternativas com menor impacto ambiental.", "Acabamentos mais limpos" },
                    { 15, 5, "Rótulos, fichas de segurança e descarte correto.", "Segurança no manuseio" },
                    { 16, 6, "Estrutura de manuais, símbolos e avisos de segurança.", "Lendo manuais" },
                    { 17, 6, "Ordens de serviço e relatórios curtos e objetivos.", "Escrevendo com clareza" },
                    { 18, 6, "Passagem de turno e registro de ocorrências.", "Comunicação na equipe" },
                    { 19, 7, "Classificação e armazenamento seguro.", "Tipos de resíduos" },
                    { 20, 7, "Reúso, reciclagem e logística reversa.", "Reaproveitamento" },
                    { 21, 7, "Como medir e acompanhar resultados.", "Indicadores ambientais" },
                    { 22, 8, "Termos de peças, ferramentas e processos.", "Vocabulário de máquinas" },
                    { 23, 8, "Estratégias para entender textos técnicos em inglês.", "Lendo normas e manuais" },
                    { 24, 8, "Frases úteis para contato com fornecedores.", "E-mails e chamadas" }
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
