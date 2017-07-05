using System;

namespace CQRS
{
    interface IMessageTransport
    {
        bool IsConnected { get; }
        void Send(object msg);
        event Action<object> msg;
    }
}
