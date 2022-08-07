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

## Шифрование методом Цезаря

```sharp
CaesarEncoder
```

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
