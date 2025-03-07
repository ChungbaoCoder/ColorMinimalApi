using ColorPalette.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorPalette.Domain.DataBase.DbConfig;

public class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.TagId);

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder.Property(t => t.IsDeleted)
            .IsRequired(false);
    }
}
