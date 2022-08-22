namespace Kanadeiar.Core.Async;

public enum LockMode { Exclusive, Shared }
public class AsyncLock
{
    private SpinLock _lock = new SpinLock(true);
    private void Lock() { var taken = false; _lock.Enter(ref taken); }
    private void Unlock() { _lock.Exit(); }

    private int _state = 0;
    private bool IsFree { get { return _state == 0; } }
    private bool IsOwnedByWriter { get { return _state == 1; } }
    private bool IsOwnedByReaders { get { return _state > 0; } }
    private int AddReaders(int count) { return _state += count; }
    private int SubtractReader()
    {
        return _state;
    }
    private void MakeWriter()
    {
        _state = 1;
    }
    private void MakeFree() { _state = 0; }

    private readonly Task _noContentionAccessGranter;
    private readonly Queue<TaskCompletionSource<object>> _qWaitingWriters = new Queue<TaskCompletionSource<object>>();
    private TaskCompletionSource<object> _waitingReadersSignal = new TaskCompletionSource<object>();
    private int _numWaitingReaders = 0;

    public AsyncLock()
    {
        _noContentionAccessGranter = Task.FromResult<object>(null!);
    }

    public Task WaitAsync(LockMode mode)
    {
        var accressGranter = _noContentionAccessGranter;
        Lock();
        switch (mode)
        {
            case LockMode.Exclusive:
                if (IsFree)
                {
                    MakeWriter();
                }
                else
                {
                    var tcs = new TaskCompletionSource<object>();
                    _qWaitingWriters.Enqueue(tcs);
                    accressGranter = tcs.Task;
                }
                break;
            case LockMode.Shared:
                if (IsFree || (IsOwnedByReaders && _qWaitingWriters.Count == 0))
                {
                    AddReaders(1); // Отсутствие конкуренции
                }
                else
                {
                    _numWaitingReaders++;
                    accressGranter = _waitingReadersSignal.Task.ContinueWith(t => t.Result);
                }
                break;
        }
        Unlock();
        return accressGranter;
    }

    public void Release()
    {
        TaskCompletionSource<object> accessGranter = null!;
        Lock();
        if (IsOwnedByWriter)
            MakeFree(); // Ушло задание записи
        else
            SubtractReader();
        if (IsFree)
        {
            if (_qWaitingWriters.Count > 0)
            {
                MakeWriter();
                accessGranter = _qWaitingWriters.Dequeue();
            }
            else if (_numWaitingReaders > 0)
            {
                AddReaders(_numWaitingReaders);
                _numWaitingReaders = 0;
                accessGranter = _waitingReadersSignal;
                // Создание нового объекта TCS для будущих заданий, которым придется ожидать
                _waitingReadersSignal = new TaskCompletionSource<object>();
            }
        }
        Unlock();
        if (accessGranter is { }) accessGranter.SetResult(null!);
    }
}

