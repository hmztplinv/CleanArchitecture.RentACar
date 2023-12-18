using AutoMapper;
using MediatR;

public class GetByIdBrandQueryRequest : IRequest<GetByIdBrandQueryResponse>
{
    public Guid Id { get; set; }

}