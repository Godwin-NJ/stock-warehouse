using stock_to_inventoryy.Models;

namespace stock_to_inventoryy.Models
{
    public class StockOrder
    {
        public int Id { get; set; }
        public string StockName { get; set; } = "new-item";

        public DateTime createdAt { get; set; } = DateTime.Now;
        public string? ItemNo { get; set; }

        public int? quantity { get; set; } = 10;
        public UnitOfMeasure? unit { get; set; } = UnitOfMeasure.CTN;
        // public string? StoreKeeperName { get; set; }
       

        // public bool? isReceipt { get; set; } = false;
        public string? OrderNo { get; set; } //order invoice number
    }
}
