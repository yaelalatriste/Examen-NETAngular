using Examen.Data;
using Examen.EventHandler.Autenticacion;
using Examen.Services.Queries.Articulos;
using Examen.Services.Queries.Clientes;
using Examen.Services.Queries.Tiendas;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Omitir propiedades nulas
    options.JsonSerializerOptions.DefaultIgnoreCondition =
        System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExamenApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDatabase")));
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddMediatR(Assembly.Load("Examen.EventHandler"));

builder.Services.AddTransient<IArticuloQueryService, ArticuloQueryService>();
builder.Services.AddTransient<IClienteQueryService, ClienteQueryService>();
builder.Services.AddTransient<ITiendaQueryService, TiendaQueryService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // origen permitido
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

builder.Services.AddSwaggerGen(c =>
{
    // Configurar esquema de Basic Auth para Swagger
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors("AllowAngularApp");
app.UseAuthentication();
app.UseAuthorization();

/*Endpoints*/
app.MapGet("/api/articulos", ()=>"").RequireAuthorization();

app.MapControllers();

app.Run();
