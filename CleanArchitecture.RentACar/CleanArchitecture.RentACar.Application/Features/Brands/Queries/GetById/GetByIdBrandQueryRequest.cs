using AutoMapper;
using MediatR;

public class GetByIdBrandQueryRequest : IRequest<GetByIdBrandQueryResponse>
{
    public Guid Id { get; set; } // gelen isteğin içindeki Id'yi alıyoruz ve GetByIdBrandQueryResponse dönüyoruz.

}