using Query.Application.Query.Interfaces;
using QueryHandler.Application.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulSettings(builder.Configuration);

builder.Services.AddScoped<IHandler<NegociationCommandRequest,NegocioCommandResponse>,NegocioCommandHandler>();
builder.Services.AddScoped<IQueryHandler<NegocioCommandResponse>, ConsultarTodosNegocios>();

builder.AddOpenAPI();
builder.Services.AddEFCore(builder.Configuration);
var app = builder.Build();

app.UseConsul(builder.Configuration);
app.MapControllers();
app.UseOpenSwagger();


app.Run();
