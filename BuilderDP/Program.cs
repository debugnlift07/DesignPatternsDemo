using System;

// Product
public class Car
{
    public string Engine { get; set; }
    public string Wheels { get; set; }
    public string Body { get; set; }

    public override string ToString()
    {
        return $"Car with {Engine}, {Wheels}, and {Body}";
    }
}

// Builder Interface
public interface ICarBuilder
{
    void BuildEngine();
    void BuildWheels();
    void BuildBody();
    Car GetCar();
}

// Concrete Builder
public class SportsCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void BuildEngine() => _car.Engine = "V8 Engine";
    public void BuildWheels() => _car.Wheels = "Alloy Wheels";
    public void BuildBody() => _car.Body = "Sleek Body";

    public Car GetCar() => _car;
}

public class SUVBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void BuildEngine() => _car.Engine = "Diesel Engine";
    public void BuildWheels() => _car.Wheels = "Off-road Wheels";
    public void BuildBody() => _car.Body = "SUV Body";

    public Car GetCar() => _car;
}

// Director
public class CarDirector
{
    private readonly ICarBuilder _builder;

    public CarDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public Car ConstructCar()
    {
        _builder.BuildEngine();
        _builder.BuildWheels();
        _builder.BuildBody();
        return _builder.GetCar();
    }
}

// Client
public class Program
{
    public static void Main()
    {
        // Build a Sports Car
        ICarBuilder sportsCarBuilder = new SportsCarBuilder();
        CarDirector director = new CarDirector(sportsCarBuilder);
        Car sportsCar = director.ConstructCar();
        Console.WriteLine(sportsCar);

        // Build an SUV
        ICarBuilder suvBuilder = new SUVBuilder();
        director = new CarDirector(suvBuilder);
        Car suv = director.ConstructCar();
        Console.WriteLine(suv);
    }
}
