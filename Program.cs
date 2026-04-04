using Microsoft.EntityFrameworkCore;
using TestingApp.Common;
using TestingApp.Data;
using TestingApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("users", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Users API",
        Version = "v1"
    });

    options.SwaggerDoc("default", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Main API",
        Version = "v1"
    });

    // Filter controllers by group
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (string.IsNullOrEmpty(apiDesc.GroupName))
            return docName == "default";

        return apiDesc.GroupName == docName;
    });
});

builder.Services.AddDbContext<TestingDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TestingAppDb")));

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/users/swagger.json", "Users API");
        options.SwaggerEndpoint("/swagger/default/swagger.json", "Default API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TestingDbContext>();
    db.Database.Migrate();
}

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

app.Run($"http://0.0.0.0:{port}");
