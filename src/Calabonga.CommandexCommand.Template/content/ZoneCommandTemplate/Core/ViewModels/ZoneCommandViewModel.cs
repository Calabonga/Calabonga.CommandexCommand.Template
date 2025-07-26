using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Zones;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Commandex.ZoneCommand.Core.ViewModels;

public partial class COMMAND_NAMEViewModel : ZoneViewModelBase
{
    public COMMAND_NAMEViewModel(ICommandexCommand command)
    {
        Title = "COMMAND_NAME created from Commandex Template";
        Command = command;
    }

    #region property Command

    /// <summary>
    /// Property Command to show on UI your COMMAND_NAME
    /// </summary>
    [ObservableProperty] private ICommandexCommand _command;

    #endregion

    #region command GoBackCommand

    [RelayCommand]
    private void GoBack()
    {
        ZoneManager.GoBack();
    }

    #endregion
}
