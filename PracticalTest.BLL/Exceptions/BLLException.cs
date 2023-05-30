using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL.Exceptions
{
    public class BLLException : ExceptionBase
    {
        private BLLException() : base("") { }
        public BLLException(ExceptionCodes.BLLExceptions code, string message)
            : base(EnumsHelper.GetDescription(code))
        {
            Code = code.ToString();
        }
        public BLLException(ExceptionCodes.BLLExceptions code, string message, Exception ex)
            : base(message, ex)
        {
            Code = code.ToString();
        }
    }
}
