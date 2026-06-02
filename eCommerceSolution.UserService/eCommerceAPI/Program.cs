using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerceAPI.Middleware;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);
//Add Infrastructure service
builder.Services.AddInfrastructure();
builder.Services.AddCore();
//Add Controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Controller routes

app.Run();
