using stock_to_inventoryy.Dtos.order;
using stock_to_inventoryy.Models;

namespace stock_to_inventoryy.Services.Interface
{
    public interface IStockOrder
    {
        Task<ServiceResponse<List<GetStockOrderDto>>> GetAllStockOrder();
        Task<ServiceResponse<GetStockOrderDto>> GetSingleStockOrder(int id);
        //Task<ServiceResponse<GetSingleStockOrderDto>> GetSingleStockOrder(int id);
        Task<ServiceResponse<GetStockOrderDto>> UpdateStockOrder(UpdateStockOrderDto updateData);
        Task<ServiceResponse<List<GetStockOrderDto>>> AddStockOrder(AddstockOrderDto addStockOrderParams);

        Task<ServiceResponse<List<GetStockOrderDto>>> DeleteStockOrder(int id);
      
    }
}
