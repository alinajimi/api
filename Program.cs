using System.Linq.Expressions;
using api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(config=>{

    config.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseAuthorization();
app.MapControllers();
var logger=app.Services.CreateScope().ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    DbInitializer.Initialize(app);
}
catch (System.Exception ex)
{
    logger.LogError(ex.Message);
    
    
}
app.Run();
