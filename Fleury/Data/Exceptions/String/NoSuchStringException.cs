using System;
using System.Runtime.Serialization;

namespace Fleury.Data.Exceptions.String
{
    [Serializable]
    public class NoSuchStringException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NoSuchStringException()
        {
        }

        public NoSuchStringException(string message) : base(message)
        {
        }

        public NoSuchStringException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NoSuchStringException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}