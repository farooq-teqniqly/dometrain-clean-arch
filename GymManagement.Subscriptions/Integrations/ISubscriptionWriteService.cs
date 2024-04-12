using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Subscriptions.Integrations;
public interface ISubscriptionWriteService
{
    Guid CreateSubscription(string subscriptionType, Guid adminId);
}
