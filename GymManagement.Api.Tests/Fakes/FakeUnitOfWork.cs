using GymManagement.Services;

namespace GymManagement.Api.Tests.Fakes;
internal class FakeUnitOfWork : IUnitOfWork
{
    public Task CommitChanges()
    {
        return Task.CompletedTask;
    }
}
