using AutoMapper;
//using FinalMockProject.BLL;
using FinalMockProject.DAL;
using FinalMockProject.DAL.Interface;
using FinalMockProject.Models;
using FinalMockProject.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalMockProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _orderRepository;
        public OrdersController(IOrdersRepository orderRepository, IMapper mapper)
        {

            _mapper = mapper;
            _orderRepository= orderRepository;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            
          
                var orders = await _orderRepository.GetAllAsync();
                var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
                return Ok(orderDtos);
           
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orders = await _orderRepository.GetByIdAsync(id);
            if (orders == null)
                return NotFound();
            var orderDtos = _mapper.Map<OrderDTO>(orders);
            return Ok(orderDtos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDto)
        {
           

            var orders = _mapper.Map<Order>(orderDto);

            await _orderRepository.AddAsync(orders);
            var createdOrderDto = _mapper.Map<OrderDTO>(orders);
            return Ok(createdOrderDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDto)
        {

            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
                return NotFound();

            _mapper.Map(orderDto, existingOrder);

            await _orderRepository.UpdateAsync(existingOrder);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if(existingOrder == null)
                return NotFound();

            await _orderRepository.DeleteAsync(existingOrder);
            return Ok("Order deleted sauccessfully");
        }

    }
}
