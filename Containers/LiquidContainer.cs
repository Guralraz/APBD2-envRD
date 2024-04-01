using APBD2_envRD.Exceptions;
using APBD2_envRD.HazardNotifiers;

namespace APBD2_envRD.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer() : base("L") // Use "L" for LiquidContainer
    {
    }

    public override void Load(double mass)
    {
        double allowedCapacity = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;
        if (mass > allowedCapacity)
        {
            NotifyHazard("Attempted to load hazardous material over allowed capacity.");
            throw new OverfillException("Cannot load hazardous material over allowed capacity.");
        }

        base.Load(mass);
    }

    public void NotifyHazard(string message)
    {
        // Implementation to notify about hazardous condition
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}
