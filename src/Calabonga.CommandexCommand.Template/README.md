# Calabonga.Commandex.Shell.Develop

## Description

This is a nuget-package [Calabonga.Commandex.Shell.Develop.Template](https://www.nuget.org/packages/Calabonga.Commandex.Shell.Develop.Template) (tools) that install to your Visual Studio a new type of the project. New type project can create a Developer version of the Command Executer (`Calabonga.Commandex`). Witch is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to copy some files to some destination. And so on... 

## What is Calabonga.Commandex

The `Calabonga.Commandex` - This is an application on WPF-platform built with CommunityToolkit.MVVM for modules (plugins) using: launch and execute.

What is the `Calabonga.Commandex` can:
* Find a modules `.dll` (plugins) in the folder you set up.
* Launch or execute modules `.dll` (plughis) from GUI.
* Get the results of the module's (plugis) work after they completed.

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** → Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.
* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** → Commands for Calabonga.Commandex.Shell that can execute them from unified shell.
* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** → This is a Developer version of the Command Executer (`Calabonga.Commandex`). Which is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…
* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** → Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.
* **[Calabonga.Commandex.Engine.Processors](https://github.com/Calabonga/Calabonga.Commandex.Engine.Processors)** → Results Processors for Calabonga.Commandex.Shell commands execution results. This is an extended version of the just show string in the notification dialog.

## How to install template

Nothing is simpler then install this template. Just execute command in `powershell`:

``` powershell
dotnet new install Calabonga.Commandex.Shell.Develop.Template
```

## How to use

This application can only test your Command for Commandex, but almost in a real conditions. How? Please do a few simple steps:

1. Please implement a `ICommandexCommand` interface in WPF Class Library project and add reference to `Calabonga.Commandex.Shell.Develop`.
2. Register your `ICommandexCommand` implementation in the `DependencyContainer.cs`.

    ``` csharp
    internal static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddLogging(options =>
        {
            options.AddSerilog(dispose: true);
            options.AddDebug();
        });

        services.AddSingleton<DefaultDialogView>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<ViewModels.MainWindowsViewModel>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IAppSettings>(_ => App.Current.Settings);
        services.AddSingleton<ISettingsReaderConfiguration, DefaultSettingsReaderConfiguration>();

        // dialogs and wizard
        services.AddTransient<IWizardView, Wizard>();
        services.AddTransient<IDialogService, DialogService>();
        services.AddTransient(typeof(IWizardManager<>), typeof(WizardManager<>));

        // --------------------------------------------------
        // 1. Attach command definition from your project where Commandex.Command implemented.
        // 2. Then uncomment line below and add your command type.
        // services.AddDefinitions(typeof(WelcomeAppDefinition)); // <-- uncomment line and register your command here
        // --------------------------------------------------

        return services.BuildServiceProvider();
    }
    ```


3. Inject your command implementation into `MainWindowsViewModel` as `ICommandexCommand`.
    ``` csharp
    public partial class MainWindowsViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public MainWindowsViewModel(IDialogService dialogService, IAppSettings settings)
        {
            Title = $"Commandex Shell Emulator for Easy developing ({settings.CommandsPath})";
            Version = "1.0.0-rc.7";
            _dialogService = dialogService;
        }

        [ObservableProperty]
        private string _version;

        /// <summary>
        /// Executes MVVM button action
        /// </summary>
        [RelayCommand]
        private Task ExecuteAsync()
        {
            _dialogService.ShowNotification("You do not attach your ICommandexCommand yet. " +
                                            "Please add your component definition in the DependencyContainer.cs file.");
            return Task.CompletedTask;
        }
    }
    ```

4. Use your injected instance in `ExecuteAsync()` method to execute command as shown above.
5. If you everything do correctly, than after button click on the form your command will come executed.

## Screenshot

v1.0.0

![image](https://github.com/user-attachments/assets/9393d2a6-fbf8-40ff-a3df-ee1b185f705e)

## Ingredients

WPF, MVVM, CommunityToolkit, AppDefinitions, etc.

## Видео (Video)

В основном репозитории [Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell) есть несколько видео с инструкциями и разъяснениями, как использовать Commandex. А также видео о том, какие типы команд существуют и как для Commandex создавать команды разных типов.