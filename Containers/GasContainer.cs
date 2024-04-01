using APBD2_envRD.Exceptions;
using APBD2_envRD.HazardNotifiers;

namespace APBD2_envRD.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer() : base("G") // Use "G" for GasContainer
    {
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            NotifyHazard("Attempted to load gas over maximum capacity.");
            throw new OverfillException("Cannot load gas over maximum capacity.");
        }

        base.Load(mass);
    }

    public override void Unload()
    {
        // Leave 5% of the load inside the container
        LoadMass = LoadMass * 0.05;
    }

    public void NotifyHazard(string message)
    {
        // Implementation to notify about hazardous condition
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}
