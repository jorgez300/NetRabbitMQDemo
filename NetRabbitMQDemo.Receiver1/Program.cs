using RabbitMQLibrary;

MessageQueueService messageQueueService = new MessageQueueService();


messageQueueService.Receive(action);

Console.WriteLine("---------------------------------");
Console.WriteLine("Ready");
Console.ReadLine();


void action(string message) {

    Console.WriteLine("Recibido: " + message);

}

