using APBD2_envRD.Exceptions;

namespace APBD2_envRD.Containers;

public abstract class Container
{
    private static int _containerCounter = 0; // Static counter to ensure unique ID for each container
    public double LoadMass { get; protected set; }
    public int Height { get; set; }
    public double OwnWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; protected set; }
    public double MaxLoadCapacity { get; set; }

    protected Container(string typeIndicator)
    {
        SerialNumber = GenerateSerialNumber(typeIndicator);
    }

    private static string GenerateSerialNumber(string typeIndicator)
    {
        _containerCounter++; // Increment the counter for each new container
        return $"KON-{typeIndicator}-{_containerCounter}";
    }

    public virtual void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
            throw new OverfillException("Cannot load more than the maximum capacity.");
        LoadMass = mass;
    }

    public virtual void Unload()
    {
        LoadMass = 0;
    }
}