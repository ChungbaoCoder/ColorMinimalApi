namespace ColorPalette.Domain.Models;

public class PaletteModel
{
    public int PaletteId { get; set; }
    public int ThemeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public int LikeCount { get; set; }
    public DateTime? IsDeleted { get; set; }
    public PaletteTheme PaletteTheme { get; set; } = null!;
    public ICollection<PaletteColor> PaletteColors { get; } = new List<PaletteColor>();
    public ICollection<PaletteTag> PaletteTags { get; } = new List<PaletteTag>();
}
