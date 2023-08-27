using IMS.CoreBusiness;
using IMS.UseCases.Repositories;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private readonly List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>
        {
            new() { InventoryId = 1, InventoryName = "Bike Seat", Price = 10, Quantity = 2 },
            new() { InventoryId = 2, InventoryName = "Bike Body", Price = 70, Quantity = 4 },
            new() { InventoryId = 3, InventoryName = "Bike Wheels", Price = 40, Quantity = 7 },
            new() { InventoryId = 4, InventoryName = "Bike Brakes", Price = 20, Quantity = 3 },
            new() { InventoryId = 5, InventoryName = "Bike Pedals", Price = 440, Quantity = 92 },
            new() { InventoryId = 6, InventoryName = "Bike Brakes", Price = 50, Quantity = 34 }
        };
    }
    
    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

        return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var maxId = _inventories.Max(x => x.InventoryId);

        inventory.InventoryId = ++maxId;
        
        _inventories.Add(inventory);

        return Task.CompletedTask;
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(x =>
                x.InventoryId != inventory.InventoryId &&
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var inv = _inventories.SingleOrDefault(x => x.InventoryId == inventory.InventoryId);

        if (inv != null)
        {
            inv.InventoryName = inventory.InventoryName;
            inv.Quantity = inventory.Quantity;
            inv.Price = inventory.Price;
        }

        return Task.CompletedTask;
    }

    public async Task<Inventory> GetInventoriesByIdAsync(int inventoryId)
    {
        var inv= await Task.FromResult(_inventories.SingleOrDefault(x => x.InventoryId == inventoryId));

        return new Inventory
        {
            InventoryName = inv.InventoryName,
            Price = inv.Price,
            InventoryId = inv.InventoryId,
            Quantity = inv.Quantity,
        };
    }
}