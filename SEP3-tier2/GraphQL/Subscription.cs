using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using SEP3_tier2.Models;

namespace SEP3_tier2.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<User>> OnUserCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        { 
            return await eventReceiver.SubscribeAsync<String, User>("UserCreated", cancellationToken);
        }
    }

    
}