namespace IMS.CoreBusiness;

public class Inventory
{
    public int InventoryId { get; set; }
    public string InventoryName { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public double Price { get; set; } = 0.0d;
}