using GymManagement.Services;
using GymManagement.Subscriptions.Integrations;

namespace GymManagement.Subscriptions;

internal class SubscriptionWriteService(IIdService idService) : ISubscriptionWriteService
{
    public Guid CreateSubscription(string subscriptionType, Guid adminId)
    {
        return idService.CreateId();
    }
}
