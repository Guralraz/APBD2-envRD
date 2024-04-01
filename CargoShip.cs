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

        double totalWeight = Containers.Sum(c => c.LoadMass + c.OwnWeight) + container.LoadMass + container.OwnWeight;
        if (totalWeight > MaxLoadWeight * 1000) // Assuming MaxLoadWeight is in tons
        {
            throw new Exception("Exceeds maximum load weight of the ship.");
        }

        Containers.Add(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        var containerToRemove = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToRemove != null)
        {
            Containers.Remove(containerToRemove);
        }
        else
        {
            throw new Exception($"Container with serial number {serialNumber} not found.");
        }
    }

    // Method to unload a specific container
    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            container.Unload();
        }
        else
        {
            throw new Exception($"Container with serial number {serialNumber} not found.");
        }
    }

    // Method to replace a container on the ship with another container
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        RemoveContainer(serialNumber);
        LoadContainer(newContainer);
    }

    // Method to transfer a container from this ship to another ship
    public void TransferContainer(string serialNumber, CargoShip targetShip)
    {
        var containerToTransfer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToTransfer != null)
        {
            RemoveContainer(serialNumber);
            targetShip.LoadContainer(containerToTransfer);
        }
        else
        {
            throw new Exception($"Container with serial number {serialNumber} not found.");
        }
    }
}
