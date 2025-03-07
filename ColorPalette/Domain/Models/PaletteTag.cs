namespace ColorPalette.Domain.Models;

public class PaletteTag
{
    public int PaletteModelId { get; set; }
    public int TagId { get; set; }
    public DateTime? IsDeleted { get; set; }
    public PaletteModel PaletteModel { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
