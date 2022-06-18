# E-Conomic PubSub

This project is a simple try to implement a PubSub pattern for both distributed and local publish and subscription that
helps applications in an integration architecture to send messages to other applications that are subscirbed and are
interested in those messages, without knowing the identity of the receivers

- Pub-sub pattern (image
  credit: [MSDN blog](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff649664(v=pandp.10)?redirectedfrom=MSDN))

  ![Schema](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/images/ff649664.despublishsubscribe_f01(en-us,pandp.10).gif)

## Technologies

- .Net 6
- Moq
- XUnit

## Usage

PubSub.Core makes it easy to implement a Pub-Sub pattern in your projects, you just need to create your project and
reference [PubSub.Core](src/PubSub.Core), then create your models as described below:

- First you should create your simple message classes :

  ```csharp 
  public class PublicChatMessage
  {
      public string From { get; set; }
      public string Body { get; set; }
  }
  ```
- Then you can create some subscribers for this type of message like below:

  ```csharp 
  public class MyFirstPublicChatSubscriber : Subscriber<PublicChatMessage>
  {
      public MyFirstPublicChatSubscriber(ILocalEventBus bus) : base(bus)
      {
      }
  
      public override void Notify(PublicChatMessage message)
      {
          Console.WriteLine($"{message.From,-5} : {message.Body}");
      }
  }
  ```
- After all to activate the subscriber you can create a new instance of it (in this example instance of ``MyFirstPublicChatSubscriber``), in this way
  subscriber will automatically be activated.
  ```csharp
  var localEventBus = new LocalEventBus();
  var MyFirstPublicChatSubscriber = new MyFirstPublicChatSubscriber(localEventBus);
  ```

- Use the way below to publish messages:
  ```csharp
  var publisher = new Publisher(localEventBus);
  //line below publishes a message
  publisher.Publish(new PublicChatMessage {From = "Reza Ariyan", Body = "Hellow world !"}); 
  ```

## Dependency Injection Subscription

There is another easy way to subscribe to a message using `dependency injection` as follow:

- First you need to create your message model exactly like the previous model.
- The second step is creating an empty interface for your subscriber :
  ```csharp
  public interface IMyFirstPublicChatSubscriber
  {
  }
  ```
- Then create your subscriber like below:
  ```csharp
  public class MyFirstPublicChatSubscriber : Subscriber<PublicChatMessage>, IMyFirstPublicChatSubscriber
  {
      public MyFirstPublicChatSubscriber(ILocalEventBus bus) : base(bus)
      {
      }
  
      public override void Notify(PublicChatMessage message)
      {
          Console.WriteLine($"{message.From,-5} : {message.Body}");
      }
  }
  ```
- Final step is injecting the subscriber class (`IMyFirstPublicChatSubscriber`), after injection it will automatically subscribe.
  for example you can use code below to inject `IMyFirstPublicChatSubscriber` in your API project:
  ```csharp
  //You can add Transient, Scoped, or Singleton, depending on your needs
  services.AddSingleton<IMyFirstPublicChatSubscriber, MyFirstPublicChatSubscriber>();
  ```
  ##### You can also inject a publisher like below:
  ```csharp
  services.AddScoped<IPublisher, Publisher>();
  ```

## Final Note

There is a sample project named [PubSub.Application](src/PubSub.Application) that is a simple implementation
of [PubSub.Core](src/PubSub.Core) project and its usage that you can check it out.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
