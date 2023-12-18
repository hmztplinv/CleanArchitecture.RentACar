using MediatR;

public class UpdateBrandCommandRequest: IRequest<UpdatedBrandCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}