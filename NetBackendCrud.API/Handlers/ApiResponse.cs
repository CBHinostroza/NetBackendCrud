using System.Net;

namespace NetBackendCrud.API.Handlers
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public Object Result { get; set; } = new object();
    }
}
