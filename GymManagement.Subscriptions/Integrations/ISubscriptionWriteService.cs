namespace GymManagement.Subscriptions.Integrations;

public interface ISubscriptionWriteService
{
    Guid CreateSubscription(string subscriptionType, Guid adminId);
}
