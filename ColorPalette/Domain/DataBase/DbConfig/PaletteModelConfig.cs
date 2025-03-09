using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class PaletteModelConfig : IEntityTypeConfiguration<PaletteModel>
{
    public void Configure(EntityTypeBuilder<PaletteModel> builder)
    {
        builder.HasKey(p => p.PaletteId);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("nvarchar(150)");

        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasColumnType("nvarchar(200)");

        builder.Property(p => p.IsDeleted)
            .IsRequired(false);
    }
}
