using RabbitMQLibrary;
using System.Text;


MessageQueueService messageQueueService = new MessageQueueService();


for (int i = 0; i < 60; i++)
{
    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
    byte[] buffer = Encoding.UTF8.GetBytes($"Mensaje {i}");

    Console.WriteLine($"Enviado: Mensaje {i}");

    messageQueueService.Send(buffer);
}

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();
