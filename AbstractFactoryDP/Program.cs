
//*****************************************************************************************************************//
//The Abstract Factory pattern is used when you want to create families of related objects, not just a single product.


/// <summary>
/// Step 5: Use factory 
/// </summary>


Console.WriteLine("**************Switch to Electirc Factory******************");

IVehicleFactory factory = new ElectricVehicleFactory();

IVehicle bus = factory.CreateBus();
bus.Manufacturing();

IVehicle bike=factory.CreateBike();
bike.Manufacturing();


//switch the factory

Console.WriteLine("**************Switch to Fuel Factory******************");

factory= new FuelVehicleFactory(); 

bus=factory.CreateBus();
bus.Manufacturing();

bike=factory.CreateBike(); 
bike.Manufacturing();

Console.ReadKey();











//Step 1: Create product interface

public interface IVehicle
{
    void Manufacturing();
}

//Step 2: Create concreate product class

public class ElectricBus : IVehicle
{
    public void Manufacturing()
    {
        Console.WriteLine("Eelectric Bus is manufacred");
    }
}

public class ElectricBike : IVehicle
{
    public void Manufacturing()
    {
        Console.WriteLine("Eelectric Bike is manufacred");
    }
}

public class FuelBus : IVehicle
{
    public void Manufacturing()
    {
        Console.WriteLine("Fuel Bus is manufacred");
    }
}

public class FuelBike : IVehicle
{
    public void Manufacturing()
    {
        Console.WriteLine("Fuel Bike is manufacred");
    }
}

//Step 3: abstract Factory
public interface IVehicleFactory
{
    IVehicle CreateBus();
    IVehicle CreateBike();
}

// Step 4: Concrete Factories

public class ElectricVehicleFactory : IVehicleFactory
{
    public IVehicle CreateBus() => new ElectricBus();
    public IVehicle CreateBike() => new ElectricBike();
}

public class FuelVehicleFactory : IVehicleFactory
{
    public IVehicle CreateBus() => new FuelBus();
    public IVehicle CreateBike() => new FuelBike();
}

