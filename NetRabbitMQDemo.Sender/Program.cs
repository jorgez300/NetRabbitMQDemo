﻿using RabbitMQLibrary;
using System.Text;


MessageQueueService messageQueueService = new MessageQueueService();


for (int i = 0; i < 100; i++)
{
    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
    byte[] buffer = Encoding.UTF8.GetBytes($"Sender 1: Message body {i}");

    Console.WriteLine($"Sender 1: Message body {i}");

    messageQueueService.Send(buffer);
}

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();
