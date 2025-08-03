namespace Commandex.WizardCommand.Core.Entities;

/// <summary>
/// Person Wizard Payload ViewModel
/// </summary>
public sealed class PersonViewModel
{
    /// <summary>
    /// FirstName for first wizard step
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// MiddleName for second wizard step
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// LastName for third wizard step
    /// </summary>
    public string? LastName { get; set; }
}
