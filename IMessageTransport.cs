using System;

namespace CQRS
{
    public interface IMessageTransport
    {
        bool IsConnected { get; }
        void Send(object msg);
        event Action<object> msg;
    }
}
