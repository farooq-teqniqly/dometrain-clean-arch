using GymManagement.Services;

namespace GymManagement.Api.Tests.Fakes;
internal class FakeTimeService : ITimeService
{
    public long GetUnixTimestamp() => 123456;
}
