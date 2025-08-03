using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.NugetDependencies;
using Calabonga.Wpf.AppDefinitions;
using Commandex.WizardCommand.Core;
using Commandex.WizardCommand.Core.Entities;
using Commandex.WizardCommand.Core.ViewModels;
using Commandex.WizardCommand.Core.WizardSteps;
using Microsoft.Extensions.DependencyInjection;

namespace Commandex.WizardCommand;

public class COMMAND_NAMEDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, COMMAND_NAMECommandex>();
         services.AddWizard<WizardCommandViewModel>();

        services.AddWizardStep<Step1, Step1WizardViewModel, PersonViewModel>("Step 1");
        services.AddWizardStep<Step2, Step2WizardViewModel, PersonViewModel>("Step 2");
        services.AddWizardStep<Step3, Step3WizardViewModel, PersonViewModel>("Step 3");
        services.AddWizardStep<StepFinal, StepFinalViewModel, PersonViewModel>("Total");
    }
}
