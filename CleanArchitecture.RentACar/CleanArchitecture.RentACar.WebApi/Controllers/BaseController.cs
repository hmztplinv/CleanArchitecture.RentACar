using Microsoft.AspNetCore.Mvc;
using MediatR;
public class BaseController : ControllerBase
{
    private IMediator? _mediator; 
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    // protected IMediator? Mediator => _mediator ?? burası elinde bir mediator varsa onu döndür yoksa 
    //HttpContext.RequestServices.GetService<IMediator>() ile yeni bir mediator oluşturup onu döndür.
    // protected olması sayesinde bu sınıfı miras alan sınıflar bu özelliği kullanabilir.

}