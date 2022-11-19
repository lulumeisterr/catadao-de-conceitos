var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulSettings(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddEFCore(builder.Configuration);
builder.AddOpenAPI();
builder.Services.AddDependenciesBusinessObject();

var app = builder.Build();

app.UseConsul(builder.Configuration);
app.MapControllers();
app.UseOpenSwagger();
app.Run();
