using System.Diagnostics;

namespace Kanadeiar.Core.Tools;

public sealed class OperationTimer : IDisposable
{
    private readonly string _text;
    private readonly int _collectionCount;
    private readonly Stopwatch _stopwatch;
    public OperationTimer(String text)
    {
        PrepareForOperation();
        _text = text;
        _collectionCount = GC.CollectionCount(0);

        _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        System.Console.WriteLine("{0} (GCs={1,3}) {2}", _stopwatch.Elapsed, GC.CollectionCount(0) - _collectionCount, _text);
    }
    private static void PrepareForOperation()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}
