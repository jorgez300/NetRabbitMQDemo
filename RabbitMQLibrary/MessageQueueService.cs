using System.Runtime.CompilerServices;

namespace RabbitMQLibrary
{
    public class MessageQueueService
    {
        public MessageQueueService()
        {

        }

        public void Send(byte[] body)
        {
            using (RabbitMQContext _context = new("Sender"))
            {
                _context.Send(body);
            }


        }

        public void Receive(Action<string> action)
        {
            //RabbitMQContext _context = new("Receiver");
            //_context.Receive();

            using (RabbitMQContext _context = new("receiver"))
            {
                _context.Receive(action);
            }
        }

    }
}
