using Calabonga.Commandex.Engine.Wizards;
using Commandex.WizardCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commandex.WizardCommand.Core.WizardSteps;

/// <summary>
/// The first step wizard ViewModel
/// </summary>
public partial class Step1WizardViewModel : WizardStepValidationViewModel<PersonViewModel>
{
    public Step1WizardViewModel()
    {
        Title = "Step 1";
    }

    [Required]
    [MinLength(5)]
    [ObservableProperty]
    [NotifyDataErrorInfo]
    private string? _firstName;

    public override void OnEnter(PersonViewModel? payload)
    {
        FirstName = payload?.FirstName ?? string.Empty;
    }

    public override void OnLeave(PersonViewModel? payload)
    {
        if (payload != null)
        {
            payload.FirstName = FirstName;
        }
    }
}
