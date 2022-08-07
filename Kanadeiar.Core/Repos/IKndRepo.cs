using Kanadeiar.Core.Base;

namespace Kanadeiar.Core.Repos;

/// <summary>
/// Репозиторий элементов
/// </summary>
/// <typeparam name="T">Тип элементов, хранимых в репозитории</typeparam>
/// <typeparam name="TKey">Тип первичного ключа</typeparam>
public interface IKndRepo<T, TKey> : IRepo where T : IKndEntity<TKey>
{
    /// <summary>
    /// Простой запрос сущностей
    /// </summary>
    IQueryable<T> Query { get; }

    /// <summary>
    /// Существует ли сущность с указанным идентификатором
    /// </summary>
    /// <param name="id">Проверяемый идентификатор сущности</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Истина, если сущность с указанным идентификатором существует в репозитории</returns>
    Task<bool> ExistId(TKey id, CancellationToken cancel = default);

    /// <summary>
    /// Существует ли в репозитории указанная сущность
    /// </summary>
    /// <param name="item">Проверяемая сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Истина, если указанная сущность существует в репозитории</returns>
    Task<bool> Exist(T item, CancellationToken cancel = default);

    /// <summary>
    /// Получить число хранимых сущностей
    /// </summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    Task<int> GetCount(CancellationToken cancel = default);

    /// <summary>
    /// Асинхронная коллекция всех сущностей
    /// </summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Асинхронная коллекция</returns>
    IAsyncEnumerable<T> GetAllAsync(CancellationToken cancel);

    /// <summary>
    /// Асинхронная коллекция отобранных элементов
    /// </summary>
    /// <param name="skip">Количество пропускаемых элементов</param>
    /// <param name="count">Количество извлекаемых элементов</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Асинхронная коллекция</returns>
    IAsyncEnumerable<T> GetSkipAsync(int skip, int count, CancellationToken cancel);

    /// <summary>
    /// Получить страницу с элементами из репозитория
    /// </summary>
    /// <param name="pageNumber">Номер страницы начиная с нуля</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Страница с сущностями из репозитория</returns>
    Task<IKndPage<T>> GetPage(int pageNumber, int pageSize, CancellationToken cancel);

    /// <summary>
    /// Получить один элемент
    /// </summary>
    /// <param name="id">Идентификатор требуемого элемента</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns></returns>
    Task<T?> GetById(TKey id, CancellationToken cancel = default);

    /// <summary>
    /// Добавить элемент
    /// </summary>
    /// <param name="entity">Новый элемент</param>
    /// <param name="saveChanges">Сохранить изменения</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Добавленный элемент</returns>
    Task<T> Add(T entity, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Добавление перечисленных сущностей в репозиторий
    /// </summary>
    /// <param name="items">Перечисление добавляемых в репозиторий сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Завершенная задача</returns>
    Task AddRange(IEnumerable<T> items, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Обновить элемент
    /// </summary>
    /// <param name="entity">Обновленный элемент</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность из репозитория с обновлёнными данными</returns>
    Task<T> Update(T entity, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Обновление перечисленных сущностей
    /// </summary>
    /// <param name="items">Перечисление сущностей, информацию из которых надо обновить в репозитории</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Завершенная задача</returns>
    Task UpdateRange(IEnumerable<T> items, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Удалить элемент
    /// </summary>
    /// <param name="entity">Удаляемый элемент</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Завершенная задача</returns>
    Task Delete(T entity, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Удаление перечисления сущностей из репозитория
    /// </summary>
    /// <param name="items">Перечисление удаляемых сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Завершенная задача</returns>
    Task DeleteRange(IEnumerable<T> items, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Удаление сущности по заданному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности, которую надо удалить</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Удалённая из репозитория сущность</returns>
    Task<T?> DeleteById(TKey id, bool saveChanges = true, CancellationToken cancel = default);

    /// <summary>
    /// Сохранение изменений в базе данных
    /// </summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Количество затронутых элементов</returns>
    Task<int> Commit(CancellationToken cancel);

    #region Дополнительные методы

    /// <summary>
    /// Проверка репозитория на пустоту
    /// </summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Истина, если в репозитории нет ни одной сущности</returns>
    async Task<bool> IsEmpty(CancellationToken cancel = default)
    {
        var count = await GetCount(cancel).ConfigureAwait(false);
        return count > 0;
    }

    /// <summary>
    /// Добавление сущности в репозиторий с помощью фабричного метода
    /// </summary>
    /// <param name="itemFactory">Метод, формирующий добавляемую в репозиторий сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Добавленная в репозиторий сущность</returns>
    Task<T> AddAsync(Func<T> itemFactory, bool saveChanges = true, CancellationToken cancel = default) => Add(itemFactory(), saveChanges, cancel);

    /// <summary>Обновление сущности в репозитории</summary>
    /// <param name="id">Идентификатор обновляемой сущности</param>
    /// <param name="ItemUpdating">Метод обновления информации в заданной сущности</param>
    /// <param name="Cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность из репозитория с обновлёнными данными</returns>
    async Task<T?> UpdateAsync(TKey id, Action<T> itemUpdating, bool saveChanges = true, CancellationToken cancel = default)
    {
        if (await GetById(id, cancel).ConfigureAwait(false) is not { } item)
            return default;
        itemUpdating(item);
        await Update(item, saveChanges, cancel);
        return item;
    }

    #endregion
}

/// <summary>
/// Совсем базовый репозиторий элементов
/// </summary>
public interface IRepo { }