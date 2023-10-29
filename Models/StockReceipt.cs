namespace stock_to_inventoryy.Models
{
    public class StockReceipt
    {
        public int id {  get; set; }
        public string StockName { get; set; } = "new-item";
        public DateTime createdAt { get; set; } = DateTime.Now;
        public string? ItemNo { get; set; }
        public int? quantity { get; set; }
        public string? StoreKeeperName { get; set; }
        public bool? isReceipt { get; set; } = false;
        public string? InvoiceNo { get; } = null;
    }
}
