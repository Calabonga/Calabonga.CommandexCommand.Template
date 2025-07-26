using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Zones;
using Commandex.ZoneCommand.Core.ViewModels;
using Commandex.ZoneCommand.Core.Views;

namespace Commandex.ZoneCommand.Core;

public class ZoneCommandCommandexCommand : ZoneCommandexCommand<ZoneCommandView, ZoneCommandViewModel>
{
    public ZoneCommandCommandexCommand(IZoneManager zoneManager) : base(zoneManager)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2025";

    public override string DisplayName => "Zone Command";

    public override string Description => "This type of the Commandex Command will be open in Shell special zone (inline).";

    public override string Version => GetType().Assembly.GetName().Version?.ToString() ?? "0.0.0";
}

