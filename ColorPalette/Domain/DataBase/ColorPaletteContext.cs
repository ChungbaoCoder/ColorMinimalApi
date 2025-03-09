using ColorPalette.Domain.DataBase.DbConfig;
using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorPalette.Domain.DataBase;

public class ColorPaletteContext : DbContext
{
    public ColorPaletteContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ColorModel> ColorModels { get; set; }
    public DbSet<PaletteModel> PaletteModels { get; set; }
    public DbSet<PaletteColor> PaletteColors { get; set; }
    public DbSet<PaletteTheme> PaletteThemes { get; set; }

    protected ColorPaletteContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ColorModelConfig().Configure(modelBuilder.Entity<ColorModel>());
        new PaletteThemeConfig().Configure(modelBuilder.Entity<PaletteTheme>());
        new PaletteModelConfig().Configure(modelBuilder.Entity<PaletteModel>());
        new PaletteColorConfig().Configure(modelBuilder.Entity<PaletteColor>());
        new TagConfig().Configure(modelBuilder.Entity<Tag>());
        new PaletteTagConfig().Configure(modelBuilder.Entity<PaletteTag>());
    }
}
