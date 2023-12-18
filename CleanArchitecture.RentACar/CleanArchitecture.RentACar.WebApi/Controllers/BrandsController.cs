
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BrandsController:BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add(CreateBrandCommandRequest request)
    {
        CreatedBrandCommandResponse response=await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        GetListBrandQueryRequest queryRequest=new() {PageRequest = request};
        GetListResponse<GetListBrandListItemDto> response=await Mediator.Send(queryRequest);
        return Ok(response);
    }
}