namespace ColorPalette.Domain.Models;

public class Tag
{
    public int TagId { get; set; }
    public required string Name { get; set; }
    public DateTime? IsDeleted { get; set; }
    public ICollection<PaletteTag> PaletteTags { get; } = new List<PaletteTag>();
}
