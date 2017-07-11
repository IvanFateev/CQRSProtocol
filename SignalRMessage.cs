using System;

namespace CQRS
{
    public class SignalRMessage
    {
        public string messageType;
        public string payload;

        public SignalRMessage(object payload)
        {
            messageType = payload.GetType().FullName;
            this.payload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
        }

        public object ToObject()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type type = null;
            foreach (var assembly in assemblies)
            {
                type = assembly.GetType(messageType);
                if (type != null)
                {
                    break;
                }
            }
            if (type == null)
            {
                throw new Exception("Can't deserialize SignalRMessage: Type " + messageType + " not found");
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject(payload, type);
        }

    }
}
