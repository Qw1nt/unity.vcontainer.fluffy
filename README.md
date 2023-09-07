
# VContainer - Fluffy

Небольшая библиотека, упрощающая создание DI-контейнеров с привычныи синтаксисом добавления зависимостей 😉

## Установка

> **Внимание!** Для работы пакета необходимо импортировать [VContainer](https://vcontainer.hadashikick.jp/getting-started/installation)


### В виде unity-модуля

Поддерживается установка в виде unity-модуля через git-ссылку в PackageManager или прямое редактирование Packages/manifest.json:

```
"com.qw1nt.vcontainerlitetemplate": "https://github.com/Qw1nt/unity.vcontainer.lite-template"
```

### В виде исходников

Код так же может быть склонирован или получен в виде архива со страницы релизов.

## Создание DI-контейнера

```csharp
public class GameplayDiContainer : DiContainerBase
{
    protected override void AddDependencies(IContainerBuilder builder)
    {
        builder.AddScoped<ScopedLifetimeDependency>(); 
        builder.AddTransient<TransientLifetimeDependency>();
        builder.AddSingleton<SingletonLifetimeDependency>();
    }
}
```

> Предусмотрена автоматическая инъекция в объекты, на которых висит ```AutoInject.cs```


