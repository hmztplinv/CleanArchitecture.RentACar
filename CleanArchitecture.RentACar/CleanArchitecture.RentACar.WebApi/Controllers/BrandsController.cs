
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BrandsController:BaseController
{

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommandRequest request)
    {
        CreatedBrandCommandResponse response=await Mediator.Send(request);
        return Ok(response);
    }
}