using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL.Exceptions
{
    public abstract class ExceptionCodes
    {
        public enum BaseExceptions
        {
            [Description("An unknown error occured")]
            unhandled_exception
        }
        public enum BLLExceptions
        {
            GetAllSportEventsAsync,
            GetSportEventsAsync,
            InsertAsync,
            DeleteAsync,
            UpdateAsync
        }
    }
}
