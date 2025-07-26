using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Commandex.DialogCommand.Core.ViewModels;
using Commandex.DialogCommand.Core.Views;
using System.Reflection;

namespace Commandex.DialogCommand.Core;

public class COMMAND_NAMECommandex : DialogCommandexCommand<COMMAND_NAMEView, COMMAND_NAMEResult>
{
    public COMMAND_NAMECommandex(IDialogService dialogService) 
        : base(dialogService)
    {
    }

    /// <summary>
    /// Who create this command COMMAND_NAME?
    /// </summary>
    public override string CopyrightInfo
        => "Copyright © 2025";

    /// <summary>
    /// A display name of the command COMMAND_NAME will be shown in command list
    /// </summary>
    public override string DisplayName
        => "COMMAND_NAME display name";

    /// <summary>
    /// A description of the command COMMAND_NAME about what it can do or what it is created for
    /// </summary>
    public override string Description
        => "COMMAND_NAME description";

    /// <summary>
    /// Version will show from project-file version attribute value
    /// </summary>
    public override string Version
        => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0.0";
}
