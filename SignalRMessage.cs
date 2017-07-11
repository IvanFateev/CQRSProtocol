using System;

namespace CQRS
{
    public class SignalRMessage
    {
        public string messageType;
        public string payload;

        public static SignalRMessage From(object payload)
        {

            var serializedObj = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            return new SignalRMessage
            {
                messageType = payload.GetType().FullName,
                payload = serializedObj
            };
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
