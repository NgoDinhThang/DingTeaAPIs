using System;
namespace MISA.WEBAPI.Core.Exceptions
{
    public class MisaValidateException:Exception
    {
        public string msgError;

        public MisaValidateException(string msg)
        {
            this.msgError = msg;
        }
        public override string Message
        {
            get
            {
                return msgError;
            }
        }
    }
}
