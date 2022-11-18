var builder = WebApplication.CreateBuilder(args);


builder.Services.AddConsulSettings(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddEFCore(builder.Configuration);
builder.AddOpenAPI();

builder.Services.AddScoped<IHandler<NegociationCommandRequest, NegocioCommandResponse>, NegocioCommandHandler>();
builder.Services.AddScoped<IQueryHandler<NegocioCommandResponse>, ConsultarTodosNegocios>();

var app = builder.Build();

app.UseConsul(builder.Configuration);
app.MapControllers();
app.UseOpenSwagger();
app.Run();
