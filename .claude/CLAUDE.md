# CLAUDE.md

Guidance for Claude Code (claude.ai/code) when working in the **`Calabonga.CommandexCommand.Template`** repository.

> Дополнительные правила — в [`.claude/rules/code-styles.md`](rules/code-styles.md) (стиль C#) и [`.claude/rules/workflow.md`](rules/workflow.md) (ветки, коммиты).
> Общий контекст рабочего пространства из шести репозиториев — в `../CLAUDE.md`.

## Что это за репозиторий

Один NuGet-пакет типа **`Template`** (`Calabonga.CommandexCommand.Template`), внутри которого **три** независимых шаблона `dotnet new` для быстрого создания команды Commandex как WPF-class-library:

| shortName | identity / sourceName | Базовый класс команды | Что внутри |
| --- | --- | --- | --- |
| `wpfcmdx-dialog` | `Commandex.DialogCommand` | `DialogCommandexCommand<TView, TResult>` | `Core/` с `View` (XAML, `IDialogView`) + `DefaultDialogResult`-наследник |
| `wpfcmdx-wizard` | `Commandex.WizardCommand` | `WizardDialogCommandexCommand<TViewModel>` | `WizardDialogViewModel<PersonViewModel>`, 4 шага (`Step1..Step3` с валидацией + `StepFinal`), payload `PersonViewModel` |
| `wpfcmdx-zone` | `Commandex.ZoneCommand` | `ZoneCommandexCommand<TView, TViewModel>` | `Core/` с `View` (`IZoneView`) + `ZoneViewModelBase`-наследник, кнопка `GoBack` |

Тип в терминах версионирования рабочего пространства — **Framework**: `PackageVersion` пакета и `PackageReference`/`<Version>` внутри шаблонных проектов в одном релизном цикле совпадают с версией `Engine`. Это content-пакет `dotnet new` — при `dotnet pack` ничего не восстанавливает, порядок публикации относительно `Engine`/`Processors` не важен (см. диаграмму в `../CLAUDE.md`). Версии `PackageReference` внутри `content/` резолвятся только когда конечный пользователь выполнит `dotnet new` и соберёт результат.

## Структура

```
src/
  Calabonga.CommandexCommand.Template.sln
  Calabonga.CommandexCommand.Template/
    Calabonga.CommandexCommand.Template.csproj   <- ПАКУЮЩИЙ проект (PackageType=Template, net10.0,
                                                     IncludeBuildOutput=false, ContentTargetFolders=content, NoDefaultExcludes=true)
    README.md                                    <- СТОРОННИЙ файл: это копия README из Shell.Develop.Template,
                                                     в пакет не попадает (PackageReadmeFile = ..\..\README.md)
    content/
      DialogCommandTemplate/
        .template.config/  template.json  dotnetcli.host.json  ide.host.json  icon.png
        Commandex.DialogCommand.csproj
        DialogCommandDefinition.cs               <- COMMAND_NAMEDefinition : AppDefinition
        Core/
          DialogCommandCommandex.cs              <- class COMMAND_NAMECommandex : DialogCommandexCommand<…>
          ViewModels/DialogCommandResult.cs      <- COMMAND_NAMEResult : DefaultDialogResult
          Views/DialogCommandView.xaml(.cs)      <- COMMAND_NAMEView : UserControl, IDialogView
      WizardCommandTemplate/  … Commandex.WizardCommand.csproj, WizardCommandDefinition.cs,
        Core/WizardCommandCommandex.cs, Core/ViewModels/WizardCommandViewModel.cs (class COMMAND_NAMEViewModel),
        Core/Entities/PersonViewModel.cs, Core/WizardSteps/Step1..Step3,StepFinal (xaml + *WizardViewModel.cs)
      ZoneCommandTemplate/   … Commandex.ZoneCommand.csproj, ZoneCommandDefinition.cs,
        Core/ZoneCommandCommandex.cs, Core/ViewModels/ZoneCommandViewModel.cs, Core/Views/ZoneCommandView.xaml(.cs)
```

### Токенизация

- `COMMAND_NAME` в **содержимом** файлов заменяется символом `CommandName` (`template.json` → `replaces`), CLI-опция — `--command-name` / `-cn` (`dotnetcli.host.json`), значение по умолчанию `DialogCommand` / `WizardCommand` / `ZoneCommand`.
- `fileRename` в `template.json` = `"DialogCommand"` / `"WizardCommand"` / `"ZoneCommand"` — переименовывает **файлы**, содержащие эту подстроку, в значение `CommandName`.
- `sourceName` (`Commandex.DialogCommand` и т. п.) заменяется на имя, переданное в `-n` при `dotnet new` — это правит namespace, имя `.csproj`, `x:Class`.

## Сборка и публикация

```bash
dotnet build src/Calabonga.CommandexCommand.Template.sln -c Release   # пакет (GeneratePackageOnBuild=True)
# собрать конкретный шаблонный проект:
dotnet build src/Calabonga.CommandexCommand.Template/content/DialogCommandTemplate/Commandex.DialogCommand.csproj
```

- **.NET 10 SDK**, только Windows. Пакующий проект — `net10.0`; все три шаблонных — `net10.0-windows8.0`, `UseWPF=true`, `Nullable=enable`, `ImplicitUsings=enable`.
- Тестов в репозитории нет. Все три шаблонных проекта собираются в Release без warnings.
- **Публикация** — `.github/workflows/main.yml`: push в `main` → `dotnet pack` → `dotnet nuget push *.nupkg --api-key $NUGET_API_KEY --source nuget.org --skip-duplicate`. Требуется secret `NUGET_API_KEY`.
- `NoDefaultExcludes=true` — служебные папки (`bin`/`obj`/`.vs`/`.idea`/`_ReSharper.Caches`) НЕ исключаются автоматически, их нужно гасить вручную в `Content Include Exclude` (сейчас перечислены только `bin`/`obj` — см. «Известные проблемы»).

## Разработка команды из шаблона (для пользователя)

1. `dotnet new install Calabonga.CommandexCommand.Template`
2. `dotnet new wpfcmdx-dialog -n My.Thing --command-name MyThingCommand` (или `wpfcmdx-wizard` / `wpfcmdx-zone`).
3. Реализовать логику в сгенерированном `COMMAND_NAMECommandex` и его `AppDefinition`; для wizard — заполнить шаги и `PersonViewModel`.
4. Собрать; DLL команды подключается в `Shell` (или в `Shell.Develop`) — либо копированием в `PublishedCommands`, либо project reference в dev-shell.

Все три шаблонных проекта ссылаются на `Calabonga.Commandex.Engine` (голый контракт; `Processors` подключается пользователем вручную, если команда отдаёт `TextFileResult`/`ClipboardResult`). `<Version>` каждого шаблонного проекта — стартовый `1.0.0` (версия свежесозданной команды не связана с версией фреймворка). Версия `PackageReference` на `Engine` = версии `Engine`, с которой собран целевой `Shell`.

Исключения для пакета и для `dotnet new` заданы в двух местах: `Content Include Exclude` в пакующем `.csproj` (`bin`/`obj`/`.vs`/`.idea`/`_ReSharper.Caches`) и `sources.modifiers.exclude` в каждом `template.json` (`bin`/`obj`/`.vs`/`.idea`/`_ReSharper.Caches`).

Все сгенерированные классы — `sealed` (команда, `AppDefinition`, `View` code-behind, result/zone VM, шаги wizard). Имя файла совпадает с именем класса после генерации: файл команды — `<Type>CommandCommandex.cs` (`class COMMAND_NAMECommandex`), wizard-VM токенизирован (`class COMMAND_NAMEViewModel` в `WizardCommandViewModel.cs`). Проверено `dotnet new wpfcmdx-* --command-name FooCommand` — файлы/классы бьются, проект собирается.

`<PackageReleaseNotes>` пакующего проекта обновлять при каждом подъёме `PackageVersion` (как и в прочих Framework-репозиториях).
