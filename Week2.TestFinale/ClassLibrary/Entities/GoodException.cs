using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class GoodException : Exception
    {
        public GoodException()
        {
        }

        public GoodException(string message) : base(message)
        {
        }

        public GoodException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GoodException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
