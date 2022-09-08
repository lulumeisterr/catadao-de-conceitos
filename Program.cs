
using System.Text.Json.Serialization;
using Application.Command.Interface.IHandler;
using Application.ViewModel.NegociacaoRequest;
using Application.ViewModel.response;
using Domain.Command.Handlers;

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
