using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IProductService _productService;

        //public ProductsController(IProductService productService)
        //{
        //    _productService = productService;
        //}
        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = _productService.GetProducts();
        //    return Ok(products);
        //}

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get() //burasi void idi task diye duzelttik cunku async
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id =Guid.NewGuid(),Name="Kitap 1", Price=100,CreatedDate = DateTime.UtcNow, Stock=10},
            //    new() { Id =Guid.NewGuid(),Name="Kitap 2", Price=200,CreatedDate = DateTime.UtcNow, Stock=20},
            //    new() { Id =Guid.NewGuid(),Name="Kitap 3", Price=300,CreatedDate = DateTime.UtcNow, Stock=30},
            //});
            //var count = await _productWriteRepository.SaveAsync();

            //Product p = await _productReadRepository.GetByIdAsync("87f355d6-e09d-44f1-a6eb-5cfa8ebd6e99", false); // burasi false oldugunda dogal olarak trancking mekanizmasi pasif olacagi icin dbde bir degisiklik olmayacak
            //p.Name = "Burak";
            //await _productWriteRepository.SaveAsync();

            //await _productWriteRepository.AddAsync(new() { Name = "Kalem", Price = 1.500F, Stock = 40, CreatedDate = DateTime.UtcNow });
            //await _productWriteRepository.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muiddin" });
            //_orderWriteRepository.AddAsync(new() { Description = "blah blah", Address = "Vezirköprü", CustomerId = customerId });
            //_orderWriteRepository.AddAsync(new() { Description = "blah blah", Address = "Söke", CustomerId = customerId });
            //_orderWriteRepository.SaveAsync();

            //Order order = await _orderReadRepository.GetByIdAsync("99706788-64dc-4e91-8e7a-7a33c9a2e1f5");
            //order.Address = "Roma";
            //_orderWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
