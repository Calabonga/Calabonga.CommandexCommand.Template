using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Commandex.ZoneCommand.Core;
using Commandex.ZoneCommand.Core.ViewModels;
using Commandex.ZoneCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Commandex.ZoneCommand;

public class ZoneCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, ZoneCommandCommandexCommand>();
        services.AddScoped<ZoneCommandView>();
        services.AddScoped<ZoneCommandViewModel>();
    }
}
