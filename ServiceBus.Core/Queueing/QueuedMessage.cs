﻿namespace ServiceBus.Queueing
{
    using ServiceBus.Messaging;
    using System;

    public class QueuedMessage
    {
        public DateTime QueuedAt { get; set; }

        public IPeer Peer { get; set; }

        public IMessage Message { get; set; }

        public bool HasSent { get; set; }
    }
}
