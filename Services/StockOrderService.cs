using AutoMapper;
using stock_to_inventoryy.Data;
using stock_to_inventoryy.Dtos.order;
using stock_to_inventoryy.Models;
using System.Linq.Expressions;

namespace stock_to_inventoryy.Services
{
    public class StockOrderService : IStockOrder
    {
       //At first setup a local data

        public static List<StockOrder> StockOrderData = new List<StockOrder>
        {
            //ILN -- Item Local Number
            new StockOrder
            {
                Id = 1,
                StockName="Martel-10yrs", 
                ItemNo="ILN-01", 
                OrderNo="ILN-01-Martel-receipt", 
                quantity=50

            },
             new StockOrder
            {
                Id = 2,
                StockName="Glenfiddich-10yrs",
                ItemNo="ILN-02",
                OrderNo="ILN-01-glenfiddish-receipt",
                
            }
        };


        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public StockOrderService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetStockOrderDto>>> AddStockOrder(AddstockOrderDto addStockOrderParams)
        {
            var service_response = new ServiceResponse<List<GetStockOrderDto>>();
            var stock = _mapper.Map<StockOrder>(addStockOrderParams);
           // stock.Id = StockOrderData.Max(q  => q.Id) + 1;
         //  stock.Id = await _context.stockOrders.MaxAsync(x => x.Id) + 1;
           // StockOrderData.Add(stock);
           _context.stockOrders.Add(stock);
            _context.SaveChanges();
            //  service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
            service_response.Data = _context.stockOrders.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
            return service_response;
            //StockOrderData.Add();
            //throw new NotImplementedException(); //for the moment
        }

        public async Task<ServiceResponse<List<GetStockOrderDto>>> DeleteStockOrder(int id)
        {
            var _serviceResponse = new ServiceResponse<List<GetStockOrderDto>>();
            try
            {
               // var stock = StockOrderData.FirstOrDefault(c => c.Id == id);
               var dbStock = await _context.stockOrders.FirstOrDefaultAsync(q => q.Id == id);
                if(dbStock is null)
                {
                    throw new Exception("Error deleteing item");
                }
                // StockOrderData.Remove(stock);
                _context.stockOrders.Remove(dbStock);
                _context.SaveChanges();
                _serviceResponse.Data = _context.stockOrders.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();


            }catch(Exception err) 
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message =err.Message;
            }
            return _serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStockOrderDto>>> GetAllStockOrder()
        {
            var service_response = new ServiceResponse<List<GetStockOrderDto>>();
            var dbStockOrders = await _context.stockOrders.ToListAsync();//from db
           // service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
           service_response.Data = dbStockOrders.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
            return service_response;
        }

        public async Task<ServiceResponse<GetStockOrderDto>> GetSingleStockOrder(int id)
        {
            var service_response = new ServiceResponse<GetStockOrderDto>();
           // var stock =  StockOrderData.FirstOrDefault(c => c.Id == id);
           var dbStockOrder = await _context.stockOrders.FirstOrDefaultAsync(c => c.Id == id);
            service_response.Data = _mapper.Map<GetStockOrderDto>(dbStockOrder);
            return service_response;

        }

       /* public Task<ServiceResponse<List<GetStockOrderDto>>> UpdateStockOrder(UpdateStockOrderDto updateStockParams)
        {
            throw new NotImplementedException();
        }*/

        public async Task<ServiceResponse<GetStockOrderDto>> UpdateStockOrder(UpdateStockOrderDto updateData)
        {
            var service_response = new ServiceResponse<GetStockOrderDto>();
            try 
            {
              
              //  var data = StockOrderData.FirstOrDefault(c => c.Id == updateData.Id);
              var dbData = await _context.stockOrders.FirstOrDefaultAsync(c => c.Id == updateData.Id);
                if (dbData is null)
                {
                    throw new Exception($"stock with id : {updateData.Id} not found");
                }
                dbData.StockName = updateData.StockName;
                dbData.quantity = updateData.quantity;
                dbData.unit = updateData.unit;
                _context.SaveChanges();

                // service_response.Data = _mapper.Map<GetStockOrderDto>(data);
                // service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
                service_response.Data = _mapper.Map<GetStockOrderDto>(dbData);
            }
            catch(Exception err) 
            { 
                service_response.Success = false;
                service_response.Message = $"{err.Message}";
            }
            return service_response;
        }
    }
}
