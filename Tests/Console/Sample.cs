class Sample : ISample
{
    private readonly ISecond _second;
    public Sample(ISecond second)
    {
        _second = second;
    }
    public string GetMessage()
    {
        return _second.Message;
    }
}