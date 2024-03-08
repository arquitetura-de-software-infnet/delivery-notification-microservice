using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Services;
using ApiUsuarios.Domain.Interfaces.Messages;
using ApiUsuarios.Infra.Messages.Consumers;
using ApiUsuarios.Infra.Messages.Producers;
using ApiUsuarios.Infra.Messages.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitando o AutoMapper no sistema
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adicionando as injeções de dependência do sistema
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MessageProducer>();
builder.Services.AddTransient<ISendMailService, SendMailService>();

//registrando o consumer
builder.Services.AddHostedService<MessageConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//tornar a classe Program.cs pública..
public partial class Program { }



