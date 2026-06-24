namespace Employee_Result_CQRS_MediatR_Repo.Result;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }

    public bool IsFailure
    {
        get
        {
            return !IsSuccess;
        }
    }

    public string Error { get; }

    private Result(bool issuccess, T? value, string err)
    {
        IsSuccess = issuccess;
        Value = value;
        Error = err;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true,value,string.Empty);
    }

    public static Result<T> Failure(string error)
    {
        return new Result<T>(false,default,error);
    }

}
