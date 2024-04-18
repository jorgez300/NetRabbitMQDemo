using RabbitMQLibrary;

MessageQueueService messageQueueService = new MessageQueueService();


messageQueueService.Receive(action);

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();


void action(string message) {
    Task.Delay(TimeSpan.FromSeconds(4)).Wait();
    Console.WriteLine("Receiver 1: " + message);

}

