using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Wizards;
using Commandex.WizardCommand.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Windows;

namespace Commandex.WizardCommand.Core.ViewModels;

/// <summary>
/// Person ViewModel Wizard Commandex Command
/// </summary>
public sealed class WizardCommandViewModel : WizardDialogViewModel<PersonViewModel>
{
    private readonly ILogger<WizardCommandViewModel> _logger;

    public WizardCommandViewModel(
        ILogger<WizardCommandViewModel> logger,
        IWizardManager<PersonViewModel> manager) : base(manager)
    {
        _logger = logger;
        Title = "Person data wizard";
    }

    protected override PersonViewModel InitializeContext()
    {
        return new PersonViewModel();
    }

    protected override void OnWizardFinishedExecute(PersonViewModel? payload)
    {
        if (payload is null)
        {
            _logger.LogInformation("Payload is null");

            return;
        }

        _logger.LogInformation(JsonSerializer.Serialize(payload, JsonSerializerOptionsExt.Cyrillic));
    }

    public override ResizeMode ResizeMode => ResizeMode.CanResize;

    public override WindowStyle WindowStyle => WindowStyle.SingleBorderWindow;

    public override SizeToContent SizeToContent => SizeToContent.WidthAndHeight;
}
