using APBD2_envRD.HazardNotifiers;

namespace APBD2_envRD.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double loadMass, int height, double tareWeight, int depth, string serialNumber, double maxLoadCapacity, bool isHazardous)
        : base(loadMass, height, tareWeight, depth, serialNumber, maxLoadCapacity)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double mass)
    {
        double maxAllowed = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;
        if (mass > maxAllowed)
        {
            NotifyHazard($"Attempt to overload a liquid container: {SerialNumber}");
            throw new OverfillException("Exceeded maximum allowed load.");
        }

        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Alert for {SerialNumber}: {message}");
    }
}
