namespace Kanadeiar.Core.Enums;

public static class Tools
{
    /// <summary>
    /// Получение списка всех значений перечисления
    /// </summary>
    public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
    {
        return (TEnum[])Enum.GetValues(typeof(TEnum));
    }
}
