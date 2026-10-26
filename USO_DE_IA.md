# Uso de Inteligência Artificial

Registro do uso de IA na atividade prática do processo seletivo (Desenvolvedor de Sistemas I, catálogo de cursos).

## 1. Ferramenta utilizada

- **Claude**, assistente de IA da Anthropic, usado pelo chat (claude.ai).
- Período de uso: de 22/10/2026 a 26/10/2026.
- Não usei outras ferramentas de IA no desenvolvimento.

## 2. Objetivo do uso

Usei o Claude como apoio em todas as etapas, principalmente para:

- planejar as etapas e o cronograma até o prazo de entrega;
- orientar a configuração do ambiente e da publicação;
- gerar a primeira versão do código do back-end (modelo de dados, migration, API) e do front-end (HTML, CSS e JavaScript), a partir do protótipo do Figma;
- escrever os dados fictícios dos cursos, módulos e descrições;
- interpretar mensagens de erro e indicar correções;
- redigir os rascunhos dos arquivos `README.md` e `USO_DE_IA.md`.

## 3. Divisão do trabalho

| O Claude gerou ou orientou | O que eu fiz |
| --- | --- |
| Plano em etapas, estimativa de horas e cronograma | Li as instruções da atividade, defini o que seria feito em cada dia e acompanhei o prazo |
| Lista de programas e sugestão da stack (.NET, SQLite) | Escolhi a stack, instalei e configurei o .NET SDK, Git, SQLite, VS Code e GitHub CLI |
| Código da API, modelo de dados e migration | Criei o projeto, organizei as pastas, executei os comandos, apliquei o código nos arquivos e corrigi a estrutura quando deu erro |
| Código do front-end e dados fictícios | Forneci os prints, as imagens e os ícones do Figma, apliquei os arquivos no projeto, rodei a aplicação e testei no navegador |
| Respostas para os erros do terminal e dos logs | Executei cada correção, apaguei e recriei o banco, limpei o repositório e confirmei se o erro tinha sumido |
| Passo a passo e arquivos de publicação (Dockerfile) | Criei o repositório e enviei o código ao GitHub, criei a conta e o serviço no Render, ajustei branch e pasta raiz, e acompanhei os deploys até a aplicação ficar no ar |
| Rascunhos do `README.md` e deste arquivo | Revisei, completei com os dados reais do projeto (links, publicação) e conferi se estavam de acordo com o que foi feito |

## 4. Prompts relevantes e o que foi aproveitado ou descartado

Os pedidos abaixo estão resumidos, porque a conversa foi feita em português, em mensagens curtas.

| Pedido (resumo) | Resultado | Aproveitado ou descartado |
| --- | --- | --- |
| Enviei o PDF da atividade e perguntei se dava para fazer com o Claude, passo a passo | Plano em 8 etapas e estimativa de 9 a 15 horas | **Aproveitado.** Usei a ordem das etapas e adaptei o cronograma |
| Quais programas instalar | Lista de obrigatórios e opcionais | **Aproveitado em parte.** Instalei os essenciais e descartei Docker local e Node.js, por não serem necessários |
| Problemas de login no GitHub pelo VS Code | Várias alternativas | **Aproveitado em parte.** O login pelo VS Code entrou em loop; resolvi com o GitHub CLI |
| Criar o modelo de dados, a migration e a API | Classes, contexto do banco e endpoints `/api/cursos`, `/api/cursos/{id}` e `/api/filtros` | **Aproveitado**, com correções (seção 6) |
| Envio do link do Figma, depois de prints e arquivos | O Claude não conseguiu abrir o link; gerou as páginas a partir dos prints | **Aproveitado.** Alguns textos cortados nos prints foram completados pela IA e estão nas limitações |
| Primeira versão dos dados fictícios (cursos genéricos) | Dados que não seguiam o Figma | **Descartado** e substituído pelos cursos do protótipo |
| Como publicar de graça | Passo a passo no Render, com Docker | **Aproveitado**, com correções (seção 6) |

## 5. Como o conteúdo foi validado

Feito por mim:

- Rodei `dotnet build` e `dotnet run` a cada mudança no back-end.
- Abri no navegador `/api/cursos`, `/api/cursos/{id}` e `/api/filtros` e conferi o total e os campos.
- Abri a página inicial e a de detalhes e conferi a navegação entre elas.
- Comparei a aparência com os prints do Figma e anotei as diferenças nas limitações do `README.md`.
- Acompanhei os logs de cada deploy no Render até a aplicação publicada abrir.

Feito pelo próprio Claude (não substitui os meus testes):

- Execução das páginas num navegador automatizado, com uma API simulada, para checar busca, filtros combinados, estados de carregamento, erro e "nenhum curso", ausência de rolagem lateral em larguras de 320 a 1280 px, ordem de navegação pelo teclado, tamanho dos alvos de toque e contraste de cores.

Testes que ainda registro como meus (marque quando concluir):

- [ ] Teste da aplicação publicada no computador e no celular
- [ ] Teste de navegação só pelo teclado
- [ ] Auditoria de acessibilidade com o Lighthouse (resultado: ___)

## 6. Exemplos de erros e inadequações identificados

**1. Dados fictícios que não seguiam o design.** A primeira versão trazia cursos genéricos (Python, Excel, gestão de projetos), categorias diferentes das do protótipo e imagens que não existiam no projeto. **Correção:** depois que enviei os prints e arquivos do Figma, os dados foram refeitos com os títulos e as categorias do protótipo. Como a migration antiga já existia, apareceu o erro `table "Categorias" already exists`; corrigi apagando o `catalogo.db` e gerando a migration de novo.

**2. Comando de PowerShell gravado dentro do `Dockerfile`.** O passo a passo para criar o arquivo usava um comando que, ao ser colado, deixou as marcas `@'` na primeira linha, e o Render falhou com `unknown instruction`. **Correção:** abri o arquivo, apaguei o conteúdo, colei só o texto do Dockerfile e conferi o resultado nos logs.

**3. Pastas `bin` e `obj` enviadas ao GitHub.** O repositório subiu arquivos de compilação do meu computador, e o build no Render falhou por não achar um pacote. **Correção:** criei o `.gitignore`, removi as pastas do repositório com `git rm --cached` e o Dockerfile passou a restaurar os pacotes no servidor.

**4. Nome do branch.** As instruções usavam `master`, mas o meu branch local era `main`, e o envio falhou. **Correção:** enviei o `main` e troquei o branch no Render.

**5. Instrução ambígua.** A orientação para editar o `Program.cs` em duas partes não ficou clara. **Correção:** pedi de novo e passei a substituir o arquivo inteiro.

## 7. Responsabilidade

Todo o código gerado com apoio de IA foi executado, testado e publicado por mim antes de entrar no repositório. Os dados e textos da aplicação são fictícios.
