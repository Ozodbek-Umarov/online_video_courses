namespace OnlineVideoCourse.Aplication.Common.Exseption;

public class ValidatorException : Exception
{
    public ValidatorException(string message)
        : base(message)
    {
    }
}