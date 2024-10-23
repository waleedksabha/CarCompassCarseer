using Domain.Common;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
builder.Services.AddHttpClient<ITPServiceUnitOfWork, TPServiceUnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region SharedSettings 
var configuration = builder.Configuration;
SharedSettings.GetAllMakesUrl = configuration.GetSection("SharedSettings").GetValue<string>("GetAllMakesUrl");
SharedSettings.LogPath = configuration.GetSection("SharedSettings").GetValue<string>("LogPath");
#endregion

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
