namespace UseCases
{
    public class ErrorBase
    {
        public ErrorBase()
        {

        }
        protected ErrorBase(string type, string code, string message)
        {
            Type = type;
            Code = code;
            Message = message;
        }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}