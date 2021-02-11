using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => 
        throw new Exception("Hey, you asked for it.");

    public static int? HandleErrorByReturningNullableType(string input)
    {
        if (int.TryParse(input, out var value))
        {
            return value;
        }

        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result) => 
        int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using var resource = disposableObject;
        throw new Exception("Hi, I'm an error.");
    }
}
