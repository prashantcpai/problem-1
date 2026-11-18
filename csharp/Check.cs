// Minimal zero-dependency test runner, so the exercise needs no package downloads.
public static class Check
{
    private static int _failures;

    public static async Task Test(string name, Func<Task> body)
    {
        try
        {
            await body();
            Console.WriteLine($"PASS  {name}");
        }
        catch (Exception e)
        {
            _failures++;
            Console.WriteLine($"FAIL  {name}  ->  {e.Message}");
        }
    }

    public static Task Test(string name, Action body) =>
        Test(name, () => { body(); return Task.CompletedTask; });

    public static void Equal<T>(T expected, T actual)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new Exception($"expected <{expected}> but was <{actual}>");
    }

    public static void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        if (!expected.SequenceEqual(actual))
            throw new Exception($"expected [{string.Join(", ", expected)}] but was [{string.Join(", ", actual)}]");
    }

    public static int Finish()
    {
        Console.WriteLine(_failures == 0 ? "\nAll tests passed." : $"\n{_failures} test(s) failed.");
        return _failures == 0 ? 0 : 1;
    }
}
