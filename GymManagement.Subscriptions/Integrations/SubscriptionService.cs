using GymManagement.Services;

namespace GymManagement.Subscriptions.Integrations;

public class SubscriptionService(IIdService idService) : ISubscriptionService
{
    public Guid CreateSubscription(string subscriptionType, Guid adminId)
    {
        return idService.CreateId();
    }
}
