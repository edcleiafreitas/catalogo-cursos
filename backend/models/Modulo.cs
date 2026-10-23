namespace CatalogoCursos.Api.Models;

public class Modulo
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public string Titulo { get; set; } = "";
    public string Descricao { get; set; } = "";
}