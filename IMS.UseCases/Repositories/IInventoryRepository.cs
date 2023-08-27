using IMS.CoreBusiness;

namespace IMS.UseCases.Repositories;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
}