//Purpose: Add behavior to objects dynamically without modifying their code.

//ASP.NET Core Middleware: Each middleware wraps the request/response, adding extra functionality (logging, authentication, exception handling, etc.).

//The request flows through a chain of decorators before reaching the final handler.




//Step 5:client
class Program
{
    static void Main()
    {
        IMessageSender sender = new EmailSender();

        // Wrap with decorators
        sender = new LoggingDecorator(sender);
        sender = new EncryptionDecorator(sender);

        sender.SendMessage("Hello Naveen!");
    }
}





//Step1- Component Interface

public interface IMessageSender
{
    void SendMessage(string message);
}


//Step2: Concreate Component

public class EmailSender : IMessageSender
{
    public void SendMessage(String message)
    {
        Console.WriteLine($"Email send: {message}");
    }
}

//Step 3: Base Decorator

public abstract class MessageSenderDecorator : IMessageSender
{
    protected readonly IMessageSender _sender;

    public MessageSenderDecorator(IMessageSender sender)
    {
        _sender = sender;
    }

    public void SendMessage(string message)
    {
        _sender.SendMessage(message); // delegate to wrapped object
    }
}

//Step 4: Base Decorator
public class LoggingDecorator : MessageSenderDecorator
{
    public LoggingDecorator(IMessageSender sender) : base(sender) { }

    public override void Send(string message)
    {
        Console.WriteLine("[Log] Sending message...");
        base.SendMessage(message);
    }
}

//Step 4: Concrete Decorators
public class EncryptionDecorator : MessageSenderDecorator
{
    public EncryptionDecorator(IMessageSender sender) : base(sender) { }

    public override void Send(string message)
    {
        string encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));
        Console.WriteLine("[Encrypt] Message encrypted.");
        base.Send(encrypted);
    }
}

