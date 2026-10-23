using CatalogoCursos.Api.Models;

namespace CatalogoCursos.Api.Data;

// Dados fictícios do catálogo. Os quatro primeiros cursos seguem os títulos do protótipo do Figma.
public static class SeedData
{
    public static readonly Categoria[] Categorias =
    {
        new() { Id = 1, Nome = "Matemática" },
        new() { Id = 2, Nome = "Ciências da Natureza" },
        new() { Id = 3, Nome = "Linguagens" },
        new() { Id = 4, Nome = "Sustentabilidade" }
    };

    public static readonly Curso[] Cursos =
    {
        new() { Id = 1, NomeCompleto = "Matemática para a Precisão: Medidas e Escalas na Metalurgia", NomeBreve = "Matemática na Metalurgia",
            Descricao = "Aplicação de grandezas, proporções e escalas em processos de corte, furação e usinagem.",
            CategoriaId = 1, Modalidade = "Online", CargaHoraria = 40, PublicoAlvo = "Estudantes e profissionais da área metalmecânica",
            Status = "Em andamento", ImagemUrl = "img/metalurgia.jpg", DataDisponibilizacao = new DateTime(2026, 1, 5) },
        new() { Id = 2, NomeCompleto = "Geometria e Modelagem no Design Têxtil", NomeBreve = "Geometria no Design Têxtil",
            Descricao = "Explora formas geométricas, simetria e padrões matemáticos presentes em tecidos e estampas.",
            CategoriaId = 1, Modalidade = "Híbrido", CargaHoraria = 30, PublicoAlvo = "Estudantes de moda e design e profissionais da indústria têxtil",
            Status = "Inscrições abertas", ImagemUrl = "img/textil.jpg", DataDisponibilizacao = new DateTime(2026, 11, 9) },
        new() { Id = 3, NomeCompleto = "Estatística e Controle de Qualidade na Produção", NomeBreve = "Estatística na Produção",
            Descricao = "Leitura e interpretação de dados de controle de qualidade e produtividade.",
            CategoriaId = 1, Modalidade = "Online", CargaHoraria = 60, PublicoAlvo = "Analistas e líderes de produção",
            Status = "Em andamento", ImagemUrl = "img/equipe.jpg", DataDisponibilizacao = new DateTime(2026, 3, 16) },
        new() { Id = 4, NomeCompleto = "Física do Movimento e da Energia na Metalurgia", NomeBreve = "Física na Metalurgia",
            Descricao = "Estudo de forças, atrito, calor e energia em máquinas, fornos e prensas.",
            CategoriaId = 2, Modalidade = "Híbrido", CargaHoraria = 45, PublicoAlvo = "Operadores e técnicos de manutenção",
            Status = "Inscrições abertas", ImagemUrl = "img/metalurgia.jpg", DataDisponibilizacao = new DateTime(2026, 11, 23) },
        new() { Id = 5, NomeCompleto = "Química Sustentável nos Processos de Acabamento", NomeBreve = "Química Sustentável",
            Descricao = "Estudo das reações envolvidas em tratamentos e acabamentos, com foco em reduzir resíduos.",
            CategoriaId = 2, Modalidade = "Online", CargaHoraria = 36, PublicoAlvo = "Técnicos e estudantes de química industrial",
            Status = "Em breve", ImagemUrl = "img/equipe.jpg", DataDisponibilizacao = new DateTime(2027, 2, 1) },
        new() { Id = 6, NomeCompleto = "Comunicação Técnica e Leitura de Manuais Industriais", NomeBreve = "Comunicação Técnica",
            Descricao = "Prática de leitura, escrita e interpretação de manuais, ordens de serviço e relatórios.",
            CategoriaId = 3, Modalidade = "Online", CargaHoraria = 24, PublicoAlvo = "Colaboradores de áreas operacionais e administrativas",
            Status = "Inscrições abertas", ImagemUrl = "img/equipe.jpg", DataDisponibilizacao = new DateTime(2026, 11, 2) },
        new() { Id = 7, NomeCompleto = "Gestão de Resíduos e Economia Circular na Indústria", NomeBreve = "Economia Circular",
            Descricao = "Como reduzir, reaproveitar e destinar resíduos industriais de forma responsável.",
            CategoriaId = 4, Modalidade = "Híbrido", CargaHoraria = 20, PublicoAlvo = "Gestores, supervisores e equipes de meio ambiente",
            Status = "Encerrado", ImagemUrl = "img/textil.jpg", DataDisponibilizacao = new DateTime(2025, 8, 18) },
        new() { Id = 8, NomeCompleto = "Inglês Técnico para a Indústria", NomeBreve = "Inglês Técnico",
            Descricao = "Vocabulário e expressões em inglês para manuais, normas e comunicação com fornecedores.",
            CategoriaId = 3, Modalidade = "Online", CargaHoraria = 50, PublicoAlvo = "Profissionais que lidam com equipamentos e documentação importados",
            Status = "Em breve", ImagemUrl = "img/textil.jpg", DataDisponibilizacao = null }
    };

    public static readonly Modulo[] Modulos =
    {
        new() { Id = 1, CursoId = 1, Titulo = "Grandezas e unidades", Descricao = "Sistema métrico, conversões e leitura de paquímetro e micrômetro." },
        new() { Id = 2, CursoId = 1, Titulo = "Proporção e escala", Descricao = "Ampliação e redução em desenhos técnicos de peças." },
        new() { Id = 3, CursoId = 1, Titulo = "Cálculos de usinagem", Descricao = "Velocidade de corte, avanço e tolerâncias na prática." },
        new() { Id = 4, CursoId = 2, Titulo = "Formas e simetrias", Descricao = "Figuras planas, rotações e reflexões em padrões de tecidos." },
        new() { Id = 5, CursoId = 2, Titulo = "Modelagem de estampas", Descricao = "Repetição de módulos e encaixe de estampas em tecidos." },
        new() { Id = 6, CursoId = 2, Titulo = "Medidas e moldes", Descricao = "Cálculo de áreas e aproveitamento de tecido." },
        new() { Id = 7, CursoId = 3, Titulo = "Coleta e organização de dados", Descricao = "Planilhas, amostragem e registro de medições da linha." },
        new() { Id = 8, CursoId = 3, Titulo = "Gráficos de controle", Descricao = "Média, desvio padrão e limites de controle." },
        new() { Id = 9, CursoId = 3, Titulo = "Melhoria contínua", Descricao = "Como usar os números para reduzir perdas e retrabalho." },
        new() { Id = 10, CursoId = 4, Titulo = "Forças e movimento", Descricao = "Leis de Newton aplicadas a prensas e esteiras." },
        new() { Id = 11, CursoId = 4, Titulo = "Atrito e desgaste", Descricao = "Lubrificação, perdas de energia e vida útil de peças." },
        new() { Id = 12, CursoId = 4, Titulo = "Calor e energia", Descricao = "Troca de calor em fornos e eficiência energética." },
        new() { Id = 13, CursoId = 5, Titulo = "Reações e materiais", Descricao = "Reações comuns em tratamentos de superfície." },
        new() { Id = 14, CursoId = 5, Titulo = "Acabamentos mais limpos", Descricao = "Alternativas com menor impacto ambiental." },
        new() { Id = 15, CursoId = 5, Titulo = "Segurança no manuseio", Descricao = "Rótulos, fichas de segurança e descarte correto." },
        new() { Id = 16, CursoId = 6, Titulo = "Lendo manuais", Descricao = "Estrutura de manuais, símbolos e avisos de segurança." },
        new() { Id = 17, CursoId = 6, Titulo = "Escrevendo com clareza", Descricao = "Ordens de serviço e relatórios curtos e objetivos." },
        new() { Id = 18, CursoId = 6, Titulo = "Comunicação na equipe", Descricao = "Passagem de turno e registro de ocorrências." },
        new() { Id = 19, CursoId = 7, Titulo = "Tipos de resíduos", Descricao = "Classificação e armazenamento seguro." },
        new() { Id = 20, CursoId = 7, Titulo = "Reaproveitamento", Descricao = "Reúso, reciclagem e logística reversa." },
        new() { Id = 21, CursoId = 7, Titulo = "Indicadores ambientais", Descricao = "Como medir e acompanhar resultados." },
        new() { Id = 22, CursoId = 8, Titulo = "Vocabulário de máquinas", Descricao = "Termos de peças, ferramentas e processos." },
        new() { Id = 23, CursoId = 8, Titulo = "Lendo normas e manuais", Descricao = "Estratégias para entender textos técnicos em inglês." },
        new() { Id = 24, CursoId = 8, Titulo = "E-mails e chamadas", Descricao = "Frases úteis para contato com fornecedores." }
    };
}
