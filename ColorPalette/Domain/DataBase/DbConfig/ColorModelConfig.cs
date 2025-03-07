using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class ColorModelConfig : IEntityTypeConfiguration<ColorModel>
{
    public void Configure(EntityTypeBuilder<ColorModel> builder)
    {
        builder.HasKey(c => c.ColorId);

        builder.HasIndex(c => c.HexCode)
            .IsUnique();

        builder.Property(c => c.HexCode)
            .IsRequired()
            .HasColumnType("varchar(7)");

        builder.Property(c => c.Name)
            .IsRequired(false)
            .HasColumnType("nvarchar(100)");

        builder.Property(c => c.Desciption)
            .IsRequired(false)
            .HasColumnType("nvarchar(200)");

        builder.Property(c => c.IsDeleted)
            .IsRequired(false);
    }
}
