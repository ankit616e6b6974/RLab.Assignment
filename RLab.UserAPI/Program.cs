using RLab.Infrastructure.Infrastructure.Middleware;
using RLab.Infrastructure.Mapper;
using RLab.Infrastructure.Repositories;
using RLab.Infrastructure.Services;
using RLab.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExternalUserService, ExternalUserService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddHttpClient("ReqResClient", (provider, client) =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var baseAddress = config["HttpClients:ReqResClient:BaseAddress"];
    client.BaseAddress = new Uri(baseAddress!);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cache successful GET responses via memory
app.UseMiddleware<ResponseCacheMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
