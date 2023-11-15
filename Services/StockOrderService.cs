using AutoMapper;
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

        public StockOrderService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetStockOrderDto>>> AddStockOrder(AddstockOrderDto addStockOrderParams)
        {
            var service_response = new ServiceResponse<List<GetStockOrderDto>>();
            var stock = _mapper.Map<StockOrder>(addStockOrderParams);
            stock.Id = StockOrderData.Max(q  => q.Id) + 1;
            StockOrderData.Add(stock);
            service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
            return service_response;
            //StockOrderData.Add();
            //throw new NotImplementedException(); //for the moment
        }

        public async Task<ServiceResponse<List<GetStockOrderDto>>> DeleteStockOrder(int id)
        {
            var _serviceResponse = new ServiceResponse<List<GetStockOrderDto>>();
            try
            {
                var stock = StockOrderData.FirstOrDefault(c => c.Id == id);
                if(stock == null)
                {
                    throw new Exception("Error deleteing item");
                }
                 StockOrderData.Remove(stock);

                _serviceResponse.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();


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
            service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
            return service_response;
        }

        public async Task<ServiceResponse<GetStockOrderDto>> GetSingleStockOrder(int id)
        {
            var service_response = new ServiceResponse<GetStockOrderDto>();
            var stock =  StockOrderData.FirstOrDefault(c => c.Id == id);
            service_response.Data = _mapper.Map<GetStockOrderDto>(stock);
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
              
                var data = StockOrderData.FirstOrDefault(c => c.Id == updateData.Id);
                if (data is null)
                {
                    throw new Exception($"stock with id : {updateData.Id} not found");
                }
                  data.StockName = updateData.StockName;
                  data.quantity = updateData.quantity;

                // service_response.Data = _mapper.Map<GetStockOrderDto>(data);
                // service_response.Data = StockOrderData.Select(c => _mapper.Map<GetStockOrderDto>(c)).ToList();
                service_response.Data = _mapper.Map<GetStockOrderDto>(data);
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
