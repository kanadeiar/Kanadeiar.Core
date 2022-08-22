# Быстрый старт

## Базовые сущности

Интерфейсы:

```sharp
IKndEntity<TKey>
IKndPage
IKndRepo<T, TKey>
```

Сущности:

```sharp
KndEntity<TKey>
```

## События

Вызов расширяющего метода уведомления о произошедшем событии:

```sharp
public virtual void OnMessage(TestEventArgs e)
{
    e.Raise(this, ref Message); //вызов метода
}
```

## Исключения

Обобщенный класс исключенияс Exception<TExceptionArgs>, в аргументе-типе производный от ExceptionArgs класс данных.

Пример класса данных:

```sharp
[Serializable]
public sealed class SampleExceptionArgs : ExceptionArgs
{
    private readonly string _message;
    public SampleExceptionArgs(string message)
    {
        _message = message;
    }
    public override String Message => _message;
}
```

Использование:

```sharp
try
{
    throw new Exception<SampleExceptionArgs>(new SampleExceptionArgs("Test"));
}
catch (Exception<SampleExceptionArgs> ex)
{
    Console.WriteLine(ex.Message + " " + ex.Args.Message);
}
```

## Асинхронность

### Метод расширения отмены операции

Метод расширения WithCancellation() позволяет отменять асинхронную операцию через заданный интервал времени. 

Пример использования этого расширения:

```sharp
Console.WriteLine("Отмена операции");
var cts = new CancellationTokenSource(1_000);
var token = cts.Token;
try
{
    await Task.Delay(10_000).WithCancellation(token); // метод отмены асинхронной операции
}
catch (OperationCanceledException)
{
    Console.WriteLine("Операция отменена");
}
```

### Класс поддержки отладки асинхронного кода

Класс TaskLogger позволяет выводить информацию о незавершенных асинхронных операциях. Полезен при отладке асинхронного кода, когда приложение виснет.

Пример использования этого класса:

```sharp
#if DEBUG
// Использование TaskLogger приводит к лишним затратам памяти
// и снижению производительности; включить для отладочной версии
TaskLogger.LogLevel = TaskLogger.TaskLogLevel.Pending;
#endif
var tasks = new List<Task>
{
    Task.Delay(2_000).Log("2с"), // добавление логирования
    Task.Delay(4_000).Log("4с"), // добавление логирования
    Task.Delay(6_000).Log("6с"), // добавление логирования
};

try
{
    await Task.WhenAll(tasks).WithCancellation(new CancellationTokenSource(3_000).Token);
}
catch (OperationCanceledException)
{
}

var logs = TaskLogger.GetLogStrings().ToArray(); // показ информации логирования
Array.ForEach(logs, Console.WriteLine);
```

### Асинхронная синхронизация

Класс, предоставляющий возможность асинхронной синхронизации с семантикой чтения/записи

Использование:

```sharp
static class SimpleStatic
{
    private static int _value;
    public static int Value => _value;
    public static async Task AddAsync(AsyncLock asyncLock)
    {
        await asyncLock.WaitAsync(LockMode.Shared); // Запросить общий доступ
        Console.WriteLine(_value); // Чтение из ресурса...
        asyncLock.Release(); // Снятие блокировки, чтобы ресурс стал доступен другим потокам
    }
}
```

## Шифрование методом Цезаря

Метод CaesarEncoder шифрует/расшифровывает методом цезаря

## Инструменты

### Инструмент замера производительности - скорости работы кода и количества сборок мусора

```sharp
using (new OperationTimer("Выводимый в консоль текст"))
{
    // измеряемый код
}
```

### Получение всех значений перечисления

```sharp
TEnum[] GetEnumValues<TEnum>()
```
