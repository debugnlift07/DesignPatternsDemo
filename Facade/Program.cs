
//Facade Pattern?

//Purpose: Provide a simplified, unified interface to a complex subsystem.

//Instead of the client directly dealing with many complicated classes, the Facade acts as a single entry point.



//Step 3: Client

  TV tv=new TV();
  SoundSytem soundSystem = new SoundSytem();
  Light light1 = new Light();

HomeTheaterFacade home = new HomeTheaterFacade(tv, soundSystem, light1);

Console.WriteLine("****************************************************");
home.WatchMovie();

Console.WriteLine("\n");
home.StopWatch();









//Step 1: Subsystem Classes


public class TV
{
    public void TurnOn() => Console.WriteLine("TV is on");
    public void TurnOff() => Console.WriteLine("Off");
}

public class SoundSytem
{
    public void SetSound(string sound) => Console.WriteLine($"Sound is set at {sound}");
}

public class Light
{
    public void DimLights() => Console.WriteLine("Lights are dimmed");
    public void Brighten() => Console.WriteLine("Lights are brightened");
}


//Step 2: Facade Class

public class HomeTheaterFacade
{
    private readonly TV _tv;
    private readonly SoundSytem _soundSytem;
    private readonly Light _light;
    public HomeTheaterFacade(TV tV, SoundSytem soundSytem, Light light)
    {
        _tv = tV;
        _soundSytem = soundSytem;
        _light = light;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Lets ready for watch movie");
        _tv.TurnOn();
        _soundSytem.SetSound("20");
        _light.DimLights();
    }

    public void StopWatch()
    {
        Console.WriteLine("Shutting down movie mode...");
        _tv.TurnOff();
        _light.Brighten();
    }
}
