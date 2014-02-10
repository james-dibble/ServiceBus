﻿namespace ServiceBus
{
    using System;
    using System.Collections.Generic;

    using ServiceBus.Event;
    using ServiceBus.Messaging;

    public interface IServiceBus : IDisposable
    {
        Uri HostAddress { get; }

        IEnumerable<IPeer> Peers { get; }

        IEnumerable<IEndpoint> LocalEndpoints { get; }

        IMessageSerialiser Serialiser { get; }

        void Receive(IMessage message);

        void Send<TMessage>(IPeer peer, TMessage message) where TMessage : class, IMessage, new();

        void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;

        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : class, IEvent;
    }
}
