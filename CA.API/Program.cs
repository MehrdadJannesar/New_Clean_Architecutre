using CA.Persistance;
using CA.Infrastructrue;
using CA.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistanceServices(builder.Configuration);
builder.Services.ConfigurationInfrastructreServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dar inja moshakhas mikoni sath darsresiharo
builder.Services.AddCors(o => {
    o.AddPolicy("CorsPolicy", b => 
        b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// middleware policy ra ezafe mikonim
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
