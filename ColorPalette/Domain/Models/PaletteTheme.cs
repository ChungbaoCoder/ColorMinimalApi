namespace ColorPalette.Domain.Models;

public class PaletteTheme
{
    public int ThemeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? IsDeleted { get; set; }
    public ICollection<PaletteModel> PaletteModels { get; } = new List<PaletteModel>();
}
