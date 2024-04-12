using GymManagement.Services;

namespace GymManagement.Subscriptions.Integrations;

internal class SubscriptionWriteService(IIdService idService) : ISubscriptionWriteService
{
    public Guid CreateSubscription(string subscriptionType, Guid adminId)
    {
        return idService.CreateId();
    }
}
