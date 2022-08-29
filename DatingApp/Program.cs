#region Usings
using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
#endregion
var builder = WebApplication.CreateBuilder(args);
#region OriginalServices
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//ContextService
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion
var app = builder.Build();
#region Middelwares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//AddCors   
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion