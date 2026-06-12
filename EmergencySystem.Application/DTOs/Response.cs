using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Application.DTOs;

public class Response<T>
{
    public T? Data { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public ErrorCodes ErrorCode { get; set; }
    public Dictionary<string, List<string>>? Errors { get; set; }

    private Response(
        T? data,
        string message,
        bool isSuccess,
        ErrorCodes errorCode,
        Dictionary<string, List<string>>? errors = null)
    {
        Data = data;
        Message = message;
        IsSuccess = isSuccess;
        ErrorCode = errorCode;
        Errors = errors;
    }

    public static Response<T> Success(T data, string message = "") =>
        new Response<T>(data, message, true, ErrorCodes.NoError);

    public static Response<T> Failure(ErrorCodes errorCode, string message = "") =>
        new Response<T>(default, message, false, errorCode);

    public static Response<T> Failure(ErrorCodes errorCode, Dictionary<string, List<string>> errors) =>
        new Response<T>(default, "", false, errorCode, errors);



}
