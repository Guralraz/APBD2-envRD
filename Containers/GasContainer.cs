using APBD2_envRD.HazardNotifiers;

namespace APBD2_envRD.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; } // Pressure in atmospheres

    public GasContainer(double loadMass, int height, double tareWeight, int depth, string serialNumber, double maxLoadCapacity, double pressure)
        : base(loadMass, height, tareWeight, depth, serialNumber, maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            NotifyHazard($"Attempt to overload a gas container: {SerialNumber}");
            throw new OverfillException("Exceeded maximum allowed load.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        // Leave 5% of the gas load
        LoadMass *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Alert for {SerialNumber}: {message}");
    }
}
