using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Commandex.DialogCommand.Core;
using Commandex.DialogCommand.Core.ViewModels;
using Commandex.DialogCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Commandex.DialogCommand;

public class COMMAND_NAMEDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
{
    // register here all dependencies you need
    services.AddScoped <ICommandexCommand, COMMAND_NAMECommandexCommand> ();
    services.AddScoped <COMMAND_NAMEView>();
    services.AddScoped <COMMAND_NAMEResult>();
}
}
