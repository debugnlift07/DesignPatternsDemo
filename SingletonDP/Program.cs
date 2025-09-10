//The Singleton design pattern ensures a class has only one instance and provide a global point of access to it. 

using System.Diagnostics.Metrics;
using System.Runtime.Serialization;

Logger log1 = Logger.GetInstance();
log1.Log("First Message");


Logger log2 = Logger.GetInstance();
log2.Log("Secand Message");

if (object.ReferenceEquals(log1, log2))
{
    Console.WriteLine("Same instance");
}
else
{
    Console.WriteLine("diffrent instance");

}



//Step1.- Create a sealed class
public sealed class Logger
{
    //counter how many times instance create
    private static int counter = 0;

    //Step2: single instace of loggger
    private static Logger log = null;

    // Lock object for thread safety
    private static readonly object LockObj = new object();

    //Step3: set private constructor
    private Logger()
    {
        counter++;
        Console.WriteLine("Logger instance created. Counter Value: " + counter.ToString());

    }

    //Step 4:Public static method to get the single instance
    public static Logger GetInstance()
    {
        if (log == null)
        {
            lock (LockObj)  // Lock only if instance is null
            {
                log = new Logger();
            }
        }
        return log;
    }

    //Add a method to print logs
    public void Log(string message)
    {
        Console.WriteLine($"Log Entry: {message}");
    }
}