namespace Kanadeiar.Core.Encoders
{
    /// <summary>
    /// Шифрование методом Цезаря
    /// </summary>
    public sealed class CaesarEncoder
    {
        /// <summary>
        /// Зашифровать
        /// </summary>
        /// <param name="str">исходная</param>
        /// <param name="key">ключ</param>
        /// <returns>зашифрованная</returns>
        public static string Encode(string str, int key = 1)
        {
            return new string(str.Select(c => (char)(c + key)).ToArray());
        }
        /// <summary>
        /// Расшифровать
        /// </summary>
        /// <param name="str">исходная</param>
        /// <param name="key">ключ</param>
        /// <returns>расшифрованная</returns>
        public static string Decode(string str, int key = 1)
        {
            return new string(str.Select(c => (char)(c - key)).ToArray());
        }
    }
}
