using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly private IProductWriteRepository _productWriteRepository;
    readonly private IProductReadRepository _productReadRepository;

    readonly private IOrderWriteRepository _orderWriteRepository;
    readonly private ICustomerWriteRepository _customerWriteRepository;
    readonly private IOrderReadRepository _orderReadRepository;


    public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICustomerWriteRepository customerWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
        _customerWriteRepository = customerWriteRepository;
    }

    [HttpGet]
    public async Task Get()
    {
        //await _productWriteRepository.AddAsync(new() { Name = "C2 Product", Price = 1.500F, Stock = 10 });
        //await _productWriteRepository.SaveAsync();
        //var customerId = Guid.NewGuid();
        //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muiddin" });
        //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Çankaya", CustomerId = customerId });
        //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara, Pursaklar", CustomerId = customerId });
        var order = await _orderReadRepository.GetByIdAsync("6ea4eb14-4b6b-4b4f-aff3-d117b9de3dd2");
        order.Description = "blabla2 updated";
        await _orderWriteRepository.SaveAsync();
    }

}
