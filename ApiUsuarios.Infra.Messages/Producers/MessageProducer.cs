﻿using ApiUsuarios.Domain.Interfaces.Messages;
using ApiUsuarios.Infra.Messages.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace ApiUsuarios.Infra.Messages.Producers
{
    public class MessageProducer : IMailService
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;

        public MessageProducer(IOptions<RabbitMQSettings>? rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings.Host) };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _rabbitMQSettings.Queue,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: _rabbitMQSettings.Queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(message)
                        );
                }
            }
        }
    }
}



