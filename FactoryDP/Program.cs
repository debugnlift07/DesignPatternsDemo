
//utilze factory 
VechileFactory vechileFactory = new VechileFactory();
IVechile bus = vechileFactory.CreateVechile("Bus");
bus.Manufaturing();

IVechile bike = vechileFactory.CreateVechile("Bike");
bike.Manufaturing();

IVechile truck = vechileFactory.CreateVechile("Truck");
truck.Manufaturing();


//Product interface
public interface IVechile
{
    void Manufaturing();
}


// product class
public class Bus : IVechile
{
    public void Manufaturing()
    {
        Console.WriteLine("Bus is manufactured");
    }
}

public class Bike : IVechile
{
    public void Manufaturing() { Console.WriteLine("Bike is manufactured"); }
}

public class Truck : IVechile
{
    public void Manufaturing() { Console.WriteLine("Truck is manufactured"); }
}


//factory class
public class VechileFactory
{
    public IVechile CreateVechile(string type)
    {
        if (type == "Bus")
        {
            return new Bus();
        }
        else if (type == "Bike")
        {
            return new Bike();
        }
        else if (type == "Truck")
        {
            return new Truck();
        }
        else
        {
            throw new ArgumentException("Invalid Type");
        }
    }
}

