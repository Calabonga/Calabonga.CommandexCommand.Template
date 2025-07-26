using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace Commandex.DialogCommand.Core.ViewModels;

public partial class COMMAND_NAMEResult : DefaultDialogResult
{
    public COMMAND_NAMEResult(ICommandexCommand command)
    {
        Title = "COMMAND_NAME created from Commandex Template";
        Command = command;
    }

    #region UI Style

    public override WindowStyle WindowStyle => WindowStyle.SingleBorderWindow;

    public override ResizeMode ResizeMode => ResizeMode.CanResize;

    public override SizeToContent SizeToContent => SizeToContent.Manual;

    public override double Height => 768;

    public override double Width => 1024;

    #endregion

    #region property Command

    /// <summary>
    /// Property Command to show on UI your COMMAND_NAME
    /// </summary>
    [ObservableProperty] private ICommandexCommand _command;

    #endregion
}
