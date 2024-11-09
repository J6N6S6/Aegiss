namespace Aegiss.Core.Exceptions
{
    public class CustomException
    {        
        public int Code { get; }
        public string Message {  get; }

        public CustomException(string message, int code)
        {
            Code = code;
            Message = message;
        }
    }
}
