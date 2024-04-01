using APBD2_envRD.Exceptions;

namespace APBD2_envRD.Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer() : base("C") // Use "C" for RefrigeratedContainer
    {
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            throw new OverfillException($"Attempt to overload a refrigerated container: {SerialNumber}. Exceeded maximum allowed load.");
        }
        LoadMass = mass;
    }

    public override void Unload()
    {
        LoadMass = 0;
    }

    // Add any specific methods for refrigerated containers if necessary
}
