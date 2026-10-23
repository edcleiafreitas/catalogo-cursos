using CatalogoCursos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCursos.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Modulo> Modulos => Set<Modulo>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Tecnologia" },
            new Categoria { Id = 2, Nome = "Gestão" },
            new Categoria { Id = 3, Nome = "Saúde e Segurança" });

        b.Entity<Curso>().HasData(
            new Curso { Id = 1, NomeCompleto = "Introdução à Programação com Python", NomeBreve = "Python Básico",
                Descricao = "Aprenda lógica de programação e os fundamentos do Python com exercícios práticos.",
                CategoriaId = 1, Modalidade = "Online", CargaHoraria = 40, PublicoAlvo = "Iniciantes em tecnologia",
                Status = "Disponível", ImagemUrl = "/img/curso-1.svg", DataDisponibilizacao = new DateTime(2026, 3, 1) },
            new Curso { Id = 2, NomeCompleto = "Excel Avançado para Análise de Dados", NomeBreve = "Excel Avançado",
                Descricao = "Tabelas dinâmicas, fórmulas avançadas e dashboards para apoiar decisões.",
                CategoriaId = 1, Modalidade = "Online", CargaHoraria = 30, PublicoAlvo = "Profissionais administrativos",
                Status = "Disponível", ImagemUrl = "/img/curso-2.svg", DataDisponibilizacao = new DateTime(2026, 4, 10) },
            new Curso { Id = 3, NomeCompleto = "Gestão de Projetos Ágeis", NomeBreve = "Projetos Ágeis",
                Descricao = "Scrum, Kanban e práticas ágeis para planejar e entregar projetos.",
                CategoriaId = 2, Modalidade = "Híbrido", CargaHoraria = 60, PublicoAlvo = "Coordenadores e líderes de equipe",
                Status = "Em breve", ImagemUrl = "/img/curso-3.svg", DataDisponibilizacao = new DateTime(2026, 11, 15) },
            new Curso { Id = 4, NomeCompleto = "Comunicação e Liderança", NomeBreve = "Liderança",
                Descricao = "Desenvolva comunicação clara, feedback e condução de equipes.",
                CategoriaId = 2, Modalidade = "Híbrido", CargaHoraria = 24, PublicoAlvo = "Gestores e futuros líderes",
                Status = "Disponível", ImagemUrl = "/img/curso-4.svg", DataDisponibilizacao = new DateTime(2026, 2, 5) },
            new Curso { Id = 5, NomeCompleto = "Segurança do Trabalho na Prática", NomeBreve = "Segurança do Trabalho",
                Descricao = "Normas, prevenção de acidentes e uso correto de equipamentos de proteção.",
                CategoriaId = 3, Modalidade = "Híbrido", CargaHoraria = 20, PublicoAlvo = "Colaboradores de áreas operacionais",
                Status = "Encerrado", ImagemUrl = "/img/curso-5.svg", DataDisponibilizacao = new DateTime(2025, 8, 20) },
            new Curso { Id = 6, NomeCompleto = "Primeiros Socorros no Ambiente de Trabalho", NomeBreve = "Primeiros Socorros",
                Descricao = "Como agir em emergências até a chegada do atendimento especializado.",
                CategoriaId = 3, Modalidade = "Online", CargaHoraria = 16, PublicoAlvo = "Todos os colaboradores",
                Status = "Em breve", ImagemUrl = "/img/curso-6.svg", DataDisponibilizacao = null });

        b.Entity<Modulo>().HasData(
            new Modulo { Id = 1, CursoId = 1, Titulo = "Lógica de programação", Descricao = "Variáveis, condições e repetições." },
            new Modulo { Id = 2, CursoId = 1, Titulo = "Python na prática", Descricao = "Funções, listas e pequenos projetos." },
            new Modulo { Id = 3, CursoId = 2, Titulo = "Fórmulas avançadas", Descricao = "PROCV, ÍNDICE/CORRESP e funções lógicas." },
            new Modulo { Id = 4, CursoId = 2, Titulo = "Dashboards", Descricao = "Tabelas dinâmicas e gráficos interativos." },
            new Modulo { Id = 5, CursoId = 3, Titulo = "Fundamentos ágeis", Descricao = "Valores, princípios e papéis no Scrum." },
            new Modulo { Id = 6, CursoId = 3, Titulo = "Cerimônias e Kanban", Descricao = "Planejamento, reuniões e fluxo de trabalho." },
            new Modulo { Id = 7, CursoId = 4, Titulo = "Comunicação eficaz", Descricao = "Escuta ativa e clareza na mensagem." },
            new Modulo { Id = 8, CursoId = 4, Titulo = "Feedback e liderança", Descricao = "Como dar e receber feedback." },
            new Modulo { Id = 9, CursoId = 5, Titulo = "Normas e riscos", Descricao = "Principais normas e identificação de riscos." },
            new Modulo { Id = 10, CursoId = 5, Titulo = "Prevenção na prática", Descricao = "EPIs e procedimentos seguros." },
            new Modulo { Id = 11, CursoId = 6, Titulo = "Avaliação da situação", Descricao = "Como avaliar a cena e pedir ajuda." },
            new Modulo { Id = 12, CursoId = 6, Titulo = "Técnicas básicas", Descricao = "Ações iniciais em emergências comuns." });
    }
}