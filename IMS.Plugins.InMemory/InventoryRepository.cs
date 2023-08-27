using IMS.CoreBusiness;
using IMS.UseCases.Repositories;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>
        {
            new() { InventoryId = 1, InventoryName = "Bike Seat", Price = 10, Quantity = 2 },
            new() { InventoryId = 2, InventoryName = "Bike Body", Price = 10, Quantity = 2 },
            new() { InventoryId = 3, InventoryName = "Bike Wheels", Price = 10, Quantity = 2 },
            new() { InventoryId = 4, InventoryName = "Bike Brakes", Price = 10, Quantity = 2 },
            new() { InventoryId = 5, InventoryName = "Bike Pedals", Price = 10, Quantity = 2 },
            new() { InventoryId = 6, InventoryName = "Bike Brakes", Price = 10, Quantity = 2 }
        };
    }
    
    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

        return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}