using MediatR;

public class DeleteBrandCommandRequest : IRequest<DeletedBrandCommandResponse>
{
    public Guid Id { get; set; }
}