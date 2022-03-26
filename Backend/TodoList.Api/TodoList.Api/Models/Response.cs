namespace TodoList.Api.Models
{
    public class Response
    {
        public Response(bool success = true, string message = "Success")
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
