var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulSettings(builder.Configuration);
builder.Services.AddScoped<IHandler<NegocioCommandResponse,NegociationCommandRequest>,NegociationCommandHandler>();
builder.AddOpenAPI();
builder.Services.AddEFCore(builder.Configuration);
var app = builder.Build();

app.UseConsul(builder.Configuration);
app.MapControllers();
app.UseOpenSwagger();


app.Run();
