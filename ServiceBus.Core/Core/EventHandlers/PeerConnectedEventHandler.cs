﻿namespace ServiceBus.Core.EventHandlers
{
    using System.Threading.Tasks;

    using ServiceBus.Core.Events;
    using ServiceBus.Event;

    internal sealed class PeerConnectedEventHandler : IEventHandler<PeerConnectedEvent>
    {
        private readonly IServiceBus _serviceBus;

        internal PeerConnectedEventHandler(IServiceBus serviceBus)
        {
            this._serviceBus = serviceBus;
        }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> part that defines the location of this <see cref="IEndpoint"/>.
        /// </summary>
        public string EndpointPath
        {
            get
            {
                return "service-bus/peer-connected";
            }
        }

        /// <summary>
        /// Invoke services to deal with this PeerConnectedEvent.
        /// </summary>
        /// <param name="event">The PeerConnectedEvent data.</param>
        /// <returns>An awaitable object representing the handling operation.</returns>
        public async Task HandleAsync(PeerConnectedEvent @event)
        {
            await this._serviceBus.SynchroniseAsync(@event.ConnectedPeer);
        }
    }
}
