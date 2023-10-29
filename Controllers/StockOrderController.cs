using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_to_inventoryy.Dtos.order;
using stock_to_inventoryy.Models;
using stock_to_inventoryy.Services;

namespace stock_to_inventoryy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockOrderController : ControllerBase
    {
        private readonly IStockOrder _stockOrderService;
      
        
        public StockOrderController(IStockOrder stockOrderService)
        {
            _stockOrderService = stockOrderService;
          
        }

        [HttpPost("AddStockOrder")]
       public async Task<ActionResult<ServiceResponse<List<GetStockOrderDto>>>> AddStockOrder(AddstockOrderDto addStock)
        {
          return  await _stockOrderService.AddStockOrder(addStock);
        }

        [HttpGet("GetAllStockOrder")]
        //ServiceResponse<List<GetStockOrderDto>>>
        public async Task<ActionResult> GetAllStockOrder()
        {
            var getAllStock = await _stockOrderService.GetAllStockOrder();
            return Ok(getAllStock);
        }

        [HttpDelete("DeleteStock")]

        public async Task<ActionResult<ServiceResponse<List<GetStockOrderDto>>>> DeleteStockOrder(int id)
        {
            var deleteStock = await _stockOrderService.DeleteStockOrder(id);
            return Ok(deleteStock);
        }

        [HttpGet("GetSingleStock")]
        public async Task<ActionResult<ServiceResponse<GetStockOrderDto>>> GetSingleStockOrder(int id)
        {
            var singleStock = await _stockOrderService.GetSingleStockOrder(id);
            return Ok(singleStock);
        }

        [HttpPut("UpdateStockOrder")]
        public async Task<ActionResult<ServiceResponse<GetStockOrderDto>>> updateStockOrder(UpdateStockOrderDto updateDataParams)
        {
            var updatedStock = await _stockOrderService.UpdateStockOrder(updateDataParams);
            return Ok(updatedStock);
        }

        
    }
}
