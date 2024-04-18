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

        public void SendMany(IEnumerable<byte[]> Bodies)
        {
            using (RabbitMQContext _context = new("Sender"))
            {
                _context.SendMany(Bodies);
            }
        }

        public void Receive(Action<string> action)
        {
            using (RabbitMQContext _context = new("Receiver"))
            {
                _context.Receive(action);
            }
        }

    }
}
