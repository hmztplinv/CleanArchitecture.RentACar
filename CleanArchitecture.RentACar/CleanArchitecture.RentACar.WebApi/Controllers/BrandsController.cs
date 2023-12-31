
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BrandsController:BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add(CreateBrandCommandRequest request)
    {
        CreatedBrandCommandResponse response=await Mediator.Send(request); 
        //Mediator.Send(request) ile CreateBrandCommandRequest'i gönderiyoruz ve 
        //Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken) ile CreatedBrandCommandResponse dönüyor.
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request) 
    {
        GetListBrandQueryRequest queryRequest=new() {PageRequest = request}; // gelen isteği queryRequest'e atıyoruz.içinde PageRequest var.
        GetListResponse<GetListBrandListItemDto> response=await Mediator.Send(queryRequest); // Mediator.Send ile queryRequest'i gönderiyoruz 
        // ve Handle(GetListBrandQueryRequest request, CancellationToken cancellationToken) ile GetListResponse<GetListBrandListItemDto> dönüyor.
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQueryRequest queryRequest=new() {Id = id};
        GetByIdBrandQueryResponse response=await Mediator.Send(queryRequest);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommandRequest request)
    {
        UpdatedBrandCommandResponse response=await Mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBrandCommandResponse response=await Mediator.Send(new DeleteBrandCommandRequest {Id = id});
        return Ok(response);
    }
}