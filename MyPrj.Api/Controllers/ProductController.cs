using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPrj.Application.Products.Command;
using MyPrj.Application.Products.Query;

namespace Sample_prj_DDDauth.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
private readonly IMediator _mediator;

public ProductController(IMediator mediator)
{
    _mediator = mediator;
}

     [HttpPost]
     [Authorize]
    public async Task<ActionResult> AddProduct(AddProductCommand command)
    {
    await _mediator.Send(command);
    return Ok();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Edit( [FromBody] EditProductCommand command)
    {


        await _mediator.Send(command);
        return NoContent();
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetProductbyid(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
        return Ok(product);
    }
    
}