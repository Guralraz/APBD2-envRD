namespace APBD2_envRD.Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; } // Temperature maintained in the container

    public RefrigeratedContainer(double loadMass, int height, double tareWeight, int depth, string serialNumber, double maxLoadCapacity, string productType, double temperature)
        : base(loadMass, height, tareWeight, depth, serialNumber, maxLoadCapacity)
    {
        ProductType = productType;
        Temperature = temperature;
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
