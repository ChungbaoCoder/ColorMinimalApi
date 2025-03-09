using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class PaletteThemeConfig : IEntityTypeConfiguration<PaletteTheme>
{
    public void Configure(EntityTypeBuilder<PaletteTheme> builder)
    {
        builder.HasKey(pt => pt.ThemeId);

        builder.HasIndex(pt => pt.Name)
            .IsUnique();

        builder.Property(pt => pt.Name)
            .IsRequired()
            .HasColumnType("nvarchar(150)");

        builder.Property(pt => pt.Description)
            .IsRequired(false)
            .HasColumnType("nvarchar(200)");

        builder.HasMany(p => p.PaletteModels)
            .WithOne(pt => pt.PaletteTheme)
            .HasForeignKey(p => p.ThemeId);

        builder.Property(pt => pt.IsDeleted)
            .IsRequired(false);
    }
}
