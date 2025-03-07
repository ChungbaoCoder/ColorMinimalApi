using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class PaletteTagConfig : IEntityTypeConfiguration<PaletteTag>
{
    public void Configure(EntityTypeBuilder<PaletteTag> builder)
    {
        builder.HasKey(pt => new { pt.PaletteModelId, pt.TagId });

        builder.HasOne(p => p.PaletteModel)
            .WithMany(pt => pt.PaletteTags)
            .HasForeignKey(p => p.PaletteModelId);

        builder.HasOne(t => t.Tag)
            .WithMany(pt => pt.PaletteTags)
            .HasForeignKey(t => t.TagId);

        builder.Property(pt => pt.IsDeleted)
            .IsRequired(false);
    }
}
