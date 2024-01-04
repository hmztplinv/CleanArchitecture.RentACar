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
}