namespace OtByBooking.Models.DTOs;

public class MessageInfoDTO
{
    public object? Result { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class MessageInfoDTO<T>
{
    public bool Success { get; set; } = false;
    public T? Result { get; set; }
    public string Message { get; set; } = string.Empty;
}