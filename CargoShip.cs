using APBD2_envRD.Containers;

namespace APBD2_envRD;

public class CargoShip
{
    public List<Container> Containers { get; private set; } = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxLoadWeight { get; set; }

    public CargoShip(double maxSpeed, int maxContainerCount, double maxLoadWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxLoadWeight = maxLoadWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new Exception("Cannot add more containers. Capacity full.");
        }

        double totalWeight = Containers.Sum(c => c.LoadMass + c.TareWeight) + container.LoadMass + container.TareWeight;
        if (totalWeight > MaxLoadWeight * 1000) // Assuming MaxLoadWeight is in tons
        {
            throw new Exception("Exceeds maximum load weight of the ship.");
        }

        Containers.Add(container);
    }

    // Implement additional required operations here...
}
