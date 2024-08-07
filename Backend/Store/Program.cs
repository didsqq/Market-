using Microsoft.EntityFrameworkCore;
using Store.Application.Services;
using Store.DataAccess;
using Store.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(StoreDbContext)));
    });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors( x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();