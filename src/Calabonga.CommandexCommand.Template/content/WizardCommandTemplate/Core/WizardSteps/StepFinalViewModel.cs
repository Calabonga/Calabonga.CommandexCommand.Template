using Calabonga.Commandex.Engine.Wizards;
using Commandex.WizardCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Commandex.WizardCommand.Core.WizardSteps;

/// <summary>
/// The final  step wizard ViewModel
/// </summary>
public sealed partial class StepFinalViewModel : WizardStepViewModel<PersonViewModel>
{
    public StepFinalViewModel()
    {
        Title = "Final";
    }

    [ObservableProperty]
    private PersonViewModel? _person;

    public override void OnEnter(PersonViewModel? payload) => Person = payload!;
}
