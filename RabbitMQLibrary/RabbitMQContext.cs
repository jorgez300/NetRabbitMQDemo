using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQLibrary
{
    public sealed class RabbitMQContext : IDisposable
    {
        private ConnectionFactory? _factory = null;
        private IConnection? _connection = null;
        private IModel? _channel = null;
        private EventingBasicConsumer _consumer;

        private string _exchangeName = "RabbitMQNet6Demo";
        private string _routingKey = "demo-routing-key";
        private string _queueName = "DemoNet6Queue";
        private string _clientProvidedName = "";
        public RabbitMQContext(string clientProvidedName)
        {
            _clientProvidedName = clientProvidedName;
            _factory = new ConnectionFactory();
            Init();
        }

        private void Init()
        {

            if (_factory == null)
            {
                _factory = new ConnectionFactory();
            }

            _factory.UserName = "guest";
            _factory.Password = "guest";
            _factory.Port = 5672;
            _factory.HostName = "localhost";

            //_factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

            _factory.ClientProvidedName = "RabbitMQ Net 6 Demo " + _clientProvidedName;

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();


            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(_queueName, false, false, false);
            _channel.QueueBind(_queueName, _exchangeName, _routingKey, null);

        }

        public void Send(byte[] body)
        {
            _channel.BasicPublish(_exchangeName, _routingKey, null, body);

        }

        public void Receive()
        {
            _channel?.BasicQos(0, 1, false);
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += (sender, args) =>
            {
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                byte[] body = args.Body.ToArray();

                string message = Encoding.UTF8.GetString(body);

                Console.WriteLine("Recibido: " + message);

                _channel?.BasicAck(args.DeliveryTag, false);
            };

            string consumerTag = _channel.BasicConsume(_queueName, false, _consumer);

            Console.ReadLine();

            _channel.BasicCancel(consumerTag);

            Dispose();

        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
            }
            if (_connection.IsOpen)
            {
                _connection.Close();
            }
            _connection?.Dispose();
            _channel?.Dispose();
            _factory = null;
        }

    }
}
