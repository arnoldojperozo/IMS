using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class Inventory
{
    public int InventoryId { get; set; }
    
    [Required]
    [StringLength(150)]
    public string InventoryName { get; set; } = string.Empty;
    
    [Range(1,int.MaxValue,ErrorMessage = "Quantity must be greater or Equal than 0")]
    public int Quantity { get; set; } = 0;

    [Range(1,int.MaxValue,ErrorMessage = "Price must be greater or Equal than 0")]
    public double Price { get; set; } = 0.0d;
}