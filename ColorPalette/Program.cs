using ColorPalette.Api;
using ColorPalette.Domain.DataBase;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ColorPaletteContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapColorEndpoints();
app.MapPaletteEndPoint();

app.Run();
