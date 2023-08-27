﻿using IMS.CoreBusiness;

namespace IMS.UseCases.Repositories;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task<Inventory> GetInventoriesByIdAsync(int inventoryId);
}