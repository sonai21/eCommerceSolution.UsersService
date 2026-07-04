using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddFluentValidationAutoValidation();


//add api explorer services
builder.Services.AddEndpointsApiExplorer();

//add swagger generation services to create swagger specifiacation
builder.Services.AddSwaggerGen();

//add cors related services
builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("").AllowAnyMethod().AllowAnyHeader();
        });
    });

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

//auth
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
