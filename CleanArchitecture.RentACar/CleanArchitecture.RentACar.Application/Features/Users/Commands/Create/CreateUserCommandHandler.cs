using AutoMapper;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserEmailShouldNotBeExistsWhenInsert(request.Email);
        //await _userBusinessRules.UserIdShouldBeExistsWhenSelected(request.Id);
        User user = _mapper.Map<User>(request);

        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash:out byte[] passwordHash,
            passwordSalt:out byte[] passwordSalt
        );

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        User createdUser = await _userRepository.AddAsync(user);

        CreateUserCommandResponse response = _mapper.Map<CreateUserCommandResponse>(createdUser);
        return response;
    }
}