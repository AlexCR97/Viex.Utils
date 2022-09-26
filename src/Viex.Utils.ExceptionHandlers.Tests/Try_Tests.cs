namespace Viex.Utils.ExceptionHandlers.Tests;

public class Try_Tests
{
    #region Actions

    [Fact]
    public void TryActionShouldSucceed()
    {
        var ex = Try.Action(() => Console.WriteLine("This is a simple action"));
        Assert.True(ex is null, "The returned exception must be null");
    }

    [Fact]
    public void TryActionShouldFail()
    {
        var ex = Try.Action(() => throw new Exception("This is an exception"));
        Assert.True(ex is not null, "The returned exception must NOT be null");
    }

    #endregion

    #region Funcs

    [Fact]
    public void TryFuncShouldSucceed()
    {
        var (result, ex) = Try.Func(() => "This is a result");
        Assert.True(ex is null, "The returned exception must be null");
        Assert.True(result is not null, "The returned result must NOT be null");
    }

    [Fact]
    public void TryFuncShouldFail()
    {
        var (result, ex) = Try.Func<string>(() => throw new Exception("This is an exception"));
        Assert.True(ex is not null, "The returned exception must NOT be null");
        Assert.True(result is null, "The returned result must be null");
    }

    #endregion

    #region Task

    [Fact]
    public async Task TryTaskShouldSucceed()
    {
        var ex = await Try.Task(Task.CompletedTask);
        Assert.True(ex is null, "The returned exception must be null");
    }

    [Fact]
    public async Task TryTaskShouldFail()
    {
        var ex = await Try.Task(Task.Run(() => throw new Exception("This is an exception")));
        Assert.True(ex is not null, "The returned exception must NOT be null");
    }

    [Fact]
    public async Task TryTaskWithAsyncCallbackShouldSucceed()
    {
        var ex = await Try.Task(async () => await Task.Delay(100));
        Assert.True(ex is null, "The returned exception must be null");
    }

    [Fact]
    public async Task TryTaskWithAsyncCallbackShouldFail()
    {
        var ex = await Try.Task(() => throw new Exception("This is an exception"));
        Assert.True(ex is not null, "The returned exception must NOT be null");
    }

    #endregion

    #region Task<T>

    [Fact]
    public async Task TryTaskResultShouldSucceed()
    {
        var (result, ex) = await Try.Task(Task.FromResult("This is a task result"));
        Assert.True(ex is null, "The returned exception must be null");
        Assert.True(result is not null, "The returned result must NOT be null");
    }

    [Fact]
    public async Task TryTaskResultShouldFail()
    {
        var (result, ex) = await Try.Task<string>(async () => throw new Exception("This is an exception"));
        Assert.True(ex is not null, "The returned exception must NOT be null");
        Assert.True(result is null, "The returned result must be null");
    }

    #endregion
}
