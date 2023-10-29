namespace stock_to_inventoryy.Dtos.OrderReceipt
{
    public class stockReceiptDto
    {
        public string StockName { get; set; } = "new-item";
        public DateTime createdAt { get; set; } = DateTime.Now;
        public string? ItemNo { get; set; }
        public int? quantity { get; set; }
        public string? StoreKeeperName { get; set; }

        public bool? isReceipt { get; set; } = false;
        public string? InvoiceNo { get; } = null;
    }
}
