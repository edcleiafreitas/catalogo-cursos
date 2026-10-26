# Catálogo de Cursos SESI + Indústria

Aplicação web de catálogo de cursos, desenvolvida como atividade prática do processo seletivo de Desenvolvedor de Sistemas I. Todos os dados exibidos são fictícios.

- **Aplicação publicada:** https://catalogo-cursos-oj9r.onrender.com
- **Repositório:** https://github.com/edcleiafreitas/catalogo-cursos

> A aplicação está em um plano gratuito, que "dorme" quando fica parada. O primeiro acesso pode levar cerca de 50 segundos. Se o serviço estiver indisponível, veja as instruções de execução local na seção 5.

## 1. Objetivo da aplicação

Permitir que a pessoa consulte, pesquise e filtre os cursos de um ambiente educacional e veja os detalhes de cada oferta. O visual segue o protótipo do Figma fornecido. A integração com o Moodle não foi feita (era opcional).

Funcionalidades:

- Listagem dos cursos por meio da API.
- Pesquisa pelo nome do curso.
- Filtros por categoria, modalidade e status, combináveis entre si e com a pesquisa.
- Quantidade de resultados, botão de limpar filtros e mensagem quando nenhum curso é encontrado.
- Estados de carregamento e de erro, com botão para tentar de novo.
- Página de detalhes com descrição, ficha do curso e módulos.
- Interface responsiva e acessível.

## 2. Tecnologias utilizadas

| Camada | Tecnologia |
| --- | --- |
| Back-end | C# com ASP.NET Core (.NET 10), Minimal API |
| Acesso a dados | Entity Framework Core com migrations |
| Banco de dados | SQLite (código aberto) |
| Front-end | HTML5, CSS3 e JavaScript puro (sem frameworks) |
| Fonte | Open Sans (Google Fonts), com fontes do sistema como alternativa |
| Publicação | Docker e Render (plano gratuito) |
| Controle de versão | Git e GitHub |

## 3. Arquitetura da solução

```
Navegador (HTML/CSS/JS)  --HTTP/JSON-->  API ASP.NET Core  --EF Core-->  SQLite (catalogo.db)
```

- A própria API entrega as páginas estáticas da pasta `wwwroot` e expõe os endpoints em `/api`. Assim, front-end e back-end são publicados juntos e usam a mesma origem.
- O front-end chama a API com `fetch`. A cada mudança de busca ou filtro, uma nova consulta é feita e a anterior é cancelada, para evitar respostas fora de ordem.
- Ao iniciar, a API aplica as migrations e cria o banco com os dados fictícios (`Database.Migrate()`).

## 4. Estrutura das pastas

```
catalogo-cursos/
├── README.md
├── USO_DE_IA.md
├── .gitignore
└── backend/
    ├── Program.cs                 # configuração da API e dos endpoints
    ├── CatalogoCursos.Api.csproj
    ├── Dockerfile                 # imagem usada na publicação
    ├── .dockerignore
    ├── Models/                    # Curso, Categoria, Modulo
    ├── Data/
    │   ├── AppDbContext.cs        # contexto do banco
    │   └── SeedData.cs            # dados fictícios
    ├── Migrations/                # migrations do EF Core
    └── wwwroot/                   # front-end
        ├── index.html             # catálogo
        ├── curso.html             # detalhes do curso
        ├── css/estilos.css
        ├── js/ (comum.js, catalogo.js, curso.js)
        └── img/                   # imagens, logos e ícones
```

## 5. Instruções para execução

Pré-requisitos: **.NET SDK 10** e **Git**.

```bash
git clone https://github.com/edcleiafreitas/catalogo-cursos.git
cd catalogo-cursos/backend
dotnet run
```

Abra no navegador o endereço exibido no terminal (por exemplo, `http://localhost:5032`). Para parar, use `Ctrl+C`.

Se o banco já existir com dados antigos e aparecer o erro `table already exists`, apague os arquivos `catalogo.db*` na pasta `backend` e rode `dotnet run` de novo.

## 6. Configuração do banco

- Banco: **SQLite**, arquivo `catalogo.db` criado na pasta `backend` (string de conexão em `Program.cs`).
- Não é preciso instalar servidor de banco.
- As migrations ficam em `backend/Migrations` e são aplicadas automaticamente na inicialização.
- Para recriar do zero: apague `catalogo.db*` e rode `dotnet run`.
- Para gerar uma nova migration após mudar o modelo (requer `dotnet tool install --global dotnet-ef`):

```bash
dotnet ef migrations add NomeDaMigration
```

## 7. Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/api/cursos` | Lista os cursos. Parâmetros opcionais: `busca` (texto), `categoria` (id), `modalidade`, `status`. Combináveis. |
| GET | `/api/cursos/{id}` | Detalhes de um curso, com seus módulos. Retorna 404 se não existir. |
| GET | `/api/filtros` | Categorias, modalidades e status disponíveis para montar os filtros. |

Exemplo:

```
GET /api/cursos?busca=matem&modalidade=Online
```

```json
{
  "total": 1,
  "cursos": [
    {
      "id": 1,
      "nomeCompleto": "Matemática para a Precisão: Medidas e Escalas na Metalurgia",
      "nomeBreve": "Matemática na Metalurgia",
      "descricao": "Aplicação de grandezas, proporções e escalas em processos de corte, furação e usinagem.",
      "categoria": "Matemática",
      "modalidade": "Online",
      "cargaHoraria": 40,
      "publicoAlvo": "Estudantes e profissionais da área metalmecânica",
      "status": "Em andamento",
      "imagemUrl": "img/metalurgia.jpg",
      "dataDisponibilizacao": "2026-01-05T00:00:00"
    }
  ]
}
```

## 8. Modelo de dados

```
Categoria 1 ──── N Curso 1 ──── N Modulo
```

| Tabela | Campos |
| --- | --- |
| Categoria | Id, Nome |
| Curso | Id, NomeCompleto, NomeBreve, Descricao, CategoriaId, Modalidade, CargaHoraria, PublicoAlvo, Status, ImagemUrl, DataDisponibilizacao (opcional) |
| Modulo | Id, CursoId, Titulo, Descricao |

Dados de exemplo: 8 cursos, 4 categorias (Matemática, Ciências da Natureza, Linguagens, Sustentabilidade), 2 modalidades (Online, Híbrido), 4 status (Inscrições abertas, Em andamento, Em breve, Encerrado) e 3 módulos por curso, com cargas horárias de 20 a 60 horas.

## 9. Estratégia de responsividade

- Abordagem fluida: `grid` com `repeat(auto-fill, minmax(...))` para os cards, `flex` para menus e barras, e unidades relativas.
- Pontos de quebra em **960 px** (filtros em duas colunas, detalhes em coluna única) e **600 px** (filtros e destaques em uma coluna, barra de matrícula empilhada).
- O carrossel usa rolagem horizontal com `scroll-snap`, funcionando por toque, setas e teclado.
- Imagens com `max-width: 100%` e `object-fit: cover`; o corpo da página não rola para os lados em telas estreitas (verificado de 320 a 1280 px).

## 10. Decisões de acessibilidade

- HTML semântico (`header`, `nav`, `main`, `section`, `article`, `footer`) e hierarquia de títulos, com idioma `pt-BR`.
- Link "Pular para o conteúdo" no início das páginas.
- Campos de pesquisa e filtros com `label` associado, e área de busca identificada com `role="search"`.
- A quantidade de resultados é anunciada com `aria-live="polite"` e a região de resultados usa `aria-busy` durante o carregamento.
- Foco visível em todos os elementos interativos e alvos de toque de pelo menos 44 px de altura.
- Imagens decorativas com `alt=""`; imagens com informação têm texto alternativo; botões só com ícone têm `aria-label`.
- Módulos do curso com `details`/`summary`, que funcionam pelo teclado sem JavaScript extra.
- Contraste de cores acima do mínimo recomendado nos textos principais (por exemplo, branco sobre o vinho dos cards, 8,5:1).
- Respeito a `prefers-reduced-motion` (rolagem suave e animação de carregamento reduzidas).
- Conteúdo dos cursos inserido com `textContent`, evitando injeção de HTML.

## 11. Processo de publicação

A aplicação foi publicada no **Render**, em um serviço do tipo *Web Service* no plano gratuito, usando Docker (o .NET não tem ambiente nativo na plataforma).

1. O código foi enviado ao GitHub (branch `main`).
2. No Render: *New > Web Service*, repositório `catalogo-cursos`, *Language* = **Docker**, *Branch* = `main`, *Root Directory* = `backend`, *Instance Type* = **Free**.
3. O `Dockerfile` (em `backend`) compila e publica o projeto em uma imagem do SDK do .NET 10 e executa a aplicação em uma imagem enxuta do ASP.NET. A porta é lida da variável `PORT` informada pelo Render.
4. A cada `git push` no branch `main`, o Render refaz o deploy automaticamente.
5. Ao iniciar, a aplicação aplica as migrations e cria o banco SQLite com os dados fictícios.

Não foi necessário configurar variáveis de ambiente nem contratar serviços pagos. Os arquivos de publicação também estão disponíveis em ZIP (`publicacao.zip`), gerado com `dotnet publish -c Release -o publicacao`.

## 12. Limitações conhecidas

Diferenças em relação ao Figma e itens não concluídos:

- Foram fornecidas apenas três fotografias, então alguns cursos reaproveitam a mesma imagem nos cards.
- A tela de catálogo com busca e filtros foi criada seguindo o estilo das demais telas, pois não constava nos prints recebidos.
- O botão de play da página de detalhes é ilustrativo (não há vídeo) e o botão "Matricule-se" apenas exibe um aviso.
- Os textos dos quatro destaques da página de detalhes e a descrição do curso de Química Sustentável foram completados, porque estavam cortados nos prints.
- As cores das categorias Linguagens e Sustentabilidade não constavam no Figma e foram escolhidas por mim.
- Links de "Área do aluno", "Sobre" e redes sociais não levam a páginas reais.
- Não há cadastro, edição ou exclusão de cursos (fora do escopo) e não há paginação (o catálogo de exemplo é pequeno).
- Integração com o Moodle não realizada (diferencial opcional).
- No plano gratuito do Render, o serviço "dorme" após um tempo sem acessos e o primeiro acesso pode levar cerca de 50 segundos.
- O disco do plano gratuito é temporário: o banco SQLite volta ao estado inicial a cada reinício (os dados são recriados pelas migrations).
- Não há testes automatizados de unidade; a validação foi manual e por verificações automáticas de navegador.

## 13. Uso de Inteligência Artificial

Detalhado em [USO_DE_IA.md](USO_DE_IA.md).
