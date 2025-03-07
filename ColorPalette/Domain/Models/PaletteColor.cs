namespace ColorPalette.Domain.Models;

public class PaletteColor
{
    public int ColorModelId { get; set; }
    public int PaletteModelId { get; set; }
    public int? ColorOrder { get; set; }
    public DateTime? IsDeleted { get; set; }
    public ColorModel ColorModel { get; set; } = null!;
    public PaletteModel PaletteModel { get; set; } = null!;
}
