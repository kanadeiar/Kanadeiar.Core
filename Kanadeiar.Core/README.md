# Быстрый старт

## Базовые сущности

Интерфейсы:

```sharp
IKndEntity
IKndEntity<T>
```

Сущности:

```sharp
KndEntity
KndEntity<T>
```

## События

Вызов расширяющего метода уведомления о произошедшем событии:

```sharp
public virtual void OnMessage(TestEventArgs e)
{
    e.Raise(this, ref Message); //вызов метода
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

