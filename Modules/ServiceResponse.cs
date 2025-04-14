namespace WebApplication1.Modules
{
    public class ServiceResponse<T>
    {
        public T data { get; set; }
        public int status { get; set; }
        public string message { get; set; }
    }
}
