
public class BrandBusinessRules:BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;
    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
    {
        Brand? brand = await _brandRepository.GetAsync(predicate: x => x.Name.ToLower() == name.ToLower());
        if (brand != null)
        {
            throw new BusinessException(BrandsMessages.BrandNameExists);
        }
    }
}


 