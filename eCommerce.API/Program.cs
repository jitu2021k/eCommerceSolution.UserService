using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//Add infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly,
                               typeof(RegisterRequestMappingProfile).Assembly);

//Buils the web application
var app = builder.Build();


app.UseExceptionHandlingMiddleware();

//Routing 
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controllers routes
app.MapControllers();
app.Run();
