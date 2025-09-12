//Proxy: An object representing another object

//Step4- main


MathProxy mathProxy = new MathProxy();
Console.WriteLine($"Add :{mathProxy.Add(5, 5)}");
Console.WriteLine($"Divide :{mathProxy.Divide(15, 5)}");
Console.WriteLine($"Subtract :{mathProxy.Subtract(15, 5)}");
Console.WriteLine($"Multiply :{mathProxy.Multiply(5, 5)}");

Console.ReadKey();




//Step 1:

public interface IMath
{
    double Add(double x, double y);
    double Subtract(double x, double y);
    double Multiply(double x, double y);
    double Divide(double x, double y);
}


//Step 2- Real object

public class Math : IMath
{
    public double Add(double x, double y)
    {
        return x + y;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }

    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public double Divide(double x, double y)
    {
        return x / y;
    }
}

//Stpe 3:-The 'Proxy Object' class

public class MathProxy : IMath
{
    private Math math = new Math();

    public double Add(double x, double y)
    {
        return math.Add(x, y);
    }

    public double Subtract(double x, double y)
    {
        return math.Subtract(x, y);
    }

    public double Multiply(double x, double y)
    {
        return math.Multiply(x, y);
    }

    public double Divide(double x, double y)
    {
        return math.Divide(x, y);
    }
}