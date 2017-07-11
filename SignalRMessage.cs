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
            var serializedObj = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(serializedObj);
            this.payload = System.Convert.ToBase64String(plainTextBytes);
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
            var serializedObj = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(payload));
            return Newtonsoft.Json.JsonConvert.DeserializeObject(serializedObj, type);
        }

    }
}
