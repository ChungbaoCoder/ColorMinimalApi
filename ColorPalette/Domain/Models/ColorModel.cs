namespace ColorPalette.Domain.Models;

public class ColorModel
{
    public int ColorId { get; set; }
    public required string HexCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desciption { get; set; } = string.Empty;
    public DateTime? IsDeleted { get; set; }
    public ICollection<PaletteColor> PaletteColors { get; } = new List<PaletteColor>();
}
