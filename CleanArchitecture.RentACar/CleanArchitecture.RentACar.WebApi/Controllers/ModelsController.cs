using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModelQueryRequest request = new GetListModelQueryRequest { PageRequest = pageRequest };
        GetListResponse<GetListModelListItemDto> response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
    {
        GetListByDynamicModelQueryRequest request = new () { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(request);
        return Ok(response);
    }
}