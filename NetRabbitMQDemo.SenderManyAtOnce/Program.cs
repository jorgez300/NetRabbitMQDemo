using RabbitMQLibrary;
using System.Text;


MessageQueueService messageQueueService = new MessageQueueService();

List<byte[]> Bodies = new List<byte[]>();
for (int i = 0; i < 50; i++)
{
    //Task.Delay(TimeSpan.FromSeconds(5)).Wait();
    Bodies.Add(Encoding.UTF8.GetBytes($"Sender 2: Message body {i}"));

    Console.WriteLine($"Sender 2: Message body {i}");
}


if (Bodies.Count > 0)
{
    messageQueueService.SendMany(Bodies);
}

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();
