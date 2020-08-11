using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace netCoreWebAPIWithRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQConsumerController : ControllerBase
    {
        // GET: api/RabbitMQConsumer
        [HttpGet]
        public string Get()
        {
            var factoryCons = new ConnectionFactory() { HostName = "localhost" };
            var connectionCons = factoryCons.CreateConnection();
            var channelCons = connectionCons.CreateModel();
            
                channelCons.QueueDeclare(queue: "nomeFila",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channelCons);
                var message = string.Empty;

            channelCons.BasicConsume(queue: "nomeFila",
                                autoAck: false,
                                consumer: consumer);
           
            consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                        
                        channelCons.BasicAck(ea.DeliveryTag, false);
                       
                    }catch(Exception ex)
                    {
                        channelCons.BasicNack(ea.DeliveryTag, false,false);
                    }

                    consumer.Shutdown += (o, a) => Console.WriteLine("Consumer Shutdown");
                 
                };

            Thread.Sleep(3000);
            return message;
        }       
       
    }
}
