using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class PaletteColorConfig : IEntityTypeConfiguration<PaletteColor>
{
    public void Configure(EntityTypeBuilder<PaletteColor> builder)
    {
        builder.HasKey(cp => new { cp.ColorModelId, cp.PaletteModelId });

        builder.Property(cp => cp.ColorOrder)
            .IsRequired(false)
            .HasColumnType("tinyint");

        builder.HasOne(cp => cp.ColorModel)
            .WithMany(c => c.PaletteColors)
            .HasForeignKey(cp => cp.ColorModelId);

        builder.HasOne(cp => cp.PaletteModel)
            .WithMany(p => p.PaletteColors)
            .HasForeignKey(cp => cp.PaletteModelId);

        builder.Property(cp => cp.IsDeleted)
            .IsRequired(false);
    }
}
