
using Domain.CommandHandler.Handlers;
using Domain.CommandHandler.Interface;
using Domain.Commands;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IHandler<NegociationCommandResponse,NegociationCommandRequest>,NegociationCommandHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);
app.Run();
