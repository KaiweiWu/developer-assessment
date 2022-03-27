namespace TodoList.Api.Models
{
    public class Response
    {
        public Response(string message, bool error = false)
        {
            Message = message;
            Error = error;
        }

        public string Message { get; set; }
        public bool Error { get; set; }
        
    }
}
