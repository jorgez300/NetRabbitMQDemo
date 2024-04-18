using RabbitMQLibrary;



MessageQueueService messageQueueService = new MessageQueueService();


messageQueueService.Receive();

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();


