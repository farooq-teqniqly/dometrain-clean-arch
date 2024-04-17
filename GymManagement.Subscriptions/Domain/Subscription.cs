namespace GymManagement.Subscriptions.Domain;

public class Subscription
{
    public Guid Id { get; private set; }
    public SubscriptionType Type { get; private set; } = default!;
    public Guid AdminId { get; private set; }

    public Subscription(Guid id, SubscriptionType type, Guid adminId)
    {
        Id = id;
        Type = type;
        AdminId = adminId;
    }
    private Subscription()
    {

    }

    public void Deconstruct(out Guid id, out SubscriptionType type, out Guid adminId)
    {
        id = Id;
        type = Type;
        adminId = AdminId;
    }

}
