using System;
using System.Collections.Concurrent;
using EasyNetQ;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public class TypeNameSerializer : ITypeNameSerializer
    {
        private readonly ConcurrentDictionary<string, Type> _deserializedTypes = new ConcurrentDictionary<string, Type>();
        private readonly ConcurrentDictionary<Type, string> _serializedTypes = new ConcurrentDictionary<Type, string>();

        public Type DeSerialize(string typeName)
        {
            return _deserializedTypes.GetOrAdd(typeName, t =>
            {
                var fullName = $"{GetType().Namespace}.{typeName}";
                var type = Type.GetType(fullName);
                if (type == null)
                {
                    throw new EasyNetQException("Cannot find type {0}", fullName);
                }
                return type;
            });
        }

        public string Serialize(Type type)
        {
            return _serializedTypes.GetOrAdd(type, t =>
            {
                var typeName = t.Name;
                if (typeName.Length > 255)
                {
                    throw new EasyNetQException("The serialized name of type '{0}' exceeds the AMQP " +
                                                "maximum short string length of 255 characters.", t.Name);
                }
                return typeName;
            });
        }
    }
}