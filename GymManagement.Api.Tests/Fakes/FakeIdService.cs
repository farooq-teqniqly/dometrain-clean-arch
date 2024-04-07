using GymManagement.Services;

namespace GymManagement.Api.Tests.Fakes;
internal class FakeIdService : IIdService
{
    public Guid CreateId() => new("d85fe8a0-f857-4391-a138-3479c903ba80");
}
