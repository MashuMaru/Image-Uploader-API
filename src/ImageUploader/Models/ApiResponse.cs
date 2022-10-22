namespace ImageUploader.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
    }
}