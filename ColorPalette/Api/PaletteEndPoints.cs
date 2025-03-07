namespace ColorPalette.Api;

public static class PaletteEndPoint
{
    public static void MapPaletteEndPoint(this WebApplication app)
    {
        var ep = app.MapGroup("api/palettes").WithTags("Palettes");

        ep.MapGet("/", () => "Get Palettes!");

        ep.MapGet("/{paletteId}", (int paletteId) => $"Palette with ID: {paletteId}");

        ep.MapPost("/", () => "Create new palette");

        ep.MapPut("/{paletteId}", (int paletteId) => $"Update color with ID: {paletteId}");

        ep.MapDelete("/{paletteId}", (int paletteId) => $"Delete palette with ID: {paletteId}");
    }
}
