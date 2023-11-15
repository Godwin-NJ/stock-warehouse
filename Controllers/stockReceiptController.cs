using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_to_inventoryy.Dtos.OrderReceipt;
using stock_to_inventoryy.Models;
using stock_to_inventoryy.Services;

namespace stock_to_inventoryy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stockReceiptController : ControllerBase
    {
        private readonly IStockReceipt _stockReceiptService;
        public stockReceiptController(IStockReceipt stockReceiptService)
        {
            _stockReceiptService = stockReceiptService;
        }

        [HttpPost("CreateStockReceipt")]
        public async Task<ActionResult<ServiceResponse<List<stockReceiptDto>>>> GenerateInvoiceForStock(AddStockInvoice stockInvoice)
        {
         return await _stockReceiptService.CreateStockInvoice(stockInvoice);
        }

        [HttpGet("GetAllStockReceipt")]
        public async Task<ActionResult<ServiceResponse<List<stockReceiptDto>>>> GetAllStockInvoice()
        {
           return  await _stockReceiptService.GetAllStockReceipt();
        }


        [HttpGet("GetStockReceipt")]
        public async Task<ActionResult<ServiceResponse<stockReceiptDto>>> GetStockInvoice(int id)
        {
            return await _stockReceiptService.GetStockReceipt(id);
        }


    }
}
