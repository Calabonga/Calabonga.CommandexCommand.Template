# Calabonga.CommandexCommand.Template

## Description

This is a nuget-package [Calabonga.CommandexCommand.Template](https://www.nuget.org/packages/Calabonga.CommandexCommand.Template) (tools) that installs a set of `dotnet new` project templates. Each template scaffolds a WPF class library with one `CommandexCommand` ready to build and plug into your Commandex Shell. Three templates are available:

| Template (`shortName`) | Command base class | Purpose |
| --- | --- | --- |
| `wpfcmdx-dialog` | `DialogCommandexCommand<TView, TResult>` | command that opens a modal dialog and (optionally) returns a typed result |
| `wpfcmdx-wizard` | `WizardDialogCommandexCommand<TViewModel>` | multi-step wizard dialog (sample: 4 steps collecting a `PersonViewModel`) |
| `wpfcmdx-zone` | `ZoneCommandexCommand<TView, TViewModel>` | command hosted inline in the Shell `MainZone` instead of a window |

## What is Calabonga.Commandex

The `Calabonga.Commandex` - This is an application on WPF-platform built with CommunityToolkit.MVVM for modules (plugins) using: launch and execute.

What is the `Calabonga.Commandex` can:
* Find a modules `.dll` (plugins) in the folder you set up.
* Launch or execute modules `.dll` (plughis) from GUI.
* Get the results of the module's (plugis) work after they completed.

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** →  Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.
* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** →  Commands for Calabonga.Commandex.Shell that can execute them from unified shell.
* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** →  (`Tool Template`) This is a Developer version of the Command Executer Shell (`Calabonga.Commandex`). Which is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…
* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** →  Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.
* **[Calabonga.Commandex.Engine.Processors](https://github.com/Calabonga/Calabonga.Commandex.Engine.Processors)** →  Results Processors for Calabonga.Commandex.Shell commands execution results. This is an extended version of the just show string in the notification dialog.
* **[Calabonga.CommandexCommand.Template](https://github.com/Calabonga/Calabonga.CommandexCommand.Template)** →  (`Tool Template`) This is a template of the project to create a Command for Commandex. Just install this nuget as a template for Visual Studio (Rider or dotnet CLI) and then you can create a DialogCommand faster.

## How to install templates

Nothing is simpler then install this template. Just execute command in `powershell`:

``` powershell
dotnet new install Calabonga.CommandexCommand.Template
```

## How to use

1. Create a project from one of the templates (the `--command-name` / `-cn` option names the generated command class; end it with `Command` by convention):

    ``` powershell
    dotnet new wpfcmdx-dialog -n My.Thing --command-name MyThingCommand
    # or: dotnet new wpfcmdx-wizard -n My.Thing --command-name MyThingCommand
    # or: dotnet new wpfcmdx-zone   -n My.Thing --command-name MyThingCommand
    ```

2. Implement your logic in the generated `*Commandex` command class and its `AppDefinition`. For the wizard template, fill in the steps and the payload view model.
3. Build the project and plug the resulting `.dll` into your Shell — copy it into `Calabonga.Commandex.Shell/PublishedCommands`, or add a project reference from `Calabonga.Commandex.Shell.Develop` for in-place debugging.

Keep the `Calabonga.Commandex.Engine` package version in the generated `.csproj` equal to the Engine version the target Shell is built against.

## Ingredients

WPF, MVVM, CommunityToolkit, AppDefinitions, etc.

## Видео (Video)

В основном репозитории [Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell) есть несколько видео с инструкциями и разъяснениями, как использовать Commandex. А также видео о том, какие типы команд существуют и как для Commandex создавать команды разных типов.