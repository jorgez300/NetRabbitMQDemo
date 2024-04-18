using RabbitMQLibrary;
using System.Text;


MessageQueueService messageQueueService = new MessageQueueService();


for (int i = 0; i < 50; i++)
{
    Task.Delay(TimeSpan.FromSeconds(5)).Wait();
    byte[] buffer = Encoding.UTF8.GetBytes($"Sender 2: Message body {i}");

    Console.WriteLine($"Sender 2: Message body {i}");

    messageQueueService.Send(buffer);
}

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();
