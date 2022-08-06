namespace Kanadeiar.Core.Enums;

public static class Tools
{
    public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
    {
        return (TEnum[])Enum.GetValues(typeof(TEnum));
    }
}
