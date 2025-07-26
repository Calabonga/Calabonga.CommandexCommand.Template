using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Commandex.ZoneCommand.Core;
using Commandex.ZoneCommand.Core.ViewModels;
using Commandex.ZoneCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Commandex.ZoneCommand;

public class COMMAND_NAMEDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, COMMAND_NAMECommandex>();
        services.AddScoped<COMMAND_NAMEView>();
        services.AddScoped<COMMAND_NAMEViewModel>();
    }
}
