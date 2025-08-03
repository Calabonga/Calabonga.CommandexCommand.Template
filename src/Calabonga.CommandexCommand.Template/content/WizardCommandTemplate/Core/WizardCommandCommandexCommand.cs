using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Extensions;
using Commandex.WizardCommand.Core.Entities;
using Commandex.WizardCommand.Core.ViewModels;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Commandex.WizardCommand.Core;

public class COMMAND_NAMECommandex : WizardDialogCommandexCommand<WizardCommandViewModel>
{
    private readonly ILogger<COMMAND_NAMECommandex> _logger;

    public COMMAND_NAMECommandex(
        ILogger<COMMAND_NAMECommandex> logger,
        IDialogService dialogService) : base(dialogService)
    {
        _logger = logger;
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

    public override bool IsPushToShellEnabled => true;

    protected override WizardCommandViewModel SetResult(WizardCommandViewModel result)
    {
        return result;
    }

    public override object? GetResult()
    {
        var payload = Result?.Payload;

        if (payload is not PersonViewModel person)
        {
            return null;
        }

        try
        {
            var data = JsonSerializer.Serialize(person, JsonSerializerOptionsExt.Cyrillic);
            _logger.LogInformation(data);

            return data;
        }
        catch
        {
            return null;
        }
    }
}
