using APBD2_envRD.Containers;
using APBD2_envRD.Exceptions;
using System;

namespace APBD2_envRD;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a Cargo Ship
        var cargoShip = new CargoShip(maxSpeed: 20, maxContainerCount: 5, maxLoadWeight: 100); // Max load weight in tons

        // Create and load a liquid container
        var liquidContainer = new LiquidContainer() // Adjusted constructor call without serialNumber parameter
        {
            IsHazardous = true,
            MaxLoadCapacity = 1000,
            OwnWeight = 100 // Assuming a weight
        };

        try
        {
            liquidContainer.Load(500); // Should be successful for hazardous liquid (up to 50% capacity)
            Console.WriteLine("Liquid container loaded successfully.");
            cargoShip.LoadContainer(liquidContainer);
            Console.WriteLine("Liquid container added to ship.");
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error loading liquid container: {ex.Message}");
        }

        // Create and attempt to load a gas container beyond its capacity
        var gasContainer = new GasContainer() // Adjusted constructor call
        {
            Pressure = 100, // Example pressure
            MaxLoadCapacity = 500,
            OwnWeight = 120 // Assuming a weight
        };

        try
        {
            gasContainer.Load(600); // This should trigger an OverfillException
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error loading gas container: {ex.Message}");
        }

        // Attempt to add the gas container to the ship (should be successful since it wasn't loaded)
        try
        {
            cargoShip.LoadContainer(gasContainer);
            Console.WriteLine("Gas container added to ship.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding gas container to ship: {ex.Message}");
        }

        // Demonstrate unloading and removing a container
        try
        {
            cargoShip.UnloadContainer(liquidContainer.SerialNumber);
            Console.WriteLine("Liquid container unloaded.");
            cargoShip.RemoveContainer(liquidContainer.SerialNumber);
            Console.WriteLine("Liquid container removed from ship.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error managing containers on ship: {ex.Message}");
        }

        // Further actions like transferring containers between ships can be demonstrated similarly.
    }
}
