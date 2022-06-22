using PubSub.Application;
using PubSub.Core.EventBus.Local.Contracts;
using PubSub.Domain.EventBus.Contracts;
using PubSub.Domain.EventBus.Models;

//DI simulation
var ioc = new Ioc();

ioc.Resolve<IGoogleSubscriber>();
ioc.Resolve<IAppleSubscriber>();

// Line below creates a list of dummy messages
var stocks = new List<dynamic> {new Apple(), new Google()};

var publisher = ioc.Resolve<IPublisher>();
var random = new Random();

//Code below publishes dummy messages until a key is pressed

Console.WriteLine("Press any key to exit...");
while (!Console.KeyAvailable)
{
    Thread.Sleep(800);
    var index = random.Next(0, stocks.Count);
    var stock = stocks[index];
    stock.Price = random.Next(100, 80000);


    // Line below Publishes a random message and subscribers will get the message and process it
    // For example if a Google message is published, the GoogleSubscriber will get the message
    publisher.Publish(stock);
}