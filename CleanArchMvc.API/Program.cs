using CleanArchMvc.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureAPI(builder.Configuration);
//ativar autenticacao e validar o token
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CleanArchMvc API",
        Description = "Projeto API",
        TermsOfService = new Uri("https://github.com/edenalencar/clean-arch-mvc/termoservico"),
        Contact = new OpenApiContact
        {
            Name = "Contato",
            Url = new Uri("https://github.com/edenalencar")
        },
        License = new OpenApiLicense
        {
            Name = "Licen�a",
            Url = new Uri("https://github.com/edenalencar/clean-arch-mvc/blob/master/LICENSE.txt")
        }
    });

    // usando System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
