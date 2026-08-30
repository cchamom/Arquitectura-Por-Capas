using Microsoft.EntityFrameworkCore;
using ArquitecturaCapas.Data;      
using ArquitecturaCapas.Repos;    
using ArquitecturaCapas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Crear la base de datos y aplicar migraciones automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TiendaDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configurar Swagger visible en desarrollo y producción para la tarea
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();