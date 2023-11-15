using stock_to_inventoryy.Dtos.OrderReceipt;
using stock_to_inventoryy.Models;

namespace stock_to_inventoryy.Services.Interface
{
    public interface IStockReceipt
    {
        Task<ServiceResponse<stockReceiptDto>> GetStockReceipt(int id);
        Task<ServiceResponse<List<stockReceiptDto>>> GetAllStockReceipt();

        Task<ServiceResponse<List<stockReceiptDto>>> CreateStockInvoice(AddStockInvoice stockInvoicedto);
    }
}
