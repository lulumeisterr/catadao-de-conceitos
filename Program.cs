var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHandler<NegocioCommandResponse,NegociationCommandRequest>,NegociationCommandHandler>();
builder.AddOpenAPI();
builder.Services.AddEFCore(builder.Configuration);
var app = builder.Build();
app.UseOpenSwagger();
app.Run();
