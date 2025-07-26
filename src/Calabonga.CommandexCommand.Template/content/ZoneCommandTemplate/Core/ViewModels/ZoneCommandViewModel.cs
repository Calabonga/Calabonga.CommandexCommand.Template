using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Zones;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Commandex.ZoneCommand.Core.ViewModels;

public partial class ZoneCommandViewModel : ZoneViewModelBase
{
    public ZoneCommandViewModel(ICommandexCommand command)
    {
        _command = command;
    }

    #region property Command

    /// <summary>
    /// Property Command
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
