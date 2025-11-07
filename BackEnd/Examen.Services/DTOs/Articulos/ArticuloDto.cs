namespace Examen.Services.DTOs.Articulos;

public class ArticuloDto
{
    public int Id { get; set; }

    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Imagen { get; set; } = null!;

    public int Stock { get; set; }
}
