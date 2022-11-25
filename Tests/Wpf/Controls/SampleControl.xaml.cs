namespace Wpf.Controls;

public partial class SampleControl : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value",
        typeof(int),
        typeof(SampleControl),
        new PropertyMetadata(0));
    [Description("Значение")]
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public SampleControl()
    {
        InitializeComponent();
    }
}