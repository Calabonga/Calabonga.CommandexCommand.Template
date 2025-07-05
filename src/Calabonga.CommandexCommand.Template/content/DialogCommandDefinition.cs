using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Commandex.DialogCommand.Core;
using Commandex.DialogCommand.Core.ViewModels;
using Commandex.DialogCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Commandex.DialogCommand;

public class COMMAND-NAMEDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
{
    // register here all dependencies you need
    services.AddScoped <ICommandexCommand, COMMAND-NAMECommandexCommand> ();
    services.AddScoped <COMMAND-NAMEView> ();
    services.AddScoped <COMMAND-NAMEResult> ();
}
}
