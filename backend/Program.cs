using CatalogoCursos.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite("Data Source=catalogo.db"));

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
}

app.MapGet("/api/cursos", async (AppDbContext db, string? busca, int? categoria, string? modalidade, string? status) =>
{
    var q = db.Cursos.AsNoTracking().AsQueryable();

    if (!string.IsNullOrWhiteSpace(busca))
    {
        var t = busca.Trim().ToLower();
        q = q.Where(c => c.NomeCompleto.ToLower().Contains(t) || c.NomeBreve.ToLower().Contains(t));
    }
    if (categoria.HasValue) q = q.Where(c => c.CategoriaId == categoria.Value);
    if (!string.IsNullOrWhiteSpace(modalidade)) q = q.Where(c => c.Modalidade == modalidade);
    if (!string.IsNullOrWhiteSpace(status)) q = q.Where(c => c.Status == status);

    var cursos = await q.OrderBy(c => c.NomeCompleto).Select(c => new
    {
        c.Id, c.NomeCompleto, c.NomeBreve, c.Descricao,
        Categoria = c.Categoria!.Nome,
        c.Modalidade, c.CargaHoraria, c.PublicoAlvo, c.Status, c.ImagemUrl, c.DataDisponibilizacao
    }).ToListAsync();

    return Results.Ok(new { total = cursos.Count, cursos });
});

app.MapGet("/api/cursos/{id:int}", async (AppDbContext db, int id) =>
{
    var curso = await db.Cursos.AsNoTracking().Where(c => c.Id == id).Select(c => new
    {
        c.Id, c.NomeCompleto, c.NomeBreve, c.Descricao,
        Categoria = c.Categoria!.Nome,
        c.Modalidade, c.CargaHoraria, c.PublicoAlvo, c.Status, c.ImagemUrl, c.DataDisponibilizacao,
        Modulos = c.Modulos.Select(m => new { m.Id, m.Titulo, m.Descricao })
    }).FirstOrDefaultAsync();

    return curso is null ? Results.NotFound() : Results.Ok(curso);
});

app.MapGet("/api/filtros", async (AppDbContext db) => Results.Ok(new
{
    categorias = await db.Categorias.OrderBy(c => c.Nome).Select(c => new { c.Id, c.Nome }).ToListAsync(),
    modalidades = await db.Cursos.Select(c => c.Modalidade).Distinct().OrderBy(x => x).ToListAsync(),
    status = await db.Cursos.Select(c => c.Status).Distinct().OrderBy(x => x).ToListAsync()
}));

app.Run();