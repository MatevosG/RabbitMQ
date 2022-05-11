using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory 
            {
                Uri = new Uri("amqp://guest@localhost:5672")
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(
                "demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
            var massage = new {Name="test",Surname="testtest"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(massage));

            channel.BasicPublish("","demo-queue",null,body);
            Console.ReadLine();
        }
    }
}
