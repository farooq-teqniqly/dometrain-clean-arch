namespace GymManagement.Services;

public class TimeService : ITimeService
{
    public long GetUnixTimestamp() => (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
}
