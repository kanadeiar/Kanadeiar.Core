namespace Kanadeiar.Core.Container;

/// <summary>
/// Простейший контейнер внедрения зависимостей
/// </summary>
public interface IKndContainer
{
    /// <summary>
    /// Зарегистрировать сервис интерфейс - реализация
    /// </summary>
    public void Register<TService, TImplementation>() where TImplementation : TService;
    /// <summary>
    /// Зарегистрировать сервис как фабричный метод
    /// </summary>
    public void Register<TService>(Func<TService> factory);
    /// <summary>
    /// Зарегистрировать сервис как инстанс
    /// </summary>
    public void RegisterInstance<TService>(TService instance);
    /// <summary>
    /// Зарегистрировать как одиночку
    /// </summary>
    public void RegisterSingleton<TService>(Func<TService> factory);
    /// <summary>
    /// Разрешить зависимость
    /// </summary>
    public T Resolve<T>();
}