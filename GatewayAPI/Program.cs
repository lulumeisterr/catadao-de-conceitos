using GatewayAPI.Application.Extensions.Ocelot;

var builder = WebApplication.CreateBuilder(args);
builder.AddOcelotConfiguration();
var app = builder.Build();
app.UseOcelot().Wait();
app.Run();