using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteTopDownApplication.Common.Behaviors;
using TesteTopDownApplication.Common.Interfaces;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Contracts.Services;
using TesteTopdownInfrastructure.Context;
using TesteTopdownInfrastructure.Repositories;
using TesteTopdownInfrastructure.Security.TokenGenerator;
using TesteTopdownInfrastructure.Security.TokenValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Section));

builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services
           .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
           .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
    options.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});

builder.Services.AddProblemDetails();

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

app.Run();
