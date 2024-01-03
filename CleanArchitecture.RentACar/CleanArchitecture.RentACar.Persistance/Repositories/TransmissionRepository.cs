public class TransmissionRepository : EfRepositoryBase<BaseDbContext, Transmission, Guid>, ITransmissionRepository
{
    public TransmissionRepository(BaseDbContext context) : base(context)
    {
    }
}