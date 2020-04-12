using Newtonsoft.Json.Serialization;
using SpaceManager.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SpaceManager.Serialization
{
    class Whitelister : ISerializationBinder
    {
        List<string> allowedNamespace = new List<string>()
        {
            "SpaceManager.Interfaces"
        };
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            if (allowedNamespace.Contains(serializedType.Namespace))
            {
                assemblyName = serializedType.Assembly.FullName;
                typeName = serializedType.Name;
            }
            else throw new TypeNotAllowedException(serializedType);
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            Type type = Type.GetType(typeName);
            if (type != null)
            {
                if (allowedNamespace.Contains(type.Namespace)) return type;
                else throw new TypeNotAllowedException(type);
            }
            else return type;
        }
    }
}
