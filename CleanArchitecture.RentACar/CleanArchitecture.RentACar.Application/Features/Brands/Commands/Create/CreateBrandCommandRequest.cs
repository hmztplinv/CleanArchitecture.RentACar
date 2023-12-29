using MediatR;

public class CreateBrandCommandRequest:IRequest<CreatedBrandCommandResponse>
{
    public string Name { get; set; }    
    // CreateBrandCommandRequest sen bir requestsin ve Name adında bir property'in var.
    // Dönüş olarak CreatedBrandCommandResponse döneceksin.
}