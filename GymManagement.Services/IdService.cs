namespace GymManagement.Services;

public class IdService : IIdService
{
    public Guid CreateId() => Guid.NewGuid();
}
