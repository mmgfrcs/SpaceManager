using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SpaceManager.Core.Serialization
{
    class TypeNotAllowedException : Exception
    {
        public TypeNotAllowedException()
        {
        }

        public TypeNotAllowedException(Type type) : base("The following type is not allowed to be loaded:\n" + type.FullName)
        {
        }

    }
}
