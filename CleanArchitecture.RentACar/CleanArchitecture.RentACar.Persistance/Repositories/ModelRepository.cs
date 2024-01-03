public class ModelRepository : EfRepositoryBase<BaseDbContext, Model, Guid>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}