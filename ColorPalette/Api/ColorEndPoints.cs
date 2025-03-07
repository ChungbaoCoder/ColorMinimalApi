namespace ColorPalette.Api;

public static class ColorEndPoint
{
    public static void MapColorEndpoints(this WebApplication app)
    {
        var ep = app.MapGroup("api/colors").WithTags("Colors");

        ep.MapGet("/", () => "Get Colors!");

        ep.MapGet("/{colorId}", (int colorId) => $"Color with ID: {colorId}");

        ep.MapPost("/", () => "Create new color");

        ep.MapPut("/{colorId}", (int colorId) => $"Update color with ID: {colorId}");

        ep.MapDelete("/{colorId}", (int colorId) => $"Delete color with ID: {colorId}");
    }
}
