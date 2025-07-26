using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Zones;
using Commandex.ZoneCommand.Core.ViewModels;
using Commandex.ZoneCommand.Core.Views;

namespace Commandex.ZoneCommand.Core;

public class COMMAND_NAMECommandex : ZoneCommandexCommand<COMMAND_NAMEView, COMMAND_NAMEViewModel>
{
    public COMMAND_NAMECommandex(IZoneManager zoneManager) : base(zoneManager)
    {
    }

    /// <summary>
    /// Who create this command COMMAND_NAME?
    /// </summary>
    public override string CopyrightInfo => "Calabonga SOFT © 2025";

    /// <summary>
    /// A display name of the command COMMAND_NAME will be shown in command list
    /// </summary>
    public override string DisplayName => "COMMAND_NAME display name";

    /// <summary>
    /// A description of the command COMMAND_NAME about what it can do or what it is created for
    /// </summary>
    public override string Description => "COMMAND_NAME description";

    /// <summary>
    /// Version will show from project-file version attribute value
    /// </summary>
    public override string Version => GetType().Assembly.GetName().Version?.ToString() ?? "0.0.0.0";
}

