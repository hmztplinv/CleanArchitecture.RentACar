using MediatR;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreatedBrandCommandResponse>
{

    public async Task<CreatedBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        CreatedBrandCommandResponse response = new CreatedBrandCommandResponse();
        response.Id = Guid.NewGuid();
        response.Name = request.Name;
        return null;
    }
}

