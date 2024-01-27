public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
        {
            throw new BusinessException(AuthMessages.UserDontExist);
        }

        return Task.CompletedTask;
    }

    public async Task UserIdShouldBeExistsWhenSelected(int id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id, enableTracking: false);
        if (!doesExist)
        {
            throw new BusinessException(AuthMessages.UserDontExist);
        }
    }

    public Task UserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        }

        return Task.CompletedTask;
    }

    public async Task UserEmailShouldNotBeExistsWhenInsert(string email)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (doesExist)
        {
            throw new BusinessException(AuthMessages.UserEmailAlreadyExists);
        }
    }

    public async Task UserEmailShouldNotExistsWhenUpdate(int id,string email)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email, enableTracking: false);
        if (doesExist)
        {
            throw new BusinessException(AuthMessages.UserEmailAlreadyExists);
        }
    }
}