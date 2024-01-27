using MediatR;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>,ISecuredRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string[] Roles => new[] { UsersOperationClaims.Admin, UsersOperationClaims.Write, UsersOperationClaims.Create };

    public CreateUserCommandRequest()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public CreateUserCommandRequest(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    
}
