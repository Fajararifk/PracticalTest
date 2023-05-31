using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase(string description) //Create account failed
            : base(description)
        {
            if (description == null) throw new ArgumentNullException("description");
            Code = description;
        }
        public ExceptionBase(string description, Exception inner)
            : base(description, inner)
        {
            // avoid devs t let throw exception without details
            if (description == null) throw new ArgumentNullException("description");
            if (inner == null) throw new ArgumentNullException("inner");
            Code = description;
        }
        public ExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Code = ExceptionCodes.BaseExceptions.unhandled_exception.ToString();
        }
        public string Code { get; set; }
    }
}
