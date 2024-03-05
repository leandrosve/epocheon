namespace Prueba.Models.DTOs
{
    public class APIResponseDTO<T>
    {
        public T? Data { get; set; }

        public string? Error { get; set; }

        public bool HasError { get; set; }
        public string? TraceId { get; set; }

        public APIResponseDTO(T? data, string? error)
        {
            Data = data;
            Error = error;
            HasError = error != null;
        }

        public APIResponseDTO()
        {
        }
    }
}
