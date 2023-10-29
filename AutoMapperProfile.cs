using AutoMapper;
using stock_to_inventoryy.Dtos.order;
using stock_to_inventoryy.Models;

namespace stock_to_inventoryy
{
    public class AutoMapperProfile:Profile
    {
       public AutoMapperProfile() 
        {
            CreateMap<StockOrder, GetStockOrderDto>();
            //CreateMap<StockOrder, GetSingleStockOrderDto>();
            CreateMap<AddstockOrderDto, StockOrder>();
        }
    }
}
