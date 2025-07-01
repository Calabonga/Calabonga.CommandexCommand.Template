using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Commandex.DialogCommand.Core.ViewModels;
using Commandex.DialogCommand.Core.Views;
using System.Reflection;

namespace Commandex.DialogCommand.Core;

public class COMMAND-NAMECommandexCommand : DialogCommandexCommand<COMMAND-NAMEView, COMMAND-NAMEResult>
{
    public COMMAND-NAMECommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo
        => "Who create the command COMMAND-NAME?";

    public override string DisplayName
        => "A display name of the command COMMAND-NAME will be shown in command list";

    public override string Description
        => "A description of the command COMMAND-NAME about what it can do or what it is created for";

    public override string Version
        => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";
}
