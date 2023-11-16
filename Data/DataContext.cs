

namespace stock_to_inventoryy.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
        }
        public DbSet<StockOrder> stockOrders => Set<StockOrder>();
        public DbSet<StockReceipt> stockReceipts => Set<StockReceipt>();
    }
}
