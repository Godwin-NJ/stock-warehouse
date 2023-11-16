using AutoMapper;
using stock_to_inventoryy.Data;
using stock_to_inventoryy.Dtos.OrderReceipt;
using stock_to_inventoryy.Models;

namespace stock_to_inventoryy.Services
{
    public class StockReceiptService : IStockReceipt
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context; //this will initiate usage of database
        public StockReceiptService(IMapper mapper, DataContext context) 
        { 
            _mapper = mapper;
            _context = context;
        }

        public static List<StockReceipt> newStockReceipts = new List<StockReceipt>
        {
            new StockReceipt
            {
               Id = 1,
               StockName="Martel-10yrs",
               ItemNo="ILN-01",
              //  OrderNo="ILN-01-Martel-receipt",
               quantity=50,
               unit=UnitOfMeasure.CTN,
               StoreKeeperName="abdul zakira",
               InvoiceNo="SN-Martel-10years"
            },

             new StockReceipt
            {
              Id = 2,
              StockName="Glenfiddich-10yrs",
              ItemNo="ILN-02",
               unit=UnitOfMeasure.CTN,
              //  OrderNo="ILN-01-Martel-receipt",
               quantity=50,
               StoreKeeperName="omolade",
               InvoiceNo="SN-glen-10years"
            }
        };
        public async Task<ServiceResponse<List<stockReceiptDto>>> CreateStockInvoice(AddStockInvoice stockInvoicedto)
        {
            var service_response = new ServiceResponse<List<stockReceiptDto>>();
            var inv = _mapper.Map<StockReceipt>(stockInvoicedto);
         //   inv.Id = newStockReceipts.Max(x => x.Id ) + 1;
          //  newStockReceipts.Add(inv);
            await _context.stockReceipts.AddAsync(inv);
            _context.SaveChanges();
            //  service_response.Data = newStockReceipts.Select(c => _mapper.Map<stockReceiptDto>(c)).ToList();
            service_response.Data = _context.stockReceipts.Select(c => _mapper.Map<stockReceiptDto>(c)).ToList();
            return service_response;
        }

        public async Task<ServiceResponse<List<stockReceiptDto>>> GetAllStockReceipt()
        {
            var service_response = new ServiceResponse<List<stockReceiptDto>>();
            var dbData = await _context.stockReceipts.ToListAsync();
            // service_response.Data = newStockReceipts.Select(c => _mapper.Map<stockReceiptDto>(c)).ToList();
            service_response.Data = dbData.Select(c => _mapper.Map<stockReceiptDto>(c)).ToList();
            return service_response;

        }

        public async Task<ServiceResponse<stockReceiptDto>> GetStockReceipt(int id)
        {
            var service_response = new ServiceResponse<stockReceiptDto>();
            var getInv = await _context.stockReceipts.FirstOrDefaultAsync(x => x.Id == id);
            service_response.Data = _mapper.Map<stockReceiptDto>(getInv);
            return service_response;
        }
    }
}
