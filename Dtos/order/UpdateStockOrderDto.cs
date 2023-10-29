namespace stock_to_inventoryy.Dtos.order
{
    public class UpdateStockOrderDto
    {
        public int Id { get; set; }
        public string StockName { get; set; } = "new-item";
        //  public DateTime UpdatedAt { get; set; } = DateTime.Now;
       // private readonly DateTime UpdatedAt = DateTime.Now;
        //   public string? ItemNo { get; set; }  //This should not be updated

        public int? quantity { get; set; }
       // public string? UserName { get; set; } //the should not be able to change username after creation
      
       // public string? OrderNo { get; } //order invoice number should not be enabled for update
    }
}
