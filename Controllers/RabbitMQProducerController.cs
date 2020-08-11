using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace netCoreWebAPIWithRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQProducerController : ControllerBase
    {
        // POST: api/RabbitMQProducer
        [HttpPost]
        public string Post(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
           
                channel.QueueDeclare(queue: "nomeFila",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "nomeFila",
                                     basicProperties: null,
                                     body: body);

            return "Mensagem enviada para a fila";
        }

       
    }
}
