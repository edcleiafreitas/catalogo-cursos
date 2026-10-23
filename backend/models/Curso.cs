namespace CatalogoCursos.Api.Models;

public class Curso
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = "";
    public string NomeBreve { get; set; } = "";
    public string Descricao { get; set; } = "";
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public string Modalidade { get; set; } = "";
    public int CargaHoraria { get; set; }
    public string PublicoAlvo { get; set; } = "";
    public string Status { get; set; } = "";
    public string ImagemUrl { get; set; } = "";
    public DateTime? DataDisponibilizacao { get; set; }
    public List<Modulo> Modulos { get; set; } = new();
}