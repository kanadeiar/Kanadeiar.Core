namespace Wpf.Models;

public class Sample : Base.ModelBase
{
    private string _Name = string.Empty;
    /// <summary>
    /// Название
    /// </summary>
    public string Name
    {
        get => _Name;
        set => Set(ref _Name, value);
    }
}