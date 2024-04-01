namespace APBD2_envRD.Containers;

public abstract class Container
{
    protected Container(double loadMass, int height, double tareWeight, int depth, string serialNumber,
        double maxLoadCapacity)
    {
        LoadMass = loadMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoadCapacity = maxLoadCapacity;
    }

    public double LoadMass { get; protected set; }
    public int Height { get; protected set; }
    public double TareWeight { get; protected set; } // Container's own weight
    public int Depth { get; protected set; }
    public string SerialNumber { get; protected set; }
    public double MaxLoadCapacity { get; protected set; }

    public abstract void Load(double mass);
    public abstract void Unload();
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}