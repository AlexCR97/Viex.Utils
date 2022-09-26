namespace Viex.Utils.ExceptionHandlers;

public static class Try
{
    public static Exception? Action(Action action)
    {
        try
        {
            action();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    public static (T, Exception?) Func<T>(Func<T> func)
    {
        try
        {
            var result = func();
            return (result, null);
        }
        catch (Exception ex)
        {
            return (default!, ex);
        }
    }

    public static async Task<Exception?> Task(Task task)
    {
        try
        {
            await task;
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    public static async Task<Exception?> Task(Func<Task> task)
    {
        try
        {
            await task();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }

    }

    public static async Task<(T, Exception?)> Task<T>(Task<T> task)
    {
        try
        {
            var result = await task;
            return (result, null);
        }
        catch (Exception ex)
        {
            return (default!, ex);
        }
    }

    public static async Task<(T, Exception?)> Task<T>(Func<Task<T>> task)
    {
        try
        {
            var result = await task();
            return (result, null);
        }
        catch (Exception ex)
        {
            return (default!, ex);
        }
    }
}
