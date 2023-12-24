using AuthorizationWithJWT.Configuration;
using AuthorizationWithJWT.JwtTokenOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationAuthentication();
builder.Services.ConfigureOptions<JwtOptionSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionSetup>();
builder.Services.AddServicesDependencies();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UserSwaggerForApplication("API v1");
}

app.UseHttpsRedirection();

app.UseApplicationAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
